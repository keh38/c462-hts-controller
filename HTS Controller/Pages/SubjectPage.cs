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

namespace HTSController.Pages
{
    [DefaultEvent(nameof(ValueChanged))]
    public partial class SubjectPage : KUserControl
    {
        private HTSNetwork _network;

        public string Project { get; private set; } = "";
        public string Subject { get; private set; } = "";

        private SubjectMetadata _subjectMetadata;

        public delegate void ProjectChangedDelegate(string projectName);
        public ProjectChangedDelegate OnProjectChanged { get; set; }

        public SubjectPage()
        {
            InitializeComponent();

            subjectDropDown.Enabled = false;
            transducerDropDown.Enabled = false;
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;

            projectDropDown.Items.Clear();
            var projects = SharedFileLocations.EnumerateHtsProjects();
            projectDropDown.Items.AddRange(projects.ToArray());

            projectDropDown.SelectedIndex = projects.IndexOf(HTSControllerSettings.LastProject);
        }

        public void RetrieveSubjectState()
        {
            if (!_network.IsConnected) return;

            Log.Information("Retrieving subject state");

            try
            {
                var subjectInfo = _network.SendRequest<string>("GetSubjectInfo");
                var parts = subjectInfo.Split('/');
                Project = parts[0];
                Subject = parts[1];
                SharedFileLocations.SetHtsSubject(Subject, Project);

                var projects = _network.SendRequest<List<string>>("GetProjectList");

                projectDropDown.Enabled = true;
                projectDropDown.Items.Clear();
                projectDropDown.Items.AddRange(projects.ToArray());
                projectDropDown.SelectedIndex = projects.IndexOf(Project);
            }
            catch (Exception ex)
            {
                Log.Error($"RetrieveSubjectState failed: {ex.Message}");
            }
        }

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
                    ApplyMetrics();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to update metrics: {ex.Message}");
            }
        }

        private void projectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectDropDown.SelectedIndex < 0)
            {
                Subject = "";
                transducerDropDown.Items.Clear();
                transducerDropDown.Enabled = false;
                subjectDropDown.Items.Clear();
                subjectDropDown.Enabled = false;
            }
            else
            {
                Project = projectDropDown.Text;
                HTSControllerSettings.LastProject = Project;

                transducerDropDown.Enabled = false;
                transducerDropDown.Items.Clear();
                transducerDropDown.SelectedIndex = -1;

                if (_network.IsConnected)
                {
                    try
                    {
                        var subjects = _network.SendRequest<List<string>>("GetSubjectList", Project);

                        subjectDropDown.Enabled = true;
                        subjectDropDown.Items.Clear();
                        subjectDropDown.Items.AddRange(subjects.ToArray());

                        _ignoreEvents = true;

                        subjectDropDown.SelectedIndex = subjects.IndexOf(Subject);
                        if (subjectDropDown.SelectedIndex < 0)
                        {
                            subjectDropDown.Text = "";
                            Subject = "";
                            OnValueChanged();
                        }

                        _ignoreEvents = false;
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"GetSubjectList failed: {ex.Message}");
                    }
                }
                OnProjectChanged?.Invoke(Project);
            }
        }

        private void subjectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                Subject = subjectDropDown.Text;
                _network.SendMessage("SetSubjectInfo", $"{Project}/{Subject}");
            }
			SharedFileLocations.SetHtsSubject(Subject, Project);

			try
			{
                _subjectMetadata = _network.SendRequest<SubjectMetadata>("GetSubjectMetadata");
            }
            catch (Exception ex)
            {
                Log.Error($"GetSubjectMetadata failed: {ex.Message}");
                _subjectMetadata = new SubjectMetadata();
            }

            var currentIgnore = _ignoreEvents;
            _ignoreEvents = true;

            try
            {
                var transducers = _network.SendRequest<List<string>>("GetTransducers");
                transducerDropDown.Enabled = true;
                transducerDropDown.Items.Clear();
                transducerDropDown.Items.AddRange(transducers.ToArray());

                var itransducer = transducerDropDown.Items.Cast<Object>().Select(item => item.ToString()).ToList().IndexOf(_subjectMetadata.Transducer);
                transducerDropDown.SelectedIndex = itransducer;
            }
            catch (Exception ex)
            {
                Log.Error($"GetTransducers failed: {ex.Message}");
            }

            ShowMetrics();
            SendMetricsToEditor();
            SendSubjectFolderToEditor();

            if (MATLAB.IsInitialized)
            {
                MATLAB.AddPath(FileLocations.GetMATLABFolder(""));
            }

            _ignoreEvents = currentIgnore;

            OnValueChanged();
        }

        private void projectDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!projectDropDown.Items.Contains(projectDropDown.Text))
                {
                    createProjectButton.Visible = true;
                }
            }
        }

        private void projectDropDown_TextChanged(object sender, EventArgs e)
        {
            createProjectButton.Visible = false;
        }

        private void subjectDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!subjectDropDown.Items.Contains(subjectDropDown.Text))
                {
                    createSubjectButton.Visible = true;
                }
            }
        }

        private void subjectDropDown_TextChanged(object sender, EventArgs e)
        {
            createSubjectButton.Visible = false;
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            createProjectButton.Visible = false;
            Project = projectDropDown.Text;
            projectDropDown.Items.Add(Project);

            if (_network.IsConnected)
            {
                _network.SendMessage("CreateProject", Project);
            }

            var projects = projectDropDown.Items.Cast<Object>().Select(item => item.ToString()).ToList();
            projectDropDown.SelectedIndex = projects.IndexOf(Project);
        }

        private void createSubjectButton_Click(object sender, EventArgs e)
        {
            createSubjectButton.Visible = false;

            Subject = subjectDropDown.Text;
            _network.SendMessage("SetSubjectInfo", $"{Project}/{Subject}");

            _ignoreEvents = true;

            var subjects = subjectDropDown.Items.Cast<Object>().Select(item => item.ToString()).ToList();
            subjectDropDown.Items.Add(Subject);
            subjects.Add(Subject);
            subjects.Sort();
            subjectDropDown.Items.Clear();
            subjectDropDown.Items.AddRange(subjects.ToArray());

            subjectDropDown.SelectedIndex = subjects.IndexOf(Subject);
            subjectDropDown.Text = Subject;

			SharedFileLocations.SetHtsSubject(Subject, Project);

			_ignoreEvents = false;
        }

        private void transducerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                _subjectMetadata.Transducer = transducerDropDown.Text;
                _network.SendMessage("SetSubjectMetadata", _subjectMetadata);
            }
        }

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
            {
                metricGridView.Rows.Add(entry.key, entry.value);
            }
        }

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

        private void metricGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_ignoreEvents || metricGridView.CurrentCell == null) return;

            int rowIndex = metricGridView.CurrentCell.RowIndex;
            var cells = metricGridView.Rows[rowIndex].Cells;
            string metricName = cells["MetricName"].Value as string;

            if (metricGridView.CurrentCell.ColumnIndex == 0)
            {
                if (rowIndex == _subjectMetadata.metrics.entries.Count)
                {
                    _subjectMetadata.metrics[metricName] = "";
                }
                else
                {
                    _subjectMetadata.metrics.RenameKey(rowIndex, metricName);
                }
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
    }
}
