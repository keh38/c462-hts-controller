using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;
using KLib.Signals;
using KLib.Signals.Enumerations;

namespace KLib.Unity.Controls.Signals
{
    public partial class ChannelView : KUserControl
    {
        private Channel _chan;
        private bool _allowExpert = false;

        public ChannelView()
        {
            InitializeComponent();

            //destinationDropDown.FillSubset(Laterality.Left, Laterality.Right, Laterality.Diotic, Laterality.Dichotic);
        }

        public Channel Value
        {
            get { return _chan; }
            set
            {
                _chan = value;
                ShowChannel(_chan);
            }
        }

        public string WavFolder
        {
            get { return waveformView.WavFolder; }
            set { waveformView.WavFolder = value; }
        }

        public void UpdateMaxLevel()
        {
            if (_chan != null) levelView.SetMaxLevel(_chan.GetMaxLevel());
        }

        public bool AllowExpertOptions
        {
            get { return _allowExpert; }
            set
            {
                _allowExpert = value;
                expertSep.Visible = value;
                expertControl.Visible = value;
                SetContextDependentLevelReferences(Waveshape.None);
            }
        }

        private void ShowChannel(Channel ch)
        {
            _ignoreEvents = true;

            if (ch == null || ch.waveform==null)
            {
                destinationDropDown.SetEnumValue(Laterality.Diotic);
                destPanel.Enabled = false;
                waveformView.Value = null;
                waveformView.Enabled = false;

                ShowModGateLevel(false);
            }
            else if (ch.waveform.Shape == Waveshape.None)
            {
                //destinationDropDown.SetEnumValue(ch.Destination);
                destPanel.Enabled = true;

                waveformView.Value = ch.waveform;
                waveformView.Enabled = true;

                ShowModGateLevel(false);
            }
            else
            {
                //destinationDropDown.SetEnumValue(ch.Destination);
                destPanel.Enabled = true;

                waveformView.Enabled = true;
                waveformView.Value = ch.waveform;

                //modulationView.Value = ch.modul;
                gateView.Value = ch.gate;

                SetContextDependentLevelUnits(ch.waveform.Shape);
                levelView.Value = ch.level;
                levelView.SetMaxLevel(ch.GetMaxLevel());

                expertControl.Value = ch;

                ShowModGateLevel(true);
                EnableBinauralProperties();
                //levelView.m
                levelView.ILD = ch.binaural.ILD;
                waveformView.IPD = ch.binaural.IPD;

                _ignoreEvents = false;
            }
        }

        private void ShowModGateLevel(bool show)
        {
            modSep.Visible = show;
            modulationView.Visible = show;

            gateSep.Visible = show;
            gateView.Visible = show;

            levelSep.Visible = show;
            levelView.Visible = show;

            expertSep.Visible = show && _allowExpert;
            expertControl.Visible = show && _allowExpert;
        }

        private void SetContextDependentLevelUnits(Waveshape waveShape)
        {
            //if (!_allowExpert)
            //    levelView.SetAllowableUnits(LevelUnits.dB_attenuation, LevelUnits.dB_SPL, LevelUnits.dB_Vrms, LevelUnits.dB_SL, LevelUnits.pctDR);
            //else
            //    levelView.SetAllowableUnits(LevelUnits.dB_attenuation, LevelUnits.dB_SPL, LevelUnits.dB_Vrms, LevelUnits.dB_SL, LevelUnits.pctDR, LevelUnits.dB_SPL_noLDL);
        }

        private void SetContextDependentLevelReferences(Waveshape waveShape)
        {
            levelView.SetAllowableReferences(null);
        }

        private void waveformView_ValueChanged(object sender, EventArgs e)
        {
            if (_chan == null) return;

            bool activated = (_chan.waveform == null || _chan.waveform.Shape==Waveshape.None) && waveformView.Value != null;

            _chan.waveform = waveformView.Value;
            ShowChannel(_chan);

            OnValueChanged();
//            if (activated) OnWaveformBecameValid();
        }

        public event EventHandler WaveformBecameValid;
        protected virtual void OnWaveformBecameValid()
        {
            if (this.WaveformBecameValid != null) WaveformBecameValid(this, null);
        }

        private void modulationView_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                //_chan.modul = modulationView.Value;
                OnValueChanged();
            }
        }

        private void gateView_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents) OnValueChanged();
        }

        private void levelView_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents) OnValueChanged();
        }

        private void destinationDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                //_chan.Destination = (Laterality) destinationDropDown.Value;
                EnableBinauralProperties();
                OnValueChanged();
            }
        }

        private void EnableBinauralProperties()
        {
            //bool isDichotic = _chan.Destination == Laterality.Dichotic;
            //levelView.IsDichotic = isDichotic;
            //waveformView.IsDichotic = isDichotic;
        }

        private void levelView_BinauralChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _chan.binaural.MBL = levelView.MBL;
                _chan.binaural.ILD = levelView.ILD;
                OnValueChanged();
            }
        }

        private void waveformView_IPDChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _chan.binaural.IPD = waveformView.IPD;
                OnValueChanged();
            }
        }

        private void expertControl_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                OnValueChanged();
            }
        }
    }
}
