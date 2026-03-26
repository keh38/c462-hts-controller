using System.ComponentModel;

using OrderedPropertyGrid;

using BasicMeasurements;
using KLib.TypeConverters;

namespace DigitsTest
{
    public enum BlockOrder { Sequential, BlockedSequential, Interleaved }

    [TypeConverter(typeof(SortableTypeConverter))]
    public class DigitsTestSettings : BasicMeasurementConfiguration
    {
        [Browsable(false)]
        public new bool UseDefaultInstructions { get; set; }

        [Browsable(false)]
        public new string InstructionMarkdown { get; set; }

        [Category("Appearance")]
        [PropertyOrder(0)]
        public string Title { get; set; }

        [Category("Appearance")]
        [PropertyOrder(1)]
        [DisplayName("Illumination")]
        public bool ApplyIllumination { get; set; }

        [Category("Sequence")]
        [PropertyOrder(1)]
        [DisplayName("Practice trials")]
        public int NumPracticeTrials { get; set; }

        [Category("Sequence")]
        [PropertyOrder(2)]
        [DisplayName("Test blocks")]
        [Description("Number of test blocks per condition")]
        public int NumTestBlocksPerCondition { get; set; }

        [Category("Sequence")]
        [PropertyOrder(3)]
        [DisplayName("Test trials")]
        [Description("Number of test trials per block")]
        public int NumTestTrialsPerBlock { get; set; }

        [Category("Sequence")]
        [PropertyOrder(4)]
        [DisplayName("Block order")]
        [Description("Order of test blocks")]
        public BlockOrder BlockOrder { get; set; }

        [Category("Level")]
        [PropertyOrder(4)]
        [DisplayName("Speaker level")]
        [Description("Level of the speaker in dB SPL")]
        public float SpeakerLevel { get; set; }

        [Category("Level")]
        [PropertyOrder(5)]
        [DisplayName("SNR")]
        [Description("Vector expression of SNRs to test (dB)")]
        public string SNR { get; set; }

        [Category("Timing")]
        [PropertyOrder(5)]
        [DisplayName("Min delay")]
        [Description("Baseline between start of trial and digits")]
        public float MinDelay { get; set; }

        [Category("Timing")]
        [PropertyOrder(6)]
        [DisplayName("Max delay")]
        [Description("Baseline between start of trial and digits")]
        public float MaxDelay { get; set; }

        [Category("Ramp")]
        [PropertyOrder(6)]
        [DisplayName("Start")]
        [Description("SNR ramp at block start to focus subject on target")]
        public float RampStart { get; set; }

        [Category("Ramp")]
        [PropertyOrder(7)]
        [DisplayName("End")]
        [Description("SNR ramp at block start to focus subject on target")]
        public float RampEnd { get; set; }

        [Category("Ramp")]
        [PropertyOrder(8)]
        [DisplayName("Step")]
        [Description("SNR ramp at block start to focus subject on target")]
        public float RampStep { get; set; }

        public DigitsTestSettings() : base()
        {
            Title = "Digits Test";
            ApplyIllumination = true;
            InstructionFontSize = 60;

            NumPracticeTrials = 3;
            NumTestBlocksPerCondition = 1;
            NumTestTrialsPerBlock = 10;
            BlockOrder = BlockOrder.Interleaved;
            SpeakerLevel = 65f;
            SNR = "0";

            MinDelay = 1;
            MaxDelay = 1;

            RampStart = 9;
            RampEnd = 0;
            RampStep = 4.5f;
        }
    }
}
