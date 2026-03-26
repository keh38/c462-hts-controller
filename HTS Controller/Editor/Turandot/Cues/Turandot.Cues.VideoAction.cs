using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Cues
{
    [JsonObject(MemberSerialization.OptOut)]
    public class VideoAction : Cue
    {
        [Category("Content")]
        public string Filename { get; set; }

        public VideoAction()
        {
        }

        [XmlIgnore]
        [JsonIgnore]
        override public string Name
        {
            get { return "Video"; }
        }

        [JsonIgnore]
        override public bool IsSequenceable
        {
            get { return BeginVisible || EndVisible; }
        }
    }
}
