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

        [Category("Appearance")]
        [DisplayName("Question font size")]
        public int FontSize { get; set; }

        [Category("Content")]
        [Editor(typeof(QuestionCollectionEditor), typeof(UITypeEditor))]
        public List<Question> Questions { get; set; }

        public Questionnaire()
        {
            Title = "Questionnaire";
            FontSize = 60;
            Questions = new List<Question>();
        }
    }
}
