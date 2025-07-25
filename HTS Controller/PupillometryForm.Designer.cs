﻿namespace HTSController
{
    partial class PupillometryForm
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
            this.gazeStartButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dynamicRangePage = new System.Windows.Forms.TabPage();
            this.dynamicRangePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.matlabDropDown = new System.Windows.Forms.ComboBox();
            this.runButton = new System.Windows.Forms.Button();
            this.calibrationPage = new System.Windows.Forms.TabPage();
            this.gazePicture = new System.Windows.Forms.PictureBox();
            this.gazeLogTextBox = new System.Windows.Forms.TextBox();
            this.gazeStopButton = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabControl.SuspendLayout();
            this.dynamicRangePage.SuspendLayout();
            this.calibrationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gazePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dataFileTextBox
            // 
            this.dataFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFileTextBox.Location = new System.Drawing.Point(7, 58);
            this.dataFileTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.dataFileTextBox.Name = "dataFileTextBox";
            this.dataFileTextBox.ReadOnly = true;
            this.dataFileTextBox.Size = new System.Drawing.Size(291, 22);
            this.dataFileTextBox.TabIndex = 17;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 88);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(291, 20);
            this.progressBar.TabIndex = 14;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(7, 9);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(176, 32);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Measure dynamic range";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(191, 9);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(107, 32);
            this.stopButton.TabIndex = 16;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Location = new System.Drawing.Point(5, 116);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(293, 102);
            this.logTextBox.TabIndex = 18;
            // 
            // gazeStartButton
            // 
            this.gazeStartButton.Location = new System.Drawing.Point(7, 18);
            this.gazeStartButton.Margin = new System.Windows.Forms.Padding(4);
            this.gazeStartButton.Name = "gazeStartButton";
            this.gazeStartButton.Size = new System.Drawing.Size(153, 32);
            this.gazeStartButton.TabIndex = 19;
            this.gazeStartButton.Text = "Calibrate gaze";
            this.gazeStartButton.UseVisualStyleBackColor = true;
            this.gazeStartButton.Click += new System.EventHandler(this.gazeStartButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dynamicRangePage);
            this.tabControl.Controls.Add(this.calibrationPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(624, 463);
            this.tabControl.TabIndex = 20;
            // 
            // dynamicRangePage
            // 
            this.dynamicRangePage.Controls.Add(this.dynamicRangePropertyGrid);
            this.dynamicRangePage.Controls.Add(this.label1);
            this.dynamicRangePage.Controls.Add(this.matlabDropDown);
            this.dynamicRangePage.Controls.Add(this.runButton);
            this.dynamicRangePage.Controls.Add(this.logTextBox);
            this.dynamicRangePage.Controls.Add(this.progressBar);
            this.dynamicRangePage.Controls.Add(this.dataFileTextBox);
            this.dynamicRangePage.Controls.Add(this.stopButton);
            this.dynamicRangePage.Controls.Add(this.startButton);
            this.dynamicRangePage.Location = new System.Drawing.Point(4, 25);
            this.dynamicRangePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamicRangePage.Name = "dynamicRangePage";
            this.dynamicRangePage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dynamicRangePage.Size = new System.Drawing.Size(616, 434);
            this.dynamicRangePage.TabIndex = 0;
            this.dynamicRangePage.Text = "Dynamic range";
            this.dynamicRangePage.UseVisualStyleBackColor = true;
            // 
            // dynamicRangePropertyGrid
            // 
            this.dynamicRangePropertyGrid.Location = new System.Drawing.Point(306, 9);
            this.dynamicRangePropertyGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dynamicRangePropertyGrid.Name = "dynamicRangePropertyGrid";
            this.dynamicRangePropertyGrid.Size = new System.Drawing.Size(303, 353);
            this.dynamicRangePropertyGrid.TabIndex = 22;
            this.dynamicRangePropertyGrid.ToolbarVisible = false;
            this.dynamicRangePropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.dynamicRangePropertyGrid_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 236);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "MATLAB analysis function";
            // 
            // matlabDropDown
            // 
            this.matlabDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matlabDropDown.FormattingEnabled = true;
            this.matlabDropDown.Location = new System.Drawing.Point(4, 256);
            this.matlabDropDown.Margin = new System.Windows.Forms.Padding(4);
            this.matlabDropDown.Name = "matlabDropDown";
            this.matlabDropDown.Size = new System.Drawing.Size(294, 24);
            this.matlabDropDown.TabIndex = 20;
            this.matlabDropDown.SelectedIndexChanged += new System.EventHandler(this.matlabDropDown_SelectedIndexChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(4, 288);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(100, 28);
            this.runButton.TabIndex = 19;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // calibrationPage
            // 
            this.calibrationPage.BackColor = System.Drawing.SystemColors.Control;
            this.calibrationPage.Controls.Add(this.gazePicture);
            this.calibrationPage.Controls.Add(this.gazeLogTextBox);
            this.calibrationPage.Controls.Add(this.gazeStopButton);
            this.calibrationPage.Controls.Add(this.propertyGrid);
            this.calibrationPage.Controls.Add(this.gazeStartButton);
            this.calibrationPage.Location = new System.Drawing.Point(4, 25);
            this.calibrationPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calibrationPage.Name = "calibrationPage";
            this.calibrationPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calibrationPage.Size = new System.Drawing.Size(616, 434);
            this.calibrationPage.TabIndex = 1;
            this.calibrationPage.Text = "Calibration";
            // 
            // gazePicture
            // 
            this.gazePicture.Location = new System.Drawing.Point(7, 58);
            this.gazePicture.Margin = new System.Windows.Forms.Padding(4);
            this.gazePicture.Name = "gazePicture";
            this.gazePicture.Size = new System.Drawing.Size(291, 222);
            this.gazePicture.TabIndex = 23;
            this.gazePicture.TabStop = false;
            this.gazePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.gazePicture_Paint);
            // 
            // gazeLogTextBox
            // 
            this.gazeLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gazeLogTextBox.Location = new System.Drawing.Point(7, 293);
            this.gazeLogTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.gazeLogTextBox.Multiline = true;
            this.gazeLogTextBox.Name = "gazeLogTextBox";
            this.gazeLogTextBox.ReadOnly = true;
            this.gazeLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gazeLogTextBox.Size = new System.Drawing.Size(290, 112);
            this.gazeLogTextBox.TabIndex = 22;
            // 
            // gazeStopButton
            // 
            this.gazeStopButton.Location = new System.Drawing.Point(191, 18);
            this.gazeStopButton.Margin = new System.Windows.Forms.Padding(4);
            this.gazeStopButton.Name = "gazeStopButton";
            this.gazeStopButton.Size = new System.Drawing.Size(107, 32);
            this.gazeStopButton.TabIndex = 21;
            this.gazeStopButton.Text = "Stop";
            this.gazeStopButton.UseVisualStyleBackColor = true;
            this.gazeStopButton.Visible = false;
            this.gazeStopButton.Click += new System.EventHandler(this.gazeStopButton_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(305, 18);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(301, 386);
            this.propertyGrid.TabIndex = 20;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // PupillometryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 491);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PupillometryForm";
            this.Text = "PupillometryForm";
            this.tabControl.ResumeLayout(false);
            this.dynamicRangePage.ResumeLayout(false);
            this.dynamicRangePage.PerformLayout();
            this.calibrationPage.ResumeLayout(false);
            this.calibrationPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gazePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox dataFileTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button gazeStartButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dynamicRangePage;
        private System.Windows.Forms.TabPage calibrationPage;
        private System.Windows.Forms.PictureBox gazePicture;
        private System.Windows.Forms.TextBox gazeLogTextBox;
        private System.Windows.Forms.Button gazeStopButton;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox matlabDropDown;
        private System.Windows.Forms.PropertyGrid dynamicRangePropertyGrid;
    }
}