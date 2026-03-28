using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using C462.Shared;

namespace HTSController
{
    public static class FileLocations
    {
        private static string MATLABFolder { get { return SharedFileLocations.ResourceFolder("MATLAB"); } }

        public static string StateFile { get { return Path.Combine(SharedFileLocations.HtsFolder, "HTSControllerState.xml"); } }
        public static string GetMATLABFolder(string subFolder)
        {
            return Path.Combine(MATLABFolder, subFolder);
        }

    }
}