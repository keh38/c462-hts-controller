using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib;
using KLib.Net;

namespace HTSController.Data_Streams
{
    public class DataStreamManager
    {
        public static readonly string ConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS", "Streams");
        private static readonly string ConfigFile = Path.Combine(ConfigFolder, "DataStreams.xml");
        private List<DataStream> _streams;
        private List<DataStreamIndicator> _indicators;

        private HTSNetwork _network;
        private System.Windows.Forms.Timer _statusTimer;
        private System.Windows.Forms.Timer _syncTimer;

        private int _statusTimerInterval = 5000;

        public DataStreamManager()
        {
            if (File.Exists(ConfigFile))
            {
                _streams = KFile.XmlDeserialize<List<DataStream>>(ConfigFile);
            }
            else
            {
                CreateDefaultStreams();

                if (!Directory.Exists(ConfigFolder))
                {
                    Directory.CreateDirectory(ConfigFolder);
                }
                KFile.XmlSerialize(_streams, ConfigFile);
            }
        }

        public void Initialize(HTSNetwork network, FlowLayoutPanel flowLayout)
        {
            _network = network;
            _indicators = new List<DataStreamIndicator>();

            foreach (var s in _streams)
            {
                var indicator = CreateIndicator(s);
                flowLayout.Controls.Add(indicator);
                _indicators.Add(indicator);
            }

            _statusTimer = new System.Windows.Forms.Timer();
            _statusTimer.Interval = 1000;
            _statusTimer.Tick += statusTimer_Tick;
            _statusTimer.Start();

            _syncTimer = new System.Windows.Forms.Timer();
            _syncTimer.Interval = 5000;
            _syncTimer.Tick += syncTimer_Tick;
        }

        public void Cleanup()
        {
            _statusTimer.Stop();
            _syncTimer.Stop();

            KFile.XmlSerialize(_streams, ConfigFile);
        }

        private DataStreamIndicator CreateIndicator(DataStream stream)
        {
            var indicator = new DataStreamIndicator(stream);
            indicator.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            return indicator;
        }

        private void OnRecordSelectionChanged(object sender, EventArgs e)
        {

        }

        public void RestartStatusTimer()
        {
            _statusTimer.Interval = 100;
            _statusTimer.Start();
        }

        public async Task<bool> StartRecording(string filename)
        {
            _statusTimer.Stop();

            var streamsToStart = _streams.FindAll(x => x.Record && x.IsPresent);
            foreach (var s in streamsToStart)
            {
                Debug.WriteLine($"{s.Name}: writing to {s.IPEndPoint}");
                await KTcpClient.SendMessageAsync(s.IPEndPoint, $"Record:{filename}");
            }

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                streamsToStart = streamsToStart.FindAll(x => x.Status == DataStream.StreamStatus.Idle);
                if (streamsToStart.Count == 0)
                {
                    break;
                }

                foreach (var s in streamsToStart)
                {
                    var status = await KTcpClient.SendMessageReceiveIntAsync(s.IPEndPoint, "Status");
                    s.Status = (DataStream.StreamStatus)status;
                }

                Thread.Sleep(250);
            }

            bool success = streamsToStart.Count == 0;

            if (success)
            {
                await SyncConnections();
                _syncTimer.Start();
            }
            else
            {
                foreach (var s in _streams.FindAll(x => x.Status != DataStream.StreamStatus.Idle))
                {
                    await KTcpClient.SendMessageAsync(s.IPEndPoint, "Stop");
                }
                _statusTimer.Start();
            }

            return success;
        }

        public async Task StopRecording()
        {
            _syncTimer.Stop();

            foreach (var s in _streams.FindAll(x => x.IsPresent && x.Record && x.Status != DataStream.StreamStatus.Idle))
            {
                await KTcpClient.SendMessageAsync(s.IPEndPoint, "Stop");
            }
        }

        private async void syncTimer_Tick(object sender, EventArgs e)
        {
            _syncTimer.Enabled = false;
            await SyncConnections();
            _syncTimer.Enabled = true;
        }

        public async Task SyncConnections()
        {
            foreach (var s in _streams.FindAll(x => x.IsPresent && x.Record))
            {
                var status = await KTcpClient.SendMessageReceiveIntAsync(s.IPEndPoint, "Status");
                s.Status = (DataStream.StreamStatus)status;
            }

            foreach (var i in _indicators)
            {
                i.ConnectionStatusUpdated();
            }
        }

        private async void statusTimer_Tick(object sender, EventArgs e)
        {
            _statusTimer.Enabled = false;
            await CheckConnections();
            _statusTimer.Interval = _statusTimerInterval;
            _statusTimer.Enabled = true;
        }

        public async Task CheckConnections()
        {
            foreach (var s in _streams)
            {
                await Task.Run(() => CheckStream(s));
            }

            foreach (var i in _indicators)
            {
                i.ConnectionStatusUpdated();
            }
        }

        private void CheckStream(DataStream stream)
        {
            stream.IPEndPoint = Discovery.Discover(stream.MulticastName, timeOut:200);

            stream.Status = DataStream.StreamStatus.Idle;
            stream.LastActivity = DateTime.Now;
        }

        private void CreateDefaultStreams()
        {
            _streams = new List<DataStream>();
            _streams.Add(new DataStream()
            {
                Name = "Hearing Test Suite",
                MulticastName = "HEARING.TEST.SUITE.SYNC",
                Icon = "tablet.png"
            });
            _streams.Add(new DataStream()
            {
                Name = "Video Recorder",
                MulticastName = "VIDEO.RECORDER",
                Icon = "video.png"
            });
            _streams.Add(new DataStream()
            {
                Name = "BioSemi",
                MulticastName = "BIOSEMI",
                Icon = "BioSemi.png"
            });
            _streams.Add(new DataStream()
            {
                Name = "EyeLink",
                MulticastName = "EYELINK",
                Icon = "Eyelink.png"
            });
        }

    }
}
