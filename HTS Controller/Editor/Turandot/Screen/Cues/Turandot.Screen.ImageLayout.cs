using System.ComponentModel;

using Newtonsoft.Json;

using Turandot.Cues;

namespace Turandot.Screen
{
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
