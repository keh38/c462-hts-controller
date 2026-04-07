namespace HTSController.Pages
{
    partial class ProtocolControl
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
            this.editButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.filePanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.questionPanel = new System.Windows.Forms.Panel();
            this.noButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.CheckBox();
            this.filePanel.SuspendLayout();
            this.questionPanel.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(20, 128);
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(192, 44);
            this.editButton.TabIndex = 13;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(20, 4);
            this.listBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(191, 116);
            this.listBox.TabIndex = 10;
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(20, 180);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(192, 44);
            this.openButton.TabIndex = 9;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // filePanel
            // 
            this.filePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filePanel.Controls.Add(this.listBox);
            this.filePanel.Controls.Add(this.editButton);
            this.filePanel.Controls.Add(this.openButton);
            this.filePanel.Location = new System.Drawing.Point(4, 46);
            this.filePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(233, 234);
            this.filePanel.TabIndex = 14;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(5, 4);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(112, 43);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // questionPanel
            // 
            this.questionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionPanel.Controls.Add(this.noButton);
            this.questionPanel.Controls.Add(this.yesButton);
            this.questionPanel.Controls.Add(this.questionLabel);
            this.questionPanel.Location = new System.Drawing.Point(4, 324);
            this.questionPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(237, 112);
            this.questionPanel.TabIndex = 17;
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(119, 69);
            this.noButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(107, 36);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(4, 69);
            this.yesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(107, 36);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // questionLabel
            // 
            this.questionLabel.Location = new System.Drawing.Point(4, 4);
            this.questionLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(221, 62);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "label1";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.titleLabel);
            this.flowLayoutPanel.Controls.Add(this.filePanel);
            this.flowLayoutPanel.Controls.Add(this.statusTextBox);
            this.flowLayoutPanel.Controls.Add(this.questionPanel);
            this.flowLayoutPanel.Controls.Add(this.controlPanel);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(245, 612);
            this.flowLayoutPanel.TabIndex = 18;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(245, 36);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Protocol";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusTextBox
            // 
            this.statusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusTextBox.Location = new System.Drawing.Point(4, 294);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(233, 22);
            this.statusTextBox.TabIndex = 22;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.closeButton);
            this.controlPanel.Controls.Add(this.startButton);
            this.controlPanel.Controls.Add(this.stopButton);
            this.controlPanel.Location = new System.Drawing.Point(4, 444);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(237, 52);
            this.controlPanel.TabIndex = 23;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(120, 4);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 43);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.stopButton.Location = new System.Drawing.Point(5, 5);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(111, 43);
            this.stopButton.TabIndex = 24;
            this.stopButton.Text = "Stop";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.CheckedChanged += new System.EventHandler(this.stopButton_CheckedChanged);
            // 
            // ProtocolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProtocolControl";
            this.Size = new System.Drawing.Size(245, 612);
            this.filePanel.ResumeLayout(false);
            this.questionPanel.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel questionPanel;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox stopButton;
    }
}
