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

namespace HTSController.Pages
{
    public partial class TurandotPage : KUserControl
    {
        private HTSNetwork _network;
        private List<string> _settings;

        [Description("Occurs when Interactive button pressed")]
        public event EventHandler<string> InteractiveClick;
        protected virtual void OnInteractiveClick(string settingsPath)
        {
            InteractiveClick?.Invoke(this, settingsPath);
        }

        public TurandotPage()
        {
            InitializeComponent();
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;
            var lastItem = HSTControllerSettings.GetLastUsed("TurandotPage");
            if (string.IsNullOrEmpty(lastItem))
            {
                lastItem = "Turandot";
            }
            fileTypeDropDown.SelectedItem = lastItem;
        }

        public void NetworkStatusChanged()
        {
            EnableButtons();
        }

        public void SetFileType(string fileType)
        {
            _settings = Directory.EnumerateFiles(FileLocations.ConfigFolder, $"{fileType}.*.xml").ToList();

            listBox.Items.Clear();
            foreach (var i in _settings)
            {
                listBox.Items.Add(Path.GetFileNameWithoutExtension(i).Remove(0, fileType.Length + 1));
            }

            var last = HSTControllerSettings.GetLastUsed(fileType);
            var index = _settings.IndexOf(last);
            listBox.SelectedIndex = index;

            EnableButtons();
        }

        private void EnableButtons()
        {
            string fileType = fileTypeDropDown.SelectedItem.ToString();
            startButton.Enabled = _network.IsConnected || fileType.Equals("Interactive");
            copyButton.Enabled = _network.IsConnected;
            editButton.Visible = fileType.Equals("Turandot");
        }

        private void interactiveButton_Click(object sender, EventArgs e)
        {
            var settingsPath = listBox.SelectedIndex > -1 ?_settings[listBox.SelectedIndex] : "";
            OnInteractiveClick(settingsPath);
        }

        private void interactiveSettingsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var result = System.Windows.Forms.MessageBox.Show($"Delete '{listBox.Text}'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var fileToDelete = _settings[listBox.SelectedIndex];
                    File.Delete(fileToDelete);
                    _settings.Remove(fileToDelete);
                    listBox.Items.RemoveAt(listBox.SelectedIndex);
                }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            var settingsPath = listBox.SelectedIndex > -1 ? _settings[listBox.SelectedIndex] : "";
            if (!string.IsNullOrEmpty(settingsPath))
            {
                if (_network.IsConnected)
                {
                    _network.SendMessage($"TransferFile:Config Files:{Path.GetFileName(settingsPath)}:{File.ReadAllText(settingsPath)}");
                    messageLabel.Text = "Transfered file to tablet";
                    messageLabel.Visible = true;
                }
            }
        }

        private void fileTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFileType(fileTypeDropDown.SelectedItem.ToString());
        }
    }
}
