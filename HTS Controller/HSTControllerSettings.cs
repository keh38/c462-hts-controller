﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using KLib;

namespace HTSController
{
    public class HSTControllerSettings
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
        public SerializeableDictionary lastUsed = new SerializeableDictionary();

        private static HSTControllerSettings _instance = null;
        private static HSTControllerSettings instance
        {
            get
            {
                if (_instance == null)
                {
                    if (File.Exists(FileLocations.StateFile))
                    {
                        _instance = KFile.XmlDeserialize<HSTControllerSettings>(FileLocations.StateFile);
                    }
                    else
                    {
                        _instance = new HSTControllerSettings();
                    }
                }
                return _instance;
            }
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