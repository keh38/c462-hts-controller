using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;
using Turandot.Inputs;

namespace HTSController
{
    public partial class PropertyControl : KUserControl
    {
        private ParameterSliderProperties _control;
        public string PropertyName { get; private set; }

        public delegate void PropertyValueChangedDelegate(string channel, string property, float value, bool selfChange);
        public PropertyValueChangedDelegate PropertyValueChanged;
        private void OnPropertyValueChanged(string channel, string property, float value, bool selfChange)
        {
            PropertyValueChanged?.Invoke(channel, property, value, selfChange);
        }

        public PropertyControl()
        {
            InitializeComponent();
        }
       
        public void SetValue(float value)
        {
            if (!float.IsNaN(value) && propertyNumeric.FloatValue != value)
            {
                propertyNumeric.FloatValue = value;
                OnPropertyValueChanged(_control.Channel, _control.Property, propertyNumeric.FloatValue, selfChange: false);
            }
        }

        public void LayoutControl(ParameterSliderProperties control)
        {
            if (_control==null || !control.Channel.Equals(_control.Channel) || !control.Property.Equals(_control.Property))
            {
                PropertyName = control.Property;
                _control = control;
                propertyLabel.Text = _control.Property;
                propertyNumeric.Value = _control.StartValue;
            }
        }

        private void propertyNumeric_ValueChanged(object sender, EventArgs e)
        {
            OnPropertyValueChanged(_control.Channel, _control.Property, propertyNumeric.FloatValue, selfChange: true);
        }
    }
}
