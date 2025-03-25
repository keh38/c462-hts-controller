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

namespace HTSController
{
    public partial class TurandotLiveForm : Form
    {
        private HTSNetwork _network;
        private string _parameterFile;
        private string _dataFile;

        public event EventHandler ClosePage;
        protected virtual void OnClosePage()
        {
            ClosePage?.Invoke(this, null);
        }

        public TurandotLiveForm(HTSNetwork network)
        {
            _network = network;

            InitializeComponent();
        }

        public void Initialize(string parameterFile)
        {
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
            await Task.Run(() => InitializeTurandot());

            dataFileLabel.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile))
            {
                _network.SendMessage($"Begin");
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

//            receivedMessageTextBox.Invoke(new Action(() => Text = $"{command}:{data}"));
            Invoke(new Action(() =>
            {
                receivedMessageTextBox.Text = $"{command}:{data}";
            }));

            switch (command)
            {
                case "File":
                    _dataFile = data;
                    break;
            }
        }
    }
}
