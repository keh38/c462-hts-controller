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
    public partial class DigitimerPage : KUserControl
    {
        private Digitimer _digitimer = null;

        public DigitimerPage()
        {
            InitializeComponent();
        }

        public Waveform Value
        {
            get { return _digitimer; }
            set
            {
                _digitimer = value as Digitimer;
                if (_digitimer != null) Redisplay();
            }
        }

        private void Redisplay()
        {
            _ignoreEvents = true;
            rateNumeric.Value = _digitimer.PulseRate_Hz;
            _ignoreEvents = false;
        }

        private void rateNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _digitimer.PulseRate_Hz = rateNumeric.FloatValue;
                OnValueChanged();
            }
        }

    }
}
