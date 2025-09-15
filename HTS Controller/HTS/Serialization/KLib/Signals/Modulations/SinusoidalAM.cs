using System;
using System.Collections.Generic;
using System.ComponentModel;
using OrderedPropertyGrid;

namespace KLib.Signals
{
	public class SinusoidalAM : AM
    {
        [DisplayName("Rate")]
        [Description("Modulation rate in Hz")]
        [PropertyOrder(0)]
        public float Frequency_Hz {  get; set; }

        [Description("Modulation depth (0-1)")]
        [PropertyOrder(1)]
        public float Depth {  get; set; }

        [DisplayName("Phase")]
        [Description("Phase in cycles (0-1). 0.75 starts at a minimum")]
        public float Phase_cycles { get; set; }

        public SinusoidalAM()
        {
            Shape = AMShape.Sinusoidal;
            Frequency_Hz = 40;
            Depth = 1;
            Phase_cycles = 0.75f;
        }

        private bool ShouldSerializeFrequency_Hz() { return false; }
        private bool ShouldSerializeDepth() { return false; }
        private bool ShouldSerializePhase_cycles() { return false; }

        public override List<string> GetSweepableParams()
        {
            return new List<string>()
            {
                "SAM.Freq_Hz",
                "SAM.Depth",
                "SAM.Phase"
            };
        }

        override public List<string> GetValidParameters()
        {
            List<string> p = new List<string>();

            p.Add("SAM.Freq_Hz");
            p.Add("SAM.Depth");
            p.Add("SAM.Depth_dB");
            p.Add("SAM.Phase");
            return p;
        }


    }
}
