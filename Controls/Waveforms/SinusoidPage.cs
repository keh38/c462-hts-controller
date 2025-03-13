using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;
using KLib.Signals.Waveforms;

namespace KLib.Unity.Controls.Signals 
{
    public partial class SinusoidPage : KUserControl
    {
        private Sinusoid _sinusoid = null;
        private bool _isDichotic;
        private float _ipd;

        public SinusoidPage()
        {
            InitializeComponent();
        }

        public Waveform Value
        {
            get { return _sinusoid; }
            set
            {
                _sinusoid = value as Sinusoid;
                if (_sinusoid != null) Redisplay();
            }
        }

        public bool IsDichotic
        {
            get { return _isDichotic; }
            set
            {
                _isDichotic = value;

                ipdLabel.Visible = _isDichotic;
                ipdNumeric.Visible = _isDichotic;
            }
        }

        public float IPD
        {
            get { return _ipd; }
            set
            {
                _ipd = value;

                _ignoreEvents = true;
                ipdNumeric.FloatValue = _ipd;
                _ignoreEvents = false;
            }
        }

        private void Redisplay()
        {
            _ignoreEvents = true;
            freqNumeric.Value = _sinusoid.Frequency_Hz;
            phaseNumeric.Value = _sinusoid.Phase_cycles;
            _ignoreEvents = false;
        }

        private void freqNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _sinusoid.Frequency_Hz = freqNumeric.FloatValue;
                OnValueChanged();
            }
        }

        public event EventHandler IPDChanged;
        protected virtual void OnIPDChanged()
        {
            if (this.IPDChanged != null)
            {
                IPDChanged(this, null);
            }
        }

        private void ipdNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _ipd = ipdNumeric.FloatValue;
                OnIPDChanged();
            }
        }

        private void phaseNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _sinusoid.Phase_cycles = phaseNumeric.FloatValue;
                OnValueChanged();
            }
        }
    }
}
