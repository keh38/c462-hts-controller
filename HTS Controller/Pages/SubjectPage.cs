using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;

using KLib.Controls;
using KLib.Net;

using C462.Shared;
using MathWorks.MATLAB.Types;
using System.IO;
using C462.Shared.Protocol.DTOs;

namespace HTSController.Pages
{
    [DefaultEvent(nameof(ValueChanged))]
    public partial class SubjectPage : KUserControl
    {
        // -------------------------------------------------------------------------
        // Events
        // -------------------------------------------------------------------------

        /// <summary>
        /// Raised when the active project changes. MainForm uses this to refresh
        /// config file lists in other parts of the UI.
        /// </summary>
        public event EventHandler<string> ProjectChanged;

        // -------------------------------------------------------------------------
        // State
        // -------------------------------------------------------------------------

        private HTSNetwork _network;
        private SubjectMetadata _subjectMetadata;

        public string Project { get; private set; } = "";
        public string Subject { get; private set; } = "";

        // -------------------------------------------------------------------------
        // Construction
        // -------------------------------------------------------------------------

        public SubjectPage()
        {
            InitializeComponent();

            subjectDropDown.Enabled = false;
            transducerDropDown.Enabled = false;
        }

        // -------------------------------------------------------------------------
        // Public entry points
        // -------------------------------------------------------------------------

        /// <summary>
        /// Called once at application startup. Populates the project list from the
        /// local file system and restores the last-used project (offline-safe).
        /// </summary>
        public void Initialize(HTSNetwork network)
        {
            _network = network;

            _ignoreEvents = true;
            var projects = SharedFileLocations.EnumerateHtsProjects();
            PopulateProjectDropDown(projects);
            Refresh();
            SetProject(HTSControllerSettings.LastProject);
            _ignoreEvents = false;
        }

