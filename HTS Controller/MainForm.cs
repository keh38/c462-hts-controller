using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;
using SerilogTraceListener;

using KLib.Net;

namespace TabletInterface
{
    public partial class MainForm : Form
    {
        private IPEndPoint _ipEndPoint;
        private string _serverAddress;

        private CancellationTokenSource _serverCancellationToken;
        private SynchronizationContext _synchronizationContext;

        public MainForm()
        {
            InitializeComponent();
            _synchronizationContext = SynchronizationContext.Current;
        }

        private async Task StartLogging()
        {
            await Task.Run(() =>
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "EPL", "Logs", "HTSController-.txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30,
                    buffered: true)
                .CreateLogger()
                );

            var listener = new SerilogTraceListener.SerilogTraceListener();
            Trace.Listeners.Add(listener);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            await StartLogging();

            Log.Information($"HTS  v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");

            Log.Information("Starting TCP listener");
            StartListener();

            await InitializeTabletConnection();

            subjectButton.Checked = true;
            subjectButton.BackColor = MainForm.DefaultBackColor;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ipEndPoint != null)
            {
                KTcpClient.SendMessage(_ipEndPoint, "Disconnect");

                if (!e.Cancel)
                {
                    _serverCancellationToken.Cancel();
                }
            }
            Log.Information("Exit");
            Log.CloseAndFlush();
        }

        #region Network Methods
        private async Task InitializeTabletConnection()
        {
            await SearchForConnection();

            if (_ipEndPoint != null)
            {
                //await Task.Run(() => GetSubjectInfo());
                //await Task.Run(() => GetTabletConfiguration());
            }
        }

        private async Task SearchForConnection()
        {
            await Task.Run(() => Discover());

            if (_ipEndPoint == null)
            {
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No tablet connection (double-click to retry)";
            }
            else
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = $"Connected to {_ipEndPoint.ToString()}";
            }
        }

        private bool Discover()
        {
            bool success = false;

            _synchronizationContext.Post(
                new SendOrPostCallback(o =>
                {
                    connectionStatusLabel.Image = imageList.Images[0];
                    connectionStatusLabel.Text = "Connecting to tablet...";
                }),
                null);
            Log.Information("Connecting to tablet");

            try
            {
                _ipEndPoint = Discovery.Discover("HEARING.TEST.SUITE");
                if (_ipEndPoint != null)
                {
                    Debug.WriteLine($"contacting host {_ipEndPoint.ToString()}");

                    var result = KTcpClient.SendMessage(_ipEndPoint, $"Connect:{_serverAddress}");
                    if (result > 0)
                    {
                        var sceneName = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetCurrentSceneName");
                        sceneNameLabel.Text = $"Scene: {sceneName}";
                    }
                    success = (result > 0);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); 
                success = false;
                _ipEndPoint = null;
            }

            return success;
        }

        private void StartListener()
        {
            _serverCancellationToken = new CancellationTokenSource();
            Task.Run(() =>
            {
                Listener(_serverCancellationToken.Token);
            }, _serverCancellationToken.Token);
        }

        private void Listener(CancellationToken ct)
        {
            var server = new KTcpListener();
            server.StartListener(4951);

            _serverAddress = server.ListeningOn;
            Debug.WriteLine($"TCP server started on {server.ListeningOn}");

            while (!ct.IsCancellationRequested)
            {
                try
                {
                    if (server.Pending())
                    {
                        ProcessTCPMessage(server);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            server.CloseListener();
            Debug.WriteLine("TCP server stopped");
        }

        private void ProcessTCPMessage(KTcpListener server)
        {
            server.AcceptTcpClient();

            //UserResponse response = null;
            //ErrorDescription error = null;

            //string input = server.ReadString();
            //switch (input)
            //{
            //    case "error":
            //        var bytes = server.ReadBytes();
            //        error = SRI.Messages.Message.FromProtoBuf<ErrorDescription>(bytes);
            //        break;

            //    case "item":
            //        bytes = server.ReadBytes();
            //        _currentItem = SRI.Messages.Message.FromProtoBuf<CurrentItem>(bytes);
            //        break;

            //    case "response":
            //        bytes = server.ReadBytes();
            //        response = SRI.Messages.Message.FromProtoBuf<UserResponse>(bytes);
            //        break;
            //}
            //server.CloseTcpClient();

            //switch (input)
            //{
            //    case "play finished":
            //        _isPlaying = false;
            //        break;

            //    case "error":
            //        _isPlaying = false;
            //        this.Invoke(this.processErrorDelgate, error);
            //        break;

            //    case "item":
            //        this.Invoke(this.showCurrentItemDelegate);
            //        break;

            //    case "response":
            //        this.Invoke(this.processResponseDelgate, response);
            //        break;
            //}
        }

        #endregion

        private void GetSubjectInfo()
        {

        }
    }
}
