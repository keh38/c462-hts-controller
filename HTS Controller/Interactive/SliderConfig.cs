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
        public bool ShowSliders { set; get; }

        private List<Tuple<string, string>> _linearValidProperties = new List<Tuple<string, string>>();
        private bool _renameInProgress = false;

        public event EventHandler<bool> ShowSlidersChanged;
        private void OnShowSlidersChanged(bool value)
        {
            ShowSlidersChanged?.Invoke(this, value);
        }

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

            _linearValidProperties.Clear();
            foreach (var c in properties)
            {
                foreach (var p in c.properties)
                {
                    _linearValidProperties.Add(new Tuple<string, string>(c.channelName, p));
                }
            }

        }

        private void ShowValue()
        {
            if (_value == null) return;

            showCheckBox.Checked = ShowSliders;
            sliderListBox.Items.Clear();
            sliderListBox.Items.AddRange(_value.Select(x => x.FullParameterName).ToArray());

            if (sliderListBox.Items.Count != 0)
            {
                sliderListBox.SelectedIndex = 0;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (_selectedSlider != null)
            {
                var startIndex = _linearValidProperties.FindIndex(x => x.Item1.Equals(_selectedSlider.Channel) && x.Item2.Equals(_selectedSlider.Property));
                index = startIndex;
                while (true)
                {
                    index++;
                    if (index >= _linearValidProperties.Count)
                    {
                        index = 0;
                    }
                    if (index == startIndex)
                    {
                        index = 0;
                        break;
                    }
                    var p = _linearValidProperties[index];
                    if (_value.Find(x => x.Channel.Equals(p.Item1) && x.Property.Equals(p.Item2)) == null)
                    {
                        break;
                    }
                }
            }

            string newChannel = _linearValidProperties[index].Item1;
            string newProperty = _linearValidProperties[index].Item2;

            var newSlider = new ParameterSliderProperties() { Channel = newChannel, Property = newProperty };
            sliderListBox.Items.Add(newSlider.FullParameterName);

            _value.Add(newSlider);
            sliderListBox.SelectedItem = newSlider.FullParameterName;
            OnValueChanged();
        }

        private void sliderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_renameInProgress) return;

            _selectedSlider = _value.Find(x => x.FullParameterName.Equals(sliderListBox.SelectedItem as string));
            propertyGrid.SelectedObject = _selectedSlider;

            _ignoreEvents = true;
            channelDropDown.SelectedItem = _selectedSlider.Channel;
            UpdatePropertyDropDown(_selectedSlider.Channel);
            _ignoreEvents = false;
        }

        private void channelDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = channelDropDown.SelectedItem as string;

            if (!_ignoreEvents)
            {
                _selectedSlider.Channel = selectedName;
                UpdatePropertyDropDown(selectedName);
            }
        }

        private void UpdatePropertyDropDown(string channelName)
        {
            propertyDropDown.Items.Clear();
            propertyDropDown.Items.AddRange(
                _channelProperties.Find(x => x.channelName == channelName)
                .properties.ToArray());

            propertyDropDown.SelectedItem = _selectedSlider.Property;
        }

        private void sliderPropertyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                var index = sliderListBox.SelectedIndex;
                _selectedSlider.Property = propertyDropDown.SelectedItem as string;

                _renameInProgress = true;
                sliderListBox.Items[index] = _selectedSlider.FullParameterName;
                propertyGrid.SelectedObject = _selectedSlider;
                _renameInProgress = false;
                OnValueChanged();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (_selectedSlider != null)
            {
                var index = sliderListBox.SelectedIndex;
                _value.Remove(_selectedSlider);
                _renameInProgress = true;
                sliderListBox.Items.RemoveAt(index);
                _renameInProgress = false;
                if (index == sliderListBox.Items.Count)
                {
                    index--;
                }
                if (_value.Count > 0)
                {
                    sliderListBox.SelectedIndex = index;
                }
                else
                {
                    _selectedSlider = null;
                    propertyGrid.SelectedObject = null;
                }
                OnValueChanged();
            }
        }

        private void showCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                ShowSliders = showCheckBox.Checked;
                OnShowSlidersChanged(ShowSliders);
            }
        }

    }
}
