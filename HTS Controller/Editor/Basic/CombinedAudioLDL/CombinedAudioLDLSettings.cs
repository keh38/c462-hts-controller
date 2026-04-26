using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

using KLib.TypeConverters;
using C462.Shared;

using BasicMeasurements;
using LDL.Haptics;

using OrderedPropertyGrid;

namespace CombinedAudioLDL
{
    [TypeConverter(typeof(SortableTypeConverter))]
    public class CombinedAudioLDLSettings : BasicMeasurementConfiguration
    {
        [Category("Appearance")]
        public string Title { get; set; }
        private bool ShouldSerializeTitle() { return false; }

        [Category("Appearance")]
        [Browsable(false)]
        public int PromptFontSize { get; set; }
        private bool ShouldSerializePromptFontSize() { return false; }

        [Category("Sequence")]
        [Description("Ears to test")]
        [DisplayName("Ears")]
        public Audiograms.TestEar TestEar { get; set; }
        private bool ShouldSerializeTestEar() { return false; }

        [Category("Sequence")]
        [Description("Test frequencies")]
        [DisplayName("Frequencies")]
        public float[] TestFrequencies { get; set; }
        private bool ShouldSerializeTestFrequencies() { return false; }

        [Category("Sequence")]
        [Description("Number of times to test each ear/frequency combo")]
        [DisplayName("Num repeats")]
        [Browsable(false)]
        public int NumRepeats { get; set; }
        private bool ShouldSerializeNumRepeats() { return false; }

        [Category("Bookkeeping")]
        [PropertyOrder(1)]
        public bool LogSliderTracks { set; get; }
        private bool ShouldSerializeLogSliderTracks() { return false; }

        [Category("Procedure")]
        [PropertyOrder(0)]
        public float MinExcursion { get; set; }
        private bool ShouldSerializeMinExcursion() { return false; }

        [Category("Procedure")]
        [PropertyOrder(1)]
        public int NumThresholdReversals { get; set; }
        private bool ShouldSerializeNumThresholdReversals() { return false; }

        [Category("Procedure")]
        [PropertyOrder(2)]
        public int NumLDLReversals { get; set; }
        private bool ShouldSerializeNumLDLReversals() { return false; }

        [Category("Contra noise")]
        [PropertyOrder(0)]
        [DisplayName("Active")]
        public bool ContraNoiseActive { set; get; }
        private bool ShouldSerializeContraNoiseActive() { return false; }

        [Category("Contra noise")]
        [PropertyOrder(1)]
        [DisplayName("Level")]
        public float ContraNoiseLevel { set; get; }
        private bool ShouldSerializeContraNoiseLevel() { return false; }

        [Category("Stimulus")]
        [PropertyOrder(0)]
        public float MinLevel { set; get; }
        private bool ShouldSerializeMinLevel() { return false; }

        [Category("Stimulus")]
        [Description("Bandwidth (octaves)")]
        [PropertyOrder(1)]
        public float Bandwidth { set; get; }
        private bool ShouldSerializeBandwidth() { return false; }

        [Category("Stimulus")]
        [Description("Duration of tone (ms)")]
        [PropertyOrder(2)]
        public float ToneDuration { set; get; }
        private bool ShouldSerializeToneDuration() { return false; }

        [Category("Stimulus")]
        [Description("Delay of tone (ms)")]
        [PropertyOrder(3)]
        public float ToneDelay { set; get; }
        private bool ShouldSerializeToneDelay() { return false; }

        [Category("Stimulus")]
        [Description("Pip interval (ms)")]
        [DisplayName("Pip interval")]
        [PropertyOrder(4)]
        public float ISI_ms { set; get; }
        private bool ShouldSerializeISI_ms() { return false; }

        [Category("Stimulus")]
        [Description("Ramp applied to tones (ms)")]
        [PropertyOrder(5)]
        public float Ramp { set; get; }
        private bool ShouldSerializeRamp() { return false; }

        [Category("Stimulus")]
        [Description("FM depth (percent)")]
        [DisplayName("FM depth")]
        [PropertyOrder(7)]
        public float ModDepth_pct { set; get; }
        private bool ShouldSerializeModDepth_pct() { return false; }

        public CombinedAudioLDLSettings() : base()
        {
            Title = "How loud does it sound?";

            TestEar = Audiograms.TestEar.Both;
            TestFrequencies = new float[] { 1000, 2000, 4000 };

            LogSliderTracks = false;

            MinLevel = 0f;
            Ramp = 5f;
            ToneDelay = 0;
            ToneDuration = 200;
            Bandwidth = 0;
            ISI_ms = 400;
            ModDepth_pct = 0;
            NumRepeats = 1;

            MinExcursion = 2.5f;
            NumThresholdReversals = 2;
            NumLDLReversals = 0;

            ContraNoiseActive = false;
            ContraNoiseLevel = 40f;

            PromptFontSize = 72;
        }
    }
}
