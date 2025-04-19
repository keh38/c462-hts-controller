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

using HTSController.Data_Streams;

namespace HTSController
{
    public partial class MainForm : Form
    {
        HTSNetwork _network;
        DataStreamManager _streamManager;
        TurandotLiveForm _liveForm = null;
        PupillometryForm _pupilForm = null;

        List<Tuple<CheckBox, TabPage>> _menu;
        bool _ignoreEvents = false;

        public MainForm()
        {
            InitializeComponent();
            tableLayoutPanel.ColumnStyles[1].Width = 0;

            _menu = new List<Tuple<CheckBox, TabPage>>();
            _menu.Add(new Tuple<CheckBox, TabPage>(subjectButton, subjectPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(turandotButton, turandotSettingsPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(pupilButton, pupilPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(adminButton, adminPage));
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
            _network.RemoteMessageHandler += OnRemoteMessage;

            subjectPageControl.Initialize(_network);
            turandotPageControl.Initialize(_network);

            //menuPanel.Enabled = false;
            //            tabControl.SelectedTab = subjectPage;
            subjectButton.Checked = true;
//            SelectTab(null);
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            await StartLogging();

            Log.Information($"HTS  v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");

            Log.Information("Starting TCP listener");
            _network.StartListener();

            connectionStatusLabel.Image = imageList.Images[0];
            connectionStatusLabel.Text = "No tablet connection yet"; // (double-click to retry)";

            _streamManager = new DataStreamManager();
            _streamManager.Initialize(_network, ipcLayoutPanel);

            connectionTimer.Start();

            matlabStatusLabel.Text = "Connecting...";
            matlabStatusLabel.Visible = true;
            var haveMATLAB = await MATLAB.Initialize();
            matlabStatusLabel.Visible = haveMATLAB;
            matlabStatusLabel.Text = "Available";
            MATLAB.UpdateMetrics = subjectPageControl.UpdateMetrics;
        }

        private async void connectionTimer_Tick(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                try
                {
                    connectionTimer.Enabled = false;
                    var success = await ConnectToTablet();
                    if (success)
                    {
                        connectionTimer.Interval = 5000;
                        subjectPageControl.Enabled = true;
                        turandotPageControl.NetworkStatusChanged();
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
                connectionTimer.Enabled = true;
            }
            else
            {
                var success = _network.CheckConnection();
                if (!success)
                {
                    Log.Information("Tablet connection lost");
                    subjectPageControl.Enabled = false;
                    turandotPageControl.NetworkStatusChanged();
                    connectionStatusLabel.Image = imageList.Images[0];
                    connectionStatusLabel.Text = "No tablet connection, retrying..."; // (double-click to retry)";
                    connectionTimer.Interval = 500;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _streamManager.Cleanup();
            MATLAB.CleanUp();

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
                m.Item1.Checked = isSelected;
                SetMenuButtonColors(m.Item1);
                if (isSelected)
                {
                    tabControl.SelectedTab = m.Item2;
                }
            }
            tabControl.SelectedTab.Focus();
            _ignoreEvents = false;
        }

        private void SetMenuButtonColors(CheckBox button)
        {
            button.FlatAppearance.BorderColor = button.Checked ? Color.Black : menuPanel.BackColor;
            button.BackColor = button.Checked ? MainForm.DefaultBackColor : menuPanel.BackColor;
            button.FlatAppearance.CheckedBackColor = button.Checked ? MainForm.DefaultBackColor : menuPanel.BackColor;
            button.FlatAppearance.MouseOverBackColor = button.Checked ? MainForm.DefaultBackColor : menuPanel.BackColor;
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
                ////connectionStatusLabel.Image = imageList.Images[0];
                //connectionStatusLabel.Text = "No tablet connection, retrying..."; // (double-click to retry)";
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

        private void OnRemoteMessage(object sender, string fullMessage)
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

        private void homeButton_Click(object sender, EventArgs e)
        {
            if (_network.IsConnected)
            {
                _network.SendMessage("ChangeScene:Home");
            }
        }

        private void turandotPageControl_InteractiveClick(object sender, string settingsPath)
        {
            connectionTimer.Stop();

            if (_network.IsConnected)
            {
                _network.SendMessage("ChangeScene:Turandot Interactive");
            }

            var dlg = new InteractiveForm(_network, settingsPath);
            dlg.ShowDialog();

            connectionTimer.Start();
        }

        private void turandotPageControl_StartTurandotClick(object sender, string settingsPath)
        {
            connectionTimer.Stop();

            if (_network.IsConnected)
            {
                _network.SendMessage("ChangeScene:Turandot");
            }

            menuPanel.Enabled = false;

            if (_liveForm == null)
            {
                _liveForm = new TurandotLiveForm(_network, _streamManager);
                _liveForm.TopLevel = false;
                _liveForm.ClosePage += OnTurandotRunPageClose;
                 runTurandotPage.Controls.Add(_liveForm);
                _liveForm.FormBorderStyle = FormBorderStyle.None;
                _liveForm.Dock = DockStyle.Fill;
                _liveForm.Show();
            }
            _liveForm.Initialize(settingsPath);

            tabControl.SelectedTab = runTurandotPage;
        }

        private void OnTurandotRunPageClose(object sender, EventArgs e)
        {
            tabControl.SelectedTab = turandotSettingsPage;
            menuPanel.Enabled = true;
            connectionTimer.Start();
        }

        private void adminButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                SelectTab(sender as CheckBox);
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            var folder = Path.Combine(FileLocations.RootFolder, "Remote Logs");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var response = _network.SendMessageAndReceiveString("GetLog");
            var parts = response.Split(new char[] { ':' }, 2);
            var logPath = Path.Combine(folder, parts[0]);
            File.WriteAllText(logPath, parts[1]);
            System.Diagnostics.Process.Start(logPath);
        }

        private void pupilButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            //connectionTimer.Stop();
            SelectTab(sender as CheckBox);

            //menuPanel.Enabled = false;

            if (_pupilForm == null)
            {
                _pupilForm = new PupillometryForm(_network, _streamManager);
                _pupilForm.TopLevel = false;
                //_pupilForm.ClosePage += OnTurandotRunPageClose;
                pupilPage.Controls.Add(_pupilForm);
                _pupilForm.FormBorderStyle = FormBorderStyle.None;
                _pupilForm.Dock = DockStyle.Fill;
                _pupilForm.Show();
            }
            _pupilForm.Initialize();

            tabControl.SelectedTab = pupilPage;

        }

        private void protocolButton_CheckedChanged(object sender, EventArgs e)
        {
            tableLayoutPanel.ColumnStyles[1].Width = protocolButton.Checked ? 188 : 0;
            SetMenuButtonColors(protocolButton);
        }

        private void protocolControl_StartProtocol(object sender, Pages.ProtocolControl.ProtocolItem e)
        {
            tableLayoutPanel.ColumnStyles[1].Width = 188;
        }
    }
}
