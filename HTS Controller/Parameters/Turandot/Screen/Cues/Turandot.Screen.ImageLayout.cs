using System.ComponentModel;

using Newtonsoft.Json;
using ProtoBuf;

using Turandot.Cues;

namespace Turandot.Screen
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    public class ImageLayout : CueLayout
    {
        public ImageLayout()
        {
        }

        public ImageAction GetDefaultCue()
        {
            return new ImageAction()
            {
                BeginVisible = true,
                EndVisible = true
            };
        }
    }
}
