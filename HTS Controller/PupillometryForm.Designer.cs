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
            this.calButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dynamicRangePage = new System.Windows.Forms.TabPage();
            this.calibrationPage = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.dynamicRangePage.SuspendLayout();
            this.calibrationPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataFileTextBox
            // 
            this.dataFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFileTextBox.Location = new System.Drawing.Point(7, 58);
            this.dataFileTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataFileTextBox.Name = "dataFileTextBox";
            this.dataFileTextBox.ReadOnly = true;
            this.dataFileTextBox.Size = new System.Drawing.Size(357, 22);
            this.dataFileTextBox.TabIndex = 17;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 90);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(357, 18);
            this.progressBar.TabIndex = 14;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(7, 9);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(176, 32);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Measure dynamic range";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(258, 9);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.logTextBox.Location = new System.Drawing.Point(6, 116);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(358, 102);
            this.logTextBox.TabIndex = 18;
            // 
            // calButton
            // 
            this.calButton.Location = new System.Drawing.Point(7, 7);
            this.calButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.calButton.Name = "calButton";
            this.calButton.Size = new System.Drawing.Size(176, 32);
            this.calButton.TabIndex = 19;
            this.calButton.Text = "Calibrate gaze";
            this.calButton.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dynamicRangePage);
            this.tabControl.Controls.Add(this.calibrationPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(518, 422);
            this.tabControl.TabIndex = 20;
            // 
            // dynamicRangePage
            // 
            this.dynamicRangePage.Controls.Add(this.logTextBox);
            this.dynamicRangePage.Controls.Add(this.progressBar);
            this.dynamicRangePage.Controls.Add(this.dataFileTextBox);
            this.dynamicRangePage.Controls.Add(this.stopButton);
            this.dynamicRangePage.Controls.Add(this.startButton);
            this.dynamicRangePage.Location = new System.Drawing.Point(4, 25);
            this.dynamicRangePage.Name = "dynamicRangePage";
            this.dynamicRangePage.Padding = new System.Windows.Forms.Padding(3);
            this.dynamicRangePage.Size = new System.Drawing.Size(510, 393);
            this.dynamicRangePage.TabIndex = 0;
            this.dynamicRangePage.Text = "Dynamic range";
            this.dynamicRangePage.UseVisualStyleBackColor = true;
            // 
            // calibrationPage
            // 
            this.calibrationPage.Controls.Add(this.calButton);
            this.calibrationPage.Location = new System.Drawing.Point(4, 25);
            this.calibrationPage.Name = "calibrationPage";
            this.calibrationPage.Padding = new System.Windows.Forms.Padding(3);
            this.calibrationPage.Size = new System.Drawing.Size(510, 393);
            this.calibrationPage.TabIndex = 1;
            this.calibrationPage.Text = "Calibration";
            this.calibrationPage.UseVisualStyleBackColor = true;
            // 
            // PupillometryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 459);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PupillometryForm";
            this.Text = "PupillometryForm";
            this.tabControl.ResumeLayout(false);
            this.dynamicRangePage.ResumeLayout(false);
            this.dynamicRangePage.PerformLayout();
            this.calibrationPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox dataFileTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button calButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dynamicRangePage;
        private System.Windows.Forms.TabPage calibrationPage;
    }
}