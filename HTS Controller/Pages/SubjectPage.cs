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
    }
}
