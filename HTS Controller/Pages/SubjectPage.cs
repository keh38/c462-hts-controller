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

namespace HTSController.Pages
{
    [DefaultEvent(nameof(ValueChanged))]
    public partial class SubjectPage : KUserControl
    {
        private HTSNetwork _network;

        private string Project { get; set; } = "";
        public string Subject { get; private set; } = "";

        public SubjectPage()
        {
            InitializeComponent();

            projectDropDown.Enabled = false;
            subjectDropDown.Enabled = false;
        }

        public void Initialize(HTSNetwork network)
        {
            _network = network;
        }

        public void RetrieveSubjectState()
        {
            if (!_network.IsConnected) return;

            Log.Information("Retrieving subject state");

            var subjectInfo = _network.SendMessageAndReceiveString("GetSubjectInfo");
            var parts = subjectInfo.Split('/');
            Project = parts[0];
            Subject = parts[1];

            var projects = _network.SendMessageAndReceiveJSON<List<string>>("GetProjectList");

            projectDropDown.Enabled = true;
            projectDropDown.Items.Clear();
            projectDropDown.Items.AddRange(projects.ToArray());
            projectDropDown.SelectedIndex = projects.IndexOf(Project);
        }

        private void projectDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!projectDropDown.Items.Contains(projectDropDown.Text))
                {
                    projectDropDown.Text = Project;
                    projectDropDown.SelectedValue = Project;
                }
            }
        }

        private void projectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectDropDown.SelectedIndex < 0)
            {
                Subject = "";
                subjectDropDown.Items.Clear();
                subjectDropDown.Enabled = false;
            }
            else
            {
                if (_network.IsConnected)
                {
                    var subjects = _network.SendMessageAndReceiveJSON<List<string>>($"GetSubjectList:{projectDropDown.Text}");

                    subjectDropDown.Enabled = true;
                    subjectDropDown.Items.Clear();
                    subjectDropDown.Items.AddRange(subjects.ToArray());

                    _ignoreEvents = true;

                    subjectDropDown.SelectedIndex = subjects.IndexOf(Subject);
                    if (subjectDropDown.SelectedIndex < 0)
                    {
                        // selected index change event does not get raised
                        subjectDropDown.Text = "";
                        Subject = "";
                        OnValueChanged();
                    }

                    _ignoreEvents = false;
                }
            }
        }

        private void subjectDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents)
            {
                Subject = subjectDropDown.Text;
                _network.SendMessage($"SetSubjectInfo:{Project}/{Subject}");
            }
            OnValueChanged();
        }

        private void subjectDropDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!subjectDropDown.Items.Contains(subjectDropDown.Text))
                {
                    createButton.Visible = true;
                }
            }

        }

        private void subjectDropDown_TextChanged(object sender, EventArgs e)
        {
            createButton.Visible = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            createButton.Visible = false;

            Subject = subjectDropDown.Text;
            _network.SendMessage($"SetSubjectInfo:{Project}/{Subject}");

            _ignoreEvents = true;

            var subjects = subjectDropDown.Items.Cast<Object>().Select(item => item.ToString()).ToList();
            subjectDropDown.Items.Add(Subject);
            subjects.Add(Subject);
            subjects.Sort();
            subjectDropDown.Items.Clear();
            subjectDropDown.Items.AddRange(subjects.ToArray());

            subjectDropDown.SelectedIndex = subjects.IndexOf(Subject);
            subjectDropDown.Text = Subject;

            _ignoreEvents = false;
        }

    }
}
