using System.ComponentModel;
using ProtoBuf;

namespace KLib.Signals
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Level
    {
        [TypeConverter(typeof(LevelUnitsConverter))]
        public LevelUnits Units { set; get; }

        public float Value { set; get; }

        public Level()
        {
            Units = LevelUnits.dB_SPL;
            Value = 50;
        }

        public override string ToString()
        {
            return "";
        }

        private bool ShouldSerializeUnits() { return false; }
        private bool ShouldSerializeValue() { return false; }

        public static List<string> GetSweepableParams()
        {
            return new List<string>()
            {
                "Level"
            };
        }


    }
}