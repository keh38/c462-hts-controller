// Originally: Turandot.Interactive.InteractiveSettings
// Stripped — CreateDefaultSignalManager() and SliderNames removed.
using System.Collections.Generic;

using KLib.Signals.Editor;
using Turandot.Inputs;

namespace Turandot.Interactive
{
    public class InteractiveSettings
    {
        public string Name { set; get; }
        public SignalManager SigMan { get; set; }
        public List<ParameterSliderProperties> Sliders { get; set; }
        public bool ShowSliders { set; get; }

        public InteractiveSettings()
        {
            Name = "Defaults";
            SigMan = new SignalManager();
            Sliders = new List<ParameterSliderProperties>();
        }
    }
}
