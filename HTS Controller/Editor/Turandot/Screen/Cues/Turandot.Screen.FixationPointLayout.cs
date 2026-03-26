using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Turandot.Cues;

namespace Turandot.Screen
{
    [JsonObject(MemberSerialization.OptOut)]
    public class FixationPointLayout : CueLayout
    {
        public enum Style { Cross, Circle }

        [Category("Appearance")]
        public Style Shape { get; set; }

        [Category("Appearance")]
        public int Size { get; set; }

        [Category("Appearance")]
        [DisplayName("Color")]
        [XmlIgnore]
        public System.Drawing.Color WindowsColor
        {
            get { return System.Drawing.Color.FromArgb(Color); }
            set { Color = value.ToArgb(); }
        }

        [Browsable(false)]
        public int Color { set; get; }

        [Category("Appearance")]
        public int BarWidth { get; set; }

        public float barAngle = 0;
        public string label = "";

        public FixationPointLayout()
        {
            Shape = Style.Cross;
            Size = 100;
            BarWidth = 25;
        }

        public FixationPointAction GetDefaultCue()
        {
            return new FixationPointAction()
            {
                BeginVisible = true,
                EndVisible = true
            };
        }
    }
}
