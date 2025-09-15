using OrderedPropertyGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KLib.TypeConverters;

namespace KLib.Signals
{
    public class ChannelConverter : SortableTypeConverter
    {
        public override PropertyDescriptorCollection? GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
        {
            var channel = value as Channel;
            if (channel != null)
            {
                var x = GetSortedProperties(value, attributes);
                List<PropertyDescriptor> filteredProperties = new List<PropertyDescriptor>();
                foreach (PropertyDescriptor prop in x)
                {
                    if (channel.Modality != Modality.Audio && prop.Name == "Laterality") { }
                    else if (channel.Modality == Modality.Audio && prop.Name == "Location") { }
                    else
                    {
                        filteredProperties.Add(prop);
                    }
                }
                return new PropertyDescriptorCollection(filteredProperties.ToArray()).Sort(GetSortedPropertyOrder(value, attributes));
            }
            return GetSortedProperties(value, attributes);
        }
    }
}
