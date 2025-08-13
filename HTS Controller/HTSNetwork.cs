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
        public event EventHandler<string> RemoteMessageHandler;
        private void OnRemoteMessage(string message) { RemoteMessageHandler?.Invoke(this, message); }


        private IPEndPoint _ipEndPoint;
        private string _serverAddress;
        private bool _lastPingSucceeded = false;
        private string _remoteVersionNumber = "";

        private CancellationTokenSource _serverCancellationToken;

        public bool IsConnected { get { return _ipEndPoint != null && _lastPingSucceeded; } }
        public bool IsLocalConnection { get { return _ipEndPoint != null && _serverAddress.StartsWith(_ipEndPoint.Address.ToString()); } }
        public string CurrentScene { get; private set; }
        public string TabletAddress { get { return (_ipEndPoint == null) ? "" : _ipEndPoint.ToString(); } }
        public string MyAddress { get { return _serverAddress; } }
        public string TabletVersion { get { return _remoteVersionNumber; } }

        public HTSNetwork() { }

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

        public bool CheckConnection()
        {
            bool connected = false;
            if (_ipEndPoint != null)
            {
                var result = KTcpClient.SendMessage(_ipEndPoint, "Ping");
                connected = result > 0;
                _lastPingSucceeded = connected;
            }

            return connected;
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

        public T SendMessageAndReceiveXml<T>(string message)
        {
            var data = default(T);
            if (_ipEndPoint != null)
            {
                var response = KTcpClient.SendMessageReceiveString(_ipEndPoint, message);
                data = KFile.FromXMLString<T>(response);
            }

            return data;
        }

        private bool Discover()
        {
            bool success = false;

            try
            {
                _ipEndPoint = Discovery.Discover("HEARING.TEST.SUITE");
                if (_ipEndPoint != null)
                {
                    Log.Information($"contacting host {_ipEndPoint.ToString()}");

                    var result = KTcpClient.SendMessage(_ipEndPoint, $"Connect:{_serverAddress.Replace(":", "/")}");
                    if (result > 0)
                    {
                        Log.Information("connected!");
                        CurrentScene = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetCurrentSceneName");
                        _remoteVersionNumber = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetVersionNumber");
                    }
                    else
                    {
                        Log.Information("remote host busy");
                    }
                    success = (result > 0);
                    _lastPingSucceeded = success;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                success = false;
                _ipEndPoint = null;
            }

            return success;
        }

        public void StartListener()
        {
            var serverEndPoint = Discovery.FindNextAvailableEndPoint();

            _serverCancellationToken = new CancellationTokenSource();
            Task.Run(() =>
            {
                Listener(serverEndPoint, _serverCancellationToken.Token);
            }, _serverCancellationToken.Token);
        }

        private void Listener(IPEndPoint serverEndPoint, CancellationToken ct)
        {
            var server = new KTcpListener();
            server.StartListener(serverEndPoint);

            _serverAddress = server.ListeningOn;
            if (_serverAddress.StartsWith("localhost"))
            {
                _serverAddress = _serverAddress.Replace("localhost", "127.0.0.1");
            }
            Log.Information($"TCP server started on {server.ListeningOn}");

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
                    Log.Information(ex.Message);
                }
            }

            server.CloseListener();
            Log.Information("TCP server stopped");
        }

        private void ProcessTCPMessage(KTcpListener server)
        {
            server.AcceptTcpClient();

            string input = server.ReadString();
            server.SendAcknowledgement();
            server.CloseTcpClient();

            if (input.StartsWith("ChangedScene"))
            {
                CurrentScene = input.Substring(("ChangedScene:").Length);
                Log.Information($"Tablet reports scene changed to {CurrentScene}");
            }

            OnRemoteMessage(input);
        }

    }
}
