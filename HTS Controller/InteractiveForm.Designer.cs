namespace HTSController
{
    partial class InteractiveForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InteractiveForm));
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.displayTimer = new System.Windows.Forms.Timer(this.components);
            this.led1 = new System.Windows.Forms.Panel();
            this.noisePage1 = new KLib.Unity.Controls.Signals.NoisePage();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(36, 59);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 35);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(168, 59);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(110, 35);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "nav_plain_green.png");
            this.imageList.Images.SetKeyName(1, "nav_plain_red.png");
            // 
            // displayTimer
            // 
            this.displayTimer.Interval = 20;
            this.displayTimer.Tick += new System.EventHandler(this.displayTimer_Tick);
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.led1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.led1.Location = new System.Drawing.Point(122, 12);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(79, 26);
            this.led1.TabIndex = 2;
            // 
            // noisePage1
            // 
            this.noisePage1.AutoSize = true;
            this.noisePage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.noisePage1.Location = new System.Drawing.Point(371, 59);
            this.noisePage1.Name = "noisePage1";
            this.noisePage1.Size = new System.Drawing.Size(180, 152);
            this.noisePage1.TabIndex = 3;
            this.noisePage1.Value = null;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(168, 176);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(110, 35);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // InteractiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 409);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.noisePage1);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "InteractiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interactive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InteractiveForm_FormClosing);
            this.Shown += new System.EventHandler(this.InteractiveForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.Panel led1;
        private KLib.Unity.Controls.Signals.NoisePage noisePage1;
        private System.Windows.Forms.Button sendButton;
    }
}