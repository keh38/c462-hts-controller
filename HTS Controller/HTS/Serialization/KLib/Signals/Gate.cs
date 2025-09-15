using System;
using System.Collections.Generic;
using System.ComponentModel;

using OrderedPropertyGrid;

namespace KLib.Signals
{
    [TypeConverter(typeof(GateConverter))]
    public class Gate
    {
        public bool Active { set; get; }

        [DisplayName("Delay")]
        [Description("Delay in milliseconds")]
        [PropertyOrder(0)]
        public float Delay_ms { set; get; }

        [DisplayName("Width")]
        [Description("Gate width in milliseconds")]
        [PropertyOrder(1)]
        public float Width_ms { set; get; }

        [DisplayName("Ramp")]
        [Description("Rise/fall time in milliseconds")]
        [PropertyOrder(2)]
        public float Ramp_ms { set; get; }

        [Description("Enable bursting")]
        [PropertyOrder(3)]
        public bool Bursted { set; get; }

        [DisplayName("Burst Duration")]
        [Description("Burst duration in milliseconds")]
        [PropertyOrder(4)]
        public float BurstDuration_ms { set; get; }

        [DisplayName("Num pulses")]
        [Description("Number of pulses per burst")]
        [PropertyOrder(5)]
        public int NumPulses { set; get; }

        [DisplayName("Duration")]
        [Description("Total duration in milliseconds. Zero makes it a one-shot.")]
        [PropertyOrder(6)]
        public float Period_ms { set; get; }

        public Gate()
        {
            Active = false;
            Delay_ms = 0;
            Width_ms = 50;
            Ramp_ms = 5;
            Period_ms = 1000;
            Bursted = false;
            NumPulses = 2;
            BurstDuration_ms = 500;
        }

        public override string ToString()
        {
            return "";
        }

        private bool ShouldSerializeActive() { return false; }
        private bool ShouldSerializeDelay_ms() { return false; }
        private bool ShouldSerializeWidth_ms() { return false; }
        private bool ShouldSerializeRamp_ms() { return false; }
        private bool ShouldSerializeBursted() { return false; }
        private bool ShouldSerializeNumPulses() { return false; }
        private bool ShouldSerializeBurstDuration_ms() { return false; }
        private bool ShouldSerializePeriod_ms() { return false; }

        public List<string> GetSweepableParams()
        {
            if (!Active) return new List<string>();

            return new List<string>()
            {
                "Gate.Delay_ms",
                "Gate.Width_ms",
                "Gate.Period_ms"
            };
        }

        public List<string> GetValidParameters()
        {
            List<string> p = new List<string>();

            if (Active)
            {
                p.Add("Gate.Delay_ms");
                p.Add("Gate.Width_ms");
                p.Add("Gate.Period_ms");
            }
            return p;
        }

    }
}
