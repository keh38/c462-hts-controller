using System.ComponentModel;

namespace Turandot.Inputs
{
    public class ParameterSliderProperties
    {
        public enum SliderScale { Linear, Log }

        [Category("Signal parameter")]
        [ReadOnly(true)]
        public string Channel { set; get; }

        [Category("Signal parameter")]
        [ReadOnly(true)]
        public string Property { set; get; }

        [Category("Scale")]
        public SliderScale Scale { set; get; }

        [Category("Scale")]
        public float MinValue { set; get; }

        [Category("Scale")]
        public float MaxValue { set; get; } = 1;

        [Category("Scale")]
        public float StartValue { set; get; }

        [Category("Appearance")]
        [Browsable(false)]
        public bool ShowDigital { set; get; }

        [Category("Appearance")]
        public string DisplayFormat { set; get; } = "F";

        [Category("Appearance")]
        public string Label { set; get; }

        [Browsable(false)]
        public string FullParameterName { get { return $"{Channel}.{Property}"; } }

        public ParameterSliderProperties() { }
    }
}
