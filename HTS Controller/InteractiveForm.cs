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
using KLib.Signals;
using KLib.Signals.Waveforms;

using KLib;

using Turandot.Interactive;

namespace HTSController
{
    public partial class InteractiveForm : Form
    {
        private HTSNetwork _network;

        private InteractiveSettings _settings;

        private CancellationTokenSource _udpCancellationToken;
        private CancellationTokenSource _queueCancellationToken;

        private Queue<byte[]> _packetQueue;
        private Task _listenerTask;

        private int _udpPort = 63557;
        private float[] amplitudes = null;
        private Color _ledOnColor = Color.FromArgb(0, 255, 0);
        private Color _ledOffColor = Color.FromArgb(0, 32, 0);

        private float _plotSampleRate = 48000;

        private bool _ignoreEvents = false;
        private bool _isLive = false;

        public string SettingsPath { get; private set; }

        public InteractiveForm(HTSNetwork network, string settingsPath)
        {
            _network = network;
            SettingsPath = settingsPath;

            _packetQueue = new Queue<byte[]>();

            InitializeComponent();

            channelControl.ChannelActiveChanged = OnChannelActiveChanged;

            KLib.KGraphics.ZedGraphUtils.InitZedGraph(signalGraph, "Time (s)", "");
            signalGraph.MasterPane.Fill.Type = ZedGraph.FillType.None;
            signalGraph.MasterPane.Border.IsVisible = false;
            signalGraph.GraphPane.Fill.Type = ZedGraph.FillType.None;
            signalGraph.GraphPane.Border.IsVisible = false;
            signalGraph.GraphPane.Chart.Fill.Type = ZedGraph.FillType.None;
            signalGraph.GraphPane.YAxis.IsVisible = false;
            signalGraph.Refresh();
        }

        private void InteractiveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _udpCancellationToken.Cancel();
            _queueCancellationToken.Cancel();
        }

