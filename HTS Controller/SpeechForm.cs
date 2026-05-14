using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.IO;
using KLib.Net;
using SpeechReception;

using HTS.Tcp;
using C462.Shared;
using C462.Shared.Protocol.DTOs;
using HTSController.Data_Streams;

using Serilog;
using System.Timers;

namespace HTSController
{
    public partial class SpeechForm : Form
    {
        private HTSNetwork _network;
        private DataStreamManager _streamManager;
        private string _dataFile;

        private string _configName;
        private readonly string _sceneName = "SpeechReception";

        bool _runAborted = false;
        bool _ignoreEvents = false;
        bool _autoRun = false;
        Watchdog _watchdog;

        SpeechTest _config;

        #region EVENTS
        public event EventHandler<AutoRunEndEventArgs> AutoRunEnd;
        private void OnAutoRunEnd(bool success, string dataFile) { AutoRunEnd?.Invoke(this, new AutoRunEndEventArgs(success, dataFile)); }

        public event EventHandler<RunStateChangedEventArgs> RunStateChanged;
        protected virtual void OnRunStateChanged(string source, bool isRunning)
        {
            RunStateChanged?.Invoke(this, new RunStateChangedEventArgs(source, isRunning));
        }

        #endregion

        public SpeechForm(HTSNetwork network, DataStreamManager streamManager)
        {
            _network = network;
            _network.RemoteMessageHandler += OnRemoteMessage;

            _streamManager = streamManager;
            _watchdog = new Watchdog(OnWatchdogTimeout);

            InitializeComponent();
        }

        public void Initialize()
        {
            startButton.Visible = true;
            startButton.Enabled = false;
            TransferButton.Enabled = _network.IsConnected;

            _dataFile = "";

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            logTextBox.Text = "";

            msSelectMeasurement.Text = "Select...";

            UpdateFileMenu();
        }

        private void UpdateFileMenu()
        {
            msSelectMeasurement.DropDownItems.Clear();
            foreach (var measType in new List<string>() { "SpeechTest" })
            {
                var measItem = new ToolStripMenuItem();
                measItem.Text = measType;
                measItem.Name = measType;

                foreach (var configFile in SharedFileLocations.EnumerateConfigFiles(measType))
                {
                    var configItem = new ToolStripMenuItem();
                    configItem.Name = $"{measType}.{configFile}";
                    configItem.Text = configFile;
                    configItem.Tag = measType;
                    configItem.Click += msSelectMeasurement_Click;

                    measItem.DropDownItems.Add(configItem);
                }

                if (measItem.DropDownItems.Count > 0)
                {
                    msSelectMeasurement.DropDownItems.Add(measItem);
                }
            }
        }

        private void msSelectMeasurement_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripItem);

            msSelectMeasurement.Text = item.Name;
            _configName = item.Text;

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var configPath = SharedFileLocations.GetConfigFile("SpeechTest", _configName);
            if (File.Exists(configPath))
            {
                _config = Files.XmlDeserialize<SpeechTest>(configPath);
                _config.TestName = _configName;
            }
            else
            {
                _config = new SpeechTest();
            }

