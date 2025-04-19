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
            this.titleLabel = new System.Windows.Forms.Label();
            this.startstopButton = new System.Windows.Forms.Button();
            this.questionPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.filePanel.SuspendLayout();
            this.questionPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.openButton.Click += new System.EventHandler(this.startButton_Click);
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
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.White;
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.Location = new System.Drawing.Point(0, 231);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(181, 30);
            this.titleLabel.TabIndex = 15;
            this.titleLabel.Text = "Protocol";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startstopButton
            // 
            this.startstopButton.Location = new System.Drawing.Point(3, 366);
            this.startstopButton.Name = "startstopButton";
            this.startstopButton.Size = new System.Drawing.Size(178, 35);
            this.startstopButton.TabIndex = 16;
            this.startstopButton.Text = "Start";
            this.startstopButton.UseVisualStyleBackColor = true;
            // 
            // questionPanel
            // 
            this.questionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionPanel.Controls.Add(this.button3);
            this.questionPanel.Controls.Add(this.button2);
            this.questionPanel.Controls.Add(this.label1);
            this.questionPanel.Location = new System.Drawing.Point(3, 269);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(178, 91);
            this.questionPanel.TabIndex = 17;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.filePanel);
            this.flowLayoutPanel1.Controls.Add(this.titleLabel);
            this.flowLayoutPanel1.Controls.Add(this.questionPanel);
            this.flowLayoutPanel1.Controls.Add(this.startstopButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(181, 459);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 30);
            this.label3.TabIndex = 19;
            this.label3.Text = "Protocol";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProtocolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ProtocolControl";
            this.Size = new System.Drawing.Size(181, 459);
            this.filePanel.ResumeLayout(false);
            this.questionPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button startstopButton;
        private System.Windows.Forms.Panel questionPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
    }
}
