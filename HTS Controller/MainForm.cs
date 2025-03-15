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

        List<Tuple<CheckBox, TabPage>> _menu;
        bool _ignoreEvents = false;

        public MainForm()
        {
            InitializeComponent();

            _menu = new List<Tuple<CheckBox, TabPage>>();
            _menu.Add(new Tuple<CheckBox, TabPage>(subjectButton, subjectPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(turandotButton, turandotPage));
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

            //menuPanel.Enabled = false;
            tabControl.SelectedTab = subjectPage;
            SelectTab(null);
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            await StartLogging();

            Log.Information($"HTS  v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");

            Log.Information("Starting TCP listener");
            _network.StartListener();

            connectionTimer.Start();
        }

        private async void connectionTimer_Tick(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                var success = await ConnectToTablet();
                if (success)
                {
                    connectionTimer.Interval = 5000;
                }
            }
            else
            {
                var success = _network.CheckConnection();
                if (!success)
                {
                    connectionTimer.Interval = 500;
                }
            }
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

        private void SelectTab(CheckBox button)
        {
            _ignoreEvents = true;
            foreach (var m in _menu)
            {
                bool isSelected = (m.Item1 == button);
                subjectButton.Checked = isSelected;
                m.Item1.FlatAppearance.BorderColor = isSelected ? Color.Black : menuPanel.BackColor;
                m.Item1.BackColor = isSelected ? MainForm.DefaultBackColor : menuPanel.BackColor;
                m.Item1.FlatAppearance.CheckedBackColor = isSelected ? MainForm.DefaultBackColor : menuPanel.BackColor;
                m.Item1.FlatAppearance.MouseOverBackColor = isSelected ? MainForm.DefaultBackColor : menuPanel.BackColor;
                if (isSelected)
                {
                    tabControl.SelectedTab = m.Item2;
                }
            }
            tabControl.SelectedTab.Focus();
            _ignoreEvents = false;
        }

        private async Task<bool> ConnectToTablet()
        {
            bool success = false;
            try
            {
                success = await _network.Connect();
            }
            catch { }

            if (success)
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = $"Connected to {_network.TabletAddress}";
                sceneNameLabel.Text = $"Scene: {_network.CurrentScene}";

                subjectPageControl.RetrieveSubjectState();
                menuPanel.Enabled = true;
                SelectTab(subjectButton);
            }
            else
            {
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No tablet connection, retrying..."; // (double-click to retry)";
            }
            return success;
        }

        private void menuButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                SelectTab(sender as CheckBox);
            }
        }

        private async void connectionStatusLabel_DoubleClick(object sender, EventArgs e)
        {
            //await ConnectToTablet();
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

        private void interactiveButton_Click(object sender, EventArgs e)
        {
            connectionTimer.Stop();

            //_network.SendMessage("ChangeScene:Turandot Interactive");
            var dlg = new InteractiveForm(_network);
            dlg.ShowDialog();

            connectionTimer.Start();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            _network.SendMessage("ChangeScene:Home");
        }

    }
}
