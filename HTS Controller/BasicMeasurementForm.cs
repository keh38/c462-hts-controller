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

using KLib;
using KLib.Net;
using BasicMeasurements;
using Audiograms;
using Bekesy;
using DigitsTest;

using LDL;
using LDL.Haptics;

using HTSController.Data_Streams;
using HTS.Tcp;

using Serilog;
using System.Timers;

namespace HTSController
{
    public partial class BasicMeasurementForm : Form
    {
        private HTSNetwork _network;
        private DataStreamManager _streamManager;
        private string _dataFile;

        private string _measType;
        private string _configName;
        private string _sceneName;

        bool _runAborted = false;
        bool _ignoreEvents = false;
        bool _autoRun = false;
        Watchdog _watchdog;

        BasicMeasurementConfiguration _config;

        #region EVENTS
        public event EventHandler<AutoRunEndEventArgs> AutoRunEnd;
        private void OnAutoRunEnd(bool success, string dataFile) { AutoRunEnd?.Invoke(this, new AutoRunEndEventArgs(success, dataFile)); }

        public event EventHandler<RunStateChangedEventArgs> RunStateChanged;
        protected virtual void OnRunStateChanged(string source, bool isRunning)
        {
            RunStateChanged?.Invoke(this, new RunStateChangedEventArgs(source, isRunning));
        }

        #endregion

        public BasicMeasurementForm(HTSNetwork network, DataStreamManager streamManager)
        {
            _network = network;
            _network.RemoteMessageHandler += HandleRemoteMessage;

            _streamManager = streamManager;
            _watchdog = new Watchdog(OnWatchdogTimeout);

            InitializeComponent();

            KLib.Controls.Utilities.SetCueBanner(newDropDown.Handle, "New...");
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
            foreach (var measType in new List<string>() { "Audiogram", "Bekesy", "Digits", "LDL", "Questionnaire" })
            {
                var measItem = new ToolStripMenuItem();
                measItem.Text = measType;
                measItem.Name = measType;

                foreach (var configFile in FileLocations.EnumerateConfigFiles(measType))
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
            _measType = item.Tag as string;
            _configName = item.Text;

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var configPath = FileLocations.GetConfigFile(_measType, _configName);
            if (File.Exists(configPath))
            {
                var obj = KFile.XmlDeserialize<BasicMeasurementConfiguration>(configPath);
                switch (_measType)
                {
                    case "Audiogram":
                        _config = obj as AudiogramMeasurementSettings;
                        break;

                    case "Bekesy":
                        _config = obj as BekesyMeasurementSettings;
                        break;

                    case "Digits":
                        _config = obj as DigitsTestSettings;
                        break;

                    case "LDL":
                        _config = obj as LDLMeasurementSettings;
                        break;

                    case "Questionnaire":
                        _config = obj as Questionnaires.Questionnaire;
                        break;
                }
            }
            else
            {
                _config = AddNewConfiguration(_measType);
            }

            propertyGrid.SelectedObject = _config;
            startButton.Enabled = true;
        }

        public void AutoRunBasicMeasurement(string measType, string configName)
        {
            _autoRun = true;

            msSelectMeasurement.Text = $"{measType}.{configName}";
            _measType = measType;
            _configName = configName;

            LoadConfiguration();
            startButton_Click(this, null);
        }

        private void EnableButtons(bool enable)
        {
            startButton.Enabled = enable && _config != null;
            SaveButton.Enabled = enable;
            newDropDown.Enabled = enable;
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

            logTextBox.Text = $"Starting {_measType} measurement...";
            Log.Information($"Starting {_measType}.{_configName} measurement...");
            _sceneName = GetSceneName(_measType, _config);
            var success = await ChangeTabletScene(_sceneName);

            if (!success)
            {
                EnableButtons(true);
                logTextBox.Text = "failed to change scene on tablet";
                Log.Error($"failed to change to {_measType} scene");
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
                    OnRunStateChanged(_measType, true);
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
                    EndAutoRun(false, null);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_dataFile) && _dataFile.StartsWith("error"))
                {
                    logTextBox.AppendText($"{Path.GetFileNameWithoutExtension(_dataFile)}{Environment.NewLine}");
                    Log.Error(_dataFile);
                }
                else
                {
                    logTextBox.AppendText($"didn't receive data file name from {_sceneName} scene");
                }
                EnableButtons(true);
                EndAutoRun(false, null);
            }
        }

