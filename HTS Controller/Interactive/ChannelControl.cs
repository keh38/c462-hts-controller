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
    public partial class ChannelControl : KUserControl
    {
        private string _channelName;

        public delegate void ChannelActiveChangedDelegate(string channel, bool active);
        public ChannelActiveChangedDelegate ChannelActiveChanged;

        public Panel LED => ledPanel;

        private void OnChannelActiveChanged(string channel, bool active)
        {
            ChannelActiveChanged?.Invoke(channel, active);
        }
        public ChannelControl()
        {
            InitializeComponent();
        }

        public void LayoutControls(string name, List<InteractiveControl> controls, PropertyControl.PropertyValueChangedDelegate callback)
        {
            _channelName = name;
            enableCheckBox.Text = name;

            for (int k=0; k < controls.Count; k++)
            {
                if (k >= flowLayoutPanel.Controls.Count - 1)
                {
                    flowLayoutPanel.Controls.Add(new PropertyControl() { PropertyValueChanged = callback });
                }
                (flowLayoutPanel.Controls[k+1] as PropertyControl).LayoutControl(controls[k]);
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
                OnChannelActiveChanged(_channelName, enableCheckBox.Checked);
            }
        }
    }
}
