using System.ComponentModel;

using Newtonsoft.Json;

namespace Turandot
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Instructions
    {
        public enum HorizontalTextAlignment { Left, Center, Right }
        public enum VerticalTextAlignment { Top, Middle, Bottom }

        [Browsable(false)]
        public string Text { get; set; }

        [Category("Appearance")]
        public int FontSize { get; set; }

        [Category("Alignment")]
        [DisplayName("Horizontal")]
        public HorizontalTextAlignment HorizontalAlignment { get; set; }

        [Category("Alignment")]
        [DisplayName("Vertical")]
        public VerticalTextAlignment VerticalAlignment { get; set; }

        [Category("Alignment")]
        [DisplayName("Line spacing")]
        public int LineSpacing { get; set; }

        public Instructions()
        {
            FontSize = 60;
            HorizontalAlignment = HorizontalTextAlignment.Left;
            VerticalAlignment = VerticalTextAlignment.Top;
            LineSpacing = 1;
        }
    }
}
