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
        private List<string> _interactiveSettings;

        [Description("Occurs when Interactive button pressed")]
        public event EventHandler<string> InteractiveClick;
        protected virtual void OnInteractiveClick(string settingsPath)
        {
            if (this.InteractiveClick != null)
            {
                InteractiveClick(this, settingsPath);
            }
        }

        public TurandotPage()
        {
            InitializeComponent();
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;
            FillInteractiveList();
        }

        public void FillInteractiveList()
        {
            _interactiveSettings = Directory.EnumerateFiles(FileLocations.ConfigFolder, "Interactive.*.xml").ToList();

            interactiveSettingsListBox.Items.Clear();
            foreach (var i in _interactiveSettings)
            {
                interactiveSettingsListBox.Items.Add(Path.GetFileNameWithoutExtension(i).Remove(0, ("Interactive.").Length));
            }

            var last = HSTControllerSettings.GetLastUsed("Turandot Interactive");
            var index = _interactiveSettings.IndexOf(last);
            interactiveSettingsListBox.SelectedIndex = index;
        }

        private void interactiveButton_Click(object sender, EventArgs e)
        {
            var settingsPath = interactiveSettingsListBox.SelectedIndex > -1 ?_interactiveSettings[interactiveSettingsListBox.SelectedIndex] : "";
            OnInteractiveClick(settingsPath);
        }

        private void interactiveSettingsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var result = System.Windows.Forms.MessageBox.Show($"Delete '{interactiveSettingsListBox.Text}'?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var fileToDelete = _interactiveSettings[interactiveSettingsListBox.SelectedIndex];
                    File.Delete(fileToDelete);
                    _interactiveSettings.Remove(fileToDelete);
                    interactiveSettingsListBox.Items.RemoveAt(interactiveSettingsListBox.SelectedIndex);
                }
            }
        }
    }
}
