using System;
using System.ComponentModel;

namespace Turandot.Screen
{
    // NOTE: KeyCode property references an external type (KeyCode). Kept as-is; remove if not applicable.
    [Serializable]
    public class ButtonLayout : InputLayout
    {
        public enum ButtonStyle { Rectangle, Circle }

        [Category("Design")]
        public string Label { set; get; }

        [Category("Appearance")]
        public int Width { get; set; }

        [Category("Appearance")]
        public int Height { get; set; }

        [Category("Appearance")]
        public ButtonStyle Style { get; set; }

        [Category("Appearance")]
        public int FontSize { get; set; }

        [Category("Behavior")]
        public KeyCode KeyCode { get; set; }

        public ButtonLayout()
        {
            Name = "Button";
            Label = "Button";
            Width = 300;
            Height = 200;
            Style = ButtonStyle.Rectangle;
            FontSize = 48;
        }
    }
}
