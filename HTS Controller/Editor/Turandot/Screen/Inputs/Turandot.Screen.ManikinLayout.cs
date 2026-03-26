using System;
using System.ComponentModel;

namespace Turandot.Screen
{
    [Serializable]
    public class ManikinLayout : InputLayout
    {
        [Category("Behavior")]
        public bool RandomizeOrder { get; set; }

        [Category("Appearance")]
        [DisplayName("Spacing")]
        [Description("Spacing between sliders (pixels)")]
        public int SliderSpacing { get; set; }

        [Category("Button")]
        [DisplayName("Spacing")]
        [Description("Spacing between sliders and apply button (pixels)")]
        public int ButtonSpacing { get; set; }

        [Category("Button")]
        [DisplayName("Width")]
        public int ButtonWidth { get; set; }

        [Category("Button")]
        [DisplayName("Height")]
        public int ButtonHeight { get; set; }

        [Category("Appearance")]
        [DisplayName("Height")]
        [Description("Slider height (pixels)")]
        public float SliderHeight { get; set; }

        [Category("Appearance")]
        [DisplayName("Width")]
        [Description("Slider width as fraction of image width (0-1)")]
        public float SliderWidth { get; set; }

        [Category("Appearance")]
        [DisplayName("Offset")]
        [Description("From top of slider to bottom of image (pixels)")]
        public int SliderVerticalOffset { get; set; }

        [Category("Appearance")]
        [DisplayName("Font size")]
        [Description("Size of label font")]
        public float SliderFontSize { get; set; }

        [Category("Sliders")]
        public ManikinCollection Manikins { get; set; }

        public ManikinLayout()
        {
            Name = "Manikins";
            Manikins = new ManikinCollection();
            RandomizeOrder = false;
            SliderFontSize = 42;
            SliderHeight = 75;
            SliderWidth = 1;
            SliderVerticalOffset = 0;
            SliderSpacing = 50;
            ButtonSpacing = 50;
            ButtonWidth = 200;
            ButtonHeight = 100;
        }
    }
}
