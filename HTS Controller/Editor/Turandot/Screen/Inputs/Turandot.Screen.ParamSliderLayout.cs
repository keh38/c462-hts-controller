using System.ComponentModel;

using Newtonsoft.Json;

namespace Turandot.Screen
{
    public enum ParamSliderButtonStyle { Fixed, Mobile }

    [JsonObject(MemberSerialization.OptOut)]
    public class ParamSliderLayout : InputLayout
    {
        [Category("Appearance")]
        public int Width { get; set; }

        [Category("Appearance")]
        public int Height { get; set; }

        [Category("Appearance")]
        public ParamSliderButtonStyle ButtonStyle { set; get; }

        public ParamSliderLayout()
        {
            Name = "Param Slider";
            Width = 1000;
            Height = 50;
            ButtonStyle = ParamSliderButtonStyle.Fixed;
        }
    }
}
