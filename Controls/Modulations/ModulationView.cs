using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;
using KLib.Signals.Enumerations;
using KLib.Signals.Modulations;

namespace KLib.Unity.Controls.Signals
{
    public partial class ModulationView : KUserControl
    {
        private AM _modulation;

        public AM Value
        {
            get { return _modulation; }
            set
            {
                _modulation = value;
                if (_modulation != null)
                {
                    shapeDropDown.SetEnumValue(_modulation.Shape);
                    ShowModulation(_modulation);
                    ActivateModulationControl(_modulation.Shape);
                }
            }
        }

        public ModulationView()
        {
            InitializeComponent();

            shapeDropDown.AddItem(AMShape.None, "Modulation OFF");
            shapeDropDown.AddItem(AMShape.Sinusoidal, "SAM");
        }

        private void ActivateModulationControl(AMShape shape)
        {
            samPage.Visible = shape == AMShape.Sinusoidal;
        }


        private void ShowModulation(AM am)
        {
            if (am == null) return;

            switch (am.Shape)
            {
                case AMShape.Sinusoidal:
                    samPage.Value = am;
                    break;
            }
        }

        private void shapeDropDown_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            _modulation = CreateNewModulation((AMShape)shapeDropDown.Value);
            ShowModulation(_modulation);
            ActivateModulationControl((AMShape)shapeDropDown.Value);
            OnValueChanged();
        }

        private AM CreateNewModulation(AMShape shape)
        {
            AM am = AMFactory.Create(shape);

            return am;
        }

        private void amTabPage_ValueChanged(object sender, EventArgs e)
        {
            //_modulation = (sender as AMTabPage).Value;
            OnValueChanged();
        }
    }
}
