using System.Security.Cryptography.Xml;
using System;

using OrderedPropertyGrid;
using System.ComponentModel;

namespace KLib.Signals
{
    public class Sinusoid : Waveform
    {
        [PropertyOrder(0)]
        [DisplayName("Frequency")]
        [Description("Frequency (Hz)")]
        public float Frequency_Hz {  get; set; }

        [PropertyOrder(1)]
        [DisplayName("Phase")]
        [Description("Phase (cycles)")]
        public float Phase_cycles { get; set; }

        public Sinusoid()
        {
            ShortName = "Tone";
            Shape = Waveshape.Sinusoid;
            Frequency_Hz = 500;
            Phase_cycles  = 0;
        }

        private bool ShouldSerializeFrequency_Hz() { return false; }
        private bool ShouldSerializePhase_cycles() { return false; }

        public override List<string> GetSweepableParams()
        {
            return new List<string>()
            {
                "Frequency_Hz",
                "Phase_cycles"
            };
        }

        override public List<string> GetValidParameters()
        {
            List<string> plist = new List<string>();
            plist.Add("Frequency_Hz");
            plist.Add("Phase_cycles");
            return plist;
        }


    }
}
