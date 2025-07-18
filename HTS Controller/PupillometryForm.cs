﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib;
using Pupillometry;

using HTSController.Data_Streams;

using Serilog;

using SREYELINKLib;
using MathWorks.MATLAB.Engine;
using MathWorks.MATLAB.Types;
using System.Xml.Linq;
using UnityEngine;

using Color = System.Drawing.Color;

namespace HTSController
{
    public partial class PupillometryForm : Form
    {
        private HTSNetwork _network;
        private DataStreamManager _streamManager;
        private string _dataFile;

        private DynamicRangeSettings _dynamicRangeSettings;
        private GazeCalibrationSettings _gazeSettings;

        private int _tabletWidth;
        private int _tabletHeight;

        private Point _targetPoint = new Point(-1, -1);

        private EyeLink _eyeLink;
        private BusyCal _busyCal;

        bool _stopCal = false;
        bool _runAborted = false;
        bool _ignoreEvents = false;
        bool _autoRun = false;

        #region EVENTS
        public event EventHandler<AutoRunEndEventArgs> AutoRunEnd;
        private void OnAutoRunEnd(bool success, string dataFile) { AutoRunEnd?.Invoke(this, new AutoRunEndEventArgs(success, dataFile)); }

        public event EventHandler<RunStateChangedEventArgs> RunStateChanged;
        protected virtual void OnRunStateChanged(string source, bool isRunning)
        {
            RunStateChanged?.Invoke(this, new RunStateChangedEventArgs(source, isRunning));
        }

        #endregion

        public PupillometryForm(HTSNetwork network, DataStreamManager streamManager)
        {
            _network = network;
            _network.RemoteMessageHandler += OnRemoteMessage;

            _streamManager = streamManager;

            InitializeComponent();
        }

        public void Initialize()
        {
            startButton.Visible = true;

            _dataFile = "";

            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            logTextBox.Text = "";

            var configPath = Path.Combine(FileLocations.ConfigFolder, "DynamicRange.Defaults.xml");
            if (File.Exists(configPath))
            {
                _dynamicRangeSettings = KFile.XmlDeserialize<DynamicRangeSettings>(configPath);
            }
            else
            {
                _dynamicRangeSettings = new DynamicRangeSettings();
            }
            dynamicRangePropertyGrid.SelectedObject = _dynamicRangeSettings;

            configPath = Path.Combine(FileLocations.ConfigFolder, "Gaze.Defaults.xml");
            if (File.Exists(configPath))
            {
                _gazeSettings = KFile.XmlDeserialize<GazeCalibrationSettings>(configPath);
            }
            else
            {
                _gazeSettings = new GazeCalibrationSettings();
            }

            propertyGrid.SelectedObject = _gazeSettings;

            matlabDropDown.Items.Clear();
            if (Directory.Exists(FileLocations.GetMATLABFolder("pupil")))
            {
                var mfiles = Directory.EnumerateFiles(FileLocations.GetMATLABFolder("pupil"), "*.m")
                    .Select(x => Path.GetFileNameWithoutExtension(x))
                    .ToList();

                matlabDropDown.Items.AddRange(mfiles.ToArray());
                matlabDropDown.Items.Add("");
                var lastmFile = HTSControllerSettings.GetLastUsed("PupilFunction");
                if (!string.IsNullOrEmpty(lastmFile))
                {
                    _ignoreEvents = true;
                    matlabDropDown.SelectedIndex = mfiles.IndexOf(lastmFile);
                    _ignoreEvents = false;
                }
            }
        }

        public void AutoRunDynamicRange()
        {
            _autoRun = true;
            tabControl.SelectedTab = dynamicRangePage;
            startButton_Click(this, null);
        }

        public void AutoRunGazeCalibration()
        {
            _autoRun = true;
            tabControl.SelectedTab = calibrationPage;
            gazeStartButton_Click(this, null);
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                logTextBox.Text = "Not connected to tablet";
                return;
            }

            startButton.Enabled = false;

            logTextBox.Text = "Starting dynamic range measurement...";
            Log.Information("Starting dynamic range measurement...");
            var success = await ChangeTabletScene("Pupil Dynamic Range");
            if (!success)
            {
                startButton.Enabled = true;
                logTextBox.Text = "failed to change scene on tablet";
                Log.Error("failed to change to pupil dynamic range scene");
                EndAutoRun(false, null);
                return;
            }