        /// <summary>
        /// Called when a connection to HTS is established. Reads the current
        /// subject state from HTS and syncs the UI to it.
        /// </summary>
        public void OnConnected()
        {
            Log.Information("Retrieving subject state from HTS");

            try
            {
                var subjectInfo = _network.SendRequest<string>("GetSubjectInfo");
                var parts = subjectInfo.Split('/');

                var projects = _network.SendRequest<List<string>>("GetProjectList");

                _ignoreEvents = true;
                PopulateProjectDropDown(projects);
                SetProject(parts[0]);
                SetSubject(parts[1]);
                _ignoreEvents = false;
            }
            catch (Exception ex)
            {
                Log.Error($"OnConnected subject sync failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Called when the connection to HTS is lost. Falls back to the local
        /// project list and clears subject-specific controls.
        /// </summary>
        public void OnDisconnected()
        {
            _ignoreEvents = true;

            subjectDropDown.Items.Clear();
            subjectDropDown.Enabled = false;
            transducerDropDown.Items.Clear();
            transducerDropDown.Enabled = false;

            PopulateProjectDropDown(SharedFileLocations.EnumerateHtsProjects());
            SetProject(Project); // re-apply current project against the local list

            _ignoreEvents = false;
        }

        /// <summary>
        /// Called by MainForm when MATLAB pushes updated metrics for the current subject.
        /// </summary>
        public void UpdateMetrics(MATLABStruct data)
        {
            try
            {
                foreach (var n in data.GetFieldNames())
                {
                    string value = "";
                    dynamic x = data.GetField(n);
                    try { value = x; } catch { double dval = x; value = dval.ToString(); }

                    _subjectMetadata.metrics[n] = value;
                    Log.Information($"Set metric {n} = '{value}'");
                }
                ApplyMetrics();
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to update metrics: {ex.Message}");
            }
        }

        // -------------------------------------------------------------------------
        // Core state setters — all state changes flow through here
        // -------------------------------------------------------------------------

        private void SetProject(string project)
        {
            if (string.IsNullOrEmpty(project)) return;

            Project = project;
            HTSControllerSettings.LastProject = project;
            SharedFileLocations.SetHtsProject(project);

            // Sync dropdown selection
            var idx = projectDropDown.Items.Cast<object>()
                .Select(x => x.ToString()).ToList().IndexOf(project);
            if (projectDropDown.SelectedIndex != idx)
                projectDropDown.SelectedIndex = idx;

            // Reset subject-dependent controls
            Subject = "";
            subjectDropDown.Items.Clear();
            subjectDropDown.Enabled = false;
            transducerDropDown.Items.Clear();
            transducerDropDown.Enabled = false;

            if (_network.IsConnected)
            {
                try
                {
                    var subjects = _network.SendRequest<List<string>>("GetSubjectList", project);
                    PopulateSubjectDropDown(subjects);
                }
                catch (Exception ex)
                {
                    Log.Error($"GetSubjectList failed: {ex.Message}");
                }
            }
            else
            {
                var subjects = SharedFileLocations.EnumerateHtsSubjects(project);
                PopulateSubjectDropDown(subjects);
            }

                ProjectChanged?.Invoke(this, project);
        }

        private void SetSubject(string subject)
        {
            Subject = subject;
            SharedFileLocations.SetHtsSubject(Project, subject);
            Debug.WriteLine($"subject data folder: {SharedFileLocations.HtsSubjectDataFolder}");

            // Sync dropdown selection
            var idx = subjectDropDown.Items.Cast<object>()
                .Select(x => x.ToString()).ToList().IndexOf(subject);
            if (subjectDropDown.SelectedIndex != idx)
                subjectDropDown.SelectedIndex = idx;

            if (_network.IsConnected)
            {
                _network.SendMessage("SetSubjectInfo", $"{Project}/{Subject}");

                try
                {
                    _subjectMetadata = _network.SendRequest<SubjectMetadata>("GetSubjectMetadata");
                }
                catch (Exception ex)
                {
                    Log.Error($"GetSubjectMetadata failed: {ex.Message}");
                    _subjectMetadata = new SubjectMetadata();
                }

                var savedIgnore = _ignoreEvents;
                _ignoreEvents = true;

                try
                {
                    var transducers = _network.SendRequest<List<string>>("GetTransducers");
                    transducerDropDown.Enabled = true;
                    transducerDropDown.Items.Clear();
                    transducerDropDown.Items.AddRange(transducers.ToArray());
                    transducerDropDown.SelectedIndex = transducers.IndexOf(_subjectMetadata.Transducer);
                }
                catch (Exception ex)
                {
                    Log.Error($"GetTransducers failed: {ex.Message}");
                }

                _ignoreEvents = savedIgnore;

                ShowMetrics();
                SendMetricsToEditor();
                SendSubjectFolderToEditor();

                if (MATLAB.IsInitialized)
                    MATLAB.AddPath(FileLocations.GetMATLABFolder(""));
            }

            OnValueChanged();
        }

        // -------------------------------------------------------------------------
        // Dropdown population helpers
        // -------------------------------------------------------------------------

        private void PopulateProjectDropDown(List<string> projects)
        {
            projectDropDown.Items.Clear();
            projectDropDown.Items.AddRange(projects.ToArray());
        }

        private void PopulateSubjectDropDown(List<string> subjects)
        {
            subjectDropDown.Enabled = true;
            subjectDropDown.Items.Clear();
            subjectDropDown.Items.AddRange(subjects.ToArray());
        }

        // -------------------------------------------------------------------------
        // Dropdown event handlers — user-initiated changes only
        // -------------------------------------------------------------------------

        private void projectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents || projectDropDown.SelectedIndex < 0) return;
            SetProject(projectDropDown.Text);
        }

        private void subjectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents || subjectDropDown.SelectedIndex < 0) return;
            SetSubject(subjectDropDown.Text);
        }

