using System.ComponentModel;

using OrderedPropertyGrid;

namespace SpeechReception
{
    [TypeConverter(typeof(MaskerConverter))]
    public class Masker
    {
        [Browsable(false)]
        public string Source { get; set; }

        [PropertyOrder(1)]
        public int NumBabblers { get; set; }
        public bool ShouldSerializeNumBabblers() { return Source.Equals("IEEE"); }

        [PropertyOrder(2)]
        public int BabbleSeed { get; set; }
        public bool ShouldSerializeBabbleSeed() { return Source.Equals("IEEE"); }

        public Masker()
        {
            Source = "None";
            NumBabblers = 4;
            BabbleSeed = 0;
        }
    }
}
