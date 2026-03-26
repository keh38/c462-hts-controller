using System.ComponentModel;
using System.Xml.Serialization;

using OrderedPropertyGrid;

namespace SpeechReception
{
    public enum MatrixTestMode { VarySignal, VaryMasker }

    [TypeConverter(typeof(MatrixTestTypeConverter))]
    public class MatrixTest
    {
        [XmlIgnore]
        [Browsable(false)]
        public bool Active { get; private set; } = false;

        [Browsable(false)]
        public MatrixTestMode Mode { get; set; } = MatrixTestMode.VarySignal;

        [PropertyOrder(1)]
        public float MaskerLevel { get; set; } = 65;

        [PropertyOrder(2)]
        public float StimLevel { get; set; } = 65;

        [PropertyOrder(3)]
        public float StartSNR { get; set; } = 0;

        [XmlIgnore]
        [Browsable(false)]
        public float SNR
        {
            get { return StimLevel - MaskerLevel; }
        }

        public MatrixTest()
        {
        }
    }
}
