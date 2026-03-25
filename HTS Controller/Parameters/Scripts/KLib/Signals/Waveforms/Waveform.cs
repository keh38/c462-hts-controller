using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;
using ProtoBuf;

namespace KLib.Signals.Waveforms
{
    /// <summary>
    /// Waveform base class.
    /// </summary>
    [System.Serializable]
    [ProtoContract]
    [XmlInclude(typeof(MovingRippleNoise))]
    [ProtoInclude(500, typeof(MovingRippleNoise))]
    [XmlInclude(typeof(FM))]
    [ProtoInclude(501, typeof(FM))]
    [XmlInclude(typeof(Noise))]
    [ProtoInclude(502, typeof(Noise))]
    [XmlInclude(typeof(Sinusoid))]
    [ProtoInclude(504, typeof(Sinusoid))]
    [XmlInclude(typeof(ToneCloud))]
    [ProtoInclude(506, typeof(ToneCloud))]
    [XmlInclude(typeof(UserFile))]
    [ProtoInclude(507, typeof(UserFile))]
    [XmlInclude(typeof(RippleNoise))]
    [ProtoInclude(508, typeof(RippleNoise))]
    [XmlInclude(typeof(Digitimer))]
    [ProtoInclude(509, typeof(Digitimer))]
    [JsonObject(MemberSerialization.OptIn)]
    public class Waveform
    {
        [ProtoMember(1, IsRequired = true)]
        [JsonProperty]
        protected Waveshape shape;

        [Browsable(false)]
        public Waveshape Shape
        {
            get { return shape; }
        }

        protected string _shortName = "None";
        [Browsable(false)]
        public string ShortName
        {
            get { return _shortName; }
        }

        [Browsable(false)]
        public string LongName
        {
            get { return shape.ToString().Replace('_', ' '); }
        }

        [Browsable(false)]
        public bool HandlesModulation { get; set; } = false;

        protected float samplingRate_Hz;
        protected float dt;
        protected int Npts;
        protected float T;

        [XmlIgnore]
        protected Channel _channel;
        protected CalibrationData _calib;

        protected string _name;

        [ProtoIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public string ChannelName
        {
            get { return _name; }
            set { _name = value; }
        }

        public Waveform()
        {
            shape = Waveshape.None;
        }
    }
}
