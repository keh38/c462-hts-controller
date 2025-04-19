namespace HTSController.Pages
{
    partial class SubjectPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.projectDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectDropDown = new System.Windows.Forms.ComboBox();
            this.createButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.transducerDropDown = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.metricGridView = new System.Windows.Forms.DataGridView();
            this.MetricName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetricValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.metricGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Projects";
            // 
            // projectDropDown
            // 
            this.projectDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.projectDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.projectDropDown.FormattingEnabled = true;
            this.projectDropDown.Location = new System.Drawing.Point(40, 44);
            this.projectDropDown.Name = "projectDropDown";
            this.projectDropDown.Size = new System.Drawing.Size(121, 21);
            this.projectDropDown.TabIndex = 2;
            this.projectDropDown.SelectedIndexChanged += new System.EventHandler(this.projectDropDown_SelectedIndexChanged);
            this.projectDropDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.projectDropDown_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subjects";
            // 
            // subjectDropDown
            // 
            this.subjectDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subjectDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.subjectDropDown.FormattingEnabled = true;
            this.subjectDropDown.Location = new System.Drawing.Point(40, 98);
            this.subjectDropDown.Name = "subjectDropDown";
            this.subjectDropDown.Size = new System.Drawing.Size(121, 21);
            this.subjectDropDown.TabIndex = 4;
            this.subjectDropDown.SelectedIndexChanged += new System.EventHandler(this.subjectDropDown_SelectedIndexChanged);
            this.subjectDropDown.TextChanged += new System.EventHandler(this.subjectDropDown_TextChanged);
            this.subjectDropDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subjectDropDown_KeyDown);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(167, 96);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(73, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Create new";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Visible = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Transducer";
            // 
            // transducerDropDown
            // 
            this.transducerDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.transducerDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.transducerDropDown.FormattingEnabled = true;
            this.transducerDropDown.Location = new System.Drawing.Point(40, 157);
            this.transducerDropDown.Name = "transducerDropDown";
            this.transducerDropDown.Size = new System.Drawing.Size(121, 21);
            this.transducerDropDown.TabIndex = 8;
            this.transducerDropDown.SelectedIndexChanged += new System.EventHandler(this.transducerDropDown_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 203);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Metrics";
            // 
            // metricGridView
            // 
            this.metricGridView.AllowUserToResizeColumns = false;
            this.metricGridView.AllowUserToResizeRows = false;
            this.metricGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.metricGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metricGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metricGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metricGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.metricGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MetricName,
            this.MetricValue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metricGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.metricGridView.EnableHeadersVisualStyles = false;
            this.metricGridView.Location = new System.Drawing.Point(40, 220);
            this.metricGridView.Margin = new System.Windows.Forms.Padding(4);
            this.metricGridView.Name = "metricGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metricGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metricGridView.RowHeadersVisible = false;
            this.metricGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metricGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metricGridView.Size = new System.Drawing.Size(250, 240);
            this.metricGridView.TabIndex = 12;
            this.metricGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.metricGridView_CellValueChanged);
            this.metricGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.metricGridView_UserDeletingRow);
            // 
            // MetricName
            // 
            this.MetricName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MetricName.HeaderText = "Name";
            this.MetricName.Name = "MetricName";
            this.MetricName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MetricName.Width = 125;
            // 
            // MetricValue
            // 
            this.MetricValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MetricValue.HeaderText = "Value";
            this.MetricValue.Name = "MetricValue";
            this.MetricValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(297, 220);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 15;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Visible = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // SubjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.metricGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.transducerDropDown);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectDropDown);
            this.Name = "SubjectPage";
            this.Size = new System.Drawing.Size(569, 486);
            ((System.ComponentModel.ISupportInitialize)(this.metricGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox projectDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox subjectDropDown;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox transducerDropDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView metricGridView;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetricName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetricValue;
    }
}
