using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HTSController.Data_Streams
{ 
    public class DataStream
    {
        public enum StreamStatus
        {
            Missed = -1,
            Idle = 0,
            Recording = 1,
            Error = 2
        }

        public string Name { get; set; }
        public string MulticastName { get; set; }
        public string Icon { get; set; }
        public bool Record { get; set; }

        [XmlIgnore]
        public IPEndPoint IPEndPoint { get; set; } = null;

        [XmlIgnore]
        public bool IsPresent { get { return IPEndPoint != null; } }

        [XmlIgnore]
        public DateTime LastActivity { get; set; }

        [XmlIgnore]
        public StreamStatus Status { set; get; } 

    }
}
