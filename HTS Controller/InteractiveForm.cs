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

namespace HTSController
{
    public partial class InteractiveForm : Form
    {
        private HTSNetwork _network;

        private CancellationTokenSource _udpCancellationToken;
        private CancellationTokenSource _queueCancellationToken;

        private Queue<byte[]> _packetQueue;
        private Task _listenerTask;

        private int _udpPort = 63557;
        private float amplitude = 0;
        private Color _ledOnColor = Color.FromArgb(0, 255, 0);
        private Color _ledOffColor = Color.FromArgb(0, 32, 0);

        private SignalManager _sigMan;

        private float _plotSampleRate = 48000;

        private bool _ignoreEvents = false;

        public InteractiveForm(HTSNetwork network)
        {
            _network = network;
            _packetQueue = new Queue<byte[]>();

            InitializeComponent();

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
            StartUDP();
            CreateDefaultSignalManager();
            channelView.Value = _sigMan.channels[0];
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
                        var floatArray2 = new float[byteArray.Length / sizeof(float)];
                        Buffer.BlockCopy(byteArray, 0, floatArray2, 0, byteArray.Length);
                        amplitude = floatArray2[0];
                    }
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("Start");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("Stop");
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            led1.BackColor = (amplitude > 0) ? _ledOnColor : _ledOffColor;
        }

        private void CreateDefaultSignalManager()
        {
            var ch = new Channel()
            {
                Name = "Audio",
                Modality = KLib.Signals.Enumerations.Modality.Audio,
                Laterality = Laterality.Diotic,
                Location = "Site 2",
                waveform = new Sinusoid()
                {
                    Frequency_Hz = 500
                },
                modulation = new KLib.Signals.Modulations.SinusoidalAM()
                {
                    Frequency_Hz = 40,
                    Depth = 1
                },
                gate = new Gate()
                {
                    Active = true,
                    Duration_ms = 250,
                    Period_ms = 1000
                },
                level = new Level()
                {
                    Units = LevelUnits.dB_attenuation,
                    Value = -20
                }
            };

            _sigMan = new SignalManager();
            _sigMan.AdapterMap = AdapterMap.DefaultStereoMap();
            _sigMan.AddChannel(ch);

            freqBox.FloatValue = (_sigMan.channels[0].waveform as Sinusoid).Frequency_Hz;
            levelBox.FloatValue = _sigMan.channels[0].level.Value;

            channelListBox.SetItems(_sigMan.channels.Select(c => c.Name).ToList());
            channelListBox.SelectedIndex = 0;
            signalGraph.Visible = true;
            PlotSignals(_sigMan);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage($"SetParams:{KFile.ToXMLString(_sigMan)}");
        }

        private void freqBox_ValueChanged(object sender, EventArgs e)
        {
            _network.SendMessage($"SetParameter:Audio.Tone.Frequency_Hz={freqBox.FloatValue}");
        }

        private void levelBox_ValueChanged(object sender, EventArgs e)
        {
            _network.SendMessage($"SetParameter:Audio.Level={levelBox.FloatValue}");
        }

        private void channelListBox_ItemAdded(object sender, KUserListBox.ChangedItem e)
        {
            Channel ch = new Channel(e.name, new Waveform());
            ch.Modality = KLib.Signals.Enumerations.Modality.Audio;
            ch.Laterality = Laterality.Diotic;
            channelView.Value = ch;

            _sigMan.channels.Insert(e.index, ch);
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
                PlotSignals(_sigMan);
            }
        }

        private void channelListBox_ItemMoved(object sender, KUserListBox.ChangedItem e)
        {
            if (_ignoreEvents || _sigMan == null) return;

            Channel ch = _sigMan.GetChannel(e.name);
            if (ch != null)
            {
                _sigMan.channels.Remove(ch);
                _sigMan.channels.Insert(e.index, ch);
            }
        }

        private void channelListBox_ItemRenamed(object sender, KUserListBox.ChangedItem e)
        {
            if (_ignoreEvents || _sigMan == null) return;

            Channel ch = _sigMan.channels[e.index];

            if (ch != null)
            {
                string oldname = ch.Name;
                ch.Name = e.name;
                channelView.Value = ch;
            }
        }

        private void channelListBox_ItemsDeleted(object sender, KUserListBox.ChangedItems e)
        {
            if (_ignoreEvents || _sigMan == null) return;

            foreach (string name in e.names)
            {
                Channel ch = _sigMan.GetChannel(name);
                if (ch != null) _sigMan.channels.Remove(ch);
            }

            if (_sigMan.channels.Count == 0)
            {
                _sigMan = null;
            }
        }

        private void channelListBox_ItemsMoved(object sender, KUserListBox.ChangedItems e)
        {
            if (_ignoreEvents || _sigMan == null) return;

            List<Channel> tmp = new List<Channel>();
            foreach (string name in e.names)
            {
                Channel ch = _sigMan.GetChannel(name);
                if (ch != null) tmp.Add(ch);
            }

            _sigMan.channels = tmp;
        }

        private void channelListBox_SelectionChanged(object sender, KUserListBox.ChangedItem e)
        {
            if (!_ignoreEvents)
            {
                Channel ch = null;
                if (_sigMan != null) ch = _sigMan.GetChannel(e.name);
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
            //sigman.CalibrationFolder = _settings.calFolder;
            //sigman.WavFolder = Path.Combine(_settings.wavFolder, _params.wavFolder);

            audioErrorTextBox.Text = "";
            audioErrorTextBox.Visible = false;

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
                audioErrorTextBox.Visible = true;
                signalGraph.Refresh();

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
                    double scaleFactor = 1 / ch.Data.Max();

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
                    audioErrorTextBox.Visible = true;
                }
                --irow;
            }

            signalGraph.GraphPane.XAxis.Scale.Min = time.Min();
            signalGraph.GraphPane.XAxis.Scale.Max = time.Max();
            signalGraph.GraphPane.YAxis.Scale.Min = -sigman.channels.Count * 2 + 0.75;
            signalGraph.GraphPane.YAxis.Scale.Max = 1.25;
            signalGraph.GraphPane.YAxis.IsVisible = false;
            signalGraph.Refresh();
        }

    }
}
