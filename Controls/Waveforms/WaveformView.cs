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
using KLib.Signals.Waveforms;

namespace KLib.Unity.Controls.Signals
{
    public partial class WaveformView : KUserControl
    {
        Waveform _wf = null;
        private bool _isDichotic = false;
        private float _ipd = 0;

        public WaveformView()
        {
            InitializeComponent();

            _ignoreEvents = true;

            wfDropDown.FillSubset(Waveshape.Sinusoid, Waveshape.Noise, Waveshape.File, Waveshape.FM, Waveshape.Digitimer);
            wfDropDown.SetEnumValue(Waveshape.Noise);
            ActivateWaveformControl(Waveshape.Noise);

            _ignoreEvents = false;
        }

        public string WavFolder
        {
            get { return userFilePage.DefaultFolder; }
            set { userFilePage.DefaultFolder = value; }
        }

        public bool IsDichotic
        {
            get { return _isDichotic; }
            set
            {
                _isDichotic = value;
                sinePage.IsDichotic = value;
            }
        }

        public float IPD
        {
            get { return _ipd; }
            set
            {
                _ipd = value;

                _ignoreEvents = true;
                sinePage.IPD = _ipd;
                _ignoreEvents = false;
            }
        }

        public Waveform Value
        {
            get { return _wf; }
            set
            {
                _wf = value;
                if (_wf != null)
                {
                    wfDropDown.SetEnumValue(_wf.Shape);
                    ShowWaveform(_wf);
                    ActivateWaveformControl(_wf.Shape);
                }
                else wfDropDown.SelectedIndex = -1;
            }
        }

        private void ShowWaveform(Waveform wf)
        {
            if (wf == null) return;

            switch (wf.Shape)
            {
                case Waveshape.File:
                    userFilePage.Value = wf;
                    break;
                case Waveshape.Noise:
                    noisePage.Value = wf;
                    break;
                case Waveshape.Sinusoid:
                    sinePage.Value = wf;
                    break;
                case Waveshape.FM:
                    fmPage.Value = wf;
                    break;
                case Waveshape.Digitimer:
                    digitimerPage.Value = wf;
                    break;
            }
        }

        private void ActivateWaveformControl(Waveshape shape)
        {
            noisePage.Visible = shape == Waveshape.Noise;
            sinePage.Visible = shape == Waveshape.Sinusoid;
            userFilePage.Visible = shape == Waveshape.File;
            fmPage.Visible = shape == Waveshape.FM;
            digitimerPage.Visible = shape == Waveshape.Digitimer;
        }

        private void wfDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            _wf = CreateNewWaveform((Waveshape)wfDropDown.Value);
            ShowWaveform(_wf);
            ActivateWaveformControl((Waveshape)wfDropDown.Value);
            OnValueChanged();
        }

        private Waveform CreateNewWaveform(Waveshape shape)
        {
            Waveform wf = WaveformFactory.Create(shape);

            return wf;
        }

        private void sinePage_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void noisePage_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void userFilePage_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void fmPage_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void digitimerPage_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        public event EventHandler IPDChanged;
        protected virtual void OnIPDChanged()
        {
            if (this.IPDChanged != null)
            {
                IPDChanged(this, null);
            }
        }

        private void sinePage_IPDChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _ipd = sinePage.IPD;
                OnIPDChanged();
            }
        }

    }
}
