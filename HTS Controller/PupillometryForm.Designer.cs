namespace HTSController
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
            this.dataFileTextBox.Location = new System.Drawing.Point(5, 47);
            this.dataFileTextBox.Name = "dataFileTextBox";
            this.dataFileTextBox.ReadOnly = true;
            this.dataFileTextBox.Size = new System.Drawing.Size(268, 20);
            this.dataFileTextBox.TabIndex = 17;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(5, 73);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(268, 15);
            this.progressBar.TabIndex = 14;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(5, 7);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 26);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Measure dynamic range";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(194, 7);
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
            this.logTextBox.Location = new System.Drawing.Point(4, 94);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(269, 83);
            this.logTextBox.TabIndex = 18;
            // 
            // gazeStartButton
            // 
            this.gazeStartButton.Location = new System.Drawing.Point(5, 15);
            this.gazeStartButton.Name = "gazeStartButton";
            this.gazeStartButton.Size = new System.Drawing.Size(115, 26);
            this.gazeStartButton.TabIndex = 19;
            this.gazeStartButton.Text = "Calibrate gaze";
            this.gazeStartButton.UseVisualStyleBackColor = true;
            this.gazeStartButton.Click += new System.EventHandler(this.gazeStartButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dynamicRangePage);
            this.tabControl.Controls.Add(this.calibrationPage);
            this.tabControl.Location = new System.Drawing.Point(9, 10);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(468, 376);
            this.tabControl.TabIndex = 20;
            // 
            // dynamicRangePage
            // 
            this.dynamicRangePage.Controls.Add(this.label1);
            this.dynamicRangePage.Controls.Add(this.matlabDropDown);
            this.dynamicRangePage.Controls.Add(this.runButton);
            this.dynamicRangePage.Controls.Add(this.logTextBox);
            this.dynamicRangePage.Controls.Add(this.progressBar);
            this.dynamicRangePage.Controls.Add(this.dataFileTextBox);
            this.dynamicRangePage.Controls.Add(this.stopButton);
            this.dynamicRangePage.Controls.Add(this.startButton);
            this.dynamicRangePage.Location = new System.Drawing.Point(4, 22);
            this.dynamicRangePage.Margin = new System.Windows.Forms.Padding(2);
            this.dynamicRangePage.Name = "dynamicRangePage";
            this.dynamicRangePage.Padding = new System.Windows.Forms.Padding(2);
            this.dynamicRangePage.Size = new System.Drawing.Size(460, 350);
            this.dynamicRangePage.TabIndex = 0;
            this.dynamicRangePage.Text = "Dynamic range";
            this.dynamicRangePage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "MATLAB analysis function";
            // 
            // matlabDropDown
            // 
            this.matlabDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matlabDropDown.FormattingEnabled = true;
            this.matlabDropDown.Location = new System.Drawing.Point(3, 208);
            this.matlabDropDown.Name = "matlabDropDown";
            this.matlabDropDown.Size = new System.Drawing.Size(175, 21);
            this.matlabDropDown.TabIndex = 20;
            this.matlabDropDown.SelectedIndexChanged += new System.EventHandler(this.matlabDropDown_SelectedIndexChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(194, 208);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
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
            this.calibrationPage.Location = new System.Drawing.Point(4, 22);
            this.calibrationPage.Margin = new System.Windows.Forms.Padding(2);
            this.calibrationPage.Name = "calibrationPage";
            this.calibrationPage.Padding = new System.Windows.Forms.Padding(2);
            this.calibrationPage.Size = new System.Drawing.Size(460, 350);
            this.calibrationPage.TabIndex = 1;
            this.calibrationPage.Text = "Calibration";
            // 
            // gazePicture
            // 
            this.gazePicture.Location = new System.Drawing.Point(5, 47);
            this.gazePicture.Name = "gazePicture";
            this.gazePicture.Size = new System.Drawing.Size(218, 180);
            this.gazePicture.TabIndex = 23;
            this.gazePicture.TabStop = false;
            this.gazePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.gazePicture_Paint);
            // 
            // gazeLogTextBox
            // 
            this.gazeLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gazeLogTextBox.Location = new System.Drawing.Point(5, 238);
            this.gazeLogTextBox.Multiline = true;
            this.gazeLogTextBox.Name = "gazeLogTextBox";
            this.gazeLogTextBox.ReadOnly = true;
            this.gazeLogTextBox.Size = new System.Drawing.Size(218, 91);
            this.gazeLogTextBox.TabIndex = 22;
            // 
            // gazeStopButton
            // 
            this.gazeStopButton.Location = new System.Drawing.Point(143, 15);
            this.gazeStopButton.Name = "gazeStopButton";
            this.gazeStopButton.Size = new System.Drawing.Size(80, 26);
            this.gazeStopButton.TabIndex = 21;
            this.gazeStopButton.Text = "Stop";
            this.gazeStopButton.UseVisualStyleBackColor = true;
            this.gazeStopButton.Visible = false;
            this.gazeStopButton.Click += new System.EventHandler(this.gazeStopButton_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(229, 15);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(226, 314);
            this.propertyGrid.TabIndex = 20;
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // PupillometryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 399);
            this.Controls.Add(this.tabControl);
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
    }
}