            _runAborted = false;
            dataFileTextBox.Text = "";
            progressBar.Value = 0;
            await Task.Run(() => InitializeDynamicRangeMeasurement());

            dataFileTextBox.Text = _dataFile;
            if (!string.IsNullOrEmpty(_dataFile))
            {
#if DEBUG
                var started = await _streamManager.StartRecording(_dataFile);
#else
                var started = await _streamManager.StartRecording(_dataFile, "EYELINK");
#endif
                if (started)
                {
                    stopButton.Enabled = true;
                    stopButton.Visible = true;
                    logTextBox.AppendText("OK" + Environment.NewLine);
                    OnRunStateChanged("PupilDynamicRange", true);
                    _network.SendMessage("Begin");
                }
                else
                {
                    logTextBox.AppendText("failed" + Environment.NewLine);
                    foreach (var s in _streamManager.ProblemStreams)
                    {
                        logTextBox.AppendText($"- {s}\n");
                        Log.Error($"failed to start stream: {s}");
                    }
                    startButton.Enabled = true;
                    _network.SendMessage($"StopSynchronizing");
                    EndAutoRun(false, null);
                }
            }
            else
            {
                logTextBox.AppendText("didn't receive data file name from Dynamic Range scene");
                Log.Error("didn't receive data file name from Dynamic Range scene");
                startButton.Enabled = true;
                _network.SendMessage($"StopSynchronizing");
                EndAutoRun(false, null);
            }
        }

        private async Task<bool> ChangeTabletScene(string sceneName)
        {
            bool success = false;
            _network.SendMessage($"ChangeScene:{sceneName}");

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                await Task.Delay(200);
                if (_network.CurrentScene.Equals(sceneName))
                {
                    success = true;
                    break;
                }
            }

