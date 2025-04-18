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

namespace HTSController.Pages
{
    public partial class ProtocolControl : KUserControl
    {
        public ProtocolControl()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            OnStartProtocol(new ProtocolItem("hello"));
        }

        #region Events
        public class ProtocolItem : EventArgs
        {
            public string filePath;
            public ProtocolItem(string filePath) { this.filePath = filePath; }
        }

        public event EventHandler<ProtocolItem> StartProtocol;
        private void OnStartProtocol(ProtocolItem protocolItem) { StartProtocol?.Invoke(this, protocolItem); }
        #endregion

    }
}
