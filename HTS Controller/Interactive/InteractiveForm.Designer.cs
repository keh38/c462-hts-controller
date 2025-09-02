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
            this.audioErrorTextBox = new System.Windows.Forms.TextBox();
            this.signalGraph = new ZedGraph.ZedGraphControl();
            this.channelListBox = new KLib.Controls.KUserListBox();
            this.graphTabControl = new System.Windows.Forms.TabControl();
            this.graphPage = new System.Windows.Forms.TabPage();
            this.errorPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.channelView = new KLib.Unity.Controls.Signals.ChannelView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.stimulusPage = new System.Windows.Forms.TabPage();
            this.sliderPage = new System.Windows.Forms.TabPage();
            this.sliderConfig = new HTSController.Interactive.SliderConfig();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.channelControl = new HTSController.ChannelControl();
            this.graphTabControl.SuspendLayout();
            this.graphPage.SuspendLayout();
            this.errorPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.stimulusPage.SuspendLayout();
            this.sliderPage.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(459, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 26);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(459, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 26);
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
            // audioErrorTextBox
            // 
            this.audioErrorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.audioErrorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.audioErrorTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.audioErrorTextBox.Location = new System.Drawing.Point(20, 25);
            this.audioErrorTextBox.Multiline = true;
            this.audioErrorTextBox.Name = "audioErrorTextBox";
            this.audioErrorTextBox.ReadOnly = true;
            this.audioErrorTextBox.Size = new System.Drawing.Size(383, 133);
            this.audioErrorTextBox.TabIndex = 8;
            // 
            // signalGraph
            // 
            this.signalGraph.BackColor = System.Drawing.SystemColors.Control;
            this.signalGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalGraph.Location = new System.Drawing.Point(3, 3);
            this.signalGraph.Margin = new System.Windows.Forms.Padding(4);
            this.signalGraph.Name = "signalGraph";
            this.signalGraph.ScrollGrace = 0D;
            this.signalGraph.ScrollMaxX = 0D;
            this.signalGraph.ScrollMaxY = 0D;
            this.signalGraph.ScrollMaxY2 = 0D;
            this.signalGraph.ScrollMinX = 0D;
            this.signalGraph.ScrollMinY = 0D;
            this.signalGraph.ScrollMinY2 = 0D;
            this.signalGraph.Size = new System.Drawing.Size(418, 171);
            this.signalGraph.TabIndex = 10;
            // 
            // channelListBox
            // 
            this.channelListBox.DefaultName = "Signal";
            this.channelListBox.Location = new System.Drawing.Point(6, 9);
            this.channelListBox.Margin = new System.Windows.Forms.Padding(4);
            this.channelListBox.Name = "channelListBox";
            this.channelListBox.SelectedIndex = -1;
            this.channelListBox.Size = new System.Drawing.Size(164, 147);
            this.channelListBox.TabIndex = 7;
            this.channelListBox.SelectionChanged += new System.EventHandler<KLib.Controls.KUserListBox.ChangedItem>(this.channelListBox_SelectionChanged);
            this.channelListBox.ItemAdded += new System.EventHandler<KLib.Controls.KUserListBox.ChangedItem>(this.channelListBox_ItemAdded);
            this.channelListBox.ItemRenamed += new System.EventHandler<KLib.Controls.KUserListBox.ChangedItem>(this.channelListBox_ItemRenamed);
            this.channelListBox.ItemMoved += new System.EventHandler<KLib.Controls.KUserListBox.ChangedItem>(this.channelListBox_ItemMoved);
            this.channelListBox.ItemsDeleted += new System.EventHandler<KLib.Controls.KUserListBox.ChangedItems>(this.channelListBox_ItemsDeleted);
            this.channelListBox.ItemsMoved += new System.EventHandler<KLib.Controls.KUserListBox.ChangedItems>(this.channelListBox_ItemsMoved);
            // 
            // graphTabControl
            // 
            this.graphTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.graphTabControl.Controls.Add(this.graphPage);
            this.graphTabControl.Controls.Add(this.errorPage);
            this.graphTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.graphTabControl.Location = new System.Drawing.Point(12, 361);
            this.graphTabControl.Name = "graphTabControl";
            this.graphTabControl.SelectedIndex = 0;
            this.graphTabControl.Size = new System.Drawing.Size(432, 186);
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
            this.graphPage.Size = new System.Drawing.Size(424, 177);
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
            this.errorPage.Size = new System.Drawing.Size(424, 177);
            this.errorPage.TabIndex = 1;
            this.errorPage.Text = "tabPage2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Errors";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(597, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // channelView
            // 
            this.channelView.AdapterMap = null;
            this.channelView.AutoScroll = true;
            this.channelView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.channelView.Location = new System.Drawing.Point(176, 9);
            this.channelView.Margin = new System.Windows.Forms.Padding(4);
            this.channelView.Name = "channelView";
            this.channelView.Size = new System.Drawing.Size(238, 290);
            this.channelView.TabIndex = 11;
            this.channelView.Value = null;
            this.channelView.WavFolder = null;
            this.channelView.ValueChanged += new System.EventHandler(this.channelView_ValueChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.stimulusPage);
            this.tabControl.Controls.Add(this.sliderPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(432, 347);
            this.tabControl.TabIndex = 15;
            // 
            // stimulusPage
            // 
            this.stimulusPage.Controls.Add(this.channelListBox);
            this.stimulusPage.Controls.Add(this.channelView);
            this.stimulusPage.Location = new System.Drawing.Point(4, 22);
            this.stimulusPage.Name = "stimulusPage";
            this.stimulusPage.Padding = new System.Windows.Forms.Padding(3);
            this.stimulusPage.Size = new System.Drawing.Size(424, 321);
            this.stimulusPage.TabIndex = 0;
            this.stimulusPage.Text = "Stimulus";
            this.stimulusPage.UseVisualStyleBackColor = true;
            // 
            // sliderPage
            // 
            this.sliderPage.Controls.Add(this.sliderConfig);
            this.sliderPage.Location = new System.Drawing.Point(4, 22);
            this.sliderPage.Margin = new System.Windows.Forms.Padding(2);
            this.sliderPage.Name = "sliderPage";
            this.sliderPage.Padding = new System.Windows.Forms.Padding(2);
            this.sliderPage.Size = new System.Drawing.Size(424, 321);
            this.sliderPage.TabIndex = 2;
            this.sliderPage.Text = "Controls";
            this.sliderPage.UseVisualStyleBackColor = true;
            // 
            // sliderConfig
            // 
            this.sliderConfig.AutoSize = true;
            this.sliderConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sliderConfig.Location = new System.Drawing.Point(10, 5);
            this.sliderConfig.Margin = new System.Windows.Forms.Padding(4);
            this.sliderConfig.Name = "sliderConfig";
            this.sliderConfig.ShowSliders = false;
            this.sliderConfig.Size = new System.Drawing.Size(404, 287);
            this.sliderConfig.TabIndex = 0;
            this.sliderConfig.Value = null;
            this.sliderConfig.ShowSlidersChanged += new System.EventHandler<bool>(this.sliderConfig_ShowSlidersChanged);
            this.sliderConfig.ValueChanged += new System.EventHandler(this.sliderConfig_ValueChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.channelControl);
            this.flowLayoutPanel.Location = new System.Drawing.Point(459, 52);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(218, 491);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // channelControl
            // 
            this.channelControl.AutoSize = true;
            this.channelControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.channelControl.Location = new System.Drawing.Point(4, 4);
            this.channelControl.Margin = new System.Windows.Forms.Padding(4);
            this.channelControl.Name = "channelControl";
            this.channelControl.Size = new System.Drawing.Size(163, 38);
            this.channelControl.TabIndex = 3;
            // 
            // InteractiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 558);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.graphTabControl);
            this.Controls.Add(this.stopButton);
            this.Name = "InteractiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interactive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InteractiveForm_FormClosing);
            this.Shown += new System.EventHandler(this.InteractiveForm_Shown);
            this.graphTabControl.ResumeLayout(false);
            this.graphPage.ResumeLayout(false);
            this.errorPage.ResumeLayout(false);
            this.errorPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.stimulusPage.ResumeLayout(false);
            this.sliderPage.ResumeLayout(false);
            this.sliderPage.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer displayTimer;
        private System.Windows.Forms.TextBox audioErrorTextBox;
        private KLib.Controls.KUserListBox channelListBox;
        private ZedGraph.ZedGraphControl signalGraph;
        private KLib.Unity.Controls.Signals.ChannelView channelView;
        private System.Windows.Forms.TabControl graphTabControl;
        private System.Windows.Forms.TabPage graphPage;
        private System.Windows.Forms.TabPage errorPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage stimulusPage;
        private ChannelControl channelControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.TabPage sliderPage;
        private Interactive.SliderConfig sliderConfig;
    }
}