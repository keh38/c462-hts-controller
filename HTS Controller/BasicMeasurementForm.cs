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
using Audiograms;
using LDL;

using HTSController.Data_Streams;

using Serilog;
using Bekesy;
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
            _network.RemoteMessageHandler += OnRemoteMessage;

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
            foreach (var measType in new List<string>() { "Audiogram", "Bekesy", "LDL", "Questionnaire" })
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
            Log.Information($"Starting  {_measType}.{_configName} measurement...");
            var success = await ChangeTabletScene(_measType);
            
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

            dataFileTextBox.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile))
            {
                bool started = true;
                if (!_config.BypassDataStreams)
                {
                    started = await _streamManager.StartRecording(_dataFile);
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
                    foreach (var s in _streamManager.ProblemStreams)
                    {
                        logTextBox.AppendText($"- {s}\n");
                        Log.Error($"failed to start stream: {s}");
                    }
                    EnableButtons(true);
                    _network.SendMessage($"StopSynchronizing");
                    EndAutoRun(false, null);
                }
            }
            else
            {
                logTextBox.AppendText($"didn't receive data file name from {_measType} scene");
                Log.Error($"didn't receive data file name from {_measType} scene");
                EnableButtons(true);
                _network.SendMessage($"StopSynchronizing");
                EndAutoRun(false, null);
            }
        }

        private async Task<bool> ChangeTabletScene(string sceneName)
        {
            bool success = false;
            _network.SendMessage($"ChangeScene:{sceneName}");

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
            _network.SendMessage($"Initialize:{KFile.ToXMLString(_config)}");

            // wait for file name to get sent back
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                Thread.Sleep(200);
                if (!string.IsNullOrEmpty(_dataFile))
                {
                    break;
                }
            }

            if (!string.IsNullOrEmpty(_dataFile) && !_config.BypassDataStreams)
            {
                Log.Information($"Remote data file = {_dataFile}");
                _network.SendMessage($"StartSynchronizing:{_dataFile}");
            }
        }

        private async void EndRun(string message, string status)
        {
            _watchdog.Stop();
            Log.Information("Run ending");
            if (!_config.BypassDataStreams)
            {
                _network.SendMessage($"StopSynchronizing");
                await _streamManager.StopRecording();

                var response = _network.SendMessageAndReceiveString("GetSyncLog");
                if (!string.IsNullOrEmpty(response) && !response.Equals("none"))
                {
                    var parts = response.Split(new char[] { ':' }, 2);
                    var logPath = Path.Combine(FileLocations.SubjectDataFolder, parts[0]);
                    File.WriteAllText(logPath, parts[1]);
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                logTextBox.AppendText($"{Environment.NewLine}{status}{Environment.NewLine}");
            }

            EnableButtons(true);
            stopButton.Visible = false;

            progressBar.Value = 0;
            _streamManager.RestartStatusTimer();
            OnRunStateChanged(_measType, false);

            EndAutoRun(success: !_runAborted && !message.Equals("Error"), dataFile:_dataFile);
        }

        private void EndAutoRun(bool success, string dataFile)
        {
            if (!_autoRun) return;
            _autoRun = false;

            OnAutoRunEnd(success, dataFile);
        }

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 4);
            if (parts.Length < 2) return;

            string target = parts[0];
            if (!target.Equals(_measType)) return;

            string command = parts[1];
            string info = (parts.Length > 2) ? parts[2] : "";
            string data = (parts.Length > 3) ? parts[3] : "";

            switch (command)
            {
                case "File":
                    _dataFile = info;
                    break;
                case "Progress":
                    int.TryParse(info, out int progress);
                    Invoke(new Action(() => progressBar.Value = progress));
                    break;
                case "ReceiveData":
                    string filePath = Path.Combine(FileLocations.SubjectDataFolder, info);
                    File.WriteAllText(filePath, data);
                    break;
                case "Status":
                    Log.Information($"Status update: {info}");
                    Invoke(new Action(() => logTextBox.AppendText($"- {info}{Environment.NewLine}")));
                    break;
                case "Error":
                    Invoke(new Action(() => { EndRun("Error", info); }));
                    break;
                case "Finished":
                    _runAborted = info.Equals("Measurement aborted");
                    Invoke(new Action(() => { EndRun("Finished", info); }));
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
                _network.SendMessage($"TransferFile:Config Files:{Path.GetFileName(fn)}:{File.ReadAllText(fn)}");
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

                case "LDL":
                    config = new LDLMeasurementSettings();
                    break;

                case "Questionnaire":
                    config = new Questionnaires.Questionnaire();
                    break;
            }
            return config;
        }

    }
}
