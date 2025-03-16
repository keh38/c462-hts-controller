﻿namespace HTSController
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
            this.audioErrorTextBox = new System.Windows.Forms.TextBox();
            this.signalGraph = new ZedGraph.ZedGraphControl();
            this.channelListBox = new KLib.Controls.KUserListBox();
            this.levelBox = new KLib.Controls.KNumericBox();
            this.freqBox = new KLib.Controls.KNumericBox();
            this.channelView = new KLib.Unity.Controls.Signals.ChannelView();
            this.graphTabControl = new System.Windows.Forms.TabControl();
            this.graphPage = new System.Windows.Forms.TabPage();
            this.errorPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.graphTabControl.SuspendLayout();
            this.graphPage.SuspendLayout();
            this.errorPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(590, 71);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 35);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(722, 71);
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
            this.led1.Location = new System.Drawing.Point(676, 24);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(79, 26);
            this.led1.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(722, 222);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(110, 35);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // audioErrorTextBox
            // 
            this.audioErrorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.audioErrorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.audioErrorTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.audioErrorTextBox.Location = new System.Drawing.Point(20, 41);
            this.audioErrorTextBox.Multiline = true;
            this.audioErrorTextBox.Name = "audioErrorTextBox";
            this.audioErrorTextBox.ReadOnly = true;
            this.audioErrorTextBox.Size = new System.Drawing.Size(457, 117);
            this.audioErrorTextBox.TabIndex = 8;
            // 
            // signalGraph
            // 
            this.signalGraph.BackColor = System.Drawing.SystemColors.Control;
            this.signalGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalGraph.Location = new System.Drawing.Point(3, 3);
            this.signalGraph.Name = "signalGraph";
            this.signalGraph.ScrollGrace = 0D;
            this.signalGraph.ScrollMaxX = 0D;
            this.signalGraph.ScrollMaxY = 0D;
            this.signalGraph.ScrollMaxY2 = 0D;
            this.signalGraph.ScrollMinX = 0D;
            this.signalGraph.ScrollMinY = 0D;
            this.signalGraph.ScrollMinY2 = 0D;
            this.signalGraph.Size = new System.Drawing.Size(489, 171);
            this.signalGraph.TabIndex = 10;
            // 
            // channelListBox
            // 
            this.channelListBox.DefaultName = "Signal";
            this.channelListBox.Location = new System.Drawing.Point(24, 17);
            this.channelListBox.Name = "channelListBox";
            this.channelListBox.SelectedIndex = -1;
            this.channelListBox.Size = new System.Drawing.Size(219, 136);
            this.channelListBox.TabIndex = 7;
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
            this.levelBox.Location = new System.Drawing.Point(732, 171);
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
            // freqBox
            // 
            this.freqBox.AllowInf = false;
            this.freqBox.AutoSize = true;
            this.freqBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.freqBox.ClearOnDisable = false;
            this.freqBox.FloatValue = 0F;
            this.freqBox.IntValue = 0;
            this.freqBox.IsInteger = false;
            this.freqBox.Location = new System.Drawing.Point(732, 133);
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
            // channelView
            // 
            this.channelView.AllowExpertOptions = false;
            this.channelView.AutoScroll = true;
            this.channelView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.channelView.Location = new System.Drawing.Point(277, 17);
            this.channelView.Name = "channelView";
            this.channelView.Size = new System.Drawing.Size(238, 461);
            this.channelView.TabIndex = 11;
            this.channelView.Value = null;
            this.channelView.WavFolder = null;
            // 
            // graphTabControl
            // 
            this.graphTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.graphTabControl.Controls.Add(this.graphPage);
            this.graphTabControl.Controls.Add(this.errorPage);
            this.graphTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.graphTabControl.Location = new System.Drawing.Point(12, 479);
            this.graphTabControl.Name = "graphTabControl";
            this.graphTabControl.SelectedIndex = 0;
            this.graphTabControl.Size = new System.Drawing.Size(503, 186);
            this.graphTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.graphTabControl.TabIndex = 12;
            // 
            // graphPage
            // 
            this.graphPage.BackColor = System.Drawing.SystemColors.Control;
            this.graphPage.Controls.Add(this.signalGraph);
            this.graphPage.Location = new System.Drawing.Point(4, 5);
            this.graphPage.Name = "graphPage";
            this.graphPage.Padding = new System.Windows.Forms.Padding(3);
            this.graphPage.Size = new System.Drawing.Size(495, 177);
            this.graphPage.TabIndex = 0;
            this.graphPage.Text = "tabPage1";
            // 
            // errorPage
            // 
            this.errorPage.BackColor = System.Drawing.SystemColors.Control;
            this.errorPage.Controls.Add(this.label1);
            this.errorPage.Controls.Add(this.audioErrorTextBox);
            this.errorPage.Location = new System.Drawing.Point(4, 5);
            this.errorPage.Name = "errorPage";
            this.errorPage.Padding = new System.Windows.Forms.Padding(3);
            this.errorPage.Size = new System.Drawing.Size(495, 177);
            this.errorPage.TabIndex = 1;
            this.errorPage.Text = "tabPage2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Errors";
            // 
            // InteractiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 677);
            this.Controls.Add(this.graphTabControl);
            this.Controls.Add(this.channelView);
            this.Controls.Add(this.channelListBox);
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
            this.graphTabControl.ResumeLayout(false);
            this.graphPage.ResumeLayout(false);
            this.errorPage.ResumeLayout(false);
            this.errorPage.PerformLayout();
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
        private System.Windows.Forms.TextBox audioErrorTextBox;
        private KLib.Controls.KUserListBox channelListBox;
        private ZedGraph.ZedGraphControl signalGraph;
        private KLib.Unity.Controls.Signals.ChannelView channelView;
        private System.Windows.Forms.TabControl graphTabControl;
        private System.Windows.Forms.TabPage graphPage;
        private System.Windows.Forms.TabPage errorPage;
        private System.Windows.Forms.Label label1;
    }
}