using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Turandot.Cues;

namespace Turandot.Screen
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ProgressBarLayout : CueLayout
    {
        [Category("Appearance")]
        public int Width { get; set; }

        [Category("Appearance")]
        public int Height { get; set; }

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

        public ProgressBarLayout()
        {
            Name = "ProgressBar";
            X = 0.5f;
            Y = 0.1f;
            Width = 750;
            Height = 75;
            Color = KLib.ColorTranslator.ColorInt(58, 80, 90, 255);
        }

        public ProgressBarAction GetDefaultCue()
        {
            return new ProgressBarAction()
            {
                BeginVisible = true,
                EndVisible = true
            };
        }
    }
}
