using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;
using ProtoBuf;

namespace Turandot.Cues
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    [XmlInclude(typeof(FixationPointAction))]
    [XmlInclude(typeof(ImageAction))]
    [XmlInclude(typeof(Message))]
    [XmlInclude(typeof(ProgressBarAction))]
    [XmlInclude(typeof(TextBoxAction))]
    [XmlInclude(typeof(VideoAction))]
    public class Cue
    {
        public int color = 0xFFFFFF;

        [Category("Action")]
        public bool BeginVisible { get; set; }

        [Category("Action")]
        public bool EndVisible { get; set; }

        [ReadOnly(true)]
        public string Target { get; set; }

        public int X = 0;
        public int Y = 0;

        public Cue() { }

        [XmlIgnore]
        [ProtoIgnore]
        [JsonIgnore]
        [Browsable(false)]
        virtual public string Name
        {
            get { return "LED"; }
        }

        [JsonIgnore]
        [Browsable(false)]
        public float A
        {
            get { return ((color & 0xFF000000) >> 24) / 255f; }
        }

        [JsonIgnore]
        [Browsable(false)]
        public float R
        {
            get { return ((color & 0xFF0000) >> 16) / 255f; }
        }

        [JsonIgnore]
        [Browsable(false)]
        public float G
        {
            get { return ((color & 0x00FF00) >> 8) / 255f; }
        }

        [JsonIgnore]
        [Browsable(false)]
        public float B
        {
            get { return (color & 0xFF) / 255f; }
        }

        [JsonIgnore]
        [Browsable(false)]
        virtual public bool IsSequenceable
        {
            get { return false; }
        }
    }
}
