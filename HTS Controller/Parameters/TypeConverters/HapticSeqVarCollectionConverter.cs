using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace LDL.Haptics
{
    public class HapticSeqVarCollectionConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is List<HapticSeqVar> myCollection)
            {
                if (myCollection.Count == 0)
                {
                    return "(no vars)";
                }

                return $"({myCollection.Count} var" + (myCollection.Count > 1 ? "s" : "") + ")";
            }

            return null;
        }
    }
}
