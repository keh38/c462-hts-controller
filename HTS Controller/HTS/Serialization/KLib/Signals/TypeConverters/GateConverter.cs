using OrderedPropertyGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KLib.TypeConverters;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace KLib.Signals
{
    public class GateConverter : SortableTypeConverter
    {
        public override PropertyDescriptorCollection? GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            List<string> gateDependentProperties = new List<string> { "Width_ms", "Ramp_ms", "Period_ms", "Bursted" };

            var gate = value as Gate;
            if (gate != null)
            {
                var x = GetSortedProperties(value, attributes);
                List<PropertyDescriptor> filteredProperties = new List<PropertyDescriptor>();
                foreach (PropertyDescriptor prop in x)
                {
                    if (prop.Name == "Delay_ms")
                    {
                        filteredProperties.Add(prop);
                    }
                    else if (!gate.Active) { }
                    else if (gateDependentProperties.Contains(prop.Name))
                    {
                        filteredProperties.Add(prop);
                    }
                    else if (!gate.Bursted) { }
                    else if (prop.Name == "Active") { }
                    else
                    {
                        filteredProperties.Add(prop);
                    }
                }
                return new PropertyDescriptorCollection(filteredProperties.ToArray()).Sort(GetSortedPropertyOrder(value, attributes));
            }
            return GetSortedProperties(value, attributes);
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, [NotNullWhen(true)] Type? destinationType)
        {
            if (destinationType == typeof(Gate))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(System.String) && value != null && value is Gate)
            {
                return (value as Gate)!.Active ? "ON" : "OFF";
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
                var gate = (context.Instance as Channel).Gate;
                gate.Active = (value as string) == "ON";
                return gate;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
        {
            return true;
        }

        public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
        {
            return new StandardValuesCollection(new string[] { "OFF", "ON" });
        }

    }
}
