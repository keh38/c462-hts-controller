using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;
using ProtoBuf;

using Turandot.Cues;
using static Turandot.Instructions;

namespace Turandot.Screen
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    public class TextBoxLayout : CueLayout
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

        [Category("Alignment")]
        [DisplayName("Text horizontal")]
        public HorizontalTextAlignment HorizontalAlignment { get; set; }

        [Category("Alignment")]
        [DisplayName("Box vertical")]
        public VerticalTextAlignment BoxVerticalAlignment { get; set; }

        [Browsable(false)]
        public int Color { set; get; }

        public TextBoxLayout() : base()
        {
            Name = "TextBox";
            FontSize = 72;
            Color = KLib.ColorTranslator.ColorInt(0, 0, 0, 1);
        }

        public TextBoxAction GetDefaultCue()
        {
            return new TextBoxAction()
            {
                BeginVisible = true
            };
        }
    }
}
