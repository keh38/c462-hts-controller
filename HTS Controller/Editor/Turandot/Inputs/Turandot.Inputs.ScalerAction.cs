using System.ComponentModel;

namespace Turandot.Inputs
{
    public class ScalerAction : Input
    {
        public float StartValue { get; set; }

        public ScalerAction() : base("Scaler")
        {
            StartValue = 0.5f;
        }
    }
}
