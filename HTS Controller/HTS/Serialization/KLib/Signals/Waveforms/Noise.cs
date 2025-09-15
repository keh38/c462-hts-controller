using System;
using System.Collections.Generic;
using System.ComponentModel;

using OrderedPropertyGrid;

namespace KLib.Signals
{
    public class Noise : Waveform
    {
        [PropertyOrder(0)]
        [DisplayName("Seed")]
        [Description("Random number generator seed")]
        public int Seed { get; set; }

        public Noise()
        {
            ShortName = "Noise";
            Shape = Waveshape.Noise;
        }

        private bool ShouldSerializeSeed() { return false; }

        public override List<string> GetSweepableParams()
        {
            return new List<string>()
            {
                "CF"
            };
        }

        override public List<string> GetValidParameters()
        {
            List<string> plist = new List<string>();
            plist.Add("CF_Hz");
            plist.Add("BW");
            plist.Add("Shape");
            return plist;
        }

    }
}
