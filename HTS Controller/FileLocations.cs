using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HTSController
{
    public static class FileLocations
    {
        public static string Project { get; private set; }
        public static string Subject { get; private set; }
        public static string DataDrive { get; private set; } = @"C:\";
        public static readonly string RootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS");
        public static string ProjectRootFolder { get; private set; } = Path.Combine(RootFolder, "Projects");
        public static string ConfigFolder { get { return Path.Combine(ProjectRootFolder, Project, "Resources", "Config Files"); } }
        public static string ProtocolFolder { get { return Path.Combine(ProjectRootFolder, Project, "Resources", "Protocols"); } }
        private static string MATLABFolder { get { return Path.Combine(ProjectRootFolder, Project, "Resources", "MATLAB"); } }

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

        public static void SetProjectRootFolder(string projectRootFolder)
        {
            ProjectRootFolder = projectRootFolder;
        }
        public static void SetProject(string projectName)
        {
            Project = projectName;

            var projectFolder = Path.Combine(ProjectRootFolder, Project);
            if (!Directory.Exists(projectFolder))
            {
                Directory.CreateDirectory(projectFolder);
            }

            var subFolders = new List<string>()
            {
                "Admin",
                "Resources",
                "Subjects"
            };
            CreateSubfolders(projectFolder, subFolders);

            var resourceFolder = Path.Combine(projectFolder, "Resources");
            var resourceFolders = new List<string>()
            {
                "Config Files",
                "Images",
                "MATLAB",
                "Plugins",
                "Protocols",
                "Schedules",
                "Videos",
                "Wav Files"
            };

            CreateSubfolders(resourceFolder, resourceFolders);
        }

        public static List<string> EnumerateProjects()
        {
            return Directory.EnumerateDirectories(ProjectRootFolder).Select(x => Path.GetFileName(x)).ToList();
        }

        private static void CreateSubfolders(string rootFolder, List<string> subFolders)
        {
            foreach (var subFolder in subFolders)
            {
                var folder = Path.Combine(rootFolder, subFolder);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
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

        public static string GetMATLABFolder(string subFolder)
        {
            return Path.Combine(MATLABFolder, subFolder);
        }
    }
}