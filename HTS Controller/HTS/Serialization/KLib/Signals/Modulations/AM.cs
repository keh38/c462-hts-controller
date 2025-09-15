using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

using OrderedPropertyGrid;

namespace KLib.Signals
{
    [XmlInclude(typeof(SinusoidalAM))]
    [TypeConverter(typeof(AMConverter))]
    public class AM
    {
        [DisplayName("Correct level")]
        [Description("Increase stimulus amplitude to compensate for loss of power imposed by modulation")]
        [PropertyOrder(100)]
        public bool ApplyLevelCorrection { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public AMShape Shape { get; protected set; }

        public AM()
        {
            Shape = AMShape.None;
            ApplyLevelCorrection = true;
        }

        private bool ShouldSerializeApplyLevelCorrection() { return false; }

        public virtual List<string> GetSweepableParams()
        {
            return new List<string>();
        }

        virtual public List<string> GetValidParameters()
        {
            List<string> p = new List<string>();
            return p;
        }


    }
}
