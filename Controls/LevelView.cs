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
    public partial class LevelView : KUserControl
    {
        private Level _level;
        private bool _usesReference = false;
        private bool _isDichotic = false;
        private float _mbl = 0;
        private float _ild = 0;

        public LevelView()
        {
            InitializeComponent();
        }

        public Level Value
        {
            get { return _level; }
            set
            {
                _level = value;
                ShowLevel(_level);
            }
        }

        public float MBL
        {
            get { return _mbl; }
            set
            {
                _mbl = value;

                _ignoreEvents = true;
                if (IsDichotic) levelNumeric.FloatValue = _mbl;
                _ignoreEvents = false;
            }
        }

        public float ILD
        {
            get { return _ild; }
            set
            {
                _ild = value;

                _ignoreEvents = true;
                ildNumeric.FloatValue = _ild;
                _ignoreEvents = false;
            }
        }

        public void SetAllowableUnits(params LevelUnits[] u)
        {
            List<LevelUnits> units = new List<LevelUnits>(u);

            unitsDropDown.FillSubset(units.ToArray());

            //if (units.FindIndex(o => o == LevelUnits.pctDR) >= 0)
            //    unitsDropDown.AddItem(LevelUnits.pctDR, "% DR");
        }

        public void SetAllowableReferences(params LevelReference[] r)
        {
            _usesReference = (r != null);

            if (r != null)
            {
                refDropDown.FillSubset(r);
            }
            _ignoreEvents = true;
            UpdateReference();
            _ignoreEvents = false;
        }

        public bool IsDichotic
        {
            get { return _isDichotic; }
            set
            {
                _isDichotic = value;
                mblLabel.Visible = _isDichotic;
                ildPanel.Visible = _isDichotic;
            }
        }

        public void ShowLevel(Level level)
        {
            if (level == null) return;

            _ignoreEvents = true;

            levelNumeric.Value = level.Value;
            unitsDropDown.SetEnumValue(level.Units);
            maxTextBox.Visible = level.Units != LevelUnits.dB_attenuation;
            UpdateReference();

            _ignoreEvents = false;
        }

        public void SetMaxLevel(double value)
        {
            maxTextBox.Text = "max = " + (double.IsNaN(value) ? "???" : value.ToString("F1"));
        }

        private void unitsDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _level.Units = (LevelUnits)unitsDropDown.Value;
                maxTextBox.Visible = _level.Units != LevelUnits.dB_attenuation;
                UpdateReference();
                OnValueChanged();
            }
        }

        private void UpdateReference()
        {
            if (_level!=null && _usesReference && _level.Units != LevelUnits.dB_attenuation)
            {
                refDropDown.Visible = true;
                refDropDown.SetEnumValue(_level.Reference);
            }
            else
            { 
                refDropDown.Visible = false;
            }
        }

        private void levelNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _level.Value = levelNumeric.FloatValue;
                if (IsDichotic)
                {
                    _mbl = _level.Value;
                    OnBinauralChanged();
                }


                OnValueChanged();
            }
        }

        private void refDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _level.Reference = (LevelReference)refDropDown.Value;
                OnValueChanged();
            }
        }

        private void ildNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _ild = ildNumeric.FloatValue;
                OnBinauralChanged();
            }
        }

        public event EventHandler BinauralChanged;
        protected virtual void OnBinauralChanged()
        {
            if (this.BinauralChanged != null)
            {
                BinauralChanged(this, null);
            }
        }
    }
}
