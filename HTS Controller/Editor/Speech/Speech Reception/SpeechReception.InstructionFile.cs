using System.ComponentModel;

using OrderedPropertyGrid;
using KLib.TypeConverters;
using Newtonsoft.Json;

namespace SpeechReception
{
    [TypeConverter(typeof(SortableTypeConverter))]
    [JsonObject(MemberSerialization.OptOut)]
    public class InstructionFile
    {
        [PropertyOrder(0)]
        [DisplayName("File name")]
        public string Name { get; set; }

        [PropertyOrder(1)]
        [DisplayName("Insert before")]
        [Description("Show these instructions before which list")]
        public int Before { get; set; }
    }
}
