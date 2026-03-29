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
        private bool ShouldSerializeActive() { return false; }

        [Browsable(false)]
        public MatrixTestMode Mode { get; set; } = MatrixTestMode.VarySignal;
        private bool ShouldSerializeMode() { return false; }

        [PropertyOrder(1)]
        public float MaskerLevel { get; set; } = 65;
        private bool ShouldSerializeMaskerLevel() { return false; }

        [PropertyOrder(2)]
        public float StimLevel { get; set; } = 65;
        private bool ShouldSerializeStimLevel() { return false; }

        [PropertyOrder(3)]
        public float StartSNR { get; set; } = 0;
        private bool ShouldSerializeStartSNR() { return false; }

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
