using System.ComponentModel;
using KLib.TypeConverters;
using OrderedPropertyGrid;

namespace Turandot.Schedules
{
    public enum TestedEars { None, Left, Right, Both }

    public class ScriptArguments
    {
        public Laterality laterality;
        public VarDimension dimension;
        public string expression;
        public string flag;
        public int value;

        public ScriptArguments()
        {
            laterality = Laterality.None;
            dimension = VarDimension.X;
        }
    }

    [TypeConverter(typeof(SortableTypeConverter))]
    public class Script
    {
        [Category("Bookkeeping")]
        [DisplayName("Script name")]
        [Description("Name of this script")]
        [PropertyOrder(0)]
        public string Name { get; set; }

        [Category("Bookkeeping")]
        [DisplayName("Protocol name")]
        [Description("Root name of generated protocol files")]
        [PropertyOrder(1)]
        public string ProtocolRootName { get; set; }

        [Category("Bookkeeping")]
        [DisplayName("Single output")]
        [Description("Generate single output protocol file")]
        [PropertyOrder(2)]
        public bool SingleProtocolFile { get; set; }

        [Category("Bookkeeping")]
        [DisplayName("Config files")]
        [Description("List of Turandot config files (just the central part of the name")]
        [PropertyOrder(3)]
        public BindingList<string> ConfigFiles { get; set; }

        [Category("Sequence")]
        [DisplayName("Ears")]
        [Description("Ears to test")]
        [PropertyOrder(1)]
        public TestedEars TestedEars { get; set; }

        [Category("Sequence")]
        [PropertyOrder(2)]
        [Browsable(false)]
        public string Groups { get; set; }

        [Category("Sequence")]
        [DisplayName("Dimension")]
        [Description("Sequence dimension along which to split")]
        [PropertyOrder(3)]
        public VarDimension Dim { get; set; }

        [Category("Sequence")]
        [Description("Value expression")]
        [PropertyOrder(4)]
        public string Expression { get; set; }

        [Category("Sequence")]
        [Description("Order in which values are distributed across split")]
        [PropertyOrder(5)]
        public Order Order { get; set; }

        [Category("Sequence")]
        [DisplayName("Split after")]
        [Description("Number of items per split")]
        [PropertyOrder(6)]
        public int SplitAfter { get; set; }

        public Script()
        {
            Name = "Untitled";
            ProtocolRootName = "";
            SingleProtocolFile = false;
            ConfigFiles = new BindingList<string>();
            TestedEars = TestedEars.None;
            Groups = "";
            Dim = VarDimension.X;
            Expression = "";
            Order = Order.Interleave;
            SplitAfter = 1;
        }
    }
}
