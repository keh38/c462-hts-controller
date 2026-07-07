using Audiograms;
using BasicMeasurements;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using OrderedPropertyGrid;
using KLib.Signals;
using KLib.Signals.Editor;
using KLib.TypeConverters;

namespace Tapping
{
    [TypeConverter(typeof(SortableTypeConverter))]
    public class TappingConfiguration : BasicMeasurementConfiguration
    {
        [Category("Appearance")]
        public string Title { get; set; }
        private bool ShouldSerializeTitle() { return false; }

        [Browsable(false)]
        public TestEar TestEar { get; set; }

        [Category("Target")]
        [PropertyOrder(0)]
        [TypeConverter(typeof(ChannelConverter))]
        public Channel Channel { get; set; }
        private bool ShouldSerializeChannel() { return false; }

        [Category("Target")]
        [PropertyOrder(1)]
        [DisplayName("Min ISI (ms)")]   
        public float MinISI { get; set; }
        private bool ShouldSerializeMinISI() { return false; }

        [Category("Target")]
        [PropertyOrder(2)]
        public int PatternLength { get; set; }
        private bool ShouldSerializePatternLength() { return false; }

        [Category("Target")]
        [PropertyOrder(3)]
        public int NumRepeats { get; set; }
        private bool ShouldSerializeNumRepeats() { return false; }

        [Category("Target")]
        [PropertyOrder(4)]
        public string IntervalExpression { get; set; }
        private bool ShouldSerializeIntervalExpression() { return false; }

        public TappingConfiguration() : base()
        {
            Title = "Tapping";

            TestEar = Audiograms.TestEar.Both;

            Channel = new Channel();
            MinISI = 500f;
            PatternLength = 5;
            IntervalExpression = "[1 2]";
            NumRepeats = 5;
        }

    }
}
