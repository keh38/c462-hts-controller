using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderedPropertyGrid;

namespace KLib.Signals
{
    [TypeConverter(typeof(ChannelConverter))]
    public class Channel
    {
        [Category("Channel")]
        [DisplayName("Name")]
        [PropertyOrder(0)]
        public string Name { get; set; }

        [Category("Channel")]
        [PropertyOrder(1)]
        public Modality Modality { get; set; }

        [Category("Channel")]
        [PropertyOrder(2)]
        public Laterality Laterality { get; set; }

        [Category("Channel")]
        [PropertyOrder(3)]
        public string Location { get; set; }

        [Category("Channel")]
        [PropertyOrder(4)]
        public Waveform Waveform { get; set; }

        [Category("Channel")]
        [PropertyOrder(5)]
        public Level Level { get; set; }

        [Category("Channel")]
        [PropertyOrder(6)]
        public Gate Gate { get; set; }

        [Category("Channel")]
        [PropertyOrder(7)]
        public AM Modulation { get; set; }

        public Channel()
        {
            Name = "Channel";
            Modality = Modality.Audio;
            Laterality = Laterality.Diotic;
            Location = "";

            Waveform = new Sinusoid();
            Level = new Level();
            Gate = new Gate();
            Modulation = new AM();
        }

        private bool ShouldSerializeName() { return false; }
        private bool ShouldSerializeModality() { return false; }
        private bool ShouldSerializeLaterality() { return false; }
        private bool ShouldSerializeLocation() { return false; }

        private bool ShouldSerializeWaveform() { return false; }
        private bool ShouldSerializeLevel() { return false; }
        private bool ShouldSerializeGate() { return false; }
        private bool ShouldSerializeModulation() { return false; }

        public override string ToString()
        {
            return Name;
        }

        public List<string> GetSweepableParams()
        {
            var sp = new List<string>();

            if (Waveform.Shape != Waveshape.None)
            {
                foreach (string p in Waveform.GetSweepableParams())
                {
                    sp.Add(Waveform.ShortName + "." + p);
                }
                sp.AddRange(Modulation.GetSweepableParams());
                sp.AddRange(Gate.GetSweepableParams());

                //var digitimer = Waveform as Digitimer;
                //if (digitimer == null || digitimer.Source == Digitimer.DemandSource.External)
                //{
                sp.AddRange(Level.GetSweepableParams());
                //}

                if (Laterality == Laterality.Binaural)
                {
                    sp.Add("MBL");
                    sp.Add("ILD");
                    if (Waveform.Shape == Waveshape.Sinusoid)
                    {
                        sp.Add("IPD");
                    }
                }
            }
            return sp;
        }


    }
}
