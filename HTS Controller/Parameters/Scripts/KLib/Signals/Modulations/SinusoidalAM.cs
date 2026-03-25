using System.ComponentModel;

using Newtonsoft.Json;
using ProtoBuf;

using OrderedPropertyGrid;
using KLib.TypeConverters;

namespace KLib.Signals.Modulations
{
    [System.Serializable]
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    public class SinusoidalAM : AM
    {
        [ProtoMember(1, IsRequired = true)]
        [PropertyOrder(0)]
        public float Frequency_Hz { get; set; }

        [ProtoMember(2, IsRequired = true)]
        [PropertyOrder(1)]
        public float Depth { get; set; }

        [ProtoMember(3, IsRequired = true)]
        [PropertyOrder(2)]
        public float Phase_cycles { get; set; }

        [ProtoIgnore]
        [Browsable(false)]
        public float CurrentPhase { get { return _phase; } }

        private float _phase;

        public SinusoidalAM() : this(40, 1)
        {
        }

        public SinusoidalAM(float frequency_Hz, float depth)
        {
            _shape = Enumerations.AMShape.Sinusoidal;
            _shortName = "SAM";

            this.Frequency_Hz = frequency_Hz;
            this.Depth = depth;
            Phase_cycles = 0.75f;
        }
    }
}
