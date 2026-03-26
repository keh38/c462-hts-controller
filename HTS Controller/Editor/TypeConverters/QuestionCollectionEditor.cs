using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Questionnaires
{
    public class QuestionCollectionEditor : CollectionEditor
    {
        public QuestionCollectionEditor(Type type) : base(type) { }

        protected override string GetDisplayText(object value)
        {
            Question item = new Question();
            item = (Question)value;

            return base.GetDisplayText(item.Prompt);
        }
    }
}