using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json;

using KLib.Signals;

namespace Turandot.Inputs
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ParamSliderAction : Input
    {
        // NOTE: ChannelConverter and PropertyConverter are inner TypeConverter classes kept as pure data/converter classes.
        internal class ContextItems
        {
            internal static string _selectedChannel;
            internal static string[] _listOfChannels;
            internal static string[] _listOfProperties;
            internal static List<ChannelProperties> _validProperties;
        }

        public enum SliderScale { Linear, Log }

        public bool reset;
        public float startRange = 0;
        public float shrinkFactor = 0;
        public bool showButton = true;

        [Category("Appearance")]
        public string Label { set; get; }

        [Category("Appearance")]
        public string MinLabel { set; get; }

        [Category("Appearance")]
        public string MaxLabel { set; get; }

        [Category("Appearance")]
        public int FontSize { set; get; }

        [Category("Behavior")]
        [Description("Hides the slider fill")]
        public bool ThumbOnly { set; get; }

        [Category("Behavior")]
        public bool BarClickable { set; get; }

        [Category("Behavior")]
        public bool ThumbTogglesSound { set; get; }

        [Category("Scale")]
        public float Min { set; get; }

        [Category("Scale")]
        public float Max { set; get; }

        [Category("Scale")]
        public SliderScale Scale { set; get; }

        [Category("Parameter")]
        public float StartValue { get; set; }

        private string _channel;
        [Category("Parameter")]
        [TypeConverter(typeof(ChannelConverter))]
        public string Channel
        {
            get
            {
                string channel = "";
                if (_channel != null)
                {
                    channel = _channel;
                }
                else
                {
                    channel = "";
                    if (ContextItems._listOfChannels != null && ContextItems._listOfChannels.Length > 0)
                    {
                        Array.Sort(ContextItems._listOfChannels);
                        channel = ContextItems._listOfChannels[0];
                        _channel = channel;
                    }
                }
                return channel;
            }
            set
            {
                _channel = value;
                ContextItems._selectedChannel = _channel;
                if (ContextItems._validProperties != null)
                {
                    ContextItems._listOfProperties = ContextItems._validProperties.Find(x => x.channelName == _channel).properties.ToArray();
                }
            }
        }

        private string _parameter;
        [Category("Parameter")]
        [TypeConverter(typeof(PropertyConverter))]
        public string Property
        {
            get
            {
                string parameter = "";
                if (_parameter != null)
                {
                    parameter = _parameter;
                }
                else
                {
                    _parameter = "";
                    if (ContextItems._listOfChannels != null && ContextItems._listOfProperties.Length > 0)
                    {
                        Array.Sort(ContextItems._listOfProperties);
                        parameter = ContextItems._listOfProperties[0];
                        _parameter = parameter;
                    }
                }
                return parameter;
            }
            set
            {
                _parameter = value;
            }
        }

        public ParamSliderAction() : base("Param Slider")
        {
            Label = "";
            MinLabel = "";
            MaxLabel = "";
            ThumbOnly = false;
            BarClickable = false;
            ThumbTogglesSound = true;
            FontSize = 48;
        }

        public class ChannelConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(ContextItems._listOfChannels);
            }
        }

        public class PropertyConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
            public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(ContextItems._listOfProperties);
            }
        }
    }
}
