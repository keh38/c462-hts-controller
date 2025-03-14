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
            this.sendButton = new System.Windows.Forms.Button();
            this.freqBox = new KLib.Controls.KNumericBox();
            this.levelBox = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(485, 64);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 35);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(617, 64);
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
            this.led1.Location = new System.Drawing.Point(571, 17);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(79, 26);
            this.led1.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(617, 215);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(110, 35);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // freqBox
            // 
            this.freqBox.AllowInf = false;
            this.freqBox.AutoSize = true;
            this.freqBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.freqBox.ClearOnDisable = false;
            this.freqBox.FloatValue = 0F;
            this.freqBox.IntValue = 0;
            this.freqBox.IsInteger = false;
            this.freqBox.Location = new System.Drawing.Point(627, 126);
            this.freqBox.MaxCoerce = false;
            this.freqBox.MaximumSize = new System.Drawing.Size(20000, 20);
            this.freqBox.MaxValue = 1.7976931348623157E+308D;
            this.freqBox.MinCoerce = false;
            this.freqBox.MinimumSize = new System.Drawing.Size(10, 20);
            this.freqBox.MinValue = 0D;
            this.freqBox.Name = "freqBox";
            this.freqBox.Size = new System.Drawing.Size(100, 20);
            this.freqBox.TabIndex = 5;
            this.freqBox.TextFormat = "K4";
            this.freqBox.ToolTip = "";
            this.freqBox.Units = "";
            this.freqBox.Value = 0D;
            this.freqBox.ValueChanged += new System.EventHandler(this.freqBox_ValueChanged);
            // 
            // levelBox
            // 
            this.levelBox.AllowInf = false;
            this.levelBox.AutoSize = true;
            this.levelBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.levelBox.ClearOnDisable = false;
            this.levelBox.FloatValue = 0F;
            this.levelBox.IntValue = 0;
            this.levelBox.IsInteger = false;
            this.levelBox.Location = new System.Drawing.Point(627, 164);
            this.levelBox.MaxCoerce = false;
            this.levelBox.MaximumSize = new System.Drawing.Size(20000, 20);
            this.levelBox.MaxValue = 1.7976931348623157E+308D;
            this.levelBox.MinCoerce = false;
            this.levelBox.MinimumSize = new System.Drawing.Size(10, 20);
            this.levelBox.MinValue = 0D;
            this.levelBox.Name = "levelBox";
            this.levelBox.Size = new System.Drawing.Size(100, 20);
            this.levelBox.TabIndex = 6;
            this.levelBox.TextFormat = "K4";
            this.levelBox.ToolTip = "";
            this.levelBox.Units = "";
            this.levelBox.Value = 0D;
            this.levelBox.ValueChanged += new System.EventHandler(this.levelBox_ValueChanged);
            // 
            // InteractiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 409);
            this.Controls.Add(this.levelBox);
            this.Controls.Add(this.freqBox);
            this.Controls.Add(this.sendButton);
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
        private System.Windows.Forms.Button sendButton;
        private KLib.Controls.KNumericBox freqBox;
        private KLib.Controls.KNumericBox levelBox;
    }
}