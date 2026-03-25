using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using KLib.TypeConverters;
using Newtonsoft.Json;
using OrderedPropertyGrid;

namespace SpeechReception
{
    public enum TestEar { SubjectDefault, Left, Right, Binaural }

    public enum TestType
    {
        QuickSIN,
        OpenSet,
        ClosedSet,
        Matrix
    }

    [TypeConverter(typeof(SpeechTestConverter))]
    [JsonObject(MemberSerialization.OptOut)]
    public class SpeechTest
    {
        [Category("About")]
        [PropertyOrder(0)]
        [DisplayName("Name")]
        public string TestName { get; set; }

        [Category("About")]
        [PropertyOrder(1)]
        [DisplayName("Type")]
        public TestType TestType { get; set; }

        [Category("About")]
        [PropertyOrder(2)]
        public string TestSource { get; set; }

        [Category("About")]
        [PropertyOrder(3)]
        public bool ApplyIllumination { get; set; }

        [Category("Instructions")]
        [DisplayName("Font size")]
        [PropertyOrder(0)]
        public int InstructionFontSize { get; set; }

        [Category("Instructions")]
        [PropertyOrder(1)]
        [TypeConverter(typeof(InstructionFileCollectionConverter))]
        public List<InstructionFile> Instructions { get; set; }

        [Category("Timing")]
        [PropertyOrder(2)]
        [DisplayName("Min delay")]
        public float MinDelay_s { get; set; }

        [Category("Timing")]
        [PropertyOrder(3)]
        [DisplayName("Max delay")]
        public float MaxDelay_s { get; set; }

        [Category("Timing")]
        [PropertyOrder(4)]
        [DisplayName("Duration")]
        public float SentenceDuration_s { get; set; }

        [Category("Timing")]
        [PropertyOrder(5)]
        [DisplayName("Masker tail")]
        public float MaskerTail_s { get; set; }

        [Category("Procedure")]
        [PropertyOrder(0)]
        public bool BypassDataStreams { get; set; }

        [Category("Procedure")]
        [PropertyOrder(6)]
        [Description("Number of recordings to have subject review")]
        public int NumToReview { get; set; }
        public bool ShouldSerializeNumToReview() { return TestType == TestType.OpenSet || TestType == TestType.QuickSIN; }

        [Category("Procedure")]
        [PropertyOrder(7)]
        public int GiveBreakEvery { get; set; }

        [Category("Procedure")]
        [PropertyOrder(17)]
        [Description("Do not use buttons to control recording")]
        public bool AudioCuesOnly { get; set; }

        [Category("Sequence")]
        [PropertyOrder(8)]
        public int NumPracticeLists { get; set; }

        [Category("Sequence")]
        [PropertyOrder(9)]
        public int NumPerSNR { get; set; }

        [Category("Sequence")]
        [PropertyOrder(10)]
        public List<TestEar> TestEars { get; set; }

        [Category("Sequence")]
        [PropertyOrder(11)]
        public string EarOrder { get; set; }

        [Category("Lists")]
        [PropertyOrder(14)]
        [Description("Total number of lists available")]
        public int NumListsAvailable { get; set; }

        [Category("Lists")]
        [PropertyOrder(15)]
        [Description("Number of lists to choose at random")]
        public int Choose { get; set; }

        [Category("Lists")]
        [PropertyOrder(16)]
        [Description("Lists to exclude from random selection")]
        public string Exclude { get; set; }

        [Category("Lists")]
        [PropertyOrder(19)]
        [TypeConverter(typeof(ListPropertiesCollectionConverter))]
        public List<ListProperties> Lists { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public bool UseMicrophone { get { return TestType == TestType.QuickSIN || TestType == TestType.OpenSet; } }

        [XmlIgnore]
        [Browsable(false)]
        public bool ReviewResponses { get { return UseMicrophone && NumToReview > 0; } }

        public SpeechTest()
        {
            TestName = "untitled";
            TestType = TestType.OpenSet;
            TestSource = "Unknown";

            Instructions = new List<InstructionFile>();
            InstructionFontSize = 60;

            MinDelay_s = 0f;
            MaxDelay_s = 0f;
            SentenceDuration_s = 0f;
            MaskerTail_s = 0f;
            NumToReview = 3;
            GiveBreakEvery = -1;
            NumPracticeLists = 0;
            NumPerSNR = 0;
            TestEars = new List<TestEar>();
            EarOrder = "Random";
            NumListsAvailable = 1;
            Choose = 0;
            Exclude = "";
            AudioCuesOnly = false;

            Lists = new List<ListProperties>();
        }
    }
}
