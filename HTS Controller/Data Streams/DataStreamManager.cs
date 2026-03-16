using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;

using KLib;
using KLib.Net;
using HTS.Tcp;
using KLib.Controls;

namespace HTSController.Data_Streams
{
    public class DataStreamManager : IDataStreamHandler
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

        private System.Windows.Forms.Timer _syncTimer;

        private string _logPath;

        private FlowLayoutPanel _panel;

        private int _statusTimerInterval = 5000;
        private int _syncInterval = 5000;
        private int _numTrialsPerSync = 4;

        private bool _exiting = false;
        private bool _recording = false;

        public List<string> GetProblemStreams() => _problemChildren;

        public DataStream Find(string name) => _streams.Find(x => x.MulticastName == name);
        public DataStream FindEyeTracker() => _streams.Find(x => x.IsEyeTracker);

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
                    Directory.CreateDirectory(ConfigFolder);

                KFile.XmlSerialize(_streams, ConfigFile);
            }
        }

        public void Initialize(FlowLayoutPanel panel, DiscoveryListener discoveryListener)
        {
            _panel = panel;
            discoveryListener.HostDiscovered += OnStreamDiscovered;
            discoveryListener.HostDisappeared += OnStreamDisappeared;
            
            _indicators = new List<DataStreamIndicator>();

            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem("Ping", new EventHandler(OnPingMenuItem_Click));
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Get log", new EventHandler(OnGetLogMenuItem_Click));
            contextMenu.MenuItems.Add(menuItem);

            foreach (var s in _streams)
            {
                var indicator = CreateIndicator(s);
                indicator.ContextMenu = contextMenu;
                panel.Controls.Add(indicator);
                _indicators.Add(indicator);
            }

            _syncTimer = new System.Windows.Forms.Timer();
            _syncTimer.Interval = 5000;
            _syncTimer.Tick += syncTimer_Tick;
        }

        public void Cleanup()
        {
            _syncTimer.Stop();

            KFile.XmlSerialize(_streams, ConfigFile);
        }

        // -------------------------------------------------------------------------
        // Discovery handlers
        // -------------------------------------------------------------------------

        private void OnStreamDiscovered(object sender, ServerBeacon beacon)
        {
            var stream = _streams.Find(s =>
                s.MulticastName.Equals(beacon.Name, StringComparison.OrdinalIgnoreCase));

            if (stream == null) return;

            stream.IPEndPoint = new IPEndPoint(IPAddress.Parse(beacon.Address), beacon.TcpPort);
            stream.Status = DataStream.StreamStatus.Idle;
            stream.LastActivity = DateTime.Now;

            Log.Information($"Data stream discovered: {beacon.Name} at {stream.IPEndPoint}");

            InvokeOnUI(() => UpdateIndicators());
        }

        private void OnStreamDisappeared(object sender, ServerBeacon beacon)
        {
            var stream = _streams.Find(s =>
                s.MulticastName.Equals(beacon.Name, StringComparison.OrdinalIgnoreCase));

            if (stream == null) return;

            stream.IPEndPoint = null;
            stream.Status = DataStream.StreamStatus.Idle;

            Log.Information($"Data stream lost: {beacon.Name}");

            InvokeOnUI(() => UpdateIndicators());
        }

        // -------------------------------------------------------------------------
        // UI helpers
        // -------------------------------------------------------------------------

        private DataStreamIndicator CreateIndicator(DataStream stream)
        {
            var indicator = new DataStreamIndicator(stream);
            indicator.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            return indicator;
        }

        private void UpdateIndicators()
        {
            foreach (var i in _indicators)
                i.ConnectionStatusUpdated();
        }

        private void OnPingMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ContextMenu contextMenu = menuItem.Parent as ContextMenu;
            DataStreamIndicator streamIndicator = contextMenu.SourceControl as DataStreamIndicator;
            DataStream dataStream = streamIndicator.Stream;

            if (dataStream.IsPresent)
            {
                var response = KTcpClient.SendRequest(dataStream.IPEndPoint, TcpMessage.Request("Ping"));
                if (response.IsOk)
                {
                    MsgBox.Show($"Ping successful!", "Ping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MsgBox.Show($"Ping failed: {response.Code}", "Ping", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void OnGetLogMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ContextMenu contextMenu = menuItem.Parent as ContextMenu;
            DataStreamIndicator streamIndicator = contextMenu.SourceControl as DataStreamIndicator;
            DataStream dataStream = streamIndicator.Stream;

            if (dataStream.IsPresent)
            {
                var error = await Task.Run(() => GetStreamLog(dataStream));
                if (error != null)
                {
                    Log.Error(error);
                    MsgBox.Show(error, "Get Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetStreamLog(DataStream dataStream)
        {
            var folder = Path.Combine(FileLocations.RootFolder, "Remote Logs");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var response = KTcpClient.SendRequest(dataStream.IPEndPoint, TcpMessage.Request("GetLog"));
            if (response.IsOk)
            {
                var payload = response.GetPayload<TextFilePayload>();
                var logPath = Path.Combine(folder, payload.Filename);
                File.WriteAllText(logPath, payload.Content);
                System.Diagnostics.Process.Start(logPath);
                return null;
            }
            else
            {
                return $"Failed to get log from {dataStream.Name}: {response.Code}";
            }
        }

        private void InvokeOnUI(Action action)
        {
            if (_panel.InvokeRequired)
                _panel.Invoke(action);
            else
                action();
        }
        // -------------------------------------------------------------------------
        // IDataStreamHandler implementation
        // -------------------------------------------------------------------------

        public async Task<bool> StartDataStreamsAsync(string filename)
            => await StartDataStreamsAsync(filename, mandatory: "");

        public async Task<bool> StartDataStreamsAsync(string filename, string mandatory = "", List<string> exclude = null)
        {
            if (exclude == null)
                exclude = new List<string>();

            _recording = true;
            _problemChildren.Clear();

            InitializeSyncLogFile(filename);

            var streamsToStart = _streams.FindAll(x => x.Record && x.IsPresent && !exclude.Contains(x.MulticastName));

            foreach (var s in streamsToStart)
            {
                var response = await Task.Run(() => KTcpClient.SendRequest(s.IPEndPoint, TcpMessage.Request("Record", (object) filename)));
                Log.Information($"{s.Name} ({s.IPEndPoint}) responds {response.Code}");
            }

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                streamsToStart = streamsToStart.FindAll(x =>
                    x.Status == DataStream.StreamStatus.Idle ||
                    x.Status == DataStream.StreamStatus.Missed);

                if (streamsToStart.Count == 0) break;

                foreach (var s in streamsToStart)
                {
                    var response = await Task.Run(() => KTcpClient.SendRequest(s.IPEndPoint, TcpMessage.Request("Status")));
                    if (response.IsOk)
                        s.Status = (DataStream.StreamStatus)response.GetPayload<DataStreamStatusPayload>().Status;
                }

                Thread.Sleep(250);
            }

            bool success = streamsToStart.Count == 0;

            if (success && !string.IsNullOrEmpty(mandatory))
            {
                var s = _streams.Find(x => x.MulticastName == mandatory);
                if (s == null || s.Status != DataStream.StreamStatus.Recording)
                {
                    Log.Error($"Mandatory stream '{s?.Name}' not started");
                    _problemChildren.Add(s?.Name);
                    success = false;
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
                    var result = await Task.Run(() => KTcpClient.SendRequest(s.IPEndPoint, TcpMessage.Request("Stop")));
                    Log.Information($"stopping {s.MulticastName}: {result.Code}");
                }
                foreach (var s in streamsToStart)
                    _problemChildren.Add(s.Name);

                _recording = false;
            }

            return success;
        }

        public async Task StopDataStreamsAsync()
        {
            _syncTimer.Stop();
            Log.Information("Sync timer stopped");

            foreach (var s in _streams.FindAll(x => x.IsPresent && x.Record))
            {
                if (s.Status == DataStream.StreamStatus.Idle)
                {
                    Log.Error($"{s.Name} is idle");
                }
                else
                {
                    var response = await Task.Run(() => KTcpClient.SendRequest(s.IPEndPoint, TcpMessage.Request("Stop")));
                    if (response.IsOk)
                    {
                        s.Status = DataStream.StreamStatus.Idle;
                    }
                    Log.Information($"stopping {s.MulticastName}: {response.Code}");
                }
            }
            foreach (var i in _indicators)
            {
                i.ConnectionStatusUpdated();
            }

        }

        // -------------------------------------------------------------------------
        // Sync and status timers
        // -------------------------------------------------------------------------
        public async Task CheckConnections()
        {
            // Status check — discovery listener now maintains IsPresent via IPEndPoint
            // This tick just refreshes the stream status for streams that are present
            foreach (var s in _streams.FindAll(x => x.IsPresent))
            {
                await Task.Run(() =>
                {
                    var response = KTcpClient.SendRequest(s.IPEndPoint, TcpMessage.Request("Status"));
                    if (response.IsOk)
                    {
                        s.Status = (DataStream.StreamStatus)response.GetPayload<DataStreamStatusPayload>().Status;
                        s.LastActivity = DateTime.Now;
                    }
                });
            }

            InvokeOnUI(() => UpdateIndicators());
        }

        private async void syncTimer_Tick(object sender, EventArgs e)
        {
            _syncTimer.Enabled = false;
            await SyncConnections();
            _syncTimer.Interval = _syncInterval;
            _syncTimer.Enabled = _recording && !_exiting;
        }

        public async Task SyncConnections()
        {
            foreach (var s in _streams.FindAll(x => x.IsPresent && x.Record))
            {
                var response = await Task.Run(() => KTcpClient.SendRequest(s.IPEndPoint, TcpMessage.Request("Status")));
                if (response.IsOk)
                {
                    s.Status = (DataStream.StreamStatus)response.GetPayload<DataStreamStatusPayload>().Status;
                    Debug.WriteLine($"status for {s.MulticastName} = {s.Status}");
                }

                if (s.Status != DataStream.StreamStatus.Idle)
                {
                    var data = await SynchronizeClocks(s);
                    AddLogEntry(s.MulticastName, data);
                    s.LastActivity = DateTime.Now;
                }
            }

            InvokeOnUI(() => UpdateIndicators());
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
                    var response = await Task.Run(() => KTcpClient.SendRequest(stream.IPEndPoint, TcpMessage.Request("Sync")));
                    var t3 = HighPrecisionClock.UtcNowIn100nsTicks;

                    if (response.IsOk)
                    {
                        var payload = response.GetPayload<ClockSyncPayload>();
                        var rtt = (double)(t3 - t0) * 1e-4 - (payload.T2 - payload.T1) * 1e-4;

                        if (rtt < maxRTT)
                        {
                            syncData.localTime = t0;
                            syncData.streamTime = payload.T1;
                            maxRTT = rtt;
                        }
                        syncData.rtt[k] = rtt;
                        syncData.valid = true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"sync error = {ex.Message}");
                }
            }
            return syncData;
        }

        // -------------------------------------------------------------------------
        // Logging
        // -------------------------------------------------------------------------

        private void InitializeSyncLogFile(string logPath)
        {
            _logPath = Path.Combine(FileLocations.SubjectDataFolder, logPath.Replace(".json", "-StreamSync.log"));

            string headerText =
                $"{"DataStream",-30}\t" +
                $"{"LocalTime",-20}\t" +
                $"{"StreamTime",-20}\t";

            for (int k = 0; k < _numTrialsPerSync; k++)
                headerText += $"{"RTT" + (k + 1),-10}\t";

            File.WriteAllText(_logPath, headerText + Environment.NewLine);
        }

        private void AddLogEntry(string streamName, SyncData data)
        {
            string logEntry =
                $"{streamName,-30}\t" +
                $"{data.localTime,-20}\t" +
                $"{data.streamTime,-20}\t";

            for (int k = 0; k < data.rtt.Length; k++)
                logEntry += $"{(data.valid ? data.rtt[k] : float.NaN),-10:0.000000}\t";

            File.AppendAllText(_logPath, logEntry + Environment.NewLine);
        }

        // -------------------------------------------------------------------------
        // Default stream configuration
        // -------------------------------------------------------------------------

        private void CreateDefaultStreams()
        {
            _streams = new List<DataStream>();
            _streams.Add(new DataStream
            {
                Name = "Hearing Test Suite",
                MulticastName = "HEARING.TEST.SUITE.SYNC",
                Icon = "tablet.png"
            });
            _streams.Add(new DataStream
            {
                Name = "Video Recorder",
                MulticastName = "VIDEO.RECORDER",
                Icon = "video.png"
            });
            _streams.Add(new DataStream
            {
                Name = "BioSemi",
                MulticastName = "BIOSEMI",
                Icon = "BioSemi.png"
            });
            _streams.Add(new DataStream
            {
                Name = "EyeLink",
                MulticastName = "EYELINK",
                Icon = "Eyelink.png"
            });
        }

        public Task<bool> StartDataStreamsAsync(string filename, string playerName)
        {
            throw new NotImplementedException();
        }
    }
}
