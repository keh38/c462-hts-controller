using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Screen
{
    [XmlInclude(typeof(ButtonLayout))]
    [XmlInclude(typeof(ChecklistLayout))]
    [XmlInclude(typeof(ManikinLayout))]
    [XmlInclude(typeof(ParamSliderLayout))]
    [XmlInclude(typeof(ScalerLayout))]
    [JsonObject(MemberSerialization.OptOut)]
    public class InputLayout
    {
        [Category("Design")]
        public string Name { get; set; }

        [Category("Layout")]
        [Description("Horizontal position of the center as fraction of the screen size")]
        public float X { get; set; }

        [Category("Layout")]
        [Description("Vertical position of the center as fraction of the screen size")]
        public float Y { get; set; }

        public InputLayout()
        {
            X = 0.5f;
            Y = 0.5f;
        }
    }
}
