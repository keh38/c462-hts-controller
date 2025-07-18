namespace HTSController
{
    partial class BasicMeasurementForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataFileTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.msSelectMeasurement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataFileTextBox
            // 
            this.dataFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFileTextBox.Location = new System.Drawing.Point(8, 78);
            this.dataFileTextBox.Name = "dataFileTextBox";
            this.dataFileTextBox.ReadOnly = true;
            this.dataFileTextBox.Size = new System.Drawing.Size(219, 20);
            this.dataFileTextBox.TabIndex = 17;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 103);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(218, 16);
            this.progressBar.TabIndex = 14;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(8, 38);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 26);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Measure";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(146, 38);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 26);
            this.stopButton.TabIndex = 16;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Location = new System.Drawing.Point(7, 125);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(220, 113);
            this.logTextBox.TabIndex = 18;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(233, 12);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(262, 287);
            this.propertyGrid.TabIndex = 22;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.dynamicRangePropertyGrid_PropertyValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msSelectMeasurement});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(65, 330);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // msSelectMeasurement
            // 
            this.msSelectMeasurement.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.msSelectMeasurement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.msSelectMeasurement.Name = "msSelectMeasurement";
            this.msSelectMeasurement.Size = new System.Drawing.Size(52, 19);
            this.msSelectMeasurement.Text = "Select...";
            // 
            // BasicMeasurementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 330);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.dataFileTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "BasicMeasurementForm";
            this.Text = "BasicMeasurementForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dataFileTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem msSelectMeasurement;
    }
}