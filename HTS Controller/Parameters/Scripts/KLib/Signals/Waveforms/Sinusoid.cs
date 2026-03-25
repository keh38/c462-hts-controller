using System;
using System.ComponentModel;

using Newtonsoft.Json;
using ProtoBuf;

namespace KLib.Signals.Waveforms
{
    [Serializable]
    [ProtoContract]
    [JsonObject(MemberSerialization.OptIn)]
    [TypeConverter(typeof(SinusoidConverter))]
    public class Sinusoid : Waveform
    {
        [ProtoMember(1, IsRequired = true)]
        [JsonProperty]
        public float Frequency_Hz;

        [ProtoMember(2, IsRequired = true)]
        [JsonProperty]
        [DisplayName("Phase")]
        [Description("Phase in cycles")]
        public float Phase_cycles { get; set; }

        public Sinusoid()
        {
            Frequency_Hz = 500;
            Phase_cycles = 0;
            shape = Waveshape.Sinusoid;
            _shortName = "Tone";
        }
    }
}
