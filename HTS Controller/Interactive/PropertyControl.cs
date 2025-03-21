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
using Turandot.Interactive;

namespace HTSController
{
    public partial class PropertyControl : KUserControl
    {
        private InteractiveControl _control;

        public delegate void PropertyValueChangedDelegate(string channel, string property, float value);
        public PropertyValueChangedDelegate PropertyValueChanged;
        private void OnPropertyValueChanged(string channel, string property, float value)
        {
            PropertyValueChanged?.Invoke(channel, property, value);
        }

        public PropertyControl()
        {
            InitializeComponent();
        }

        public void LayoutControl(InteractiveControl control)
        {
            if (_control==null || !control.channel.Equals(_control.channel) || !control.property.Equals(_control.property))
            {
                _control = control;
                propertyLabel.Text = _control.property;
                propertyNumeric.Value = _control.value;
            }
        }

        private void propertyNumeric_ValueChanged(object sender, EventArgs e)
        {
            OnPropertyValueChanged(_control.channel, _control.property, propertyNumeric.FloatValue);
        }
    }
}