        private string GetSceneName(string measType, BasicMeasurementConfiguration config)
        {
            string sceneName = measType;
            if (measType == "LDL" && (config as LDLMeasurementSettings).HapticStimulus.Source != HapticSource.NONE)
            {
                sceneName = "LDL_Haptics";
            }

            return sceneName;
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

                var syncLog = _network.SendRequest<TextFilePayload>("GetSyncLog");
                if (syncLog != null)
                {
                    var logPath = Path.Combine(FileLocations.SubjectDataFolder, syncLog.Filename);
                    File.WriteAllText(logPath, syncLog.Content);
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                logTextBox.AppendText($"{Environment.NewLine}{status}{Environment.NewLine}");
            }

            EnableButtons(true);
            stopButton.Visible = false;

            progressBar.Value = 0;
            OnRunStateChanged(_measType, false);

            EndAutoRun(success: !_runAborted && !message.Equals("Error"), dataFile: _dataFile);
        }

        private void EndAutoRun(bool success, string dataFile)
        {
            if (!_autoRun) return;
            _autoRun = false;

            OnAutoRunEnd(success, dataFile);
        }

        private void HandleRemoteMessage(object sender, TcpMessage message)
        {
            var payload = message.GetPayload<RemoteMessagePayload>();
            Debug.WriteLine($"Received remote message: {message.Command} - {payload.Target} - {payload.Data}");
            if (!payload.Target.Equals(_sceneName)) return;

            switch (message.Command)
            {
                case "Progress":
                    int.TryParse(payload.Data, out int progress);
                    Invoke(new Action(() => progressBar.Value = progress));
                    break;
                case "ReceiveData":
                    var filePayload = FileIO.JSONDeserializeFromString<TransferFilePayload>(payload.Data);
                    string filePath = Path.Combine(FileLocations.SubjectDataFolder, filePayload.Filename);
                    if (File.Exists(filePath))
                    {
                        Log.Warning($"File {filePath} already exists, backing up. This shouldn't happen.");
                        File.Move(filePath, filePath + ".bak");
                    }
                    File.WriteAllText(filePath, filePayload.Content);
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_config != null)
            {
                var fn = FileLocations.GetConfigFile(_measType, _config.Name);
                KLib.KFile.XmlSerialize(_config, fn);
                msSelectMeasurement.Text = $"{_measType}.{_config.Name}";
                UpdateFileMenu();
            }
        }

        private void newDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (newDropDown.SelectedIndex < 0) return;

            _measType = newDropDown.SelectedItem.ToString();
            _config = AddNewConfiguration(_measType);
            _config.Name = "Untitled";
            propertyGrid.SelectedObject = _config;
            startButton.Enabled = true;
            msSelectMeasurement.Text = $"{_measType}.{_config.Name}";

            newDropDown.SelectedIndex = -1;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_config != null)
            {
                var fn = FileLocations.GetConfigFile(_measType, _config.Name);
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
                var fn = FileLocations.GetConfigFile(_measType, _config.Name);
                _network.SendMessage("TransferFile", new TransferFilePayload
                {
                    Folder = "Config Files",
                    Filename = Path.GetFileName(fn),
                    Content = File.ReadAllText(fn)
                });
            }
        }

        private BasicMeasurementConfiguration AddNewConfiguration(string measType)
        {
            var config = new BasicMeasurementConfiguration();
            switch (measType)
            {
                case "Audiogram":
                    config = new AudiogramMeasurementSettings();
                    break;

                case "Bekesy":
                    config = new BekesyMeasurementSettings();
                    break;

                case "Digits":
                    config = new DigitsTestSettings();
                    break;

                case "LDL":
                    config = new LDLMeasurementSettings();
                    break;

                case "Questionnaire":
                    config = new Questionnaires.Questionnaire();
                    break;
            }
            return config;
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGrid.Refresh();
        }
    }
}
