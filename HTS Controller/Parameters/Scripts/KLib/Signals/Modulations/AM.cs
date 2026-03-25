using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;
using ProtoBuf;

using KLib.Signals.Enumerations;

namespace KLib.Signals.Modulations
{
    [System.Serializable]
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [JsonObject(MemberSerialization.OptOut)]
    [XmlInclude(typeof(SinusoidalAM))]
    [ProtoInclude(500, typeof(SinusoidalAM))]
    [TypeConverter(typeof(AMConverter))]
    public class AM
    {
        [ProtoMember(1, IsRequired = true)]
        public bool ApplyLevelCorrection = true;

        protected AMShape _shape = AMShape.None;
        [ProtoIgnore]
        [Browsable(false)]
        public AMShape Shape
        {
            get { return _shape; }
        }

        protected string _shortName = "None";
        [ProtoIgnore]
        [Browsable(false)]
        public string ShortName
        {
            get { return _shortName; }
        }

        [ProtoIgnore]
        [Browsable(false)]
        public string LongName
        {
            get { return _shape.ToString().Replace('_', ' '); }
        }

        public AM()
        {
        }

        [ProtoIgnore]
        [Browsable(false)]
        public virtual float LevelCorrection
        {
            get
            {
                return 0;
            }
        }
    }
}
