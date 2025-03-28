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
            modeDropDown.SelectedIndex = (int) _digitimer.PulseMode;
            polarityDropDown.SelectedIndex = (int)_digitimer.PulsePolarity;
            rateNumeric.Value = _digitimer.PulseRate_Hz;
            widthNumeric.IntValue = (int) _digitimer.Width;
            recoveryNumeric.IntValue = (int)_digitimer.Recovery;
            dwellNumeric.IntValue = (int)_digitimer.Dwell;
            demandNumeric.FloatValue = _digitimer.Demand;
            sourceDropDown.SelectedIndex = (int)_digitimer.Source;
            demandLabel.Visible = sourceDropDown.SelectedItem.Equals("Internal");
            demandNumeric.Visible = sourceDropDown.SelectedItem.Equals("Internal");

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

        private void modeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _digitimer.PulseMode = (float)modeDropDown.SelectedIndex;
                OnValueChanged();
            }
        }

        private void polarityDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _digitimer.PulsePolarity = (float)polarityDropDown.SelectedIndex;
                OnValueChanged();
            }
        }

        private void widthNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _digitimer.Width = (float)widthNumeric.IntValue;
                OnValueChanged();
            }
        }

        private void recoveryNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _digitimer.Recovery = (float)recoveryNumeric.IntValue;
                OnValueChanged();
            }
        }

        private void dwellNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _digitimer.Dwell = (float)dwellNumeric.IntValue;
                OnValueChanged();
            }
        }

        private void demandDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            _digitimer.Source = (Digitimer.DemandSource)sourceDropDown.SelectedIndex;

            bool showDemand = sourceDropDown.SelectedItem.Equals("Internal");
            demandLabel.Visible = showDemand;
            demandNumeric.Visible = showDemand;

            OnValueChanged();
        }

        private void demandNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            _digitimer.Demand = demandNumeric.FloatValue;
            OnValueChanged();
        }
    }
}
