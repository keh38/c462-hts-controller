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
using Microsoft.Win32;

using Serilog;

using C462.Shared;
using KLib.Controls;
using KLib.IO;

using HTS.Tcp;

namespace HTSController.Pages
{
    public class StartTurandotEventArgs : EventArgs
    {
        public string settingsPath;
        public string extraSettings;
        public StartTurandotEventArgs(string settingsPath, string extraSettings) { this.settingsPath = settingsPath; this.extraSettings = extraSettings; }
    }

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
        public event EventHandler<StartTurandotEventArgs> StartTurandotClick;
        protected virtual void OnStartTurandotClick(string settingsPath, string extraSettings)
        {
            StartTurandotClick?.Invoke(this, new StartTurandotEventArgs(settingsPath, extraSettings));
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
            EnableControls();
        }

        public void SetFileType(string fileType)
        {
            _settings = Directory.EnumerateFiles(SharedFileLocations.HtsConfigFolder, $"{fileType}.*.xml").ToList();

            listBox.Items.Clear();
            foreach (var i in _settings)
            {
                listBox.Items.Add(Path.GetFileNameWithoutExtension(i).Remove(0, fileType.Length + 1));
            }

            var last = HTSControllerSettings.GetLastUsed(fileType);
            var index = _settings.IndexOf(last);
            listBox.SelectedIndex = index;

            EnableControls();
        }

        private void EnableControls()
        {
            string fileType = fileTypeDropDown.SelectedItem?.ToString();
            startButton.Enabled = true;
            copyButton.Enabled = _network.IsConnected;
            editButton.Visible = fileType != null && fileType.Equals("Turandot");

            bool isScript = fileType != null && fileType.Equals("TScript");
            propertyGrid.Visible = isScript;
            newButton.Visible = isScript;
            saveButton.Visible = isScript;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var fileType = fileTypeDropDown.SelectedItem.ToString();
            var settingsPath = listBox.SelectedIndex > -1 ? _settings[listBox.SelectedIndex] : "";

            HTSControllerSettings.SetLastUsed(fileType, settingsPath);
            if (fileType.Equals("Interactive"))
            {
                OnStartInteractiveClick(settingsPath);
            }
            else if (fileType.Equals("Turandot"))
            {
                OnStartTurandotClick(settingsPath, null);
            }
            else if (fileType.Equals("TScript"))
            {
                ApplyScript();
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
                    _network.SendMessage("TransferFile", new TransferFilePayload
                    {
                        Folder = "Config Files",
                        Filename = Path.GetFileName(settingsPath),
                        Content = File.ReadAllText(settingsPath)
                    });
                    ShowMessage("Transferred file to tablet");
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
            if (!TurandotEditorBridge.IsRunning)
            {
                if (!TurandotEditorBridge.IsInstalled)
                {
                    Log.Information("TurandotEditor is not installed.");
                    //MsgBox.Show("TurandotEditor is not installed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                TurandotEditorBridge.Launch();
            }

            if (!TurandotEditorBridge.WaitUntilReady())
            {
                Log.Information("Could not connect to TurandotEditor.");
                //MsgBox.Show("Could not connect to TurandotEditor.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            TurandotEditorBridge.OpenFile(settingsPath);
            TurandotEditorBridge.SetHtsEndpoint(_network.RemoteEndPoint);

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

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileTypeDropDown.SelectedItem.ToString().Equals("TScript"))
            {
                var script = Files.XmlDeserialize<Turandot.Schedules.Script>(_settings[listBox.SelectedIndex]);
                propertyGrid.SelectedObject = script;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var script = new Turandot.Schedules.Script();
            propertyGrid.SelectedObject = script;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Turandot.Schedules.Script script = propertyGrid.SelectedObject as Turandot.Schedules.Script;
            string filepath = Path.Combine(SharedFileLocations.HtsConfigFolder, $"TScript.{script.Name}.xml");
            Files.XmlSerialize(script, filepath);

            HTSControllerSettings.SetLastUsed("TScript", filepath);
            SetFileType("TScript");
        }

        private void ApplyScript()
        {
            Turandot.Schedules.Script script = propertyGrid.SelectedObject as Turandot.Schedules.Script;
            script.Apply(SharedFileLocations.HtsProtocolFolder);
            ShowMessage("Created protocol files");
        }
    }
}
