using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            _network.RemoteMessageHandler -= OnRemoteMessage;
            OnClosePage();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "Starting run...";

            startButton.Enabled = false;
            await Task.Run(() => InitializeTurandot());

            dataFileLabel.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile))
            {
                var started = await _streamManager.StartRecording(_dataFile);
                if (started)
                {
                    logTextBox.AppendText("OK" + Environment.NewLine);
                    _network.SendMessage("Begin");
                }
                else
                {
                    logTextBox.AppendText("failed" + Environment.NewLine);
                    startButton.Enabled = true;
                }
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

            Invoke(new Action(() =>
            {
                startButton.Enabled = true;
                startButton.Visible = true;
                _streamManager.RestartStatusTimer();
            }));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _network.SendMessage("Begin");
        }

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 3);
            if (parts.Length != 3) return;

            string target = parts[0];
            if (!target.Equals("Turandot")) return;

            string command = parts[1];
            string data = parts[2];

            Invoke(new Action(() =>
            {
                receivedMessageTextBox.Text = $"{command}:{data}";
            }));

            switch (command)
            {
                case "File":
                    _dataFile = data;
                    break;
                case "Finished":
                    EndRun();
                    break;
            }
        }
    }
}
