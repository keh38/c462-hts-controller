using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

using KLib;
using static KLib.Expressions;
using KLib.TypeConverters;
using Newtonsoft.Json;
using OrderedPropertyGrid;

using C462.Shared;
using C462.Shared.Turandot;

namespace Protocols
{
    public class ProtocolEntry
    {
        public string Title;
        public string Scene;
        public string Settings;
    }

    public class Protocol
    {
        public string Title;
        public bool FullAuto;
        public List<ProtocolEntry> Tests = new List<ProtocolEntry>();
    }
}

namespace Turandot.Schedules
{
    public class ScriptArguments
    {
        public Laterality laterality;
        public VarDimension dimension;
        public string expression;
        public string flag;
        public int value;

        public ScriptArguments()
        {
            laterality = Laterality.None;
            dimension = VarDimension.X;
        }
    }

    [TypeConverter(typeof(SortableTypeConverter))]
    public class Script
    {
        [Category("Bookkeeping")]
        [DisplayName("Script name")]
        [Description("Name of this script")]
        [PropertyOrder(0)]
        public string Name { get; set; }

        [Category("Bookkeeping")]
        [DisplayName("Protocol name")]
        [Description("Root name of generated protocol files")]
        [PropertyOrder(1)]
        public string ProtocolRootName { get; set; }

        [Category("Bookkeeping")]
        [DisplayName("Single output")]
        [Description("Generate single output protocol file")]
        [PropertyOrder(2)]
        public bool SingleProtocolFile { get; set; }

        [Category("Bookkeeping")]
        [DisplayName("Config files")]
        [Description("List of Turandot config files (just the central part of the name")]
        [PropertyOrder(3)]
        public BindingList<string> ConfigFiles { get; set; }

        [Category("Sequence")]
        [DisplayName("Ears")]
        [Description("Ears to test")]
        [PropertyOrder(1)]
        public TestedEars TestedEars { get; set; }

        [Category("Sequence")]
        [PropertyOrder(2)]
        [Browsable(false)]
        public string Groups { get; set; }

        [Category("Sequence")]
        [DisplayName("Dimension")]
        [Description("Sequence dimension along which to split")]
        [PropertyOrder(3)]
        public VarDimension Dim { get; set; }

        [Category("Sequence")]
        [Description("Value expression")]
        [PropertyOrder(4)]
        public string Expression { get; set; }

        [Category("Sequence")]
        [Description("Order in which values are distributed across split")]
        [PropertyOrder(5)]
        public Order Order { get; set; }

        [Category("Sequence")]
        [DisplayName("Split after")]
        [Description("Number of items per split")]
        [PropertyOrder(6)]
        public int SplitAfter { get; set; }

        public Script()
        {
            Name = "Untitled";
            ProtocolRootName = "";
            SingleProtocolFile = false;
            ConfigFiles = new BindingList<string>();
            TestedEars = TestedEars.None;
            Groups = "";
            Dim = VarDimension.X;
            Expression = "";
            Order = Order.Interleave;
            SplitAfter = 1;
        }

        public void Apply(string protocolFolder)
        {
            if (ConfigFiles.Count == 0) return;

            float[] values = null;

            if (!string.IsNullOrEmpty(Expression))
            {
                double[] dvals = Evaluate(Expression);
                values = System.Array.ConvertAll(dvals, v => (float)v);
                if (Order == Order.Random || Order == Order.Interleave)
                {
                    KMath.Permute(values);
                }
            }

            if (!string.IsNullOrEmpty(Groups))
            {
                EvaluateToInt(Groups);
            }

            int nfile = 1;
            int nperFile = 1;
            if (values != null)
            {
                nperFile = values.Length;
                if (values.Length > 0 && SplitAfter > 0)
                {
                    nfile = (int)System.Math.Ceiling((double)values.Length / SplitAfter);
                    nperFile = SplitAfter;
                }
            }

            string protocolRootName = Name;
            if (!string.IsNullOrEmpty(ProtocolRootName))
            {
                protocolRootName = ProtocolRootName;
            }

            var combinedEntries = new List<Protocols.ProtocolEntry>();

            int i1 = 0;
            for (int k = 0; k < nfile; k++)
            {
                var args = new ScriptArguments();

                if (values != null)
                {
                    args.dimension = Dim;
                    args.expression = "[";
                    int i2 = System.Math.Min(i1 + nperFile, values.Length);
                    for (int kv = i1; kv < i2; kv++) args.expression += $"{values[kv]} ";
                    args.expression += "]";
                    i1 = i2;
                }

                if (TestedEars == TestedEars.None)
                {
                    args.laterality = Laterality.None;
                    var entries = CreateEntries(args);
                    if (SingleProtocolFile)
                        combinedEntries.AddRange(entries);
                    else
                        CreateOneProtocolFile(protocolFolder, $"{protocolRootName}-{k + 1}", entries);
                }
                else
                {
                    if (TestedEars == TestedEars.Left || TestedEars == TestedEars.Both)
                    {
                        args.laterality = Laterality.Left;
                        var entries = CreateEntries(args);
                        if (SingleProtocolFile)
                            combinedEntries.AddRange(entries);
                        else
                            CreateOneProtocolFile(protocolFolder, $"{protocolRootName}-{k + 1}Left", entries);
                    }
                    if (TestedEars == TestedEars.Right || TestedEars == TestedEars.Both)
                    {
                        args.laterality = Laterality.Right;
                        var entries = CreateEntries(args);
                        if (SingleProtocolFile)
                            combinedEntries.AddRange(entries);
                        else
                            CreateOneProtocolFile(protocolFolder, $"{protocolRootName}-{k + 1}Right", entries);
                    }
                }

                if (SingleProtocolFile)
                {
                    CreateOneProtocolFile(protocolFolder, protocolRootName, combinedEntries);
                }
            }
        }

        private List<Protocols.ProtocolEntry> CreateEntries(ScriptArguments args)
        {
            var entries = new List<Protocols.ProtocolEntry>();
            string serializedArgs = JsonConvert.SerializeObject(args, Formatting.None);

            foreach (string configFile in ConfigFiles)
            {
                entries.Add(new Protocols.ProtocolEntry()
                {
                    Title = $"{configFile}-{args.laterality}-{args.expression}",
                    Scene = "Turandot",
                    Settings = $"{configFile}:{serializedArgs}"
                });
            }
            return entries;
        }

        private void CreateOneProtocolFile(string folder, string name, List<Protocols.ProtocolEntry> entries)
        {
            var protocol = new Protocols.Protocol();
            protocol.Title = name;
            protocol.FullAuto = true;
            protocol.Tests.AddRange(entries);
            KFile.XmlSerialize(protocol, Path.Combine(folder, $"{name}.xml"));
        }
    }
}
