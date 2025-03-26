using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;

namespace HTSController.Data_Streams
{
    public partial class DataStreamIndicator : KUserControl
    {
        private DataStream _stream;

        public DataStreamIndicator()
        {
            InitializeComponent();
        }

        public DataStreamIndicator(DataStream stream)
        {
            _stream = stream;
            InitializeComponent();

            checkBox.Text = _stream.Name;
            checkBox.Checked = _stream.Record;
            statusLabel.Text = "";
            addressLabel.Text = "";

            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS");

            pictureBox.Image = Image.FromFile(Path.Combine(folder, "tablet.png"));
        }

        public void ConnectionStatusUpdated()
        {
            BackColor = StatusToColor(_stream.Status);
            statusLabel.Text = _stream.LastActivity.ToLongTimeString();
            addressLabel.Text = _stream.IPEndPoint.ToString();
        }

        private Color StatusToColor(DataStream.StreamStatus status)
        {
            return SystemColors.Control;
            //return Color.LightGreen;
        }
    }
}
