// Originally: Turandot.Cues.ProgressBarAction (Turandot\Cues\Turandot.Cues.ProgressBarAction.cs)
// using UnityEngine, using System.Collections, using System.Collections.Generic removed — unused.
// ProtoBuf attributes removed.
// Placed in Turandot.Cues (same namespace as Cue base class) to preserve
// XmlSerializer subtype resolution and [XmlInclude] in Cue.cs.
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Cues
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ProgressBarAction : Cue
    {
        public ProgressBarAction() { }

        [XmlIgnore]
        [JsonIgnore]
        override public string Name
        {
            get { return "Progress bar"; }
        }
    }
}