        private void InteractiveForm_Shown(object sender, EventArgs e)
        {
            var adapterMap = _network.SendMessageAndReceiveXml<AdapterMap>("GetAdapterMap");
            adapterMap = AdapterMap.Default7point1Map();
            adapterMap.AudioTransducer = "HD280";

            StartUDP();

            InitializeSettings();

            _settings.SigMan.AdapterMap = adapterMap;
            channelView.AdapterMap = adapterMap;
            channelView.Value = _settings.SigMan.channels[0];

            controlGridView.SetDataForContext(_settings.SigMan.GetValidProperties());
            controlGridView.Value = _settings.Controls;

            PlotSignals(_settings.SigMan);
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
                    //Debug.WriteLine(ex.Message);
                }
            }

            client.Close();
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
                        var floatArray = new float[byteArray.Length / sizeof(float)];
                        Buffer.BlockCopy(byteArray, 0, floatArray, 0, byteArray.Length);
                        amplitudes = floatArray;
                    }
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage($"SetParams:{KFile.ToXMLString(_settings)}");
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
            if (amplitudes == null) return;

            for (int k = 0; k < flowLayoutPanel.Controls.Count; k++)
            {
                (flowLayoutPanel.Controls[k] as ChannelControl).LED.BackColor =
                    (amplitudes[k] > 0) ? _ledOnColor : _ledOffColor;
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
                _settings = KFile.XmlDeserialize<InteractiveSettings>(SettingsPath);
            }

            channelListBox.SetItems(_settings.SigMan.channels.Select(c => c.Name).ToList());
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
            Channel ch = new Channel(e.name, new Waveform());
            ch.Modality = KLib.Signals.Enumerations.Modality.Audio;
            ch.Laterality = Laterality.Diotic;
            channelView.Value = ch;

            _settings.SigMan.channels.Insert(e.index, ch);
            CurateControls();
        }

        private void channelView_WaveformBecameValid(object sender, EventArgs e)
        {
            //if (_selectedState.sigMan == null) _selectedState.sigMan = new SignalManager();
            //_selectedState.sigMan.channels.Insert(channelListBox.SelectedIndex, channelView.Data);
        }

        private void channelView_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                PlotSignals(_settings.SigMan);
                CurateControls();
            }
        }

        private void channelListBox_ItemMoved(object sender, KUserListBox.ChangedItem e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            Channel ch = _settings.SigMan.GetChannel(e.name);
            if (ch != null)
            {
                _settings.SigMan.channels.Remove(ch);
                _settings.SigMan.channels.Insert(e.index, ch);
            }

            CurateControls();
        }

        private void channelListBox_ItemRenamed(object sender, KUserListBox.ChangedItem e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            Channel ch = _settings.SigMan.channels[e.index];

            if (ch != null)
            {
                string oldname = ch.Name;
                ch.Name = e.name;
                channelView.Value = ch;

                foreach (var c in _settings.Controls)
                {
                    if (c.channel.Equals(oldname))
                    {
                        c.channel = e.name;
                    }
                }

            }
            CurateControls();
        }

        private void channelListBox_ItemsDeleted(object sender, KUserListBox.ChangedItems e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            foreach (string name in e.names)
            {
                Channel ch = _settings.SigMan.GetChannel(name);
                if (ch != null) _settings.SigMan.channels.Remove(ch);
            }
            CurateControls();
        }

        private void channelListBox_ItemsMoved(object sender, KUserListBox.ChangedItems e)
        {
            if (_ignoreEvents || _settings.SigMan == null) return;

            List<Channel> tmp = new List<Channel>();
            foreach (string name in e.names)
            {
                Channel ch = _settings.SigMan.GetChannel(name);
                if (ch != null) tmp.Add(ch);
            }

            _settings.SigMan.channels = tmp;
            CurateControls();
        }

        private void channelListBox_SelectionChanged(object sender, KUserListBox.ChangedItem e)
        {
            if (!_ignoreEvents)
            {
                Channel ch = null;
                if (_settings.SigMan != null) ch = _settings.SigMan.GetChannel(e.name);
                if (ch == null)
                {
                    ch = new Channel(e.name);
                    ch.Laterality = Laterality.Diotic;
                }
                channelView.Value = ch;
            }
        }

        private void PlotSignals(SignalManager sigman)
        {
            //sigman.WavFolder = Path.Combine(_settings.wavFolder, _params.wavFolder);

            audioErrorTextBox.Text = "";

            string chanName = "";
            int npts = 0;
            double[] time;
            try
            {
                signalGraph.GraphPane.CurveList.Clear();

                float T = 0.001f * sigman.GetMaxInterval(1000);
                T = Math.Min(T, 25);

                npts = (int)(_plotSampleRate * T);

                sigman.Initialize(_plotSampleRate, npts);
                channelView.UpdateMaxLevel();

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
            foreach (Channel ch in sigman.channels)
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

                    signalGraph.GraphPane.AddCurve("", time, y, Color.Blue, ZedGraph.SymbolType.None);
                }
                catch (Exception ex)
                {
                    audioErrorTextBox.Text += chanName + ": " + ex.Message + Environment.NewLine;
                    graphTabControl.SelectedTab = errorPage;
                }
                --irow;
            }

            signalGraph.GraphPane.XAxis.Scale.Min = time.Min();
            signalGraph.GraphPane.XAxis.Scale.Max = time.Max();
            signalGraph.GraphPane.YAxis.Scale.Min = -sigman.channels.Count * 2 + 0.75;
            signalGraph.GraphPane.YAxis.Scale.Max = 1.25;
            signalGraph.GraphPane.YAxis.IsVisible = false;
            signalGraph.Refresh();
            graphTabControl.SelectedTab = string.IsNullOrEmpty(audioErrorTextBox.Text) ? graphPage : errorPage;
        }

        private void LayoutControls()
        {
            InitializeControlValues();

            var chanNames = _settings.SigMan.channels.Select(x => x.Name).ToList();
            for (int k=0; k < chanNames.Count; k++)
            {
                var controls = _settings.Controls.FindAll(x => x.channel.Equals(chanNames[k]));
                if (k >= flowLayoutPanel.Controls.Count)
                {
                    var c = new ChannelControl();
                    c.ChannelActiveChanged = OnChannelActiveChanged;
                    flowLayoutPanel.Controls.Add(c);
                }
                (flowLayoutPanel.Controls[k] as ChannelControl).LayoutControls(chanNames[k], controls, OnPropertyValueChanged);
            }

            int nremove = flowLayoutPanel.Controls.Count - chanNames.Count;
            for (int k = 0; k < nremove; k++) flowLayoutPanel.Controls.RemoveAt(chanNames.Count);
        }

        private void InitializeControlValues()
        {
            foreach (var c in _settings.Controls)
            {
                c.value = _settings.SigMan.GetParameter(c.channel, c.property);
            }
        }

        private void CurateControls()
        {
            var valid = _settings.SigMan.GetValidProperties();

            var toDelete = new List<InteractiveControl>();
            foreach (var c in _settings.Controls)
            {
                if (valid.Find(x => x.channelName.Equals(c.channel) && x.properties.Contains(c.property)) == null)
                {
                    toDelete.Add(c);
                }
            }
            foreach (var c in toDelete) _settings.Controls.Remove(c);

            controlGridView.SetDataForContext(_settings.SigMan.GetValidProperties());
            controlGridView.Value = _settings.Controls;

            LayoutControls();
        }

        private void OnChannelActiveChanged(string channel, bool enabled)
        {
            if (_isLive)
            {
                _network.SendMessage($"SetActive:{channel}={(enabled?1:0)}");
            }
        }

        private void OnPropertyValueChanged(string channel, string property, float value)
        {
            if (_isLive)
            {
                _network.SendMessage($"SetProperty:{channel}.{property}={value}");
            }

            _settings.SigMan.SetParameter(channel, property, value);
            channelView.UpdateParameters();
            PlotSignals(_settings.SigMan);
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
                KFile.XmlSerialize(_settings, SettingsPath);
                SetTitle();
            }
        }

        private void controlGridView_ValueChanged(object sender, EventArgs e)
        {
            LayoutControls();
        }
    }
}
