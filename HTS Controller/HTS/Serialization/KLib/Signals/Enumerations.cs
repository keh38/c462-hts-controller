using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLib.Signals
{
    public enum AMShape
    {
        None,
        Sinusoidal
    }

    public enum Laterality
    {
        None,
        Left,
        Right,
        Binaural,
        Diotic
    }

    public enum LevelUnits
    {
        Volts,
        dB_attenuation,
        dB_Vrms,
        dB_SPL,
        dB_HL,
        dB_SL,
        PercentDR,
        [Description("dB SPL (no LDL)")]
        dB_SPL_noLDL,
        mA
    };

    public enum Modality
    {
        Unspecified,
        Audio,
        Haptic,
        Electric
    }

    public enum Waveshape
    {
        None,
        Sinusoid,
        Noise,
        Moving_Ripple_Noise,
        Tone_Cloud,
        FM,
        File,
        Ripple_Noise,
        Digitimer
    }


}
