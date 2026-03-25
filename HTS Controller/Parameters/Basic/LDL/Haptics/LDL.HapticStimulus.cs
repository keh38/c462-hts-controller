using System.Collections.Generic;
using System.ComponentModel;

using KLib.Signals.Modulations;
using KLib.Signals.Waveforms;

using Newtonsoft.Json;
using OrderedPropertyGrid;

namespace LDL.Haptics
{
    public enum HapticSource { NONE, Vibration, TENS }

    [TypeConverter(typeof(HapticStimulusConverter))]
    [JsonObject(MemberSerialization.OptOut)]
    public class HapticStimulus
    {
        [Browsable(false)]
        public HapticSource Source { get; set; }

        [PropertyOrder(0)]
        public bool SaveLDLGram { get; set; }

        [PropertyOrder(1)]
        public bool DoAudioOnly { get; set; }

        [PropertyOrder(2)]
        public Digitimer TENS { get; set; }

        [PropertyOrder(2)]
        public Sinusoid Vibration { get; set; }

        [PropertyOrder(3)]
        public string Location { get; set; }

        [PropertyOrder(4)]
        [Description("Amplitude in volts")]
        public float Level { get; set; }

        [PropertyOrder(5)]
        public float Delay_ms { get; set; }

        [PropertyOrder(6)]
        public float Duration_ms { get; set; }

        [PropertyOrder(7)]
        public AM Envelope { get; set; }

        [PropertyOrder(8)]
        [TypeConverter(typeof(HapticSeqVarCollectionConverter))]
        public List<HapticSeqVar> SeqVars { get; set; }

        public HapticStimulus()
        {
            SaveLDLGram = false;
            DoAudioOnly = true;
            Source = HapticSource.NONE;
            TENS = new Digitimer();
            Vibration = new Sinusoid()
            {
                Frequency_Hz = 175
            };
            Level = 1;
            Delay_ms = 0;
            Duration_ms = 200;
            Envelope = new AM();
            SeqVars = new List<HapticSeqVar>();
        }
    }
}
