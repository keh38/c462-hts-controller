using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using KLib;

namespace HTSController
{
    public class HTSControllerSettings
    {
        public class SerializeableDictionary
        {
            public class Entry
            {
                public string key;
                public string value;
                public Entry() { }
            }
            public List<Entry> entries = new List<Entry>();
            public string this[string key]
            {
                get { return entries.Find(x => x.key.Equals(key))?.value; }
                set
                {
                    var e = entries.Find(x => x.key.Equals(key));
                    if (e == null)
                    {
                        entries.Add(new Entry() { key = key, value = value });
                    }
                    else
                    {
                        e.value = value;
                    }
                }
            }
        }

        public string dataDrive { get; set; } = @"C:\";
        public string projectRootFolder { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EPL", "HTS", "Projects"); 
        public string lastProject { get; set; }
        public SerializeableDictionary lastUsed = new SerializeableDictionary();

        private static HTSControllerSettings _instance = null;
        private static HTSControllerSettings instance
        {
            get
            {
                if (_instance == null)
                {
                    if (File.Exists(FileLocations.StateFile))
                    {
                        _instance = KFile.XmlDeserialize<HTSControllerSettings>(FileLocations.StateFile);
                    }
                    else
                    {
                        _instance = new HTSControllerSettings();
                    }
                }
                return _instance;
            }
        }

        public static string DataDrive
        {
            get { return instance.dataDrive; }
            set { instance.dataDrive = value; Save(); }
        }

        public static string ProjectRootFolder
        {
            get { return instance.projectRootFolder; }
            set { instance.projectRootFolder = value; Save(); }
        }

        public static string LastProject
        {
            get { return instance.lastProject; }
            set { instance.lastProject = value; Save(); }
        }

        public static void SetLastUsed(string key, string value)
        {
            instance.lastUsed[key] = value;
            Save();
        }
        
        public static string GetLastUsed(string key)
        {
            return instance.lastUsed[key];
        }

        private static void Save()
        {
            KFile.XmlSerialize(_instance, FileLocations.StateFile);
        }

    }
}