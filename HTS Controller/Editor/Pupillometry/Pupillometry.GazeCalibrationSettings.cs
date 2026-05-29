using System.ComponentModel;
using System.Xml.Serialization;

using OrderedPropertyGrid;
using KLib.TypeConverters;
using Newtonsoft.Json;

namespace Pupillometry
{
    // NOTE: UnityEngine.KeyCode and KLib.ColorTranslator references require manual attention.
    // The KeyCode property and constructor initialization using UnityEngine.KeyCode and KLib.ColorTranslator
    // could not be resolved without Unity/KLib references. These are preserved as-is.
    [JsonObject(MemberSerialization.OptOut)]
    [TypeConverter(typeof(SortableTypeConverter))]
    public class GazeCalibrationSettings
    {
        [Category("Screen")]
        [PropertyOrder(1)]
        public int Width { get; set; }
        private bool ShouldSerializeWidth() { return false; }

        [Category("Screen")]
        [PropertyOrder(2)]
        public int Height { get; set; }
        private bool ShouldSerializeHeight() { return false; }


        [Category("Screen")]
        [PropertyOrder(3)]
        [DisplayName("Background Color")]
        [XmlIgnore]
        [JsonIgnore]
        public System.Drawing.Color BackgroundWindowsColor
        {
            get { return System.Drawing.Color.FromArgb(BackgroundColor); }
            set { BackgroundColor = value.ToArgb(); }
        }
        private bool ShouldSerializeBackgroundWindowsColor() { return false; }

        [Browsable(false)]
        public int BackgroundColor { set; get; }
        private bool ShouldSerializeBackgroundColor() { return false; }

        [Category("Target")]
        [PropertyOrder(1)]
        [DisplayName("Size Factor")]
        public float TargetSizeFactor { get; set; }
        private bool ShouldSerializeTargetSizeFactor() { return false; }

        [Category("Target")]
        [PropertyOrder(2)]
        [DisplayName("Hole Size Factor")]
        public float HoleSizeFactor { get; set; }
        private bool ShouldSerializeHoleSizeFactor() { return false; }

        [Category("Target")]
        [PropertyOrder(3)]
        [DisplayName("Color")]
        [XmlIgnore]
        [JsonIgnore]
        public System.Drawing.Color TargetWindowsColor
        {
            get { return System.Drawing.Color.FromArgb(TargetColor); }
            set { TargetColor = value.ToArgb(); }
        }
        private bool ShouldSerializeTargetWindowsColor() { return false; }

        [Browsable(false)]
        public int TargetColor { set; get; }
        private bool ShouldSerializeTargetColor() { return false; }

        [Category("Calibration")]
        [DisplayName("Type")]
        public string CalibrationType { get; set; }
        private bool ShouldSerializeCalibrationType() { return false; }

        public GazeCalibrationSettings()
        {
            Width = -1;
            Height = -1;
            CalibrationType = "HV9";

            TargetSizeFactor = 60;
            HoleSizeFactor = 300;

            TargetColor = KLib.ColorTranslator.ColorInt(0.75f, 0.75f, 0.75f, 1);
            BackgroundColor = KLib.ColorTranslator.ColorInt(0, 0, 0, 1);
        }
    }
}
