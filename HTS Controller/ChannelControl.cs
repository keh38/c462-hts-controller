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
        public ChannelControl()
        {
            InitializeComponent();
        }

        public void LayoutControls(string name, List<InteractiveControl> controls, PropertyControl.PropertyValueChangedDelegate callback)
        {
            channelLabel.Text = name;

            for (int k=0; k < controls.Count; k++)
            {
                if (k >= flowLayoutPanel.Controls.Count - 1)
                {
                    flowLayoutPanel.Controls.Add(new PropertyControl() { PropertyValueChanged = callback });
                }
                (flowLayoutPanel.Controls[k+1] as PropertyControl).LayoutControl(controls[k]);
            }

        }

    }
}
