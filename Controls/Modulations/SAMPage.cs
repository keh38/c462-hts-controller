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
using KLib.Signals.Enumerations;
using KLib.Signals.Modulations;

namespace KLib.Unity.Controls.Signals
{
    public partial class SAMPage : KUserControl
    {
        private SinusoidalAM _sam;

        public SAMPage()
        {
            InitializeComponent();
        }

        public AM Value
        {
            get { return _sam; }
            set
            {
                _sam = value as SinusoidalAM;
                Redisplay();
            }
        }

        private void Redisplay()
        {
            if (_sam == null) return;

            _ignoreEvents = true;

            freqNumeric.Value = _sam.Frequency_Hz;
            depthNumeric.Value = _sam.Depth;
            phaseNumeric.Value = _sam.Phase_cycles;

            _ignoreEvents = false;
        }

        private void freqNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _sam.Frequency_Hz = (sender as KNumericBox).FloatValue;
                OnValueChanged();
            }
        }

        private void depthNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _sam.Depth = (sender as KNumericBox).FloatValue;
                OnValueChanged();
            }
        }

        private void phaseNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _sam.Phase_cycles = (sender as KNumericBox).FloatValue;
                OnValueChanged();
            }
        }

    }
}
