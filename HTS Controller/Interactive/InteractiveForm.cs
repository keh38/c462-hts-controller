using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Controls;
using KLib.Signals.Editor;

using KLib.IO;
using KLib.Net;

using HTS.Tcp;
using C462.Shared;
using Turandot.Editor;
using Bekesy;

using Color = System.Drawing.Color;

using ScottPlot;

namespace HTSController
{
    public partial class InteractiveForm : Form
    {
        private HTSNetwork _network;

        private InteractiveSettings _settings;

        private CancellationTokenSource _udpCancellationToken;
        private CancellationTokenSource _queueCancellationToken;

        private Queue<byte[]> _packetQueue;
        private UDPPacket _udpPacket = new UDPPacket();
        private Task _listenerTask;

        private int _udpPort = 63557;
        private Color _ledOnColor = Color.FromArgb(0, 255, 0);
        private Color _ledOffColor = Color.FromArgb(0, 32, 0);

        private float _plotSampleRate = 48000;

        private bool _ignoreEvents = false;
        private bool _isLive = false;

        private List<ChannelControl> _channelControls;
        private List<Action<float>> _sliderActions;

        private int _packetsReceived = 0;
        private int _lastPacketProcessed = 0;

        private KLib.Signals.SignalManager _signalEngine = new KLib.Signals.SignalManager();

        public string SettingsPath { get; private set; }

        public InteractiveForm(HTSNetwork network, string settingsPath)
        {
            _network = network;
            _network.RemoteMessageHandler += OnRemoteMessage;
            SettingsPath = settingsPath;

            _packetQueue = new Queue<byte[]>();

            InitializeComponent();

            channelControl.ChannelActiveChanged = OnChannelActiveChanged;
        }

        private void InteractiveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _network.RemoteMessageHandler -= OnRemoteMessage;
            Debug.WriteLine("cancelling tokens");
            _udpCancellationToken.Cancel();
            _queueCancellationToken.Cancel();
        }

        private void InteractiveForm_Shown(object sender, EventArgs e)
        {
            AdapterMap adapterMap = null;
            if (_network.IsConnected)
            {
                try
                {
                    adapterMap = _network.SendRequest<AdapterMap>("GetAdapterMap");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"GetAdapterMap failed: {ex.Message}");
                    adapterMap = AdapterMap.Default7point1Map("HD280");
                }
            }
            else
            {
                adapterMap = AdapterMap.Default7point1Map("HD280");
            }

            StartUDP();

            InitializeSettings();

            //_settings.SigMan.AdapterMap = adapterMap;
            channelPropertyGrid.SelectedObject = _settings.SigMan.Channels[0];

            sliderConfig.SetDataForContext(_settings.SigMan.GetValidSweepables());
            sliderConfig.ShowSliders = _settings.ShowSliders;
            sliderConfig.Value = _settings.Sliders;

