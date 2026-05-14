using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTSController.Data_Streams
{
    public class DataStreamConfig
    {
        public float StartTimeout { get; set; }
        public float EndTimeout { get; set; }
        public List<DataStream> DataStreams { get; set; }

        public DataStreamConfig()
        {
            StartTimeout = 10.0f;
            EndTimeout = 20.0f;
            DataStreams = new List<DataStream>();
        }
    }
}
