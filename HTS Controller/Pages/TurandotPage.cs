﻿using System;
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
using Microsoft.Win32;

using Serilog;

using KLib.Controls;

namespace HTSController.Pages
{
    public partial class TurandotPage : KUserControl
    {
        private HTSNetwork _network;
        private List<string> _settings;

        [Description("Occurs when Start button pressed")]
        public event EventHandler<string> StartInteractiveClick;
        protected virtual void OnStartInteractiveClick(string settingsPath)
        {
            StartInteractiveClick?.Invoke(this, settingsPath);
        }
        public event EventHandler<string> StartTurandotClick;
        protected virtual void OnStartTurandotClick(string settingsPath)
        {
            StartTurandotClick?.Invoke(this, settingsPath);
        }

        public TurandotPage()
        {
            InitializeComponent();
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;
        }

        public void UpdateConfigFileList()
        {
            var lastItem = HTSControllerSettings.GetLastUsed("TurandotPage");
            if (string.IsNullOrEmpty(lastItem))
            {
                lastItem = "Turandot";
            }

            _ignoreEvents = true;

            fileTypeDropDown.SelectedItem = lastItem;
            SetFileType(lastItem);

            _ignoreEvents = false;
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

            var last = HTSControllerSettings.GetLastUsed(fileType);
            var index = _settings.IndexOf(last);
            listBox.SelectedIndex = index;

            EnableButtons();
        }

        private void EnableButtons()
        {
            string fileType = fileTypeDropDown.SelectedItem?.ToString();
            startButton.Enabled = true;// _network.IsConnected || fileType.Equals("Interactive");
            copyButton.Enabled = _network.IsConnected;
            editButton.Visible = fileType != null && fileType.Equals("Turandot");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var fileType = fileTypeDropDown.SelectedItem.ToString();
            var settingsPath = listBox.SelectedIndex > -1 ?_settings[listBox.SelectedIndex] : "";

            HTSControllerSettings.SetLastUsed(fileType, settingsPath);
            if (fileType.Equals("Interactive"))
            {
                OnStartInteractiveClick(settingsPath);
            }
            else if (fileType.Equals("Turandot"))
            {
                OnStartTurandotClick(settingsPath);
            }
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
                    ShowMessage("Transfered file to tablet");
                }
            }
        }

        private void fileTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                SetFileType(fileTypeDropDown.SelectedItem.ToString());
            }
        }

        private async void editButton_Click(object sender, EventArgs e)
        {
            var settingsPath = listBox.SelectedIndex > -1 ? _settings[listBox.SelectedIndex] : "";
            var success = await Task.Run(() => EditTurandotFile(settingsPath));

            if (!success)
            {
                ShowMessage("Could not start Turandot Editor");
            }
        }

        private bool EditTurandotFile(string settingsPath)
        {
            var ip = KLib.Net.Discovery.Discover("TURANDOT.EDITOR");
            if (ip != null)
            {
                KLib.Net.KTcpClient.SendMessage(ip, $"OpenFile:{settingsPath}");
                return true;
            }

#if DEBUG
            string editorFolder = @"D:\Development\C462\c462-turandot-editor\Turandot Editor\bin\Debug";
            if (!Directory.Exists(editorFolder))
            {
                editorFolder = "C" + editorFolder.Substring(1);
            }
#else
            string editorFolder = "";
            // https://stackoverflow.com/questions/2039186/reading-the-registry-and-wow6432node-key
            string key = @"Software\EPL\C462\Turandot Editor";
            using (var view64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var subKey = view64.OpenSubKey(key, false))
                {
                    editorFolder = subKey.GetValue("InstallPath", "").ToString();
                }
            }
#endif

            var editorPath = Path.Combine(editorFolder, "Turandot Editor.exe");
            
            if (!File.Exists(editorPath)) return false;

            var processStartInfo = new ProcessStartInfo(editorPath, $"\"{settingsPath}\"");
            processStartInfo.WorkingDirectory = editorFolder;
            var process = Process.Start(processStartInfo);

            return true;
        }

        private void ShowMessage(string message)
        {
            messageLabel.Text = message;
            messageLabel.Visible = true;
            messageTimer.Start();
        }

        private void messageTimer_Tick(object sender, EventArgs e)
        {
            messageTimer.Stop();
            messageLabel.Visible = false;
        }
    }
}
