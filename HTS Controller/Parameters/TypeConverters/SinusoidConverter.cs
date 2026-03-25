using System;
using System.ComponentModel;
using System.Globalization;

using KLib.TypeConverters;

namespace KLib.Signals.Waveforms
{
    public class SinusoidConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(System.String) && value is Sinusoid)
            {
                return (value as Sinusoid).Frequency_Hz.ToString() + " Hz";
            }
            return "";
        }
    }
}
