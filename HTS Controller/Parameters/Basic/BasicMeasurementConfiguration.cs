using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace BasicMeasurements
{
    [XmlInclude(typeof(Audiograms.AudiogramMeasurementSettings))]
    [XmlInclude(typeof(Bekesy.BekesyMeasurementSettings))]
    [XmlInclude(typeof(DigitsTest.DigitsTestSettings))]
    [XmlInclude(typeof(LDL.LDLMeasurementSettings))]
    [XmlInclude(typeof(Questionnaires.Questionnaire))]
    [JsonObject(MemberSerialization.OptOut)]
    public class BasicMeasurementConfiguration
    {
        [Category("Bookkeeping")]
        [Description("This sets the filename")]
        public string Name { get; set; }

        [Category("Bookkeeping")]
        [Description("If true, will not record data streams for this measurement")]
        public bool BypassDataStreams { get; set; }

        [Category("Instructions")]
        [DisplayName("Use default")]
        [Description("If true, use default instructions")]
        public bool UseDefaultInstructions { get; set; }

        [Category("Instructions")]
        [DisplayName("Font size")]
        public int InstructionFontSize { get; set; }

        [Category("Instructions")]
        [DisplayName("Markdown")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string InstructionMarkdown { get; set; }

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
