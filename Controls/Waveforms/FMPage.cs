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

namespace KLib.Unity.Controls.Signals.Waveforms
{
    public partial class FMPage : KUserControl
    {
        private FM _value = null;

        public FMPage()
        {
            InitializeComponent();
        }

        public Waveform Value
        {
            get { return _value; }
            set
            {
                _value = value as FM;
                if (_value != null) Redisplay();
            }
        }

        private void Redisplay()
        {
            _ignoreEvents = true;
            carrierNumeric.Value = _value.Carrier_Hz;
            modFreqNumeric.Value = _value.ModFreq_Hz;
            depthNumeric.Value = _value.Depth_Hz;
            phaseNumeric.Value = _value.Phase_cycles;
            _ignoreEvents = false;
        }

        private void carrierNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _value.Carrier_Hz = carrierNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void modFreqNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _value.ModFreq_Hz = modFreqNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void depthNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _value.Depth_Hz = depthNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void phaseNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _value.Phase_cycles = phaseNumeric.FloatValue;
                OnValueChanged();
            }
        }
    }
}