            //PlotSignals(_settings.SigMan);
            LayoutControls();
        }

        private void StartUDP()
        {
            _udpCancellationToken = new CancellationTokenSource();

            _listenerTask = Task.Run(() =>
            {
                Listener(_udpCancellationToken.Token);
            }, _udpCancellationToken.Token);

            _packetQueue.Clear();
            _queueCancellationToken = new CancellationTokenSource();
            Task.Run(() =>
            {
                ProcessPacketQueue(_queueCancellationToken.Token);
            }, _queueCancellationToken.Token);

            displayTimer.Enabled = true;
        }

        private void Listener(CancellationToken ct)
        {
            UdpClient client = new UdpClient(_udpPort);
            client.Client.ReceiveTimeout = 500;

            var address = _network.MyAddress.Split(':')[0];

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(address), _udpPort);

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    byte[] data = client.Receive(ref ip);
                    _packetQueue.Enqueue(data);
                }
                catch (Exception ex)
                {
                    // timeout or cancellation
                }
            }

            client.Close();
            Debug.WriteLine("UDP listener stopped");
        }

        private void ProcessPacketQueue(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                if (_packetQueue.Count == 0)
                {
                    Thread.Sleep(50);
                }
                else
                {
                    var byteArray = _packetQueue.Dequeue();
                    if (byteArray != null)
                    {
                        _udpPacket.FromByteArray(byteArray);
                        _packetsReceived++;
                    }
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("SetParams", _settings);
            _network.SendMessage("Start");
            startButton.Visible = false;
            _isLive = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("Stop");
            startButton.Visible = true;
            _isLive = false;
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            if (_packetsReceived <= _lastPacketProcessed) return;

            for (int k = 0; k < flowLayoutPanel.Controls.Count; k++)
            {
                (flowLayoutPanel.Controls[k] as ChannelControl).LED.BackColor =
                    (_udpPacket.Amplitudes[k] > 0) ? _ledOnColor : _ledOffColor;
            }

            if (_settings.ShowSliders)
            {
                for (int k = 0; k < _sliderActions.Count; k++)
                {
                    _sliderActions[k]?.Invoke(_udpPacket.Values[k]);
                }
                for (int k = 0; k < _channelControls.Count; k++)
                {
                    if (_udpPacket.Active[k] >= 0)
                    {
                        _channelControls[k].SetActive(_udpPacket.Active[k] > 0);
                    }
                }
            }
        }

        private void InitializeSettings()
        {
            if (string.IsNullOrEmpty(SettingsPath) || !File.Exists(SettingsPath))
            {
                _settings = new InteractiveSettings();
            }
            else
            {
                _settings = Files.XmlDeserialize<InteractiveSettings>(SettingsPath);
            }

            channelListBox.SetItems(_settings.SigMan.Channels.Select(c => c.Name).ToList());
            channelListBox.SelectedIndex = 0;
            signalGraph.Visible = true;

            SetTitle();
        }

        private void SetTitle()
        {
            this.Text = $"Interactive: {_settings.Name}";
        }

        private void channelListBox_ItemAdded(object sender, KUserListBox.ChangedItem e)
        {
            Debug.WriteLine($"added {e.name}");
            //Channel ch = new Channel(e.name, new Waveform());
            //ch.Modality = KLib.Signals.Enumerations.Modality.Audio;
            //ch.Laterality = Laterality.Diotic;
            //channelView.Value = ch;

            //_settings.SigMan.Channels.Insert(e.index, ch);

            CurateControls();
        }

        private void channelView_WaveformBecameValid(object sender, EventArgs e)
        {
        }

        private void channelView_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                //PlotSignals(_settings.SigMan);
                CurateControls();
            }
        }

        private void channelListBox_ItemMoved(object sender, KUserListBox.ChangedItem e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            //Channel ch = _settings.SigMan.GetChannel(e.name);
            //if (ch != null)
            //{
            //    _settings.SigMan.Channels.Remove(ch);
            //    _settings.SigMan.Channels.Insert(e.index, ch);
            //}

            CurateControls();
        }

        private void channelListBox_ItemRenamed(object sender, KUserListBox.ChangedItem e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            _settings.SigMan.Channels[e.index].Name = e.name;

            CurateControls();
        }

        private void channelListBox_ItemsDeleted(object sender, KUserListBox.ChangedItems e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            foreach (string name in e.names)
            {
                //Channel ch = _settings.SigMan.GetChannel(name);
                //if (ch != null) _settings.SigMan.Channels.Remove(ch);
            }
            CurateControls();
        }

        private void channelListBox_ItemsMoved(object sender, KUserListBox.ChangedItems e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            List<Channel> tmp = new List<Channel>();
            foreach (string name in e.names)
            {
                //Channel ch = _settings.SigMan.GetChannel(name);
                //if (ch != null) tmp.Add(ch);
            }

            _settings.SigMan.Channels = tmp;
            CurateControls();
        }

        private void channelListBox_SelectionChanged(object sender, KUserListBox.ChangedItem e)
        {
            if (!_ignoreEvents && !string.IsNullOrEmpty(e.name) && _settings.SigMan != null)
            {
                Channel ch = _settings.SigMan.GetChannel(e.name);
                if (ch != null)
                {
                    channelPropertyGrid.SelectedObject = ch;
                }
            }
        }

        private void PlotSignals(KLib.Signals.SignalManager sigman)
        {
            audioErrorTextBox.Text = "";

            string chanName = "";
            int npts = 0;
            double[] time;
            try
            {
                signalGraph.Plot.Clear();

                float T = 0.001f * sigman.GetMaxInterval(1000);
                T = Math.Min(T, 25);

                npts = (int)(_plotSampleRate * T);

                //if (!string.IsNullOrEmpty(FileLocations.SubjectDataFolder))
                //{
                //    KLib.Signals.Calibration.CalibrationFactory.AudiogramFolder = Path.Combine(FileLocations.SubjectDataFolder, "meta");
                //}
                //else
                //{
                //    KLib.Signals.Calibration.CalibrationFactory.AudiogramFolder = Path.Combine(FileLocations.RootFolder, "Calibrations");
                //}
                sigman.Initialize(_plotSampleRate, npts);
                //channelView.UpdateMaxLevel();

                time = new double[npts];
            }
            catch (Exception ex)
            {
                audioErrorTextBox.Text = ex.Message;
                signalGraph.Refresh();
                graphTabControl.SelectedTab = errorPage;
                return;
            }

            int irow = 0;
            foreach (KLib.Signals.Channel ch in sigman.Channels)
            {
                try
                {
                    chanName = ch.Name;
                    ch.Create();

                    double[] y = new double[npts];
                    var maxVal = ch.Data.Max();
                    double scaleFactor = maxVal > 0 ? 1 / ch.Data.Max() : 1;

                    for (int k = 0; k < npts; k++)
                    {
                        time[k] = k / _plotSampleRate;
                        y[k] = ch.Data[k] * scaleFactor + 2 * irow;
                    }

                    signalGraph.Plot.Add.SignalXY(time, y);
                }
                catch (Exception ex)
                {
                    audioErrorTextBox.Text += chanName + ": " + ex.Message + Environment.NewLine;
                    graphTabControl.SelectedTab = errorPage;
                }
                --irow;
            }

            signalGraph.Plot.Axes.AutoScale();
            // Hide axis label and tick
            signalGraph.Plot.Axes.Left.TickLabelStyle.IsVisible = false;
            signalGraph.Plot.Axes.Left.MajorTickStyle.Length = 0;
            signalGraph.Plot.Axes.Left.MinorTickStyle.Length = 0;
            signalGraph.Plot.XLabel("Time (ms)");

            // Hide axis edge line
            signalGraph.Plot.Axes.Left.FrameLineStyle.Width = 0;
            signalGraph.Plot.Axes.Right.FrameLineStyle.Width = 0;
            signalGraph.Plot.Axes.Top.FrameLineStyle.Width = 0; signalGraph.Refresh();
            graphTabControl.SelectedTab = string.IsNullOrEmpty(audioErrorTextBox.Text) ? graphPage : errorPage;
        }

        private void LayoutControls()
        {
            displayTimer.Enabled = false;

            //LayoutMyControls();
            //InitializeControlValues();

            displayTimer.Enabled = true;
        }

        private void LayoutMyControls()
        {
            _channelControls = new List<ChannelControl>();
            _sliderActions = new List<Action<float>>();

            var chanNames = _settings.SigMan.Channels.Select(x => x.Name).ToList();
            for (int k = 0; k < chanNames.Count; k++)
            {
                var controls = _settings.Sliders.FindAll(x => x.Channel.Equals(chanNames[k]));
                if (k >= flowLayoutPanel.Controls.Count)
                {
                    var c = new ChannelControl();
                    c.ChannelActiveChanged = OnChannelActiveChanged;
                    flowLayoutPanel.Controls.Add(c);
                }
                _channelControls.Add(flowLayoutPanel.Controls[k] as ChannelControl);
                _channelControls[k].LayoutControls(chanNames[k], controls, OnPropertyValueChanged);

                foreach (var c in controls)
                {
                    var pc = _channelControls[k].GetPropertyControl(c.Property);
                    if (pc != null)
                    {
                        _sliderActions.Add(x => pc.SetValue(x));
                    }
                    else
                    {
                        _sliderActions.Add(null);
                    }
                }
            }

            int nremove = flowLayoutPanel.Controls.Count - chanNames.Count;
            for (int k = 0; k < nremove; k++) flowLayoutPanel.Controls.RemoveAt(chanNames.Count);
        }

        private void InitializeSliders()
        {
            _sliderActions = new List<Action<float>>();

            foreach (var s in _settings.Sliders)
            {
                var pc = _channelControls.Find(x => x.ChannelName.Equals(s.Channel))?.GetPropertyControl(s.Property);
                if (pc != null)
                {
                    _sliderActions.Add(x => pc.SetValue(x));
                }
                else
                {
                    _sliderActions.Add(null);
                }
            }
        }

        private void InitializeControlValues()
        {
            foreach (var s in _settings.Sliders)
            {
                //_settings.SigMan.SetParameter(s.Channel, s.Property, s.StartValue);
            }
            //channelView.UpdateParameters();
            //PlotSignals(_settings.SigMan);
        }

        private void CurateControls()
        {
            //var valid = _settings.SigMan.GetValidSweepables();

            //var toDelete = new List<Turandot.Inputs.ParameterSliderProperties>();
            //foreach (var s in _settings.Sliders)
            //{
            //    if (valid.Find(x => x.channelName.Equals(s.Channel) && x.properties.Contains(s.Property)) == null)
            //    {
            //        toDelete.Add(s);
            //    }
            //}
            //foreach (var c in toDelete) _settings.Sliders.Remove(c);

            //LayoutControls();
        }

        private void OnChannelActiveChanged(string channel, bool enabled, bool selfChange)
        {
            //if (selfChange && (_isLive || (_network.IsConnected && _settings.ShowSliders)))
            //{
            //    _network.SendMessage("SetActive", $"{channel}={(enabled ? 1 : 0)}");
            //}
            //_settings.SigMan[channel].SetActive(enabled);
        }

        private void OnPropertyValueChanged(string channel, string property, float value, bool selfChange)
        {
            //if (selfChange && (_isLive || (_network.IsConnected && _settings.ShowSliders)))
            //{
            //    _network.SendMessage("SetProperty", $"{channel}.{property}={value}");
            //}

            //_settings.SigMan.SetParameter(channel, property, value);
            ////channelView.UpdateParameters();
            //_settings.Sliders.Find(x => x.Channel.Equals(channel) && x.Property.Equals(property)).StartValue = value;
            //PlotSignals(_settings.SigMan);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();

            dlg.InitialDirectory = FileLocations.ConfigFolder;
            dlg.FileName = Path.GetFileName(SettingsPath);
            dlg.Filter = "Interactive settings | Interactive.*.xml";
            dlg.OverwritePrompt = true;

            var result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                var folder = Path.GetDirectoryName(dlg.FileName);
                var name = Path.GetFileNameWithoutExtension(dlg.FileName);
                if (name.StartsWith("Interactive."))
                {
                    name = name.Remove(0, ("Interactive.").Length);
                }

                _settings.Name = name;
                SettingsPath = Path.Combine(folder, $"Interactive.{name}.xml");
                Files.XmlSerialize(_settings, SettingsPath);
                SetTitle();
            }
        }

        private void controlGridView_ValueChanged(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void sliderConfig_ShowSlidersChanged(object sender, bool show)
        {
            if (_ignoreEvents) return;

            _settings.ShowSliders = show;
            if (_isLive)
            {
                _network.SendMessage("ShowSliders", show.ToString());
            }
            else if (_network.IsConnected)
            {
                _network.SendMessage("SetParams", Files.ToXMLString(_settings));
            }
        }

        private void sliderConfig_ValueChanged(object sender, EventArgs e)
        {
            var x = sliderConfig.Value;
            CurateControls();
        }

        private void OnRemoteMessage(object sender, TcpMessage message)
        {
            var payload = message.GetPayload<RemoteMessagePayload>();
            if (!payload.Target.Equals("TurandotInteractive")) return;

            switch (message.Command)
            {
                case "Error":
                    Invoke(new Action(() =>
                    {
                        audioErrorTextBox.Text = $"Remote error: {payload.Data}" + Environment.NewLine;
                        graphTabControl.SelectedTab = errorPage;
                    }));
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xml = Files.ToXMLString(_settings.SigMan);
            _signalEngine = Files.FromXMLString<KLib.Signals.SignalManager>(xml);
            _signalEngine.AdapterMap = AdapterMap.DefaultStereoMap("HD280");
            PlotSignals(_signalEngine);
        }

        private void channelPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var xml = Files.ToXMLString(_settings.SigMan);
            _signalEngine = Files.FromXMLString<KLib.Signals.SignalManager>(xml);
            _signalEngine.AdapterMap = AdapterMap.DefaultStereoMap("HD280");
            PlotSignals(_signalEngine);
        }
    }
}
