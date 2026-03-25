using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;
using ProtoBuf;

using System.ComponentModel;

namespace KLib.Signals
{
    #region ENUMERATIONS
    public enum LevelReference
    {
        Total_power,
        Spectrum_level,
    }
    [TypeConverter(typeof(LevelUnitsConverter))]
    public enum LevelUnits
    {
        Volts,
        dB_attenuation,
        dB_Vrms,
        dB_SPL,
        dB_HL,
        dB_SL,
        PercentDR,
        dB_SPL_noLDL,
        mA
    };
    #endregion

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    public class Level
    {
        [ProtoMember(1, IsRequired = true)]
        public LevelUnits Units { set; get; }

        [ProtoMember(2, IsRequired = true)]
        public LevelReference Reference { set; get; }

        [ProtoMember(3, IsRequired = true)]
        public float Value { set; get; }

        [ProtoMember(4, IsRequired = true)]
        public float VolumeControldB { set; get; }

        [ProtoMember(5, IsRequired = true)]
        public bool ClampToMax
        {
            get { return _clampToMax; }
            set { _clampToMax = value; }
        }

        private bool _clampToMax = false;

        public Level()
        {
            Units = LevelUnits.dB_attenuation;
            Reference = LevelReference.Total_power;
            Value = 0;
            VolumeControldB = 0;
        }
    }
}
