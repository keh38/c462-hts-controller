using System;
using System.ComponentModel;

namespace Turandot.Screen
{
    [Serializable]
    public class ChecklistLayout : InputLayout
    {
        [Category("Appearance")]
        public int FontSize { get; set; }

        [Category("Appearance")]
        [Description("Spacing between prompt and checklist items in pixels")]
        public int PromptSpacing { get; set; }

        [Category("Behavior")]
        [Description("If true, does not show Apply button if single selection")]
        [DisplayName("Auto advance")]
        public bool AutoAdvance { get; set; }

        [Category("Behavior")]
        [Description("If true, allow no selection")]
        [DisplayName("Allow none")]
        public bool AllowNone { get; set; }

        [Category("Behavior")]
        [Description("If true, allow multiple selections")]
        [DisplayName("Allow multiple")]
        public bool AllowMultiple { get; set; }

        [Category("Behavior")]
        [Description("If true, never show the apply button")]
        [DisplayName("Disable apply")]
        public bool DisableApply { get; set; }

        [Category("Button")]
        [DisplayName("Font size")]
        public int ButtonFontSize { get; set; }

        [Category("Button")]
        [Description("Button width in pixels")]
        [DisplayName("Width")]
        public int ButtonWidth { get; set; }

        [Category("Button")]
        [Description("Button height in pixels")]
        [DisplayName("Height")]
        public int ButtonHeight { get; set; }

        [Category("Design")]
        public string Label { set; get; }

        [Category("Content")]
        public BindingList<string> Items { set; get; }

        public ChecklistLayout()
        {
            Name = "Checklist";
            Label = "Select one";
            FontSize = 48;
            Items = new BindingList<string>();
            AllowMultiple = false;
            AllowNone = false;
            AutoAdvance = false;
            PromptSpacing = 50;

            ButtonFontSize = 0;
            ButtonWidth = 200;
            ButtonHeight = 100;
        }
    }
}