            ListProperties.SerializationTestType = _config.TestType;
            propertyGrid.SelectedObject = _config;
            startButton.Enabled = true;
        }

        public void AutoRunSpeechTest(string configName)
        {
            _autoRun = true;

            msSelectMeasurement.Text = $"SpeechTest.{configName}";
            _configName = configName;

            LoadConfiguration();
            startButton_Click(this, null);
        }

        private void EnableButtons(bool enable)
        {
            startButton.Enabled = enable && _config != null;
            SaveButton.Enabled = enable;
            newButton.Enabled = enable;
            RemoveButton.Enabled = enable;
            TransferButton.Enabled = enable && _network.IsConnected;
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                logTextBox.Text = "Not connected to tablet";
                return;
            }

            EnableButtons(false);

            logTextBox.Text = "Starting speech test...";
            Log.Information($"Starting speech test...");
            var success = await ChangeTabletScene(_sceneName);

            if (!success)
            {
                EnableButtons(true);
                logTextBox.Text = "failed to change scene on tablet";
                Log.Error($"failed to change to {_sceneName} scene");
                EndAutoRun(false, null);
                return;
            }

            _runAborted = false;
            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            await Task.Run(() => InitializeRemoteMeasurement());

            if (!string.IsNullOrEmpty(_dataFile) && !_dataFile.StartsWith("error"))
            {
                dataFileTextBox.Text = _dataFile;

                bool started = true;
                if (!_config.BypassDataStreams)
                {
                    started = await _streamManager.StartDataStreamsAsync(_dataFile);
                }
                if (started)
                {
                    stopButton.Enabled = true;
                    stopButton.Visible = true;
                    logTextBox.AppendText("OK" + Environment.NewLine);
                    OnRunStateChanged(_sceneName, true);
                    _network.SendMessage("Begin");
                }
                else
                {
                    logTextBox.AppendText("failed" + Environment.NewLine);
                    foreach (var s in _streamManager.GetProblemStreams())
                    {
                        logTextBox.AppendText($"- {s}\n");
                        Log.Error($"failed to start stream: {s}");
                    }
                    EnableButtons(true);
                    _network.SendMessage("StopSynchronizing");
                    EndAutoRun(false, null);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_dataFile) && _dataFile.StartsWith("error"))
                {
                    logTextBox.AppendText($"{_dataFile}{Environment.NewLine}");
                    Log.Error(_dataFile);
                }
                else
                {
                    logTextBox.AppendText($"failed to change to {_sceneName} scene");
                }
                EnableButtons(true);
                EndAutoRun(false, null);
            }
        }

        private async Task<bool> ChangeTabletScene(string sceneName)
        {
            bool success = false;
            _network.SendMessage("ChangeScene", sceneName);

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                await Task.Delay(200);
                if (_network.CurrentScene.Equals(sceneName))
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        private void InitializeRemoteMeasurement()
        {
            var result = _network.SendRequest<string>("Initialize", _config);
            _dataFile = result ?? "";
         
            if (!string.IsNullOrEmpty(_dataFile))
            {
                Log.Information($"Remote data file = {_dataFile}");
            }
        }

        private async void EndRun(string message, string status)
        {
            _watchdog.Stop();
            Log.Information("Run ending");
            if (!_config.BypassDataStreams)
            {
                await _streamManager.StopDataStreamsAsync();

                try
                {
                    var syncLog = _network.SendRequest<TextFilePayload>("GetSyncLog");
                    if (syncLog != null && !string.IsNullOrEmpty(syncLog.Filename))
                    {
                        var logPath = Path.Combine(SharedFileLocations.HtsSubjectDataFolder, syncLog.Filename);
                        File.WriteAllText(logPath, syncLog.Content);
                    }
                }
                catch (Exception ex)
                {
                    Log.Warning($"Could not retrieve sync log: {ex.Message}");
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                logTextBox.AppendText($"{Environment.NewLine}{status}{Environment.NewLine}");
            }

            EnableButtons(true);
            stopButton.Visible = false;

            progressBar.Value = 0;
            OnRunStateChanged(_sceneName, false);

            EndAutoRun(success: !_runAborted && !message.Equals("Error"), dataFile: _dataFile);
        }

        private void EndAutoRun(bool success, string dataFile)
        {
            if (!_autoRun) return;
            _autoRun = false;

            OnAutoRunEnd(success, dataFile);
        }

        private void OnRemoteMessage(object sender, TcpMessage message)
        {
            var payload = message.GetPayload<RemoteMessagePayload>();
            if (!payload.Target.Equals(_sceneName)) return;

            switch (message.Command)
            {
                case "File":
                    _dataFile = payload.Data;
                    Invoke(new Action(() => dataFileTextBox.Text = _dataFile));
                    break;
                case "Progress":
                    int.TryParse(payload.Data, out int progress);
                    Invoke(new Action(() => progressBar.Value = progress));
                    break;
                case "ReceiveData":
                    var rcvParts = payload.Data.Split(new char[] { ':' }, 2);
                    string filePath = Path.Combine(SharedFileLocations.HtsSubjectDataFolder, rcvParts[0]);
                    File.WriteAllText(filePath, rcvParts.Length > 1 ? rcvParts[1] : "");
                    break;
                case "Status":
                    Log.Information($"Status update: {payload.Data}");
                    Invoke(new Action(() => logTextBox.AppendText($"- {payload.Data}{Environment.NewLine}")));
                    break;
                case "Error":
                    Invoke(new Action(() => { EndRun("Error", payload.Data); }));
                    break;
                case "Finished":
                    _runAborted = payload.Data.Equals("Measurement aborted");
                    Invoke(new Action(() => { EndRun("Finished", payload.Data); }));
                    break;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Log.Information("User stopping measurement");

            _runAborted = true;
            stopButton.Enabled = false;
            _network.SendMessage("Abort");
            _watchdog.Start();
        }

        private void OnWatchdogTimeout(object sender, EventArgs e)
        {
            Log.Error("Watchdog timed out");
            EndRun("Error", "Timed out waiting for tablet.");
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            _config = new SpeechTest();
            _config.TestName = "Untitled";
            propertyGrid.SelectedObject = _config;
            startButton.Enabled = true;
            msSelectMeasurement.Text = $"SpeechTest.{_config.TestName}";
            ListProperties.SerializationTestType = _config.TestType;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_config != null)
            {
                var fn = SharedFileLocations.GetConfigFile("SpeechTest", _config.TestName);
                KLib.IO.Files.XmlSerialize(_config, fn);
                msSelectMeasurement.Text = $"SpeechTest.{_config.TestName}";
                UpdateFileMenu();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_config != null)
            {
                var fn = SharedFileLocations.GetConfigFile("SpeechTest", _config.TestName);
                File.Delete(fn);
                _config = null;
                propertyGrid.SelectedObject = null;
                msSelectMeasurement.Text = "Select...";
                UpdateFileMenu();
            }
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            if (_config != null && _network.IsConnected)
            {
                var fn = SharedFileLocations.GetConfigFile("SpeechTest", _config.TestName);
                _network.SendMessage("ReceiveTextFile", new TransferFilePayload
                {
                    Destination = FileDestination.ProjectResources,
                    SubPath = "Config Files",
                    Filename = Path.GetFileName(fn),
                    Content = File.ReadAllText(fn)
                });
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGrid.Refresh();
            ListPropertiesConverter.TestType = _config.TestType;
        }
    }
}
