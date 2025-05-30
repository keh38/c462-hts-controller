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

using KLib.Controls;
using KLib.Signals.Waveforms;
using KLib.Wave;

namespace KLib.Unity.Controls.Signals
{
    public partial class UserFilePage : KUserControl
    {
        private UserFile _userFile;

        private string _defaultFolder;
        public string DefaultFolder
        {
            get { return _defaultFolder; }
            set
            {
                _defaultFolder = value;
                fileBrowser.DefaultFolder = value;
            }
        }

        public UserFilePage()
        {
            InitializeComponent();
        }

        public Waveform Value
        {
            get { return _userFile; }
            set
            {
                _userFile = value as UserFile;
                ShowData(_userFile);
            }
        }

        private void ShowData(UserFile uf)
        {
            if (uf == null) return;
            _ignoreEvents = true;

            fileBrowser.Value = _userFile.fileName;
            oneShotCheckBox.Checked = _userFile.oneShot;
            canComputeCheckBox.Checked = _userFile.canComputeReference;
            UpdateMetadata();

            _ignoreEvents = false;
        }

        private void UpdateMetadata()
        {
            string wfpath = _userFile.fileName;
            if (!string.IsNullOrEmpty(DefaultFolder) && !string.IsNullOrEmpty(_userFile.fileName))
            {
                wfpath = Path.Combine(DefaultFolder, Path.GetFileName(_userFile.fileName));
            }

            if (File.Exists(wfpath))
            {
                WaveFile wf = new WaveFile();
                wf.Read(wfpath, true);

                if (!float.IsNaN(wf.SamplingRate))
                {
                    string dur = wf.Duration > 10 ? Math.Round(wf.Duration) + "s": Math.Round(wf.Duration * 1000) + "ms";
                    formatTextBox.Text = dur + " @ " + (wf.SamplingRate) + "Hz";
                }
                else
                    formatTextBox.Text = "";
            }
        }

        private void fileBrowser_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _userFile.fileName = fileBrowser.Value;
                UpdateMetadata();
                OnValueChanged();
            }
        }

        private void oneShotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _userFile.oneShot = oneShotCheckBox.Checked;
                OnValueChanged();
            }
        }

        private void canComputeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _userFile.canComputeReference = canComputeCheckBox.Checked;
                OnValueChanged();
            }
        }
    }
}
