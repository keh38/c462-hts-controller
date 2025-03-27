namespace HTSController
{
    partial class TurandotLiveForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.closeButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.dataFileTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(36, 18);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 32);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusTextBox.Location = new System.Drawing.Point(36, 100);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(357, 22);
            this.statusTextBox.TabIndex = 5;
            // 
            // logTextBox
            // 
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Location = new System.Drawing.Point(36, 145);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(358, 173);
            this.logTextBox.TabIndex = 6;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(36, 337);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(358, 19);
            this.progressBar.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(287, 18);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(107, 32);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(36, 18);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(107, 32);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // dataFileTextBox
            // 
            this.dataFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFileTextBox.Location = new System.Drawing.Point(36, 68);
            this.dataFileTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataFileTextBox.Name = "dataFileTextBox";
            this.dataFileTextBox.ReadOnly = true;
            this.dataFileTextBox.Size = new System.Drawing.Size(357, 22);
            this.dataFileTextBox.TabIndex = 10;
            // 
            // TurandotLiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 383);
            this.Controls.Add(this.dataFileTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TurandotLiveForm";
            this.Text = "TurandotLiveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox dataFileTextBox;
    }
}