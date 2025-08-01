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

        public event EventHandler RecordSelectionChanged;
        private void OnRecordSelectionChanged() { RecordSelectionChanged?.Invoke(this, null); }

        public DataStreamIndicator()
        {
            InitializeComponent();
        }

        public DataStreamIndicator(DataStream stream)
        {
            _stream = stream;
            InitializeComponent();

            _ignoreEvents = true;

            checkBox.Text = _stream.Name;
            checkBox.Checked = _stream.Record;
            statusLabel.Text = "";
            addressLabel.Text = "";

            pictureBox.Image = Image.FromFile(Path.Combine(DataStreamManager.ConfigFolder, stream.Icon));

            _ignoreEvents = false;
        }

        public void ConnectionStatusUpdated()
        {
            var newcolor = _stream.IsPresent ? StatusToColor(_stream.Status) : Color.LightGray;
            if (newcolor != BackColor)
            {
                Serilog.Log.Information($"{_stream.Name} changed to {_stream.Status}");
            }
            BackColor = newcolor;
            //BackColor = _stream.IsPresent ? StatusToColor(_stream.Status) : Color.LightGray;
            statusLabel.Text = _stream.LastActivity.ToLongTimeString();
            addressLabel.Text = _stream.IsPresent ? _stream.IPEndPoint.ToString() : "";
            statusLabel.Text = (_stream.IsPresent && _stream.Status != DataStream.StreamStatus.Idle) ? _stream.LastActivity.ToLongTimeString() : "";

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

            _stream.Record = checkBox.Checked;
            OnRecordSelectionChanged();
        }
    }
}
