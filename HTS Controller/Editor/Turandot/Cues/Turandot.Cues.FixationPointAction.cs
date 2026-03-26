// Originally: Turandot.Cues.FixationPointAction (Turandot\Cues\Turandot.Cues.FixationPointAction.cs)
// using UnityEngine, using System.Collections, using System.Collections.Generic removed — unused.
// ProtoBuf attributes removed — protobuf-net not referenced in this project context.
// Placed in Turandot.Cues (same namespace as Cue base class) to preserve
// XmlSerializer subtype resolution and [XmlInclude] in Cue.cs.
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Cues
{
    [JsonObject(MemberSerialization.OptOut)]
    public class FixationPointAction : Cue
    {
        public float angle = 0f;
        public string label = "";

        public FixationPointAction() { }

        [XmlIgnore]
        [JsonIgnore]
        override public string Name
        {
            get { return "Fixation point"; }
        }
    }
}
