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
using KLib.Signals.Waveforms;
using KLib.Signals.Enumerations;

namespace KLib.Unity.Controls.Signals
{
    public partial class ChannelView : KUserControl
    {
        private Channel _chan;
        private bool _allowExpert = false;

        public AdapterMap AdapterMap { set; get; }

        public ChannelView()
        {
            InitializeComponent();

            modalityDropDown.Fill<Modality>();
            destinationDropDown.Fill<Laterality>();
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

        public void UpdateParameters()
        {
            ShowChannel(Value);
        }

        private void ShowChannel(Channel ch)
        {
            _ignoreEvents = true;
            DrawingControl.SuspendDrawing(this);

            if (ch == null || ch.waveform==null)
            {
                modalityDropDown.SetEnumValue(Modality.Unspecified);
                destinationDropDown.SetEnumValue(Laterality.Diotic);
                destPanel.Enabled = false;
                waveformView.Value = null;
                waveformView.Enabled = false;

                ShowModGateLevel(false);
            }
            else if (ch.waveform.Shape == Waveshape.None)
            {
                modalityDropDown.SetEnumValue(ch.Modality);
                ShowModalitySpecific();
                destPanel.Enabled = true;

                waveformView.Value = ch.waveform;
                waveformView.Enabled = true;

                ShowModGateLevel(false);
            }
            else
            {
                modalityDropDown.SetEnumValue(ch.Modality);
                ShowModalitySpecific();
                destPanel.Enabled = true;

                waveformView.Enabled = true;
                waveformView.Value = ch.waveform;

                modulationView.Value = ch.modulation;
                gateView.Value = ch.gate;

                SetContextDependentLevelUnits(ch.Modality);
                levelView.Value = ch.level;
                //levelView.SetMaxLevel(ch.GetMaxLevel());

                ShowModGateLevel(true);
                EnableBinauralProperties();
                levelView.ILD = ch.binaural.ILD;
                waveformView.IPD = ch.binaural.IPD;
            }
            if (ch != null && ch.waveform.Shape == Waveshape.Digitimer)
            {
                var showLevel = (ch.waveform as Digitimer).Source == Digitimer.DemandSource.External;
                levelView.Visible = showLevel;
                modSep.Visible = showLevel;
            }

            DrawingControl.ResumeDrawing(this);
            _ignoreEvents = false;
        }

        private void ShowModalitySpecific()
        {
            switch (_chan.Modality)
            {
                case Modality.Audio:
                    destPanel.Visible = true;
                    locationPanel.Visible = false;
                    destinationDropDown.Fill<Laterality>();
                    destinationDropDown.SetEnumValue(_chan.Laterality);
                    break;
                case Modality.Haptic:
                case Modality.Electric:
                    destPanel.Visible = false;
                    locationPanel.Visible = true;
                    var items = AdapterMap.GetLocations(_chan.Modality.ToString());
                    locationDropDown.Items.Clear();
                    locationDropDown.Items.AddRange(items.ToArray());
                    locationDropDown.SelectedIndex = items.IndexOf(_chan.Location);
                    break;
                default:
                    destPanel.Visible = false;
                    locationPanel.Visible = false;
                    break;
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
        }

        private void SetContextDependentLevelUnits(Modality modality)
        {
            if (modality == Modality.Audio)
            {
                levelView.SetAllowableUnits(LevelUnits.dB_attenuation, LevelUnits.dB_SPL, LevelUnits.dB_Vrms, LevelUnits.dB_SL);
            }
            else if (modality == Modality.Haptic)
            {
                levelView.SetAllowableUnits(LevelUnits.Volts, LevelUnits.dB_Vrms, LevelUnits.dB_attenuation);
            }
            else if (modality == Modality.Electric)
            {
                levelView.SetAllowableUnits(LevelUnits.Volts, LevelUnits.mA);
            }
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
                _chan.modulation = modulationView.Value;
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
                _chan.Laterality = (Laterality) destinationDropDown.Value;
                EnableBinauralProperties();
                OnValueChanged();
            }
        }

        private void EnableBinauralProperties()
        {
            bool isDichotic = _chan.Modality == Modality.Audio && _chan.Laterality == Laterality.Diotic;
            levelView.IsDichotic = isDichotic;
            waveformView.IsDichotic = isDichotic;
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

        private void locationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _chan.Location = locationDropDown.Text;
                OnValueChanged();
            }
        }

        private void modalityDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _ignoreEvents = true;

                _chan.Modality = (Modality)modalityDropDown.Value;

                ShowModalitySpecific();
                SetContextDependentLevelUnits(_chan.Modality);

                _ignoreEvents = false;
            }
        }
    }
}
