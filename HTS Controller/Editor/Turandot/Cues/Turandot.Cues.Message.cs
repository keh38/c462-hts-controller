using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Cues
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Message : Cue
    {
        public enum Icon { None, Right, Wrong, Warning }

        [Category("Appearance")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Text { get; set; }

        public int fontSize = 40;

        public Icon icon = Icon.None;
        public int iconSize = 128;

        public Message() : this("")
        {
        }

        public Message(string text)
        {
            this.Text = text;
        }

        [XmlIgnore]
        [JsonIgnore]
        override public string Name
        {
            get { return "Message"; }
        }
    }
}
