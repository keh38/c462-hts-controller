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
using KLib.Signals;

namespace KLib.Unity.Controls.Signals
{
    public partial class GateView : KUserControl
    {
        private Gate _gate;

        public GateView()
        {
            InitializeComponent();
        }

        public Gate Value
        {
            get { return _gate; }
            set
            {
                _gate = value;
                ShowGate(_gate);
            }
        }

        private void ShowGate(Gate g)
        {
            if (g == null) return;

            _ignoreEvents = true;

            activeComboBox.SelectedIndex = g.Active ? 1 : 0;
            delayNumeric.FloatValue = g.Delay_ms;
            rampNumeric.FloatValue = g.Ramp_ms;
            durationNumeric.FloatValue = g.Duration_ms;
            intervalNumeric.FloatValue = g.Period_ms;

            burstCheckbox.Checked = g.Bursted;
            burstNumNumeric.IntValue = g.NumPulses;
            burstDurNumeric.FloatValue = g.BurstDuration_ms;

            ShowContextDependentNumerics(g.Active);

            _ignoreEvents = false;
        }

        void ShowContextDependentNumerics(bool show)
        {
            rampNumeric.Visible = show;
            rampLabel.Visible = show;
            durationNumeric.Visible = show;
            durationLabel.Visible = show;
            intervalNumeric.Visible = show;
            intervalLabel.Visible = show;
            burstCheckbox.Visible = show;
            burstPanel.Visible = show && burstCheckbox.Checked;
        }

        private void delayNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.Delay_ms = delayNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void rampNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.Ramp_ms = rampNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void durationNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.Duration_ms = durationNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void intervalNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.Period_ms = intervalNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void activeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.Active = activeComboBox.SelectedIndex == 1;
                ShowContextDependentNumerics(_gate.Active);
                OnValueChanged();
            }
        }

        private void burstCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.Bursted = burstCheckbox.Checked;
                burstPanel.Visible = burstCheckbox.Checked;
                OnValueChanged();
            }
        }

        private void burstDurNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.BurstDuration_ms = burstDurNumeric.FloatValue;
                OnValueChanged();
            }
        }

        private void burstNumNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _gate.NumPulses = burstNumNumeric.IntValue;
                OnValueChanged();
            }
        }
    }
}
