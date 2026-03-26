using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Turandot.Cues;

namespace Turandot.Screen
{
    [JsonObject(MemberSerialization.OptOut)]
    public class MessageLayout : CueLayout
    {
        [Category("Appearance")]
        [Description("")]
        public int FontSize { get; set; }

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

        public string DefaultText { get; set; }

        public MessageLayout() : base()
        {
            Name = "Message";
            FontSize = 72;
            Color = KLib.ColorTranslator.ColorInt(0, 0, 0, 1);
            DefaultText = "message goes here";
        }

        public Message GetDefaultCue()
        {
            return new Message()
            {
                Text = DefaultText,
                BeginVisible = true
            };
        }
    }
}
