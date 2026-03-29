using System.ComponentModel;
using System.Xml.Serialization;

namespace Pupillometry
{
    // NOTE: UnityEngine.KeyCode and KLib.ColorTranslator references require manual attention.
    // The KeyCode property and constructor initialization using UnityEngine.KeyCode and KLib.ColorTranslator
    // could not be resolved without Unity/KLib references. These are preserved as-is.
    public class GazeCalibrationSettings
    {
        public int Width { get; set; }
        private bool ShouldSerializeWidth() { return false; }

        public int Height { get; set; }
        private bool ShouldSerializeHeight() { return false; }

        public float TargetSizeFactor { get; set; }
        private bool ShouldSerializeTargetSizeFactor() { return false; }

        public float HoleSizeFactor { get; set; }
        private bool ShouldSerializeHoleSizeFactor() { return false; }

        [DisplayName("Target Color")]
        [XmlIgnore]
        public System.Drawing.Color TargetWindowsColor
        {
            get { return System.Drawing.Color.FromArgb(TargetColor); }
            set { TargetColor = value.ToArgb(); }
        }

        [Browsable(false)]
        public int TargetColor { set; get; }
        private bool ShouldSerializeTargetColor() { return false; }

        [DisplayName("Background Color")]
        [XmlIgnore]
        public System.Drawing.Color BackgroundWindowsColor
        {
            get { return System.Drawing.Color.FromArgb(BackgroundColor); }
            set { BackgroundColor = value.ToArgb(); }
        }

        [Browsable(false)]
        public int BackgroundColor { set; get; }
        private bool ShouldSerializeBackgroundColor() { return false; }

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
