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
    public partial class NoisePage : KUserControl
    {
        private Noise _noise;

        public NoisePage()
        {
            InitializeComponent();
        }

        public Waveform Value
        {
            get { return _noise; }
            set
            {
                _noise = value as Noise;
                ShowNoise(_noise);
            }
        }


        private void ShowNoise(Noise n)
        {
            if (n == null) return;

            _ignoreEvents = true;

            seedNumeric.IntValue = n.seed;
            filterSpecView.Value = _noise.filter;

            _ignoreEvents = false;
        }

        private void filterSpecView_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _noise.filter = filterSpecView.Value;
                OnValueChanged();
            }
        }

        private void seedNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _noise.seed = seedNumeric.IntValue;
                OnValueChanged();
            }
        }
    }
}
