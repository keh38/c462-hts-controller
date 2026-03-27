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
            this.channelListBox = new KLib.Controls.KUserListBox();
            this.graphTabControl = new System.Windows.Forms.TabControl();
            this.graphPage = new System.Windows.Forms.TabPage();
            this.signalGraph = new ScottPlot.WinForms.FormsPlot();
            this.errorPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.stimulusPage = new System.Windows.Forms.TabPage();
            this.channelPropertyGrid = new System.Windows.Forms.PropertyGrid();
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
            this.startButton.Location = new System.Drawing.Point(612, 15);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 32);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(612, 15);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(107, 32);
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
            this.audioErrorTextBox.Location = new System.Drawing.Point(27, 31);
            this.audioErrorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.audioErrorTextBox.Multiline = true;
            this.audioErrorTextBox.Name = "audioErrorTextBox";
            this.audioErrorTextBox.ReadOnly = true;
            this.audioErrorTextBox.Size = new System.Drawing.Size(510, 163);
            this.audioErrorTextBox.TabIndex = 8;
            // 
            // channelListBox
            // 
            this.channelListBox.DefaultName = "Signal";
            this.channelListBox.Location = new System.Drawing.Point(8, 11);
            this.channelListBox.Margin = new System.Windows.Forms.Padding(5);
            this.channelListBox.Name = "channelListBox";
            this.channelListBox.SelectedIndex = -1;
            this.channelListBox.Size = new System.Drawing.Size(219, 181);
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
            this.graphTabControl.Location = new System.Drawing.Point(16, 444);
            this.graphTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.graphTabControl.Name = "graphTabControl";
            this.graphTabControl.SelectedIndex = 0;
            this.graphTabControl.Size = new System.Drawing.Size(576, 229);
            this.graphTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.graphTabControl.TabIndex = 12;
            // 
            // graphPage
            // 
            this.graphPage.BackColor = System.Drawing.SystemColors.Control;
            this.graphPage.Controls.Add(this.signalGraph);
            this.graphPage.Location = new System.Drawing.Point(4, 5);
            this.graphPage.Margin = new System.Windows.Forms.Padding(4);
            this.graphPage.Name = "graphPage";
            this.graphPage.Padding = new System.Windows.Forms.Padding(4);
            this.graphPage.Size = new System.Drawing.Size(568, 220);
            this.graphPage.TabIndex = 0;
            this.graphPage.Text = "tabPage1";
            // 
            // signalGraph
            // 
            this.signalGraph.DisplayScale = 0F;
            this.signalGraph.Location = new System.Drawing.Point(8, 7);
            this.signalGraph.Name = "signalGraph";
            this.signalGraph.Size = new System.Drawing.Size(545, 206);
            this.signalGraph.TabIndex = 0;
            // 
            // errorPage
            // 
            this.errorPage.BackColor = System.Drawing.SystemColors.Control;
            this.errorPage.Controls.Add(this.label1);
            this.errorPage.Controls.Add(this.audioErrorTextBox);
            this.errorPage.Location = new System.Drawing.Point(4, 5);
            this.errorPage.Margin = new System.Windows.Forms.Padding(4);
            this.errorPage.Name = "errorPage";
            this.errorPage.Padding = new System.Windows.Forms.Padding(4);
            this.errorPage.Size = new System.Drawing.Size(568, 220);
            this.errorPage.TabIndex = 1;
            this.errorPage.Text = "tabPage2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Errors";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(796, 15);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(107, 32);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.stimulusPage);
            this.tabControl.Controls.Add(this.sliderPage);
            this.tabControl.Location = new System.Drawing.Point(16, 15);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(576, 427);
            this.tabControl.TabIndex = 15;
            // 
            // stimulusPage
            // 
            this.stimulusPage.Controls.Add(this.channelPropertyGrid);
            this.stimulusPage.Controls.Add(this.channelListBox);
            this.stimulusPage.Location = new System.Drawing.Point(4, 25);
            this.stimulusPage.Margin = new System.Windows.Forms.Padding(4);
            this.stimulusPage.Name = "stimulusPage";
            this.stimulusPage.Padding = new System.Windows.Forms.Padding(4);
            this.stimulusPage.Size = new System.Drawing.Size(568, 398);
            this.stimulusPage.TabIndex = 0;
            this.stimulusPage.Text = "Stimulus";
            this.stimulusPage.UseVisualStyleBackColor = true;
            // 
            // channelPropertyGrid
            // 
            this.channelPropertyGrid.Location = new System.Drawing.Point(235, 37);
            this.channelPropertyGrid.Name = "channelPropertyGrid";
            this.channelPropertyGrid.Size = new System.Drawing.Size(318, 348);
            this.channelPropertyGrid.TabIndex = 8;
            this.channelPropertyGrid.ToolbarVisible = false;
            this.channelPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.channelPropertyGrid_PropertyValueChanged);
            // 
            // sliderPage
            // 
            this.sliderPage.Controls.Add(this.sliderConfig);
            this.sliderPage.Location = new System.Drawing.Point(4, 25);
            this.sliderPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sliderPage.Name = "sliderPage";
            this.sliderPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sliderPage.Size = new System.Drawing.Size(568, 398);
            this.sliderPage.TabIndex = 2;
            this.sliderPage.Text = "Controls";
            this.sliderPage.UseVisualStyleBackColor = true;
            // 
            // sliderConfig
            // 
            this.sliderConfig.AutoSize = true;
            this.sliderConfig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sliderConfig.Location = new System.Drawing.Point(13, 6);
            this.sliderConfig.Margin = new System.Windows.Forms.Padding(5);
            this.sliderConfig.Name = "sliderConfig";
            this.sliderConfig.ShowSliders = false;
            this.sliderConfig.Size = new System.Drawing.Size(539, 352);
            this.sliderConfig.TabIndex = 0;
            this.sliderConfig.Value = null;
            this.sliderConfig.ShowSlidersChanged += new System.EventHandler<bool>(this.sliderConfig_ShowSlidersChanged);
            this.sliderConfig.ValueChanged += new System.EventHandler(this.sliderConfig_ValueChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.channelControl);
            this.flowLayoutPanel.Location = new System.Drawing.Point(612, 64);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(290, 604);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // channelControl
            // 
            this.channelControl.AutoSize = true;
            this.channelControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.channelControl.Location = new System.Drawing.Point(5, 5);
            this.channelControl.Margin = new System.Windows.Forms.Padding(5);
            this.channelControl.Name = "channelControl";
            this.channelControl.Size = new System.Drawing.Size(204, 47);
            this.channelControl.TabIndex = 3;
            // 
            // InteractiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 687);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.graphTabControl);
            this.Controls.Add(this.stopButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.PropertyGrid channelPropertyGrid;
        private ScottPlot.WinForms.FormsPlot signalGraph;
    }
}