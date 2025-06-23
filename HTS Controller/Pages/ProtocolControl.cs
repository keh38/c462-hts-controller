using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private string _historyPath;

        private List<Label> _labels = new List<Label>();
        private int _nextTestIndex = 0;

        DialogResult _dlgResult = DialogResult.None;

        public ProtocolControl()
        {
            InitializeComponent();

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
        
        private async void openButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0) return;

            _network.RemoteMessageHandler += OnRemoteMessage;

            await InitializeProtocol(listBox.SelectedItem.ToString());

            _state = ProtocolState.Idle;
            filePanel.Visible = false;

            titleLabel.Text = _protocol.Title;
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Bold);

            _labels.Clear();
            int index = flowLayoutPanel.Controls.GetChildIndex(titleLabel);
            int outlineNum = 1;

            for (int k=0; k<_protocol.Tests.Count; k++)
            {
                var label = new Label();
                if (!_protocol.Tests[k].HideOutline)
                {
                    label.Text = $"{outlineNum}. {_protocol.Tests[k].Title}";
                    outlineNum++;
                }
                else
                {
                    label.Text = $"- {_protocol.Tests[k].Title}";
                }
                label.Click += label_Click;
                label.AutoSize = true;
                label.Margin = new Padding(10, 3, 0, 3);
                flowLayoutPanel.Controls.Add(label);
                flowLayoutPanel.Controls.SetChildIndex(label, index + 1);
                _labels.Add(label);
                index++;
            }

            controlPanel.Visible = true;

            ShowProtocolProgress(_nextTestIndex);
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

            titleLabel.Text = "Protocol";
            titleLabel.Font = new Font(titleLabel.Font, FontStyle.Regular);
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


            startButton.Visible = false;

            await StartRemote();

            OnProtocolStateChange(running: true);
        }

        private async Task StartRemote(bool finished = false)
        {
            var success = await ChangeTabletScene("Protocol");
            if (!success)
            {
                startButton.Enabled = true;
                closeButton.Enabled = true;
                statusTextBox.Text = "error changing scene";
                Log.Error("failed to change to protocol scene");
                StopProtocol();
                return;
            }

            _network.SendMessage($"SetProtocol:{KLib.KFile.ToXMLString(_protocol)}");
            _network.SendMessage($"SetHistory:{KLib.KFile.ToXMLString(_history)}");

            if (finished)
            {
                _network.SendMessage("Finish:");
            }
            else
            {
                _network.SendMessage($"Begin:{_nextTestIndex}");
                _state = ProtocolState.WaitingForUser;
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (_state == ProtocolState.Idle || _state == ProtocolState.Stopped)
            {
                _nextTestIndex = _labels.IndexOf(sender as Label);
                ShowProtocolProgress(_nextTestIndex);
            }
        }

        private async Task InitializeProtocol(string name)
        {
            var protocolPath = Path.Combine(FileLocations.ProtocolFolder, $"{name}.xml");
            _protocol = KLib.KFile.XmlDeserialize<Protocol>(protocolPath);

            bool restore = false;

            var fileList = Directory.GetFiles(FileLocations.SubjectDataFolder, $"{FileLocations.Subject}-{name}-History-*.json").ToList();
            if (fileList.Count > 0)
            {
                fileList.Sort((x, y) => File.GetCreationTime(y).CompareTo(File.GetCreationTime(x)));
                for (int k = 0; k < fileList.Count; k++) Debug.WriteLine(fileList[k]);

                _history = KLib.KFile.RestoreFromJson<ProtocolHistory>(fileList[0]);
                if (_history.Matches(_protocol) && !_history.Finished)
                {
                    _historyPath = fileList[0];
                    _nextTestIndex = _history.NextTextIndex;
                    var response = await AskQuestion($"Resume previous?\n{File.GetCreationTime(_historyPath)}");
                    restore = response == DialogResult.Yes;
                }
            }

            if (!restore)
            {
                _history = new ProtocolHistory(_protocol);
                _nextTestIndex = 0;
                _historyPath = Path.Combine(
                    FileLocations.SubjectDataFolder,
                    $"{FileLocations.Subject}-{name}-History-{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.json");
            }


            HTSControllerSettings.SetLastUsed("Protocol", protocolPath);
        }

        private async Task<DialogResult> AskQuestion(string question)
        {
            _dlgResult = DialogResult.None;

            questionLabel.Text = question;
            questionPanel.Visible = true;

            await Task.Run(() =>
            {
                while (_dlgResult == DialogResult.None) { Thread.Sleep(100); }
            });

            return _dlgResult;
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
                else if (string.IsNullOrEmpty(_history.Data[k].Date))
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

        private void Advance()
        {
            _state = ProtocolState.TestInProgress;
            statusTextBox.Text = "Running...";
            var nextTest = _history.Data[_nextTestIndex];
            OnAdvanceProtocol(new ProtocolItem(nextTest.Scene, nextTest.Settings));
        }

        public async void TestFinished(bool success, string dataFile)
        {
            if (success)
            {
                _history.Data[_nextTestIndex].Date = DateTime.Now.ToString();
                _history.Data[_nextTestIndex].DataFile = dataFile;
                KLib.KFile.JSONSerialize(_history, _historyPath);

                _nextTestIndex++;
                ShowProtocolProgress(_nextTestIndex);
                if (stopButton.Checked)
                {
                    StopProtocol();
                    stopButton.Checked = false;
                }
                else if (_nextTestIndex == _protocol.Tests.Count)
                {
                    StopProtocol(finished: true);
                    await StartRemote(finished: true);
                }
                else if (_protocol.Tests[_nextTestIndex].HideOutline)
                {
                    Advance();
                }
                else
                {
                    await StartRemote();
                }
            }
            else
            {
                StopProtocol(finished: false, message: "There was a problem");
            }
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
                    Invoke(new Action(() => { Advance(); }));
                    break;
                case "Quit":
                    Invoke(new Action(() => { StopProtocol(false, "User quit"); }));
                    break;
            }
        }
        
        private void stopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_state != ProtocolState.TestInProgress)
            {
                StopProtocol();
            }
        }

        private void StopProtocol(bool finished = false, string message = "")
        {
            if (finished)
            {
                _state = ProtocolState.Finished;
                statusTextBox.Text = string.IsNullOrEmpty(message) ? "Finished" : message;
            }
            else
            {
                _state = ProtocolState.Stopped;
                statusTextBox.Text = string.IsNullOrEmpty(message) ? "Stopped" : message;
            }
            startButton.Visible = true;
            startButton.Enabled = true;
            closeButton.Enabled = true;

            OnProtocolStateChange(running: false);
        }

        #region Events
        public class ProtocolItem : EventArgs
        {
            public string sceneName;
            public string settingsFile;
            public ProtocolItem(string sceneName, string settingsFile)
            {
                this.sceneName = sceneName;
                this.settingsFile = settingsFile;
            }
        }

        public event EventHandler<ProtocolItem> AdvanceProtocol;
        private void OnAdvanceProtocol(ProtocolItem protocolItem) { AdvanceProtocol?.Invoke(this, protocolItem); }

        public class ProtocolStateChangeEventArgs : EventArgs
        {
            public bool running;
            public ProtocolStateChangeEventArgs(bool running) { this.running = running; }
        }
        public event EventHandler<ProtocolStateChangeEventArgs> ProtocolStateChange;
        private void OnProtocolStateChange(bool running) { ProtocolStateChange?.Invoke(this, new ProtocolStateChangeEventArgs(running)); }
        #endregion

        private void yesButton_Click(object sender, EventArgs e)
        {
            _dlgResult = DialogResult.Yes;
            questionPanel.Visible = false;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            _dlgResult = DialogResult.No;
            questionPanel.Visible = false;
        }
    }
}
