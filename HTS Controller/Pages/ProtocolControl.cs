using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;

using Protocols;

namespace HTSController.Pages
{
    public partial class ProtocolControl : KUserControl
    {
        private HTSNetwork _network;

        private Protocol _protocol;

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

        public void ShowControl(bool visible)
        {
            _network.RemoteMessageHandler += OnRemoteMessage;
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

        private void openButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0) return;
            var protocolPath = Path.Combine(FileLocations.ProtocolFolder, $"{listBox.SelectedItem.ToString()}.xml");
            _protocol = KLib.KFile.XmlDeserialize<Protocol>(protocolPath);

            filePanel.Visible = false;

            titleLabel.Text = _protocol.Title;
            titleLabel.Visible = true;

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
                index++;
            }

            statusTextBox.Visible = true;
            controlPanel.Visible = true;

            //OnOpenProtocol(new ProtocolItem("hello"));
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            titleLabel.Visible = false;
            controlPanel.Visible = false;
            statusTextBox.Visible = false;

            filePanel.Visible = true;
        }

        private void label_Click(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.AliceBlue;
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

            //switch (command)
            //{
            //    case "File":
            //        _dataFile = info;
            //        break;
            //    case "Trial":
            //        Invoke(new Action(() => logTextBox.Text = info));
            //        break;
            //    case "Progress":
            //        int.TryParse(info, out int progress);
            //        Invoke(new Action(() => progressBar.Value = progress));
            //        break;
            //    case "State":
            //        Invoke(new Action(() => statusTextBox.Text = info));
            //        break;
            //    case "ReceiveData":
            //        string filePath = Path.Combine(FileLocations.SubjectDataFolder, info);
            //        File.WriteAllText(filePath, data);
            //        break;
            //    case "Error":
            //        EndRun("Error", info);
            //        break;
            //    case "Finished":
            //        EndRun("Finished", info);
            //        break;
            //}
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
