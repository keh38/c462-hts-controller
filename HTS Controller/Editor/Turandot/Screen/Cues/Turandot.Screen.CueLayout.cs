using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Screen
{
    [JsonObject(MemberSerialization.OptOut)]
    [XmlInclude(typeof(FixationPointLayout))]
    [XmlInclude(typeof(ImageLayout))]
    [XmlInclude(typeof(MessageLayout))]
    [XmlInclude(typeof(ProgressBarLayout))]
    [XmlInclude(typeof(TextBoxLayout))]
    [XmlInclude(typeof(VideoLayout))]
    public class CueLayout
    {
        [Category("Design")]
        public string Name { get; set; }

        [Category("Layout")]
        [Description("Horizontal position of the center as fraction of the screen size")]
        public float X { get; set; }

        [Category("Layout")]
        [Description("Vertical position of the center as fraction of the screen size")]
        public float Y { get; set; }

        public CueLayout()
        {
            X = 0.5f;
            Y = 0.5f;
        }
    }
}
