using System;
using System.IO;

namespace HTSController
{
    public static class FileLocations
    {
        public static readonly string RootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS");
        public static string ConfigFolder
        {
            get
            {
                var folder = Path.Combine(RootFolder, "Config");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                return folder;
            }
        }
        public static string StateFile { get { return Path.Combine(RootFolder, "State.xml"); } }
    }
}