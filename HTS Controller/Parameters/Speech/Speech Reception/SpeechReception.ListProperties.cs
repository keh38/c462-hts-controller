using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using KLib.TypeConverters;
using Newtonsoft.Json;
using OrderedPropertyGrid;

using KLib.Signals.Enumerations;
using C462.Shared;

namespace SpeechReception
{
    [TypeConverter(typeof(ListPropertiesConverter))]
    [JsonObject(MemberSerialization.OptOut)]
    public class ListProperties
    {
        private static TestType _serializationTestType = TestType.OpenSet;
        public static TestType SerializationTestType
        {
            get { return _serializationTestType; }
            set
            {
                _serializationTestType = value;
                ListPropertiesConverter.TestType = value;
            }
        }

        [Category("List properties")]
        [PropertyOrder(0)]
        public string Name { get; set; }

        [Category("List properties")]
        [PropertyOrder(1)]
        public float Level { get; set; }
        public bool ShouldSerializeLevel() { return _serializationTestType != TestType.QuickSIN; }

        [Category("List properties")]
        [PropertyOrder(2)]
        public LevelUnits Units { get; set; }
        public bool ShouldSerializeUnits() { return _serializationTestType != TestType.QuickSIN; }

        [Category("List properties")]
        [PropertyOrder(3)]
        public string SNR { get; set; }
        public bool ShouldSerializeSNR() { return _serializationTestType != TestType.QuickSIN; }

        [Category("List properties")]
        [PropertyOrder(4)]
        public Masker Masker { get; set; }
        public bool ShouldSerializeMasker() { return _serializationTestType != TestType.QuickSIN; }

        [Category("List properties")]
        [PropertyOrder(5)]
        public ClosedSet ClosedSet { get; set; }
        public bool ShouldSerializeClosedSet() { return _serializationTestType == TestType.ClosedSet; }

        [Category("List properties")]
        [PropertyOrder(6)]
        public Sequence Sequence { get; set; }
        public bool ShouldSerializeSequence() { return _serializationTestType == TestType.ClosedSet; }

        [Category("List properties")]
        [PropertyOrder(7)]
        public MatrixTest MatrixTest { get; set; }
        public bool ShouldSerializeMatrixTest() { return _serializationTestType == TestType.Matrix; }

        [Browsable(false)]
        public List<ListDescription.Sentence> sentences;
        public bool ShouldSerializeSentences() { return _serializeAllFields; }

        [Browsable(false)]
        public TestType TestType { get; set; }
        public bool ShouldSerializeTestType() { return _serializeAllFields; }

        [Browsable(false)]
        public string TestSource { get; set; }
        public bool ShouldSerializeTestSource() { return _serializeAllFields; }

        [Browsable(false)]
        public TestEar TestEar { get; set; }
        public bool ShouldSerializeTestEar() { return _serializeAllFields; }

        [Browsable(false)]
        public string Title { get; set; }
        public bool ShouldSerializeTitle() { return _serializeAllFields; }

        [XmlIgnore]
        [Browsable(false)]
        public int listIndex = -1;

        [XmlIgnore]
        [Browsable(false)]
        public bool ShowFeedback { get { return ClosedSet != null && ClosedSet.Feedback != ClosedSet.FeedbackType.None; } }

        [XmlIgnore]
        [Browsable(false)]
        public bool MaskerAvailable { get { return Masker != null && !string.IsNullOrEmpty(Masker.Source); } }

        [XmlIgnore]
        [Browsable(false)]
        public bool UseMasker { get { return Masker != null && !string.IsNullOrEmpty(Masker.Source) && (AnyFiniteSNR || (MatrixTest != null && MatrixTest.Active)); } }

        [XmlIgnore]
        [Browsable(false)]
        public bool AnyFiniteSNR { get; private set; }

        private bool _serializeAllFields = false;

        public ListProperties()
        {
            Name = "";
            Level = 60;
            Units = LevelUnits.dB_SPL;
            SNR = "";
            Masker = new Masker();
            ClosedSet = new ClosedSet();
            Sequence = new Sequence();
            MatrixTest = new MatrixTest();
        }

        public ListProperties(ListProperties that)
        {
            this.Name = that.Name;
            this.Level = that.Level;
            this.Units = that.Units;
            this.SNR = that.SNR;
            this.Masker = that.Masker;
            this.ClosedSet = that.ClosedSet;
            this.Sequence = that.Sequence;
            this.MatrixTest = that.MatrixTest;
        }
    }
}
