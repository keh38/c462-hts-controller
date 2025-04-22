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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.editButton.Location = new System.Drawing.Point(15, 104);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(144, 36);
            this.editButton.TabIndex = 13;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(15, 3);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(144, 95);
            this.listBox.TabIndex = 10;
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(15, 146);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(144, 36);
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
            this.filePanel.Location = new System.Drawing.Point(3, 38);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(175, 190);
            this.filePanel.TabIndex = 14;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(4, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(84, 35);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // questionPanel
            // 
            this.questionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionPanel.Controls.Add(this.button3);
            this.questionPanel.Controls.Add(this.button2);
            this.questionPanel.Controls.Add(this.label1);
            this.questionPanel.Location = new System.Drawing.Point(3, 265);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(178, 91);
            this.questionPanel.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "No";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Yes";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.titleLabel);
            this.flowLayoutPanel.Controls.Add(this.filePanel);
            this.flowLayoutPanel.Controls.Add(this.statusTextBox);
            this.flowLayoutPanel.Controls.Add(this.questionPanel);
            this.flowLayoutPanel.Controls.Add(this.controlPanel);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(181, 497);
            this.flowLayoutPanel.TabIndex = 18;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(181, 30);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Protocol";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusTextBox
            // 
            this.statusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusTextBox.Location = new System.Drawing.Point(3, 239);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(175, 20);
            this.statusTextBox.TabIndex = 22;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.closeButton);
            this.controlPanel.Controls.Add(this.startButton);
            this.controlPanel.Controls.Add(this.stopButton);
            this.controlPanel.Location = new System.Drawing.Point(3, 362);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(178, 42);
            this.controlPanel.TabIndex = 23;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(90, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(84, 35);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.stopButton.Location = new System.Drawing.Point(4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(83, 35);
            this.stopButton.TabIndex = 24;
            this.stopButton.Text = "Stop";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.CheckedChanged += new System.EventHandler(this.stopButton_CheckedChanged);
            // 
            // ProtocolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "ProtocolControl";
            this.Size = new System.Drawing.Size(181, 497);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox stopButton;
    }
}
