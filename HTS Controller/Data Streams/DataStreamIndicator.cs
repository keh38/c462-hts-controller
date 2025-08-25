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
        public DataStream Stream { get; private set; }

        public event EventHandler RecordSelectionChanged;
        private void OnRecordSelectionChanged() { RecordSelectionChanged?.Invoke(this, null); }

        public DataStreamIndicator()
        {
            InitializeComponent();
        }

        public DataStreamIndicator(DataStream stream)
        {
            Stream = stream;
            InitializeComponent();

            _ignoreEvents = true;

            checkBox.Text = Stream.Name;
            checkBox.Checked = Stream.Record;
            statusLabel.Text = "";
            addressLabel.Text = "";

            pictureBox.Image = Image.FromFile(Path.Combine(DataStreamManager.ConfigFolder, stream.Icon));

            _ignoreEvents = false;
        }

        public void ConnectionStatusUpdated()
        {
            var newcolor = Stream.IsPresent ? StatusToColor(Stream.Status) : Color.LightGray;
            if (newcolor != BackColor)
            {
                Serilog.Log.Information($"{Stream.Name} changed to {Stream.Status}");
            }
            BackColor = newcolor;
            //BackColor = _stream.IsPresent ? StatusToColor(_stream.Status) : Color.LightGray;
            statusLabel.Text = Stream.LastActivity.ToLongTimeString();
            addressLabel.Text = Stream.IsPresent ? Stream.IPEndPoint.ToString() : "";
            statusLabel.Text = (Stream.IsPresent && Stream.Status != DataStream.StreamStatus.Idle) ? Stream.LastActivity.ToLongTimeString() : "";

            Refresh();
        }

        private Color StatusToColor(DataStream.StreamStatus status)
        {
            switch (status)
            {
                //case DataStream.StreamStatus.Idle:
                //    return SystemColors.Control;
                case DataStream.StreamStatus.Recording:
                    return Color.LightGreen;
                case DataStream.StreamStatus.Missed:
                    return Color.Orange;
                case DataStream.StreamStatus.Error:
                    return Color.Red;
            }
            return SystemColors.Control;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            Stream.Record = checkBox.Checked;
            OnRecordSelectionChanged();
        }
    }
}
