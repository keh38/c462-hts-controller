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

using KLib;
using KLib.Signals;
using KLib.Controls;

using Turandot;
using Turandot.Interactive;
using Turandot.Schedules;

namespace Turandot_Editor
{
    public partial class InteractiveControlGridView : KUserControl
    {
        List<InteractiveControl> _controls = null;
        List<ChannelProperties> _channelProperties = null;

        public InteractiveControlGridView()
        {
            InitializeComponent();
        }

        public List<InteractiveControl> Value
        {
            get { return _controls; }
            set
            {
                _controls = value;
                ShowControls(_controls);
            }
        }

        public void SetDataForContext(List<ChannelProperties> properties)
        {
            _controls = new List<InteractiveControl>();
            _channelProperties = properties;

            UpdateAvailableChannels();
        }

        public int MaxNumberRows { get; set; }

        public void UpdateAvailableChannels()
        {
            dataGridView.Rows.Clear();

            DataGridViewComboBoxColumn col = dataGridView.Columns["Channel"] as DataGridViewComboBoxColumn;
            col.Items.Clear();
            col.Items.AddRange(_channelProperties.Select(x => x.channelName).ToArray());

            ShowControls(_controls);
        }

        private void ShowControls(List<InteractiveControl> controls)
        {
            if (controls == null) return;

            _ignoreEvents = true;

            dataGridView.Rows.Clear();
            foreach (var c in controls) AddControlRow(c);

            if (MaxNumberRows == 0) DisableCells(dataGridView.RowCount - 1, 1);

            _ignoreEvents = false;
        }

        private void DisableCells(int rowIndex, int from)
        {
            if (rowIndex >= 0)
            {
                for (int k = 1; k < 3; k++) dataGridView.Rows[rowIndex].Cells[k].ReadOnly = k >= from;
            }
        }

        private void propGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_ignoreEvents && _controls != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                var cells = dataGridView.Rows[rowIndex].Cells;
                string channel = cells["Channel"].Value as string;

