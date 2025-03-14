using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public InteractiveForm(HTSNetwork network)
        {
            _network = network;
            _packetQueue = new Queue<byte[]>();

            InitializeComponent();
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
                Adapter = "Audio",
                Laterality = Laterality.Diotic,
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
            _sigMan.AddChannel(ch);

            freqBox.FloatValue = (_sigMan.channels[0].waveform as Sinusoid).Frequency_Hz;
            levelBox.FloatValue = _sigMan.channels[0].level.Value;
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
    }
}
