using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLib.Signals
{
    public static class AMFactory
    {
        public static AM Create(string shape)
        {
            AM am = new AM();
            switch (shape)
            {
                case "Sinusoidal":
                case "SAM":
                    am = new SinusoidalAM();
                    break;
            }
            return am;
        }

    }
}
