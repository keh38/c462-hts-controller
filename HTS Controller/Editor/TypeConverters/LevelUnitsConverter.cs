using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

using C462.Shared;

namespace KLib.Signals
{
    class LevelUnitsConverter : EnumConverter
    {
        public static LevelUnits[] Shit = null;
        private Type enumType;

        public LevelUnitsConverter(Type type) : base(type)
        {
            enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            FieldInfo fi = enumType.GetField(Enum.GetName(enumType, value));

            DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            if (dna != null)
            {
                return dna.Description;
            }
            else
            {
                return value.ToString().Replace("_", " ");
            }
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            foreach (FieldInfo fi in enumType.GetFields())
            {
                DescriptionAttribute dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
                if (dna != null && value != null && ((string)value == dna.Description))
                    return Enum.Parse(enumType, fi.Name);
            }

            if (value != null)
            {
                return Enum.Parse(enumType, ((string)value).Replace(" ", "_"));
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (Shit != null)
                return new StandardValuesCollection(Shit);

            return new StandardValuesCollection(Enum.GetValues(typeof(LevelUnits)));
        }
    }
}
