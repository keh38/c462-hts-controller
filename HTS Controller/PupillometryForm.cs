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

using HTSController.Data_Streams;

using SREYELINKLib;

namespace HTSController
{
    public partial class PupillometryForm : Form
    {
        private HTSNetwork _network;
        private DataStreamManager _streamManager;
        private string _dataFile;

        public PupillometryForm(HTSNetwork network, DataStreamManager streamManager)
        {
            _network = network;
            _network.RemoteMessageHandler += OnRemoteMessage;

            _streamManager = streamManager;

            InitializeComponent();
        }

        public void Initialize()
        {
            startButton.Visible = true;

            _dataFile = "";

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            logTextBox.Text = "";
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                logTextBox.Text = "Not connected to tablet";
                return;
            }

            startButton.Enabled = false;

            logTextBox.Text = "Starting dynamic range measurement...";
            var success = await ChangeTabletScene();
            if (!success)
            {
                startButton.Enabled = true;
                logTextBox.Text = "failed to change scene on tablet";
                Debug.WriteLine("failed to change to pupil dynamic range scene");
                return;
            }

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            await Task.Run(() => InitializeDynamicRangeMeasurement());

            dataFileTextBox.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile))
            {
                var started = await _streamManager.StartRecording(_dataFile);
                if (started)
                {
                    stopButton.Enabled = true;
                    stopButton.Visible = true;
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
                }
            }
            else
            {
                logTextBox.AppendText("didn't receive data file name from Dynamic Range scene");
                startButton.Enabled = true;
            }
        }

        private async Task<bool> ChangeTabletScene()
        {
            string sceneName = "Pupil Dynamic Range";

            bool success = false;
            _network.SendMessage($"ChangeScene:{sceneName}");

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                Debug.WriteLine(_network.CurrentScene);
                await Task.Delay(200);
                if (_network.CurrentScene.Equals(sceneName))
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        private void InitializeDynamicRangeMeasurement()
        {
            _network.SendMessage("Initialize:");

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

        private async void EndRun(string message, string info)
        {
            _network.SendMessage($"StopSynchronizing");
            await _streamManager.StopRecording();
            _network.SendMessage("SendSyncLog");

            Invoke(new Action(() =>
            {
                startButton.Enabled = true;
                stopButton.Visible = false;
                if (!string.IsNullOrEmpty(info))
                {
                    logTextBox.AppendText($"{Environment.NewLine}{info}");
                }
                progressBar.Value = 0;
                _streamManager.RestartStatusTimer();
            }));
        }

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 4);
            if (parts.Length < 2) return;

            string target = parts[0];
            if (!target.Equals("Pupil Dynamic Range")) return;

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
                    EndRun("Error", info);
                    break;
                case "Finished":
                    EndRun("Finished", info);
                    break;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            _network.SendMessage("Abort");
        }

        private void TestEyeLink()
        {
            var e = new SREYELINKLib.EyeLink();
            e.open("100.1.1.1");
            e.sendCommand("screen_pixel_coords 0 0 1000 1000");
            e.sendCommand("calibration_type = HS9");

        }
    }
}