        private void projectDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !projectDropDown.Items.Contains(projectDropDown.Text))
                createProjectButton.Visible = true;
        }

        private void projectDropDown_TextChanged(object sender, EventArgs e)
        {
            createProjectButton.Visible = false;
        }

        private void subjectDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !subjectDropDown.Items.Contains(subjectDropDown.Text))
            {
                createSubjectButton.Visible = true;
                audiogramButton.Visible = false;
            }
        }

        private void subjectDropDown_TextChanged(object sender, EventArgs e)
        {
            createSubjectButton.Visible = false;
            audiogramButton.Visible = true;
        }

        // -------------------------------------------------------------------------
        // Create project / subject
        // -------------------------------------------------------------------------

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            createProjectButton.Visible = false;

            var project = projectDropDown.Text;
            if (_network.IsConnected)
                _network.SendMessage("CreateProject", project);

            // Add to sorted list and repopulate
            var projects = projectDropDown.Items.Cast<object>()
                .Select(x => x.ToString()).ToList();
            projects.Add(project);
            projects.Sort();

            _ignoreEvents = true;
            PopulateProjectDropDown(projects);
            _ignoreEvents = false;

            SetProject(project);
        }

        private void createSubjectButton_Click(object sender, EventArgs e)
        {
            createSubjectButton.Visible = false;
            audiogramButton.Visible = true;

            var subject = subjectDropDown.Text;
            var subjects = subjectDropDown.Items.Cast<object>()
                .Select(x => x.ToString()).ToList();
            subjects.Add(subject);
            subjects.Sort();

            _ignoreEvents = true;
            PopulateSubjectDropDown(subjects);
            _ignoreEvents = false;

            SetSubject(subject);
        }

        // -------------------------------------------------------------------------
        // Transducer
        // -------------------------------------------------------------------------

        private void transducerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreEvents) return;
            _subjectMetadata.Transducer = transducerDropDown.Text;
            _network.SendMessage("SetSubjectMetadata", _subjectMetadata);
        }

        // -------------------------------------------------------------------------
        // Metrics
        // -------------------------------------------------------------------------

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplyMetrics();
        }

        private void ApplyMetrics()
        {
            _network.SendMessage("SetSubjectMetrics", _subjectMetadata.metrics);
            ShowMetrics();
            SendMetricsToEditor();
            applyButton.Visible = false;
        }

        private void ShowMetrics()
        {
            _subjectMetadata.metrics.Sort();
            metricGridView.Rows.Clear();
            foreach (var entry in _subjectMetadata.metrics.entries)
                metricGridView.Rows.Add(entry.key, entry.value);
        }

        private void metricGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_ignoreEvents || metricGridView.CurrentCell == null) return;

            int rowIndex = metricGridView.CurrentCell.RowIndex;
            var cells = metricGridView.Rows[rowIndex].Cells;
            string metricName = cells["MetricName"].Value as string;

            if (metricGridView.CurrentCell.ColumnIndex == 0)
            {
                if (rowIndex == _subjectMetadata.metrics.entries.Count)
                    _subjectMetadata.metrics[metricName] = "";
                else
                    _subjectMetadata.metrics.RenameKey(rowIndex, metricName);
            }
            else if (metricGridView.CurrentCell.ColumnIndex == 1)
            {
                _subjectMetadata.metrics[metricName] = cells["MetricValue"].Value.ToString();
            }

            applyButton.Visible = true;
        }

        private void metricGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var metricName = e.Row.Cells["MetricName"].Value.ToString();
            _subjectMetadata.metrics.RemoveKey(metricName);
            applyButton.Visible = true;
        }

        // -------------------------------------------------------------------------
        // Editor integration (pending)
        // -------------------------------------------------------------------------

        private void SendSubjectFolderToEditor()
        {
            // TODO: Update when Turandot Editor discovery API is finalized in KLib.Net
            // var ep = DiscoverEditor("TURANDOT.EDITOR");
            // if (ep != null) KTcpClient.SendRequest(ep, TcpMessage.Request("SetSubjectFolder", SharedFileLocations.HtsSubjectDataFolder));
        }

        private void SendMetricsToEditor()
        {
            // TODO: Update when Turandot Editor discovery API is finalized in KLib.Net
            // var ep = DiscoverEditor("TURANDOT.EDITOR");
            // if (ep != null) KTcpClient.SendRequest(ep, TcpMessage.Request("SetMetrics", KLib.IO.Files.ToXMLString(_subjectMetadata.metrics)));
        }

        private void audiogramButton_Click(object sender, EventArgs e)
        {
            var audiogram = Audiograms.AudiogramData.Load(SharedFileLocations.AudiogramPath);
            var ldlgram = Audiograms.AudiogramData.Load(SharedFileLocations.LDLPath);

            AudiogramPlot.SetData(audiogram, ldlgram, Subject);
            AudiogramPlot.Show(this.FindForm());
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            if (!_network.IsConnected)
            {
                return;
            }

            try
            {
                var audiogramFile = SharedFileLocations.AudiogramPath;
                var ldlgramFile = SharedFileLocations.LDLPath;
                if (!File.Exists(audiogramFile) && !File.Exists(ldlgramFile))
                {
                    MessageBox.Show("No audiogram files found to transfer.");
                    return;
                }

                if (File.Exists(audiogramFile))
                    TransferAudiogramFile(audiogramFile);
                if (File.Exists(ldlgramFile))
                    TransferAudiogramFile(ldlgramFile);

                MessageBox.Show("Audiogram files sent to HTS.");
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to transfer audiogram files: {ex.Message}");
            }
        }

        private void TransferAudiogramFile(string file)
        {
            var payload = new TextFilePayload()
            {
                Filename = Path.GetFileName(file),
                Content = File.ReadAllText(file)
            };
            _network.SendMessage("ReceiveAudiogram", payload);
        }
    }
}