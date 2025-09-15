using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Xml.Serialization;

namespace HTS.Serialization
{
    [XmlInclude(typeof(Audiograms.AudiogramMeasurementSettings))]
    [XmlInclude(typeof(Bekesy.BekesyMeasurementSettings))]
    [XmlInclude(typeof(LDL.LDLMeasurementSettings))]
    [XmlInclude(typeof(Questionnaires.Questionnaire))]
    public class BasicMeasurementConfiguration
    {
        [Category("Bookkeeping")]
        [Description("This sets the filename")]
        public string Name { get; set; }
        private bool ShouldSerializeName() { return false; }

        [Category("Bookkeeping")]
        [Description("If true, will not record data streams for this measurement")]
        public bool BypassDataStreams { get; set; }
        private bool ShouldSerializeBypassDataStreams() { return false; }

        [Category("Instructions")]
        [DisplayName("Use default")]
        [Description("If true, use default instructions")]
        public bool UseDefaultInstructions { get; set; }
        private bool ShouldSerializeUseDefaultInstructions() { return false; }

        [Category("Instructions")]
        [DisplayName("Font size")]
        public int InstructionFontSize { get; set; }
        private bool ShouldSerializeInstructionFontSize() { return false; }

        [Category("Instructions")]
        [DisplayName("Markdown")]
        //[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string InstructionMarkdown { get; set; }
        private bool ShouldSerializeInstructionMarkdown() { return false; }

        public BasicMeasurementConfiguration()
        {
            Name = "Defaults";
            BypassDataStreams = false;

            UseDefaultInstructions = true;
            InstructionFontSize = 48;
            InstructionMarkdown = "";
        }
    }
}