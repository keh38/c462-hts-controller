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

using HTS.Tcp;
using C462.Shared;
using C462.Shared.Protocol.DTOs;

using HTSController.Data_Streams;
using System.Runtime.CompilerServices;
using Markdig;

namespace HTSController
{
    public partial class MainForm : Form
    {
        HTSNetwork _network;
        DataStreamManager _streamManager;
        TurandotLiveForm _liveForm = null;
        BasicMeasurementForm _basicForm = null;
        SpeechForm _speechForm = null;
        PupillometryForm _pupilForm = null;

        List<Tuple<CheckBox, TabPage>> _menu;

        string _logPath;

        bool _ignoreEvents = false;

        public MainForm()
        {
            InitializeComponent();
            tableLayoutPanel.ColumnStyles[1].Width = 0;

            _menu = new List<Tuple<CheckBox, TabPage>>();
            _menu.Add(new Tuple<CheckBox, TabPage>(subjectButton, subjectPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(turandotButton, turandotSettingsPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(basicButton, basicPageContainer));
            _menu.Add(new Tuple<CheckBox, TabPage>(speechButton, speechPageContainer));
            _menu.Add(new Tuple<CheckBox, TabPage>(pupilButton, pupilPage));
            _menu.Add(new Tuple<CheckBox, TabPage>(adminButton, adminPage));

            subjectPageControl.OnProjectChanged = subjectPageControl_ProjectChanged;
        }

        private async Task StartLogging()
        {
            _logPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "EPL",
                "Logs",
                $"HTSController-{DateTime.Now.ToString("yyyyMMdd")}.txt");

            await Task.Run(() =>
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File(path: Path.Combine(_logPath),
                              retainedFileCountLimit: 30,
                              flushToDiskInterval: TimeSpan.FromSeconds(5),
                              buffered: true)
                .CreateLogger()
                );

            var listener = new SerilogTraceListener.SerilogTraceListener();
            Trace.Listeners.Add(listener);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _network = new HTSNetwork();
            _network.RemoteMessageHandler += HandleRemoteMessage;
            _network.SceneChangeHandler += HandleSceneChange;

            SharedFileLocations.SetDataDrive(HTSControllerSettings.DataDrive);
            SharedFileLocations.SetProjectRootFolder(HTSControllerSettings.ProjectRootFolder);

            turandotPageControl.Initialize(_network);
            subjectPageControl.Initialize(_network);
            protocolControl.Initialize(_network);

            lightsButton.Visible = false;

            subjectButton.Checked = true;

            fileSyncControl.Initialize(_network);

            driveDropDown.Items.Clear();
            foreach (var di in DriveInfo.GetDrives())
            {
                if (di.DriveType == DriveType.Fixed)
                {
                    driveDropDown.Items.Add(di.Name);
                }
            }
            _ignoreEvents = true;
            driveDropDown.SelectedItem = HTSControllerSettings.DataDrive;
            projectRootBrowser.Value = HTSControllerSettings.ProjectRootFolder;
            _ignoreEvents = false;
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            await StartLogging();

            Log.Information($"HTS v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");

            Log.Information("Starting network...");
            _network.ConnectionChanged += OnConnectionChanged;

            _streamManager = new DataStreamManager();
            _streamManager.Initialize(ipcLayoutPanel, _network.DiscoveryListener);  // wire first

            _network.Initialize(this);  // start listener last  

            connectionStatusLabel.Image = imageList.Images[0];
            connectionStatusLabel.Text = "No tablet connection yet";

            matlabStatusLabel.Text = "Connecting...";
            matlabStatusLabel.Visible = true;
            var haveMATLAB = await MATLAB.Initialize();
            matlabStatusLabel.Visible = haveMATLAB;
            matlabStatusLabel.Text = "Available";
            MATLAB.UpdateMetrics = subjectPageControl.UpdateMetrics;
            if (haveMATLAB && !string.IsNullOrEmpty(subjectPageControl.Subject))
            {
                MATLAB.AddPath(FileLocations.GetMATLABFolder(""));
            }
        }

        private async void OnConnectionChanged(object sender, bool connected)
        {
            if (connected)
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = $"Connected to {_network.TabletAddress} (V{_network.TabletVersion})";
                sceneNameLabel.Text = $"Scene: {_network.CurrentScene}";

                try
                {
                    var colorString = _network.SendRequest<string>("GetLEDColors");
                    if (string.IsNullOrEmpty(colorString) || colorString == "none")
                    {
                        lightsButton.Visible = false;
                    }
                    else
                    {
                        lightsButton.Visible = true;
                        SetLightsButtonBackgroundColor(colorString);
                    }
                }
                catch { lightsButton.Visible = false; }

                // Send local paths when running on the same machine as HTS
                if (_network.TabletAddress == "127.0.0.1")
                {
                    _network.SendMessage("SetDataRoot", SharedFileLocations.HtsProjectRootFolder);
                    if (!string.IsNullOrEmpty(subjectPageControl.Project))
                    {
                        _network.SendMessage("SetProject", subjectPageControl.Project);
                    }
                }

                subjectPageControl.RetrieveSubjectState();
                turandotPageControl.UpdateConfigFileList();
                menuPanel.Enabled = true;
                subjectPageControl.Enabled = true;
                turandotPageControl.NetworkStatusChanged();
                SelectTab(subjectButton);
            }
            else
            {
                Log.Information("Tablet connection lost");
                subjectPageControl.Enabled = false;
                turandotPageControl.NetworkStatusChanged();
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No tablet connection, retrying...";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _streamManager.Cleanup();
            MATLAB.CleanUp();

            if (!e.Cancel)
            {
                _network.Shutdown();
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

        private void SetLightsButtonBackgroundColor(string value)
        {
            var parts = value.Split(',');
            if (parts.Length == 4)
            {
                var r = (int)(float.Parse(parts[0]) * 255);
                var g = (int)(float.Parse(parts[1]) * 255);
                var b = (int)(float.Parse(parts[2]) * 255);
                var w = (int)(float.Parse(parts[3]) * 255);

                if (r == 0 && g == 0 && b == 0)
                {
                    r = w;
                    g = w;
                    b = w;
                }

                if (r == 0 && g == 0 && b == 0)
                {
                    lightsButton.BackColor = menuPanel.BackColor;
                }
                else
                {
                    lightsButton.BackColor = Color.FromArgb(r, g, b);
                }
            }
        }

        private void menuButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                SelectTab(sender as CheckBox);
            }
        }

        private void subjectPageControl_ValueChanged(object sender, EventArgs e)
        {
            subjectButton.Text = string.IsNullOrEmpty(subjectPageControl.Subject) ? "Subject" : subjectPageControl.Subject;
        }

        private void subjectPageControl_ProjectChanged(string projectName)
        {
            SharedFileLocations.SetHtsSubject(projectName);
            turandotPageControl.UpdateConfigFileList();
        }

        private void HandleSceneChange(object sender, string sceneName)
        {
            sceneNameLabel.Text = $"Scene: {sceneName}";
        }

        private void HandleRemoteMessage(object sender, TcpMessage message)
        {
            var payload = message.GetPayload<RemoteMessagePayload>();

            switch (message.Command)
            {
                case "ChangedLEDColors":
                    SetLightsButtonBackgroundColor(payload.Data);
                    break;
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            if (_network.IsConnected)
            {
                _network.SendMessage("ChangeScene", "Home");
            }
        }

        private void turandotPageControl_InteractiveClick(object sender, string settingsPath)
        {
            if (_network.IsConnected)
            {
                _network.SendMessage("ChangeScene", "Turandot Interactive");
            }

            var dlg = new InteractiveForm(_network, settingsPath);
            dlg.ShowDialog();
        }

        private void turandotPageControl_StartTurandotClick(object sender, HTSController.Pages.StartTurandotEventArgs e)
        {
            menuPanel.Enabled = false;

            if (_network.IsConnected)
            {
                _network.SendMessage("ChangeScene", "Turandot");
            }

            if (_liveForm == null)
            {
                _liveForm = new TurandotLiveForm(_network, _streamManager);
                _liveForm.TopLevel = false;
                _liveForm.AutoRunEnd += TestRunEnded;
                _liveForm.ClosePage += OnTurandotRunPageClose;
                runTurandotPage.Controls.Add(_liveForm);
                _liveForm.FormBorderStyle = FormBorderStyle.None;
                _liveForm.Dock = DockStyle.Fill;
                _liveForm.Show();
            }

            _liveForm.Initialize(e.settingsPath, e.extraSettings);

            tabControl.SelectedTab = runTurandotPage;
        }

        private void OnTurandotRunPageClose(object sender, EventArgs e)
        {
            tabControl.SelectedTab = turandotSettingsPage;
            menuPanel.Enabled = true;
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
            var folder = Path.Combine(SharedFileLocations.HtsFolder, "Remote Logs");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            try
            {
                var logFile = _network.SendRequest<TextFilePayload>("GetLog");
                if (logFile != null && !string.IsNullOrEmpty(logFile.Filename))
                {
                    var logPath = Path.Combine(folder, logFile.Filename);
                    File.WriteAllText(logPath, logFile.Content);
                    System.Diagnostics.Process.Start(logPath);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }

        private void localLogButton_Click(object sender, EventArgs e)
        {
            Process.Start(_logPath);
        }

        private void basicButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            SelectTab(sender as CheckBox);

            if (_basicForm == null)
            {
                _basicForm = new BasicMeasurementForm(_network, _streamManager);
                _basicForm.TopLevel = false;
                _basicForm.AutoRunEnd += TestRunEnded;
                _basicForm.RunStateChanged += RunStateChanged;
                basicPageContainer.Controls.Add(_basicForm);
                _basicForm.FormBorderStyle = FormBorderStyle.None;
                _basicForm.Dock = DockStyle.Fill;
                _basicForm.Show();
            }
            _basicForm.Initialize();

            tabControl.SelectedTab = basicPageContainer;
        }

        private void speechButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            SelectTab(sender as CheckBox);

            if (_speechForm == null)
            {
                _speechForm = new SpeechForm(_network, _streamManager);
                _speechForm.TopLevel = false;
                _speechForm.AutoRunEnd += TestRunEnded;
                _speechForm.RunStateChanged += RunStateChanged;
                speechPageContainer.Controls.Add(_speechForm);
                _speechForm.FormBorderStyle = FormBorderStyle.None;
                _speechForm.Dock = DockStyle.Fill;
                _speechForm.Show();
            }
            _speechForm.Initialize();

            tabControl.SelectedTab = speechPageContainer;
        }

        private void pupilButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;

            SelectTab(sender as CheckBox);

            if (_pupilForm == null)
            {
                _pupilForm = new PupillometryForm(_network, _streamManager);
                _pupilForm.TopLevel = false;
                _pupilForm.AutoRunEnd += TestRunEnded;
                _pupilForm.RunStateChanged += RunStateChanged;
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
            protocolControl.UpdateList();
        }

        private void protocolControl_AdvanceProtocol(object sender, Pages.ProtocolControl.ProtocolItem e)
        {
            switch (e.sceneName)
            {
                case "Audiogram":
                case "Digits":
                case "LDL":
                    basicButton.Checked = true;
                    _basicForm.AutoRunBasicMeasurement(e.sceneName, e.settingsFile);
                    break;
                case "Pupil Dynamic Range":
                    pupilButton.Checked = true;
                    _pupilForm.AutoRunDynamicRange(e.settingsFile);
                    break;
                case "Gaze Calibration":
                    pupilButton.Checked = true;
                    _pupilForm.AutoRunGazeCalibration();
                    break;
                case "Investigator":
                    MarkdownDialog.ShowMarkdownDialog(e.instructions);
                    protocolControl.TestFinished(success: true, dataFile: null);
                    break;
                case "Speech Reception":
                    speechButton.Checked = true;
                    _speechForm.AutoRunSpeechTest(e.settingsFile);
                    break;
                case "Turandot":
                    turandotButton.Checked = true;
                    var parts = e.settingsFile.Split(new char[] { ':' }, 2);
                    string fileName = parts[0];
                    string extraSettings = (parts.Length > 1) ? parts[1] : "";
                    turandotPageControl_StartTurandotClick(this, new HTSController.Pages.StartTurandotEventArgs(Path.Combine(SharedFileLocations.HtsConfigFolder, $"Turandot.{fileName}.xml"), extraSettings));
                    _liveForm.AutoRun();
                    break;
            }
        }

        private void protocolControl_ProtocolStateChange(object sender, Pages.ProtocolControl.ProtocolStateChangeEventArgs e)
        {
            menuPanel.Enabled = !e.running;
        }

        private void RunStateChanged(object sender, RunStateChangedEventArgs e)
        {
            //if (e.isRunning)
            //{
            //    connectionTimer.Stop();
            //    Log.Information("connection timer stopped");
            //}
            //else
            //{
            //    connectionTimer.Start();
            //    Log.Information("connection timer started");
            //}
        }

        private void TestRunEnded(object sender, AutoRunEndEventArgs e)
        {
            protocolControl.TestFinished(e.success, e.dataFile);
        }

        private void driveDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                HTSControllerSettings.DataDrive = driveDropDown.SelectedItem as string;
                SharedFileLocations.SetDataDrive(HTSControllerSettings.DataDrive);
            }
        }

        private void projectRootBrowser_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                HTSControllerSettings.ProjectRootFolder = projectRootBrowser.Value;
                SharedFileLocations.SetProjectRootFolder(HTSControllerSettings.ProjectRootFolder);
            }
        }

    }
}
