using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib;

namespace HTSController.Data_Streams
{
    public class DataStreamManager
    {
        private static readonly string ConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS", "DataStreams.xml");
        private List<DataStream> _streams;
        private List<DataStreamIndicator> _indicators;

        private HTSNetwork _network;
        private Timer _statusTimer;

        public DataStreamManager()
        {
            if (File.Exists(ConfigFile))
            {
                _streams = KFile.XmlDeserialize<List<DataStream>>(ConfigFile);
            }
            else
            {
                CreateDefaultStreams();
            }
        }

        public void Initialize(HTSNetwork network, FlowLayoutPanel flowLayout)
        {
            _network = network;
            _indicators = new List<DataStreamIndicator>();

            foreach (var s in _streams)
            {
                var indicator = CreateIndicator(s);
                flowLayout.Controls.Add(indicator);
                _indicators.Add(indicator);
            }

            _statusTimer = new Timer();
            _statusTimer.Interval = 5000;
            _statusTimer.Tick += statusTimer_Tick;
            _statusTimer.Start();
        }

        private DataStreamIndicator CreateIndicator(DataStream stream)
        {
            var indicator = new DataStreamIndicator(stream);
            indicator.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            return indicator;
        }

        private async void statusTimer_Tick(object sender, EventArgs e)
        {
            CheckConnections();
        }

        public void CheckConnections()
        {
            foreach (var s in _streams)
            {
                CheckStream(s);
            }

            foreach (var i in _indicators)
            {
                i.ConnectionStatusUpdated();
            }
        }

        private void CheckStream(DataStream stream)
        {
            stream.IsPresent = true;
            stream.IPEndPoint = new IPEndPoint(IPAddress.Parse("169.254.32.33"), 3456);
            stream.Status = DataStream.StreamStatus.OK;
            stream.LastActivity = DateTime.Now;
        }

        private void CreateDefaultStreams()
        {
            _streams = new List<DataStream>();
            _streams.Add(new DataStream()
            {
                Name = "Hearing Test Suite",
                MulticastName = "HEARING.TEST.SUITE.SYNC",
                Icon = "tablet"
            });
        }

    }
}
