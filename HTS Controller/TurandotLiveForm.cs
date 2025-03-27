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

namespace HTSController
{
    public partial class TurandotLiveForm : Form
    {
        private HTSNetwork _network;
        private DataStreamManager _streamManager;
        private string _parameterFile;
        private string _dataFile;

        public event EventHandler ClosePage;
        protected virtual void OnClosePage()
        {
            ClosePage?.Invoke(this, null);
        }

        public TurandotLiveForm(HTSNetwork network, DataStreamManager streamManager)
        {
            _network = network;
            _streamManager = streamManager;

            InitializeComponent();
        }

        public void Initialize(string parameterFile)
        {
            startButton.Visible = true;

            _dataFile = "";
            _parameterFile = parameterFile;
            _network.RemoteMessageHandler += OnRemoteMessage;
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "Starting run...";

            startButton.Enabled = false;
            closeButton.Visible = false;

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            await Task.Run(() => InitializeTurandot());

            dataFileTextBox.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile))
            {
                var started = await _streamManager.StartRecording(_dataFile);
                if (started)
                {
                    startButton.Visible = false;
                    logTextBox.AppendText("OK" + Environment.NewLine);
                    _network.SendMessage("Begin");
                }
                else
                {
                    logTextBox.AppendText("failed" + Environment.NewLine);
                    startButton.Enabled = true;
                    closeButton.Visible = true;
                }
            }
            else
            {
                logTextBox.AppendText("didn't receive data file name from Turandot");
                closeButton.Visible = true;
                startButton.Enabled = true;
            }
        }

        private void InitializeTurandot()
        {
            var p = KFile.XmlDeserialize<Turandot.Parameters>(_parameterFile);
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

            if (!string.IsNullOrEmpty(_dataFile))
            {
                _network.SendMessage($"StartSynchronizing:{_dataFile}");
            }
        }

        private async void EndRun()
        {
            _network.SendMessage($"StopSynchronizing");
            await _streamManager.StopRecording();
            _network.SendMessage("SendSyncLog");

            Invoke(new Action(() =>
            {
                startButton.Enabled = true;
                startButton.Visible = true;
                closeButton.Visible = true;
                progressBar.Value = 0;
                _streamManager.RestartStatusTimer();
            }));

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
                    Debug.WriteLine(info);
                    string filePath = Path.Combine(FileLocations.SubjectDataFolder, info);
                    Debug.WriteLine(filePath);
                    File.WriteAllText(filePath, data);
                    break;
                case "Finished":
                    EndRun();
                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _network.RemoteMessageHandler -= OnRemoteMessage;
            _streamManager.Cleanup();
            OnClosePage();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("Abort");
        }
    }
}
