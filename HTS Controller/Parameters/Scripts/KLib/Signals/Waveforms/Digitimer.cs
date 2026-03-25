using System;
using System.ComponentModel;
using System.ComponentModel.Design;

using Newtonsoft.Json;
using ProtoBuf;

using KLib.Signals.Enumerations;

using OrderedPropertyGrid;

namespace KLib.Signals.Waveforms
{
    [Serializable]
    [ProtoContract]
    [JsonObject(MemberSerialization.OptIn)]
    [TypeConverter(typeof(DigitimerConverter))]
    public class Digitimer : Waveform
    {
        public enum DemandSource { Internal, External }

        [ProtoMember(1, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(1)]
        [DisplayName("Pulse rate")]
        [Description("Pulse rate in pulse per second (pps)")]
        public float PulseRate_Hz { get; set; }

        [ProtoMember(2, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(2)]
        [DisplayName("Mode")]
        [Description("")]
        [TypeConverter(typeof(DigitimerModeConverter))]
        public float PulseMode { get; set; }

        [ProtoMember(3, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(3)]
        [DisplayName("Polarity")]
        [TypeConverter(typeof(DigitimerPolarityConverter))]
        public float PulsePolarity { get; set; }

        private float _width;
        [ProtoMember(4, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(4)]
        [Description("Pulse width in us (50-2000)")]
        public float Width
        {
            get { return _width; }
            set
            {
                _width = value;
                if (_width < 50) _width = 50;
                if (_width > 2000) _width = 2000;
            }
        }

        private float _recovery;
        [ProtoMember(5, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(5)]
        [Description("Duration of recovery phase as % of pulse width (10-100)")]
        public float Recovery
        {
            get { return _recovery; }
            set
            {
                _recovery = value;
                if (_recovery < 10) _recovery = 10;
                if (_recovery > 100) _recovery = 100;
            }
        }

        private float _dwell;
        [ProtoMember(6, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(6)]
        [Description("Interphase gap in us (1 to 990 in steps of 10)")]
        public float Dwell
        {
            get { return _dwell; }
            set
            {
                _dwell = value;
                if (_dwell < 1) _dwell = 1;
                if (_dwell > 990) _dwell = 990;
            }
        }

        [ProtoMember(7, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(7)]
        public DemandSource Source { get; set; }

        private float _demand;
        [ProtoMember(8, IsRequired = true)]
        [JsonProperty]
        [PropertyOrder(8)]
        [Description("Pulse amplitude (0-1000 mA)")]
        public float Demand
        {
            get { return _demand; }
            set
            {
                _demand = value;
                if (_demand < 0) _demand = 0;
                if (_dwell > 1000) _demand = 1000;
            }
        }

        public Digitimer()
        {
            PulseRate_Hz = 20;
            PulseMode = 1;
            PulsePolarity = 2;
            Width = 200;
            Recovery = 100;
            Dwell = 1;
            Demand = 0;
            Source = DemandSource.Internal;

            shape = Waveshape.Digitimer;
            _shortName = "Digitimer";
            HandlesModulation = true;
        }
    }
}
