﻿using System;
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
    public partial class ChannelControl : KUserControl
    {
        public string ChannelName { get; private set; }

        public delegate void ChannelActiveChangedDelegate(string channel, bool active);
        public ChannelActiveChangedDelegate ChannelActiveChanged;

        public Panel LED => ledPanel;

        private List<PropertyControl> _propertyControls;

        private void OnChannelActiveChanged(string channel, bool active)
        {
            ChannelActiveChanged?.Invoke(channel, active);
        }
        public ChannelControl()
        {
            InitializeComponent();
        }

        public PropertyControl GetPropertyControl(string name)
        {
            return _propertyControls.Find(x => x.PropertyName.Equals(name));
        }

        public void LayoutControls(string name, List<InteractiveControl> controls, PropertyControl.PropertyValueChangedDelegate callback)
        {
            ChannelName = name;
            enableCheckBox.Text = name;

            _propertyControls = new List<PropertyControl>();

            for (int k=0; k < controls.Count; k++)
            {
                if (k >= flowLayoutPanel.Controls.Count - 1)
                {
                    var pc = new PropertyControl() { PropertyValueChanged = callback };
                    flowLayoutPanel.Controls.Add(pc);
                    _propertyControls.Add(pc);
                }
                _propertyControls[k].LayoutControl(controls[k]);
            }

            int nremove = flowLayoutPanel.Controls.Count - controls.Count - 1;
            for (int k=0; k<nremove; k++)
            {
                flowLayoutPanel.Controls.RemoveAt(controls.Count+1);
            }
        }

        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                OnChannelActiveChanged(ChannelName, enableCheckBox.Checked);
            }
        }
    }
}
