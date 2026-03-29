using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Xml.Serialization;

using BasicMeasurements;

namespace Questionnaires
{
    [System.Serializable]
    public class Questionnaire : BasicMeasurementConfiguration
    {
        [Category("Appearance")]
        public string Title { get; set; }
        private bool ShouldSerializeTitle() { return false; }

        [Category("Appearance")]
        [DisplayName("Question font size")]
        public int FontSize { get; set; }
        private bool ShouldSerializeFontSize() { return false; }

        [Category("Content")]
        [Editor(typeof(QuestionCollectionEditor), typeof(UITypeEditor))]
        public List<Question> Questions { get; set; }
        private bool ShouldSerializeQuestions() { return false; }

        public Questionnaire()
        {
            Title = "Questionnaire";
            FontSize = 60;
            Questions = new List<Question>();
        }
    }
}
