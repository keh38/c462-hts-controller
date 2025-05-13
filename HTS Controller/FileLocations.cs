using System;
using System.IO;

namespace HTSController
{
    public static class FileLocations
    {
        public static string Subject { get; private set; }
        public static string DataDrive { get; private set; } = @"C:\";
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
        public static string ProtocolFolder
        {
            get
            {
                var folder = Path.Combine(RootFolder, "Protocols");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                return folder;
            }
        }
        public static string StateFile { get { return Path.Combine(RootFolder, "State.xml"); } }
        public static string SubjectDataFolder { get; private set; }
        public static void SetDataDrive(string drive)
        {
            DataDrive = drive;
            if (!string.IsNullOrEmpty(Subject))
            {
                SubjectDataFolder = Path.Combine($"{DataDrive}Data", Subject);
                if (!Directory.Exists(SubjectDataFolder))
                {
                    Directory.CreateDirectory(SubjectDataFolder);
                }
            }
        }
        public static void SetSubject(string id)
        {
            Subject = id;
            SubjectDataFolder = Path.Combine($"{DataDrive}Data", id);
            if (!Directory.Exists(SubjectDataFolder))
            {
                Directory.CreateDirectory(SubjectDataFolder);
            }
        }
        private static string MATLABFolder { get { return Path.Combine(RootFolder, "MATLAB"); } }
        public static string GetMATLABFolder(string subFolder)
        {
            return Path.Combine(MATLABFolder, subFolder);
        }
    }
}