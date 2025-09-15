using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace KLib.Signals
{
    [XmlInclude(typeof(Noise))]
    [XmlInclude(typeof(Sinusoid))]
    [TypeConverter(typeof(WaveformConverter))]
    public class Waveform
    {
        protected Waveshape shape;

        [Browsable(false)]
        [XmlIgnore]
        public Waveshape Shape { get; protected set; }

        [Browsable(false)]
        [XmlIgnore]
        public string ShortName { get; protected set; }

        [Browsable(false)]
        [XmlIgnore]
        public bool HandlesModulation { get; set; } 

        public Waveform()
        {
            ShortName = "None";
            shape = Waveshape.None;
            HandlesModulation = false;
        }

        virtual public List<string> GetSweepableParams()
        {
            return new List<string>();
        }

        virtual public List<string> GetValidParameters()
        {
            return new List<string>();
        }

    }
}