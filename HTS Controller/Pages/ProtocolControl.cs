using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;

using KLib.Controls;

using Protocols;

namespace HTSController.Pages
{
    public partial class ProtocolControl : KUserControl
    {
        private enum ProtocolState { Idle, WaitingForUser, TestInProgress, Stopped, Finished }
        private ProtocolState _state = ProtocolState.Idle;

        private HTSNetwork _network;

        private Protocol _protocol;
        private ProtocolHistory _history;

        private List<Label> _labels = new List<Label>();

        public ProtocolControl()
        {
            InitializeComponent();

            titleLabel.Visible = false;
            questionPanel.Visible = false;
            controlPanel.Visible = false;
            statusTextBox.Visible = false;
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;
        }

        public void UpdateList()
        {
            var files = Directory.EnumerateFiles(FileLocations.ProtocolFolder, "*.xml").ToList();

            listBox.Items.Clear();
            foreach (var i in files)
            {
                listBox.Items.Add(Path.GetFileNameWithoutExtension(i));
            }

            var last = HTSControllerSettings.GetLastUsed("Protocol");
            var index = files.IndexOf(last);
            listBox.SelectedIndex = index;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0) return;
            var protocolPath = Path.Combine(FileLocations.ProtocolFolder, $"{listBox.SelectedItem.ToString()}.xml");
            System.Diagnostics.Process.Start(protocolPath);
        }
        
        private void openButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0) return;

            _network.RemoteMessageHandler += OnRemoteMessage;

            InitializeProtocol(listBox.SelectedItem.ToString());

            _state = ProtocolState.Idle;
            filePanel.Visible = false;

            titleLabel.Text = _protocol.Title;
            titleLabel.Visible = true;

            _labels.Clear();
            int index = flowLayoutPanel.Controls.GetChildIndex(titleLabel);
            for (int k=0; k<_protocol.Tests.Count; k++)
            {
                var label = new Label();
                label.Text = $"{k+1}. {_protocol.Tests[k].Title}";
                label.Click += label_Click;
                label.AutoSize = true;
                label.Margin = new Padding(10, 3, 0, 3);
                flowLayoutPanel.Controls.Add(label);
                flowLayoutPanel.Controls.SetChildIndex(label, index + 1);
                _labels.Add(label);
                index++;
            }

            controlPanel.Visible = true;

            ShowProtocolProgress(0);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _network.RemoteMessageHandler -= OnRemoteMessage;

            for (int k=0; k<_labels.Count; k++)
            {
                flowLayoutPanel.Controls.Remove(_labels[k]);
                _labels[k].Dispose();
            }
            _labels.Clear();

            titleLabel.Visible = false;
            controlPanel.Visible = false;
            statusTextBox.Visible = false;

            filePanel.Visible = true;
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            statusTextBox.Visible = true;

            if (!_network.IsConnected)
            {
                statusTextBox.Text = "Not connected to tablet";
                return;
            }

            statusTextBox.Text = "Starting...";

            startButton.Enabled = false;
            closeButton.Enabled = false;
            stopButton.Checked = false;

            var success = await ChangeTabletScene("Protocol");
            if (!success)
            {
                startButton.Enabled = true;
                closeButton.Enabled = true;
                statusTextBox.Text = "error changing scene";
                Log.Error("failed to change to protocol scene");
                return;
            }

            startButton.Visible = false;

            _network.SendMessage($"SetProtocol:{KLib.KFile.ToXMLString(_protocol)}");
            _network.SendMessage($"SetHistory:{KLib.KFile.ToXMLString(_history)}");
            _network.SendMessage($"Begin:{0}");

            _state = ProtocolState.WaitingForUser;
            //OnOpenProtocol(new ProtocolItem("hello"));
        }

        private void label_Click(object sender, EventArgs e)
        {
            //(sender as Label).BackColor = Color.AliceBlue;
        }

        private void InitializeProtocol(string name)
        {
            var protocolPath = Path.Combine(FileLocations.ProtocolFolder, $"{name}.xml");
            _protocol = KLib.KFile.XmlDeserialize<Protocol>(protocolPath);
            _history = new ProtocolHistory(_protocol);

            HTSControllerSettings.SetLastUsed("Protocol", protocolPath);
        }

        private void ShowProtocolProgress(int index)
        {
            for (int k=0; k < _history.Data.Count; k++)
            {
                if (k == index)
                {
                    _labels[k].ForeColor = Color.Green;
                    _labels[k].Font = new Font(_labels[k].Font, FontStyle.Bold);

                }
                else if (string.IsNullOrEmpty(_history.Data[k].DataFile))
                {
                    _labels[k].ForeColor = Color.Black;
                    _labels[k].Font = new Font(_labels[k].Font, FontStyle.Regular);
                }
                else
                {
                    _labels[k].ForeColor = Color.Gray;
                    _labels[k].Font = new Font(_labels[k].Font, FontStyle.Italic);
                }
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

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 4);
            if (parts.Length < 2) return;

            string target = parts[0];
            if (!target.Equals("Protocol")) return;

            string command = parts[1];
            string info = (parts.Length > 2) ? parts[2] : "";
            string data = (parts.Length > 3) ? parts[3] : "";

            switch (command)
            {
                case "Instructions":
                    Invoke(new Action(() => { statusTextBox.Text = "Showing instructions..."; }));
                    _state = ProtocolState.WaitingForUser;
                    break;
                case "Waiting":
                    Invoke(new Action(() => { statusTextBox.Text = "Waiting for user..."; }));
                    _state = ProtocolState.WaitingForUser;
                    break;
                case "Advance":
                    Invoke(new Action(() => { statusTextBox.Text = "Advancing..."; }));
                    _state = ProtocolState.WaitingForUser;
                    break;

            }
        }
        
        private void stopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_state != ProtocolState.TestInProgress)
            {
                PauseProtocol();
            }
        }

        private void PauseProtocol()
        {
            _state = ProtocolState.Stopped;
            statusTextBox.Text = "Stopped";
            startButton.Visible = true;
            startButton.Enabled = true;
            closeButton.Enabled = true;
        }

        #region Events
        public class ProtocolItem : EventArgs
        {
            public string filePath;
            public ProtocolItem(string filePath) { this.filePath = filePath; }
        }

        public event EventHandler<ProtocolItem> OpenProtocol;
        private void OnOpenProtocol(ProtocolItem protocolItem) { OpenProtocol?.Invoke(this, protocolItem); }
        #endregion
    }
}
