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

namespace HTSController
{
    public partial class MainForm : Form
    {
        HTSNetwork _network;

        public MainForm()
        {
            InitializeComponent();
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
            _network = new HTSNetwork();
            _network.RemoteMessageHandler = HandleRemoteMessage;

            subjectPageControl.Initialize(_network);

            menuPanel.Enabled = false;
            subjectButton.Checked = false;
            subjectButton.BackColor = menuPanel.BackColor;
            //subjectButton.BackColor = MainForm.DefaultBackColor;
            tabControl.SelectedTab = subjectPage;
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            await StartLogging();

            Log.Information($"HTS  v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");

            Log.Information("Starting TCP listener");
            _network.StartListener();

            await ConnectToTablet();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                _network.Disconnect();
            }

            Log.Information("Exit");
            Log.CloseAndFlush();
        }

        private async Task ConnectToTablet()
        {
            var success = await _network.Connect();

            if (success)
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = $"Connected to {_network.TabletAddress}";
                sceneNameLabel.Text = $"Scene: {_network.CurrentScene}";

                subjectPageControl.RetrieveSubjectState();
                menuPanel.Enabled = true;
                subjectButton.Checked = true;
                subjectButton.BackColor = MainForm.DefaultBackColor;
            }
            else
            {
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No tablet connection (double-click to retry)";
            }
        }

        private void menuButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void connectionStatusLabel_DoubleClick(object sender, EventArgs e)
        {
            await ConnectToTablet();
        }

        private void subjectPageControl_ValueChanged(object sender, EventArgs e)
        {
            subjectButton.Text = string.IsNullOrEmpty(subjectPageControl.Subject) ? "Subject" : subjectPageControl.Subject;
        }

        private void HandleRemoteMessage(string fullMessage)
        {
            var parts = fullMessage.Split(':');
            string message = parts[0];
            string data = (parts.Length > 1) ? parts[1] : null;

            switch (message)
            {
                case "ChangedScene":
                    sceneNameLabel.Text = $"Scene: {data}";
                    break;
            }
        }
    }
}
