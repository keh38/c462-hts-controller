using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTSController
{
    public enum Scale { Linear, Log };
    class ParamSliderProperties
    {
        public Scale Scale { set; get; }
        public float MinVal { set; get; }
    }
}
