using System.ComponentModel;
using System.Xml.Serialization;

using OrderedPropertyGrid;

namespace SpeechReception
{
    public enum Order { Sequential, FullRandom, BlockRandom }

    [TypeConverter(typeof(SequenceTypeConverter))]
    public class Sequence
    {
        [Browsable(false)]
        public Order Order { get; set; }

        [PropertyOrder(1)]
        public int RepeatsPerBlock { get; set; }

        [PropertyOrder(2)]
        public int NumBlocks { get; set; }

        public int choose = -1;

        private int _itemsPerBlock;

        public Sequence()
        {
            Order = Order.Sequential;
            RepeatsPerBlock = 1;
            NumBlocks = 1;
        }

        [XmlIgnore]
        [Browsable(false)]
        public int ItemsPerBlock
        {
            get { return _itemsPerBlock; }
            set { _itemsPerBlock = value; }
        }
    }
}
