using System.ComponentModel;

using Newtonsoft.Json;

using OrderedPropertyGrid;
using KLib.TypeConverters;

namespace Turandot.Screen
{
    [JsonObject(MemberSerialization.OptOut)]
    [TypeConverter(typeof(SortableTypeConverter))]
    public class ScalerLayout : InputLayout
    {
        [Category("Appearance")]
        public int Width { get; set; }

        [Category("Appearance")]
        public int Height { get; set; }

        [Category("Appearance")]
        public int FontSize { get; set; }

        [Category("Behavior")]
        [Description("Shows the thumb")]
        public bool ShowThumb { set; get; }

        [Category("Behavior")]
        [Description("Shows the slider fill")]
        public bool ShowFill { set; get; }

        [Category("Behavior")]
        public bool BarClickable { set; get; }

        [Category("Labels")]
        [PropertyOrder(0)]
        [DisplayName("Min")]
        public string MinLabel { get; set; }

        [Category("Labels")]
        [PropertyOrder(1)]
        [DisplayName("Max")]
        public string MaxLabel { get; set; }

        [Category("Scale")]
        [DisplayName("Min")]
        [PropertyOrder(0)]
        public float MinValue { get; set; }

        [Category("Scale")]
        [DisplayName("Max")]
        [PropertyOrder(1)]
        public float MaxValue { get; set; }

        [Category("Scale")]
        [DisplayName("Whole numbers")]
        [PropertyOrder(1)]
        public bool WholeNumbers { get; set; }

        [Category("Ticks")]
        [DisplayName("Show")]
        [PropertyOrder(0)]
        public bool ShowTicks { get; set; }

        [Category("Ticks")]
        [PropertyOrder(1)]
        [DisplayName("Label")]
        public bool LabelTicks { get; set; }

        public ScalerLayout()
        {
            Name = "Scaler";
            Width = 1000;
            Height = 125;
            FontSize = 48;
            MinLabel = "";
            MaxLabel = "";
            ShowFill = true;
            ShowThumb = true;
            BarClickable = false;
            MinValue = 0;
            MaxValue = 1;
            WholeNumbers = false;
            ShowTicks = false;
            LabelTicks = false;
        }
    }
}
