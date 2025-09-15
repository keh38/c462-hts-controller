using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using KLib.TypeConverters;

namespace KLib.Signals
{
    public class WaveformConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
        {
            if (destinationType == typeof(Waveform))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(System.String) && value is Waveform)
            {
                return (value as Waveform)?.Shape.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string)
            {
                return WaveformFactory.Create(value as string);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
        {
            return new StandardValuesCollection(new string[] { "Sinusoid", "Noise" });
        }
    }
}