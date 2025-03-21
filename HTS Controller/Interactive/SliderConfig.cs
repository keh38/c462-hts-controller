using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;
using KLib.Signals;
using Turandot.Inputs;

namespace HTSController.Interactive
{
    public partial class SliderConfig : KUserControl
    {
        private List<ChannelProperties> _channelProperties;
        private ParameterSliderProperties _selectedSlider = null;

        private List<ParameterSliderProperties> _value;
        public List<ParameterSliderProperties> Value
        {
            get { return _value; }
            set
            {
                _value = value;
                ShowValue();
            }
        }

        private bool _renameInProgress = false;

        public SliderConfig()
        {
            InitializeComponent();
        }

        public void SetDataForContext(List<ChannelProperties> properties)
        {
            _channelProperties = properties;

            channelDropDown.Items.Clear();
            var items = _channelProperties.Select(x => x.channelName).ToList();
            channelDropDown.Items.AddRange(items.ToArray());
        }

        private void ShowValue()
        {
            if (_value == null) return;

            var items = _value.Select(x => x.FullParameterName).ToList();
            sliderListBox.Items.Clear();
            sliderListBox.Items.AddRange(items.ToArray());

            sliderListBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newChannel = (string)channelDropDown.Items[0];
            string newProperty = _channelProperties.Find(x => x.channelName == newChannel).properties[0];

            var newSlider = new ParameterSliderProperties() { Channel = newChannel, Property = newProperty };
            sliderListBox.Items.Add(newSlider.FullParameterName);

            _value.Add(newSlider);
        }

        private void SelectSlider(int num)
        {
            _ignoreEvents = true;

            _ignoreEvents = false;
        }

        private void sliderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_renameInProgress) return;

            _selectedSlider = _value.Find(x => x.FullParameterName.Equals(sliderListBox.SelectedItem as string));
            propertyGrid.SelectedObject = _selectedSlider;

            _ignoreEvents = true;
            channelDropDown.SelectedItem = _selectedSlider.Channel;
            _ignoreEvents = false;
        }

        private void channelDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = channelDropDown.SelectedItem as string;

            propertyDropDown.Items.Clear();
            propertyDropDown.Items.AddRange(
                _channelProperties.Find(x => x.channelName == selectedName)
                .properties.ToArray());

            propertyDropDown.SelectedItem = _selectedSlider.Property;

            if (!_ignoreEvents)
            {
                _selectedSlider.Channel = selectedName;
                Debug.WriteLine(_selectedSlider.MaxValue);
                propertyGrid.SelectedObject = _selectedSlider;
            }
        }

        private void sliderPropertyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                var index = sliderListBox.SelectedIndex;
                _selectedSlider.Property = propertyDropDown.SelectedItem as string;

                _renameInProgress = true;
                sliderListBox.Items[index] = _selectedSlider.FullParameterName;
                _renameInProgress = false;
            }
        }
    }
}
