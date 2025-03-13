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
    public partial class ChannelAdvancedControl : KUserControl
    {
        private Channel _value = null;

        public ChannelAdvancedControl()
        {
            InitializeComponent();
        }

        public Channel Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Show(_value);
            }
        }

        private void Show(Channel ch)
        {
            if (ch == null) return;

            _ignoreEvents = true;

            imCheckBox.Checked = !string.IsNullOrEmpty(ch.intramural);

            imTextBox.Text = ch.intramural;
            imTextBox.Visible = imCheckBox.Checked;

            _ignoreEvents = false;
        }

        private void imCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                imTextBox.Visible = imCheckBox.Checked;
            }
        }

        private void imTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                imTextBox.Text = _value.intramural;
                e.Handled = true;
            }
            else if (e.KeyChar == (char)13)
            {
                base.OnKeyPress(e);
                _value.intramural = imTextBox.Text;
                OnValueChanged();
            }
            else
            {
                base.OnKeyPress(e);
            }
        }

        private void imTextBox_Leave(object sender, EventArgs e)
        {
            _value.intramural = imTextBox.Text;
            OnValueChanged();
        }
    }
}
