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
        public enum StreamStatus { OK, Missed, Error}

        public string Name { get; set; }
        public string MulticastName { get; set; }
        public string Icon { get; set; }
        public bool Record { get; set; }

        [XmlIgnore]
        public bool IsPresent { get; set; }

        [XmlIgnore]
        public IPEndPoint IPEndPoint { get; set; }

        [XmlIgnore]
        public DateTime LastActivity { get; set; }

        [XmlIgnore]
        public StreamStatus Status { set; get; } 

    }
}