            return success;
        }

        private void InitializeDynamicRangeMeasurement()
        {
            _network.SendMessage($"Initialize:{KFile.ToXMLString(_dynamicRangeSettings)}");

            // wait for file name to get sent back
            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                Thread.Sleep(200);
                if (!string.IsNullOrEmpty(_dataFile))
                {
                    break;
                }
            }

            if (!string.IsNullOrEmpty(_dataFile))
            {
                _network.SendMessage($"StartSynchronizing:{_dataFile}");
            }
        }

        private async void EndRun(string message, string status)
        {
            _network.SendMessage($"StopSynchronizing");
            await _streamManager.StopRecording();
            _network.SendMessage("SendSyncLog");

            if (!string.IsNullOrEmpty(status))
            {
                logTextBox.AppendText($"{Environment.NewLine}{status}{Environment.NewLine}");
            }

            var functionName = matlabDropDown.SelectedItem?.ToString();
            bool analyzeData = !_runAborted && !message.Equals("Error") && !string.IsNullOrEmpty(functionName) && MATLAB.IsInitialized;
            bool haveData = false;
            bool analysisSuccess = !analyzeData;
            if (analyzeData)
            {
                Invoke(new Action(() => { logTextBox.AppendText("Waiting for EyeLink data" + Environment.NewLine); }));
                haveData = await WaitForEyeLinkData(Path.Combine(FileLocations.SubjectDataFolder, _dataFile.Replace(".json", ".edf")));
            }

            startButton.Enabled = true;
            stopButton.Visible = false;

            if (analyzeData)
            {
                if (haveData)
                {
                    logTextBox.AppendText($"{Environment.NewLine}Calling MATLAB function...{Environment.NewLine}");

                    var result = MATLAB.RunFunction(functionName, Path.Combine(FileLocations.SubjectDataFolder, _dataFile));
                    logTextBox.AppendText(result);
                    analysisSuccess = !result.StartsWith("Error");
                }
                else
                {
                    logTextBox.AppendText("Timed out waiting for EyeLink data");
                    Log.Information("Timed out waiting for EyeLink data");
                }
            }
            progressBar.Value = 0;
            _streamManager.RestartStatusTimer();
            OnRunStateChanged("PupilDynamicRange", false);

            EndAutoRun(success: !_runAborted && !message.Equals("Error") && analysisSuccess, dataFile:_dataFile);
        }

        private void EndAutoRun(bool success, string dataFile)
        {
            if (!_autoRun) return;
            _autoRun = false;

            OnAutoRunEnd(success, dataFile);
        }

        private async Task<bool> WaitForEyeLinkData(string fn)
        {
            bool success = false;
            long lastLength = -1;

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 10)
            {
                await Task.Delay(200);
                if (File.Exists(fn))
                {
                    var length = new FileInfo(fn).Length;
                    if (length == lastLength)
                    {
                        success = true;
                        break;
                    }
                    lastLength = length;
                }
            }
            return success;
        }

        private void OnRemoteMessage(object sender, string message)
        {
            var parts = message.Split(new char[] { ':' }, 4);
            if (parts.Length < 2) return;

            string target = parts[0];
            if (!target.Equals("Pupil Dynamic Range") && !target.Equals("Gaze Calibration")) return;

            string command = parts[1];
            string info = (parts.Length > 2) ? parts[2] : "";
            string data = (parts.Length > 3) ? parts[3] : "";

            switch (command)
            {
                case "File":
                    _dataFile = info;
                    break;
                case "Progress":
                    int.TryParse(info, out int progress);
                    Invoke(new Action(() => progressBar.Value = progress));
                    break;
                case "ReceiveData":
                    string filePath = Path.Combine(FileLocations.SubjectDataFolder, info);
                    File.WriteAllText(filePath, data);
                    break;
                case "Response":
                    Log.Information("Gaze calibration response received");
                    _eyeLink.sendKeybutton(13, (short)0, (short)10);
                    break;
                case "Error":
                    Invoke(new Action(() => { EndRun("Error", info); }));
                    break;
                case "Finished":
                    _runAborted = info.Equals("Measurement aborted");
                    Invoke(new Action(() => { EndRun("Finished", info); }));
                    break;
                case "GazeCalibrationFinished":
                    _stopCal = true;
                    break;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _runAborted = true;
            stopButton.Enabled = false;
            _network.SendMessage("Abort");
        }
        private void dynamicRangePropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var configPath = Path.Combine(FileLocations.ConfigFolder, "DynamicRange.Defaults.xml");
            KLib.KFile.XmlSerialize(_dynamicRangeSettings, configPath);
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var configPath = Path.Combine(FileLocations.ConfigFolder, "Gaze.Defaults.xml");
            KLib.KFile.XmlSerialize(_gazeSettings, configPath);
        }

        private async void gazeStartButton_Click(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                gazeLogTextBox.Text = "Not connected to tablet";
                return;
            }

            _runAborted = false;
            _stopCal = false;
            gazeStartButton.Enabled = false;

            Log.Information("Starting gaze calibration");
            gazeLogTextBox.Text = "Starting gaze calibration..." + Environment.NewLine;
            var success = await ChangeTabletScene("Gaze Calibration");
            if (!success)
            {
                gazeStartButton.Enabled = true;
                gazeLogTextBox.AppendText("failed to change scene on tablet" + Environment.NewLine);
                Log.Error("failed to change to gaze calibration scene");
                EndAutoRun(false, null);
                return;
            }

            // Stop EyeLink Interface if it's running
            _streamManager.Find("EYELINK")?.SendMessage("Abort");
            
            success = GetTabletScreenSize();
            if (success)
            {
                gazeLogTextBox.AppendText($"- Screen size = {_tabletWidth} x {_tabletHeight}" + Environment.NewLine);
                gazePicture.Refresh();
            }
            else
            {
                gazeLogTextBox.AppendText("- Could not retrieve tablet screen size" + Environment.NewLine);
                Log.Error("could not retrieve tablet screen size");
                gazeStartButton.Enabled = true;
                EndAutoRun(false, null);
                return;
            }

            _network.SendMessage($"Initialize:{KFile.ToXMLString(_gazeSettings)}");

            success = await StartEyeLink();
            if (!success)
            {
                gazeLogTextBox.AppendText("- Could not start EyeLink" + Environment.NewLine);
                Log.Error("could not start EyeLink");
                gazeStartButton.Enabled = true;
                EndAutoRun(false, null);
                return;
            }

            gazeLogTextBox.AppendText("- Running..." + Environment.NewLine);
            gazeStopButton.Visible = true;

            await Task.Run(() => PollForJobs());
        }

        private void PollForJobs()
        {
            _eyeLink.sendKeybutton(99, 0, 10);
            var job = _busyCal.job;
            var lastjob = job;

            while (true)
            {
                //if (job > 0 && job != 6 && job != lastjob) Log.Information($" job = {job}");
                lastjob = job;

                if (job == 9)
                {
                    _busyCal.getCalLocation(out short x, out short y);
                    //Log.Information($"target location = {x}, {y}");
                    _targetPoint = new Point(x, y);
                    _network.SendMessage($"Location:{x},{y}");
                    Invoke(new Action(() => gazePicture.Refresh()));
                }
                else if (job == 14)
                {
                    break;
                }

                if (_stopCal)
                {
                    Thread.Sleep(200);
                    break;
                }

                Thread.Sleep(1);
                job = _busyCal.job;
            }

            EndGazeCalibration();
        }

        private void gazeStopButton_Click(object sender, EventArgs e)
        {
            _runAborted = true;
            _stopCal = true;
            _network.SendMessage("Abort");
        }

        private bool GetTabletScreenSize()
        {
            bool success = false;

            var response = _network.SendMessageAndReceiveString("GetScreenSize");
            var parts = response.Split(',');
            if (parts.Length == 2)
            {
                _tabletWidth = int.Parse(parts[0]);
                _tabletHeight = int.Parse(parts[1]);
                success = true;
            }

            return success;
        }

        private async Task<bool> StartEyeLink()
        {
            bool success = false;

            _eyeLink = new EyeLink();
            try
            {
                _eyeLink.open("100.1.1.1");
            }
            catch (Exception ex)
            {
                Log.Error($"[Gaze Calibration] error connecting to EyeLink: {ex.Message}");
                return false;
            }

            int width = _tabletWidth;
            int height = _tabletHeight;

            if (_gazeSettings.Width > 0)
            {
                width = _gazeSettings.Width;
                height = _gazeSettings.Height;
            }
            _eyeLink.sendCommand($"screen_pixel_coords 0 0 {width} {height}");
            _eyeLink.sendCommand($"calibration_type = {_gazeSettings.CalibrationType}");

            _busyCal = new EyeLinkUtil().getBusyCal();
            _busyCal.startCameraSetup();

            var startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < 5)
            {
                await Task.Delay(200);
                if (_eyeLink.getTrackerMode() == 3)
                {
                    success = true;
                    break;
                }
            }
            return success;
        }

        private void EndGazeCalibration()
        {
            _eyeLink.exitCalibration();
            _eyeLink.setOfflineMode();
            _eyeLink.close();

            gazeStopButton.Visible = false;
            gazeStartButton.Enabled = true;

            gazeLogTextBox.AppendText(" - finished." + Environment.NewLine);
            _targetPoint = new Point(-1, -1);
            gazePicture.Refresh();

            _streamManager.Find("EYELINK")?.SendMessage("Free Run");

            EndAutoRun(success: !_runAborted, dataFile: null);
        }

        private void gazePicture_Paint(object sender, PaintEventArgs e)
        {
            if (_tabletWidth == 0) return;

            float aspectRatio = (float) _tabletWidth / _tabletHeight;

            float width = gazePicture.Width;
            float height = gazePicture.Width / aspectRatio;
            if (height > gazePicture.Height)
            {
                height = gazePicture.Height;
                width = height * aspectRatio;
            }

            float xoff = (gazePicture.Width - width) / 2;
            float yoff = (gazePicture.Height - height) / 2;

            var rect = new RectangleF(xoff, yoff, width, height);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(_gazeSettings.BackgroundColor)), rect);

            if (_targetPoint.X >= 0)
            {
                float x = xoff + (float)_targetPoint.X / _tabletWidth * width;
                float y = yoff + (float)_targetPoint.Y / _tabletHeight * height;
                float size = 10; 

                rect = new RectangleF(x - size / 2, y - size / 2, size, size);

                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(_gazeSettings.TargetColor)), rect);
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (MATLAB.IsInitialized)
            {
                var functionName = matlabDropDown.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(functionName))
                {
                    //_dataFile = @"C:\Users\hancock\OneDrive\Engineering\Polley\HTS\Sync\Test Data\_Yu-PupilDR-2025-04-14_103307.json";
                    //var result = MATLAB.RunFunction(functionName, _dataFile);
                    var result = MATLAB.RunFunction(functionName, Path.Combine(FileLocations.SubjectDataFolder, _dataFile));
                    logTextBox.AppendText(result);
                }
            }
        }

        private void matlabDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                HTSControllerSettings.SetLastUsed("PupilFunction", matlabDropDown.SelectedItem.ToString());
            }
        }

    }
}
