using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Xml.Serialization;

namespace Questionnaires
{
    public class Question
    {
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Prompt { get; set; }
        private bool ShouldSerializePrompt() { return false; }

        [DisplayName("Select multiple")]
        [Description("If true, subject can select multiple options")]
        public bool AllowMultipleSelections { get; set; }
        private bool ShouldSerializeAllowMultipleSelections() { return false; }

        public BindingList<string> Options { get; set; }
        private bool ShouldSerializeOptions() { return false; }

        public Question()
        {
            Prompt = "";
            Options = new BindingList<string>();
        }
    }
}
