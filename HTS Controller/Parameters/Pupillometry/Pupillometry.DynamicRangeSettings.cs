using System.ComponentModel;
using System.Xml.Serialization;

namespace Pupillometry
{
    public class DynamicRangeSettings
    {
        [DisplayName("(Name)")]
        public string Name { get; set; }

        [Description("Duration of baseline period before stimulation (seconds)")]
        public float PrestimulusBaseline { get; set; }

        [Description("Duration of baseline period after stimulation (seconds)")]
        public float PoststimulusBaseline { get; set; }

        [Description("Duration of light modulation cycle (seconds)")]
        public float StimulusPeriod { get; set; }

        [Description("Number of light modulation cycles")]
        public int NumRepetitions { get; set; }

        [Category("LED Intensity")]
        [DisplayName("Min")]
        [Description("Minimum intensity of LEDs if present (0-1)")]
        public float MinLEDIntensity { get; set; }

        [Category("LED Intensity")]
        [DisplayName("Max")]
        [Description("Maximum intensity of LEDs if present (0-1)")]
        public float MaxLEDIntensity { get; set; }

        [DisplayName("Fixation size")]
        [Description("Fixation point size in pixels")]
        public int FixationPointSize { get; set; }

        [Category("Screen Intensity")]
        [DisplayName("Min")]
        [Description("Minimum screen intensity")]
        public float MinScreenIntensity { get; set; }

        [Category("Screen Intensity")]
        [DisplayName("Max")]
        [Description("Maximum screen intensity")]
        public float MaxScreenIntensity { get; set; }

        public DynamicRangeSettings()
        {
            Name = "Defaults";
            PrestimulusBaseline = 2;
            PoststimulusBaseline = 2;
            StimulusPeriod = 20;
            NumRepetitions = 4;
            MinLEDIntensity = 0;
            MaxLEDIntensity = 1;
            MinScreenIntensity = 0;
            MaxScreenIntensity = 1;
            FixationPointSize = 50;
        }
    }
}
