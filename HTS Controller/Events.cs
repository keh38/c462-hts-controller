using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTSController
{
    public class AutoRunEndEventArgs : EventArgs
    {
        public bool success;
        public string dataFile;
        public AutoRunEndEventArgs(bool success, string dataFile)
        {
            this.success = success;
            this.dataFile = dataFile;
        }
    }
}