                if (dataGridView.CurrentCell.ColumnIndex == 0)
                {
                    if (dataGridView.CurrentCell.RowIndex == _controls.Count && (MaxNumberRows == 0 || dataGridView.Rows.Count < MaxNumberRows))
                    {
                        _controls.Add(new InteractiveControl() { channel = channel }); 
                    }
                    else
                    {
                        _controls[rowIndex].channel = channel;
                    }
                    DisableCells(rowIndex, 10);
                    _ignoreEvents = true;
                    UpdateChannelSelection(rowIndex, channel);
                    _ignoreEvents = false;
                }
                else if (dataGridView.CurrentCell.ColumnIndex == 1)
                {
                    _controls[rowIndex].property = cells["Property"].Value as string;
                }
                else if (dataGridView.CurrentCell.ColumnIndex == 2)
                {
                    _controls[rowIndex].expression = cells["Expr"].Value as string;
                    //TestExpression(cells["Expr"]);
                }
                OnValueChanged();
            }
        }

        private void TestExpression(DataGridViewCell cell)
        {
            //string xvector = "";
            //string yvector = "";
            //for (int k=0; k<_controls.Count;k++)
            //{
            //    //if (k != cell.RowIndex && _varList[k].dim == VarDimension.X && string.IsNullOrEmpty(xvector))
            //    if (string.IsNullOrEmpty(xvector) && _controls[k].dim == VarDimension.X)
            //    {
            //        float[] xvec = Expressions.Evaluate(_controls[k].expression);
            //        xvector = Expressions.ToVectorString(xvec);
            //    }

            //    if (k != cell.RowIndex && _controls[k].dim == VarDimension.Y && string.IsNullOrEmpty(yvector))
            //    {
            //        string yexpr = _controls[k].expression;
            //        if (yexpr.Contains("X") && !string.IsNullOrEmpty(xvector)) yexpr = yexpr.Replace("X", xvector);

            //        float[] yvec = Expressions.Evaluate(yexpr);
            //        yvector = Expressions.ToVectorString(yvec);
            //    }
            //}

            //string expr = cell.Value as string;
            //if (expr.Contains("X") && !string.IsNullOrEmpty(xvector)) expr = expr.Replace("X", xvector);
            //if (expr.Contains("Y") && !string.IsNullOrEmpty(yvector)) expr = expr.Replace("Y", yvector);

            //if (!Expressions.TryEvaluate(expr, _propVals))
            //{
            //    cell.ErrorText = Expressions.LastError;
            //}
            //else cell.ErrorText = "";
        }

        private void UpdateChannelSelection(int rowIndex, string channel)
        {
            DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["Property"];
            cbCell.Value = null;
            cbCell.Items.Clear();

            var props = _channelProperties.Find(x => x.channelName.Equals(channel)).properties;
            cbCell.Items.AddRange(props.ToArray());

            if (props.Count == 1)
            {
                cbCell.Value = props[0];
                _controls[rowIndex].property = props[0];
                //DisableCells(rowIndex, 10);
            }
            else if (props.Contains(_controls[rowIndex].property)) cbCell.Value = _controls[rowIndex].property;
        }

        private void AddControlRow(InteractiveControl control)
        {
            int rowIndex = dataGridView.Rows.Add();
            var cells = dataGridView.Rows[rowIndex].Cells;

            UpdateChannelSelection(rowIndex, control.channel);

            cells["Channel"].Value = control.channel;
            cells["Property"].Value = control.property;
            cells["Expr"].Value = control.expression;

            dataGridView.AllowUserToAddRows = MaxNumberRows == 0 || dataGridView.Rows.Count < MaxNumberRows;

            DisableCells(rowIndex, 10);
        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!_ignoreEvents && dataGridView.CurrentCell.ColumnIndex<3 && dataGridView.IsCurrentCellDirty)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!_ignoreEvents)
            {
                _controls.RemoveAt(e.Row.Index);
                OnValueChanged();
            }
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (MaxNumberRows > 0 && dataGridView.Rows != null) dataGridView.AllowUserToAddRows = dataGridView.Rows.Count < MaxNumberRows;
        }

        private void dataGridView_Leave(object sender, EventArgs e)
        {
            //if (_controls == null) return;

            //List<Variable> toDelete = new List<Variable>();
            //foreach (Variable v in _controls)
            //{
            //    if (string.IsNullOrEmpty(v.state) ||
            //        string.IsNullOrEmpty(v.chan) ||
            //        string.IsNullOrEmpty(v.property) ||
            //        string.IsNullOrEmpty(v.expression))
            //    {
            //        toDelete.Add(v);
            //    }
            //}
            //foreach (Variable v in toDelete) _controls.Remove(v);
            //if (toDelete.Count > 0) ShowFamily(_controls);
        }

        private void dataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu cm = BuildContextMenu(e.Location);
                cm.Show(this, e.Location);
            }
        }

        private ContextMenu BuildContextMenu(Point point)
        {
            var cm = new ContextMenu();

            MenuItem mi;

            if (_controls.Count > 1)
            {
                mi = new MenuItem();
                mi.Text = "Sort";
                mi.Click += sortClick;
                cm.MenuItems.Add(mi);

                mi = new MenuItem();
                mi.Text = "-";
                cm.MenuItems.Add(mi);
            }

            if (_controls.Count > 0)
            {
                mi = new MenuItem();
                mi.Text = "Delete selected row(s)";
                mi.Click += deleteRowClick;
                cm.MenuItems.Add(mi);

                mi = new MenuItem();
                mi.Text = "-";
                cm.MenuItems.Add(mi);

                mi = new MenuItem();
                mi.Text = "Clear table";
                mi.Click += clearTableClick;
                cm.MenuItems.Add(mi);
            }

            return cm;
        }

        void deleteRowClick(object sender, EventArgs e)
        {
            //List<Variable> toDelete = new List<Variable>();
            //foreach (var row in dataGridView.SelectedRows)
            //    toDelete.Add(_controls[row.Index]);

            //foreach (var v in toDelete) _controls.Remove(v);

            //foreach (DataGridViewRow row in dataGridView.SelectedRows)
            //    dataGridView.Rows.Remove(row);

            //OnValueChanged();
        }

        void clearTableClick(object sender, EventArgs e)
        {
            //_controls.Clear();
            //ShowFamily(_controls);

            //OnValueChanged();
        }

        void sortClick(object sender, EventArgs e)
        {
            //List<Variable> tmp = new List<Variable>();
            //foreach (Variable v in _controls) tmp.Add(new Variable(v));

            //_controls.Clear();
            //foreach (Variable v in tmp.FindAll(o => o.dim == VarDimension.X)) _controls.Add(new Variable(v));
            //foreach (Variable v in tmp.FindAll(o => o.dim == VarDimension.Y)) _controls.Add(new Variable(v));
            //foreach (Variable v in tmp.FindAll(o => o.dim == VarDimension.Ind)) _controls.Add(new Variable(v));

            //ShowFamily(_controls);

            //OnValueChanged();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

    }
}
