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

            InitializeComponent();
        }

        public void Initialize()
        {
            startButton.Visible = true;
            startButton.Enabled = false;

            _dataFile = "";

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            logTextBox.Text = "";

            msSelectMeasurement.DropDownItems.Clear();
            msSelectMeasurement.Text = "Select...";

            foreach (var measType in new List<string>() { "Audiogram", "LDL" })
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
                msSelectMeasurement.DropDownItems.Add(measItem);
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
            var configPath = Path.Combine(FileLocations.ConfigFolder, _measType, _configName);
            if (!File.Exists(configPath))
            {
                configPath = null;
            }
            
            switch ( _measType )
            {
                case "Audiogram":
                    if (configPath == null)
                    {
                        _config = new AudiogramMeasurementSettings();
                    }
                    else
                    {
                        _config = KFile.XmlDeserialize<AudiogramMeasurementSettings>(configPath);
                    }
                    break;

                case "LDL":
                    if (configPath == null)
                    {
                        _config = new LDLMeasurementSettings();
                    }
                    else
                    {
                        _config = KFile.XmlDeserialize<LDLMeasurementSettings>(configPath);
                    }
                    break;
            }

            propertyGrid.SelectedObject = _config;
            startButton.Enabled = true;
        }

        public void AutoRunDynamicRange()
        {
            _autoRun = true;
            startButton_Click(this, null);
        }


        private async void startButton_Click(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                logTextBox.Text = "Not connected to tablet";
                return;
            }

            startButton.Enabled = false;

            logTextBox.Text = $"Starting {_measType} measurement...";
            Log.Information($"Starting  {_measType}.{_configName} measurement...");
            var success = await ChangeTabletScene(_measType);
            
            if (!success)
            {
                startButton.Enabled = true;
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
                var started = await _streamManager.StartRecording(_dataFile);
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
                    startButton.Enabled = true;
                    _network.SendMessage($"StopSynchronizing");
                    EndAutoRun(false, null);
                }
            }
            else
            {
                logTextBox.AppendText($"didn't receive data file name from {_measType} scene");
                Log.Error($"didn't receive data file name from {_measType} scene");
                startButton.Enabled = true;
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

            if (!string.IsNullOrEmpty(_dataFile))
            {
                _network.SendMessage($"StartSynchronizing:{_dataFile}");
            }
        }

        private async void EndRun(string message, string status)
        {
            _network.SendMessage($"StopSynchronizing");
            await _streamManager.StopRecording();

            var response = _network.SendMessageAndReceiveString("GetSyncLog");
            if (!response.Equals("none"))
            {
                var parts = response.Split(new char[] { ':' }, 2);
                var logPath = Path.Combine(FileLocations.SubjectDataFolder, parts[0]);
                File.WriteAllText(logPath, parts[1]);
            }

            if (!string.IsNullOrEmpty(status))
            {
                logTextBox.AppendText($"{Environment.NewLine}{status}{Environment.NewLine}");
            }

            startButton.Enabled = true;
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
            _runAborted = true;
            stopButton.Enabled = false;
            _network.SendMessage("Abort");
        }
        private void dynamicRangePropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var configPath = Path.Combine(FileLocations.ConfigFolder, "DynamicRange.Defaults.xml");
//            KLib.KFile.XmlSerialize(_dynamicRangeSettings, configPath);
        }

    }
}
