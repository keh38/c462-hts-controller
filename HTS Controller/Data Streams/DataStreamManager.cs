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

using Serilog;

using KLib;
using KLib.Net;
using static SyncPulseDetector.SyncPulseEvent;

namespace HTSController.Data_Streams
{
    public class DataStreamManager
    {
        internal class SyncData
        {
            public bool valid = false;
            public long localTime = -1;
            public long streamTime = -1;
            public double[] rtt;

            public SyncData() { }
            public SyncData(int numRTT) { rtt = new double[numRTT]; }

        }

        public static readonly string ConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS", "Streams");
        private static readonly string ConfigFile = Path.Combine(ConfigFolder, "DataStreams.xml");
        private List<DataStream> _streams;
        private List<DataStreamIndicator> _indicators;

        private List<string> _problemChildren = new List<string>();

        private HTSNetwork _network;
        private System.Windows.Forms.Timer _statusTimer;
        private System.Windows.Forms.Timer _syncTimer;

        private string _logPath;

        private int _statusTimerInterval = 5000;
        private int _syncInterval = 5000;
        private int _numTrialsPerSync = 4;

        private bool _exiting = false;

        public List<string> ProblemStreams { get { return _problemChildren; } }

        public DataStream Find(string name)
        {
            return _streams.Find(x => x.MulticastName == name);
        }

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

        public async Task<bool> StartRecording(string filename, params string[] mandatory)
        {
            _statusTimer.Stop();
            _problemChildren.Clear();

            InitializeSyncLogFile(filename);

            var streamsToStart = _streams.FindAll(x => x.Record && x.IsPresent);
            foreach (var s in streamsToStart)
            {
                var response = await KTcpClient.SendMessageAsync(s.IPEndPoint, $"Record:{Path.Combine(FileLocations.SubjectDataFolder, filename)}");
                Log.Information($"{s.Name} ({s.IPEndPoint}) responds {response}");
            }

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                streamsToStart = streamsToStart.FindAll(x => x.Status == DataStream.StreamStatus.Idle || x.Status == DataStream.StreamStatus.Missed);
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

            if (success && mandatory.Length > 0)
            {
                foreach (var m in mandatory)
                {
                    var s = _streams.Find(x => x.MulticastName == m);
                    if (s==null || s.Status != DataStream.StreamStatus.Recording)
                    {
                        Log.Error($"Mandatory stream '{s.Name}' not started");
                        _problemChildren.Add(s.Name);
                        success = false;
                    }
                }
            }

            if (success)
            {
                _syncTimer.Interval = 500;
                _syncTimer.Start();
            }
            else
            {
                foreach (var s in _streams.FindAll(x => x.Status != DataStream.StreamStatus.Idle))
                {
                    var result = await KTcpClient.SendMessageAsync(s.IPEndPoint, "Stop");
                    Log.Information($"stopping {s.MulticastName}: {result}");
                }
                foreach (var s in streamsToStart)
                {
                    _problemChildren.Add(s.Name);
                }
                _statusTimer.Start();
            }

            return success;
        }

        private void InitializeSyncLogFile(string logPath)
        {
                _logPath = Path.Combine(FileLocations.SubjectDataFolder, logPath.Replace(".json", "-StreamSync.log"));

            string headerText =
                $"{"DataStream",-30}\t" +
                $"{"LocalTime",-20}\t" +
                $"{"StreamTime",-20}\t";

            for (int k = 0; k < _numTrialsPerSync; k++)
            {
                var rttHeader = $"RTT{k + 1}";
                headerText += $"{rttHeader,-10}\t";
            }

            File.WriteAllText(_logPath, headerText + Environment.NewLine);
        }

        public async Task StopRecording()
        {
            _syncTimer.Stop();

            foreach (var s in _streams.FindAll(x => x.IsPresent && x.Record && x.Status != DataStream.StreamStatus.Idle))
            {
                var result = await KTcpClient.SendMessageAsync(s.IPEndPoint, "Stop");
                Log.Information($"stopping {s.MulticastName}: {result}");
            }
        }

        private async void syncTimer_Tick(object sender, EventArgs e)
        {
            _syncTimer.Enabled = false;
            await SyncConnections();
            _syncTimer.Interval = _syncInterval;
            _syncTimer.Enabled = !_exiting;
        }

        public async Task SyncConnections()
        {
            foreach (var s in _streams.FindAll(x => x.IsPresent && x.Record))
            {
                var status = await KTcpClient.SendMessageReceiveIntAsync(s.IPEndPoint, "Status");
                s.Status = (DataStream.StreamStatus)status;

                if (s.Status != DataStream.StreamStatus.Idle)
                {
                    var data = await SynchronizeClocks(s);
                    AddLogEntry(s.MulticastName, data);

                    s.LastActivity = DateTime.Now;
                }
            }

            foreach (var i in _indicators)
            {
                i.ConnectionStatusUpdated();
            }
        }

        private void AddLogEntry(string streamName, SyncData data)
        {
            string logEntry =
                 $"{streamName,-30}\t" +
                 $"{data.localTime,-20}\t" +
                 $"{data.streamTime,-20}\t";

            for (int k = 0; k < data.rtt.Length; k++)
            {
                var rttEntry = $"{(data.valid ? data.rtt[k] : float.NaN),-10:0.000000}\t";
                logEntry += rttEntry;
            }

            File.AppendAllText(_logPath, logEntry + Environment.NewLine);
        }

        private async Task<SyncData> SynchronizeClocks(DataStream stream)
        {
            var syncData = new SyncData(_numTrialsPerSync);

            double maxRTT = double.MaxValue;

            for (int k = 0; k < _numTrialsPerSync; k++)
            {
                try
                {
                    var t0 = HighPrecisionClock.UtcNowIn100nsTicks;
                    var byteArray = await KTcpClient.SendMessageReceiveByteArrayAsync(stream.IPEndPoint, "Sync");
                    var t1 = BitConverter.ToInt64(byteArray, 0);
                    var t2 = BitConverter.ToInt64(byteArray, 8);
                    var t3 = HighPrecisionClock.UtcNowIn100nsTicks;

                    var rtt = (double)(t3 - t0) * 1e-4 - (t2 - t1) * 1e-4;

                    if (rtt < maxRTT)
                    {
                        syncData.localTime = t0;
                        syncData.streamTime = t1;
                        maxRTT = rtt;
                    }
                    syncData.rtt[k] = rtt;
                    syncData.valid = true;
                }
                catch (Exception ex)
                {
                }
            }
            return syncData;
        }

        private async void statusTimer_Tick(object sender, EventArgs e)
        {
            _statusTimer.Enabled = false;
            await CheckConnections();
            _statusTimer.Interval = _statusTimerInterval;
            _statusTimer.Enabled = !_exiting;
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
