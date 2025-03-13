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
using KLib.Signals.Enumerations;

namespace KLib.Unity.Controls.Signals
{
    public partial class FilterSpecView : KUserControl
    {
        private FilterSpec _filterSpec = new FilterSpec();

        public FilterSpecView()
        {
            InitializeComponent();

            shapeDropDown.Fill(typeof(FilterShape), null);
            bwMethodDropDown.Fill(typeof(BandwidthMethod), null);

            shapeDropDown.SelectedIndex = (int) FilterShape.Band_pass;
            bwMethodDropDown.SelectedIndex = 0;
        }

        public FilterSpec Value
        {
            get { return _filterSpec; }
            set
            {
                _filterSpec = value;
                Redisplay();
            }
        }

        private void Redisplay()
        {
            _ignoreEvents = true;

            shapeDropDown.SetEnumValue(_filterSpec.shape);
            bwMethodDropDown.SetEnumValue(_filterSpec.bandwidthMethod);

            ShapeDependendentDisplay();
            BWMethodDependentDisplay();

            _ignoreEvents = false;
        }

        private void shapeDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _filterSpec.shape = (FilterShape)shapeDropDown.Value;
                ShapeDependendentDisplay();
                BWMethodDependentDisplay();
                OnValueChanged();
            }
        }

        private void ShapeDependendentDisplay()
        {
            switch (_filterSpec.shape)
            {
                case FilterShape.None:
                    FminLabel.Visible = false;
                    FminNumeric.Visible = false;
                    FmaxLabel.Visible = false;
                    FmaxNumeric.Visible = false;
                    bwMethodDropDown.Visible = false;
                    break;
                case FilterShape.Band_pass:
                case FilterShape.Band_stop:
                    FminLabel.Visible = true;
                    FminNumeric.Visible = true;

                    FmaxLabel.Visible = true;
                    FmaxNumeric.Visible = true;
                    bwMethodDropDown.Visible = true;
                    break;

                case FilterShape.Low_pass:
                case FilterShape.High_pass:
                    FminLabel.Visible = true;
                    FminLabel.Text = "Fcorner (Hz)";
                    FminNumeric.Visible = true;
                    FminNumeric.Value = _filterSpec.CF;

                    FmaxLabel.Visible = false;
                    FmaxNumeric.Visible = false;
                    bwMethodDropDown.Visible = false;
                    break;
            }

            brickwallCheckbox.Visible = _filterSpec.shape != FilterShape.None;
            brickwallCheckbox.Checked = _filterSpec.brickwall;
        }

        private void BWMethodDependentDisplay()
        {
            if (_filterSpec.shape != FilterShape.Band_pass && _filterSpec.shape != FilterShape.Band_stop)
            {
                return;
            }

            if (_filterSpec.bandwidthMethod == BandwidthMethod.Edges)
            {
                FminLabel.Text = "Fmin (Hz)";
                FminNumeric.Value = _filterSpec.Fmin;
                FmaxLabel.Text = "Fmax (Hz)";
                FmaxNumeric.Value = _filterSpec.Fmax;
            }
            else
            {
                FminLabel.Text = "Fcenter (Hz)";
                FminNumeric.Value = _filterSpec.CF;
                FmaxLabel.Text = "Bandwidth";
                FmaxNumeric.Value = _filterSpec.BW;
            }
        }

        private void bwMethodDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _filterSpec.ChangeBandwidthMethod((BandwidthMethod)bwMethodDropDown.Value);
                BWMethodDependentDisplay();
                OnValueChanged();
            }
        }

        private void FminNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                if (_filterSpec.shape == FilterShape.Band_pass || _filterSpec.shape == FilterShape.Band_stop)
                {
                    _filterSpec.Set(_filterSpec.bandwidthMethod, FminNumeric.FloatValue, FmaxNumeric.FloatValue);
                }
                else
                {
                    _filterSpec.CF = FminNumeric.FloatValue;
                }
                OnValueChanged();
            }
        }

        private void brickwallCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _filterSpec.brickwall = brickwallCheckbox.Checked;
                OnValueChanged();
            }
        }
    }
}
