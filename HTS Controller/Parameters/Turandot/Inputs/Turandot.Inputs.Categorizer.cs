// Originally: Turandot.Inputs.Categorizer (Turandot\Inputs\Turandot.Inputs.Categorizer.cs)
// using UnityEngine, using System.Collections removed — unused.
// ProtoBuf attributes removed — protobuf-net not referenced in C462.Shared.
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Turandot.Inputs
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Categorizer : Input
    {
        public List<string> categories = new List<string>();

        public Categorizer() : base("Categorizer") { }
    }
}
