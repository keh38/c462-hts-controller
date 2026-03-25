using System;
using System.Collections;
using System.ComponentModel;

namespace Turandot.Screen
{
    public class ManikinSpec
    {
        public string Name { get; set; }

        [Category("Appearance")]
        public string Label { get; set; }

        [Category("Appearance")]
        public string Image { get; set; }

        [Category("Behavior")]
        public float StartPosition { get; set; }

        [Category("Behavior")]
        public bool RandomizeStartPosition { get; set; }

        [Category("Behavior")]
        public float MinStartPosition { get; set; }

        [Category("Behavior")]
        public float MaxStartPosition { get; set; }

        public ManikinSpec()
        {
            Name = "Manikin";
            Label = "Label";
            Image = "Image";

            StartPosition = 0.5f;
            RandomizeStartPosition = false;
            MinStartPosition = 0;
            MaxStartPosition = 1;
        }
    }

    public class ManikinCollection : CollectionBase
    {
        public ManikinSpec this[int index]
        {
            get { return (ManikinSpec)List[index]; }
        }
        public void Add(ManikinSpec ms)
        {
            List.Add(ms);
        }
        public void Remove(ManikinSpec ms)
        {
            List.Remove(ms);
        }
    }
}
