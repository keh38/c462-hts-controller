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

using KLib;
using KLib.Net;

namespace HTSController
{
    public class HTSNetwork
    {
        public delegate void RemoteMessageHandlerDelegate (string message);
        public RemoteMessageHandlerDelegate RemoteMessageHandler { set; get; } = null;

        private IPEndPoint _ipEndPoint;
        private string _serverAddress;
        private int _serverPort = 4951;

        private CancellationTokenSource _serverCancellationToken;

        public bool IsConnected { get { return _ipEndPoint != null; } }
        public string CurrentScene { get; private set; }
        public string TabletAddress { get { return (_ipEndPoint == null) ? "" : _ipEndPoint.ToString(); } }
        public string MyAddress { get { return _serverAddress; } }

        public HTSNetwork()
        {
        }

        public async Task<bool> Connect()
        {
            return await Task.Run(() => Discover());
        }

        public void Disconnect()
        {
            if (_ipEndPoint != null)
            {
                KTcpClient.SendMessage(_ipEndPoint, "Disconnect");
                _serverCancellationToken.Cancel();
            }
        }

        public bool SendMessage(string message)
        {
            var response = KTcpClient.SendMessage(_ipEndPoint, message);
            return response > 0;
        }

        public string SendMessageAndReceiveString(string message)
        {
            string response = null;
            if (_ipEndPoint != null)
            {
                response = KTcpClient.SendMessageReceiveString(_ipEndPoint, message);
            }

            return response;
        }

        public T SendMessageAndReceiveJSON<T>(string message)
        {
            var data = default(T);
            if (_ipEndPoint != null)
            {
                var response = KTcpClient.SendMessageReceiveString(_ipEndPoint, message);
                data = KFile.JSONDeserializeFromString<T>(response);
            }

            return data;
        }

        private bool Discover()
        {
            bool success = false;

            Log.Information("Discovering...");

            try
            {
                _ipEndPoint = Discovery.Discover("HEARING.TEST.SUITE");
                if (_ipEndPoint != null)
                {
                    Debug.WriteLine($"contacting host {_ipEndPoint.ToString()}");

                    var result = KTcpClient.SendMessage(_ipEndPoint, $"Connect:{_serverAddress.Replace(":","/")}");
                    if (result > 0)
                    {
                        CurrentScene = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetCurrentSceneName");
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

        public void StartListener()
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
            server.StartListener(_serverPort);

            _serverAddress = server.ListeningOn;
            if (_serverAddress.StartsWith("localhost"))
            {
                _serverAddress = _serverAddress.Replace("localhost", "127.0.0.1");
            }
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

            string input = server.ReadString();
            server.SendAcknowledgement();
            server.CloseTcpClient();

            if (RemoteMessageHandler != null)
            {
                RemoteMessageHandler.Invoke(input);
            }
        }

    }
}
