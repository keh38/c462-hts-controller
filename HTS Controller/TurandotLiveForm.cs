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
using System.Timers;
using System.Windows.Forms;

using Serilog;

using KLib;

using HTSController.Data_Streams;
using UnityEngine.WSA;

namespace HTSController
{
    public partial class TurandotLiveForm : Form
    {
        private HTSNetwork _network;
        private DataStreamManager _streamManager;
        private string _parameterFile;
        private string _dataFile;
        private string _postRunMATLABFile = "";

        private bool _autoRun;
        Watchdog _watchdog;
        private bool _runAborted;

        #region EVENTS
        public event EventHandler<AutoRunEndEventArgs> AutoRunEnd;
        private void OnAutoRunEnd(bool success, string dataFile) { AutoRunEnd?.Invoke(this, new AutoRunEndEventArgs(success, dataFile)); }

        public event EventHandler ClosePage;
        protected virtual void OnClosePage()
        {
            ClosePage?.Invoke(this, null);
        }
        #endregion

        public TurandotLiveForm(HTSNetwork network, DataStreamManager streamManager)
        {
            _network = network;
            _streamManager = streamManager;
            _watchdog = new Watchdog(OnWatchdogTimeout);

            InitializeComponent();
        }

        public void Initialize(string parameterFile)
        {
            startButton.Visible = true;

            _dataFile = "";
            _parameterFile = parameterFile;
            _network.RemoteMessageHandler += OnRemoteMessage;

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            statusTextBox.Text = "";
            logTextBox.Text = "";
        }

        public void AutoRun()
        {
            _autoRun = true;
            startButton_Click(null, null);
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            Log.Information("Starting Turandot run");
            logTextBox.Text = "Starting run...";

            startButton.Enabled = false;
            closeButton.Visible = false;

            _runAborted = false;
            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            await Task.Run(() => InitializeTurandot());

            dataFileTextBox.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile) && !_dataFile.Equals("error"))
            {
                var started = await _streamManager.StartRecording(_dataFile);
                if (started)
                {
                    startButton.Visible = false;
                    stopButton.Enabled = true;
                    logTextBox.AppendText("OK" + Environment.NewLine);
                    _network.SendMessage("Begin");
                }
                else
                {
                    logTextBox.AppendText("failed" + Environment.NewLine);
                    foreach (var s in _streamManager.ProblemStreams)
                    {
                        logTextBox.AppendText($"- {s}\n");
                    }
                    startButton.Enabled = true;
                    closeButton.Visible = true;
                    EndAutoRun(success: false, dataFile: _dataFile);
                }
            }
            else
            {
                if (_dataFile.Equals("error"))
                {
                    logTextBox.AppendText("Turandot reported an error during initialization");
                }
                else
                {
                    logTextBox.AppendText("didn't receive data file name from Turandot");
                }
                closeButton.Visible = true;
                startButton.Enabled = true;
            }
        }

        private void InitializeTurandot()
        {
            Log.Information($"Turandot parameter file: {_parameterFile}");
            var p = KFile.XmlDeserialize<Turandot.Parameters>(_parameterFile);
            _postRunMATLABFile = p.matlabFunction;
            _network.SendMessage($"SetParams:{KFile.ToXMLString(p)}");

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

            if (!string.IsNullOrEmpty(_dataFile) && !_dataFile.Equals("error"))
            {
                _network.SendMessage($"StartSynchronizing:{_dataFile}");
            }
        }

        private async void EndRun(string message, string status)
        {
            _watchdog.Stop();
            _network.SendMessage($"StopSynchronizing");
            await _streamManager.StopRecording();
            //_network.SendMessage("SendSyncLog");

            var response = _network.SendMessageAndReceiveString("GetSyncLog");
            if (response == null || response.Equals("none"))
            {
                Log.Information("tablet has no sync log file to send");
            }
            else
            {
                var parts = response.Split(new char[] { ':' }, 2);
                var logPath = Path.Combine(FileLocations.SubjectDataFolder, parts[0]);
                File.WriteAllText(logPath, parts[1]);
            }

            statusTextBox.Text = message;
            if (!string.IsNullOrEmpty(status))
            {
                logTextBox.AppendText($"{Environment.NewLine}{status}{Environment.NewLine}");
            }

            if (!message.Equals("Error") && !string.IsNullOrEmpty(_postRunMATLABFile) && MATLAB.IsInitialized)
            {
                logTextBox.AppendText($"{Environment.NewLine}Calling MATLAB function...{Environment.NewLine}");

                var result = MATLAB.RunFunction(Path.GetFileNameWithoutExtension(_postRunMATLABFile), Path.Combine(FileLocations.SubjectDataFolder, _dataFile));
                logTextBox.AppendText(result);
            }

            startButton.Enabled = true;
            startButton.Visible = true;
            closeButton.Visible = true;
            progressBar.Value = 0;
            _streamManager.RestartStatusTimer();

            EndAutoRun(success: !_runAborted && !message.Equals("Error"), dataFile: _dataFile);
        }

        private void EndAutoRun(bool success, string dataFile)
        {
            if (!_autoRun) return;
            _autoRun = false;

            closeButton_Click(null, null);
            OnAutoRunEnd(success, dataFile);
        }

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 4);
            if (parts.Length < 2) return;

            string target = parts[0];
            if (!target.Equals("Turandot")) return;

            string command = parts[1];
            string info = (parts.Length > 2) ? parts[2] : "";
            string data = (parts.Length > 3) ? parts[3] : "";

            switch (command)
            {
                case "File":
                    _dataFile = info;
                    break;
                case "Trial":
                    Invoke(new Action(() => logTextBox.Text = info));
                    break;
                case "Progress":
                    int.TryParse(info, out int progress);
                    Invoke(new Action(() => progressBar.Value = progress));
                    break;
                case "State":
                    Invoke(new Action(() => statusTextBox.Text = info));
                    break;
                case "ReceiveData":
                    string filePath = Path.Combine(FileLocations.SubjectDataFolder, info);
                    File.WriteAllText(filePath, data);
                    break;
                case "Error":
                    Invoke(new Action(() => { EndRun("Error", info); }));
                    break;
                case "Finished":
                    Invoke(new Action(() => { EndRun("Finished", info); }));
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _network.RemoteMessageHandler -= OnRemoteMessage;
            //_streamManager.Cleanup();
            OnClosePage();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            _runAborted = true;
            if (_network.CheckConnection())
            {
                _network.SendMessage("Abort");
                _watchdog.Start();
            }
            else
            {
                EndRun("Error", "Lost connection");
            }
        }

        private void OnWatchdogTimeout(object sender, EventArgs e)
        {
            Log.Error("Watchdog timed out");
            EndRun("Error", "Timed out waiting for tablet.");
        }
    }
}
