using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;
using ProtoBuf;

namespace Turandot.Cues
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    public class VideoAction : Cue
    {
        [Category("Content")]
        public string Filename { get; set; }

        public VideoAction()
        {
        }

        [XmlIgnore]
        [ProtoIgnore]
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
