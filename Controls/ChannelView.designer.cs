namespace KLib.Unity.Controls.Signals
{
    partial class ChannelView
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
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.destPanel = new System.Windows.Forms.Panel();
            this.destinationDropDown = new KLib.Controls.EnumDropDown();
            this.modSep = new System.Windows.Forms.Label();
            this.gateSep = new System.Windows.Forms.Label();
            this.levelSep = new System.Windows.Forms.Label();
            this.expertSep = new System.Windows.Forms.Label();
            this.waveformView = new KLib.Unity.Controls.Signals.WaveformView();
            this.modulationView = new KLib.Unity.Controls.Signals.ModulationView();
            this.gateView = new KLib.Unity.Controls.Signals.GateView();
            this.levelView = new KLib.Unity.Controls.Signals.LevelView();
            this.expertControl = new KLib.Unity.Controls.Signals.ChannelAdvancedControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.destPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.destPanel);
            this.flowLayoutPanel1.Controls.Add(this.waveformView);
            this.flowLayoutPanel1.Controls.Add(this.modSep);
            this.flowLayoutPanel1.Controls.Add(this.modulationView);
            this.flowLayoutPanel1.Controls.Add(this.gateSep);
            this.flowLayoutPanel1.Controls.Add(this.gateView);
            this.flowLayoutPanel1.Controls.Add(this.levelSep);
            this.flowLayoutPanel1.Controls.Add(this.levelView);
            this.flowLayoutPanel1.Controls.Add(this.expertSep);
            this.flowLayoutPanel1.Controls.Add(this.expertControl);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(204, 617);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // destPanel
            // 
            this.destPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destPanel.AutoSize = true;
            this.destPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.destPanel.Controls.Add(this.destinationDropDown);
            this.destPanel.Controls.Add(this.label2);
            this.destPanel.Location = new System.Drawing.Point(3, 3);
            this.destPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.destPanel.Name = "destPanel";
            this.destPanel.Size = new System.Drawing.Size(201, 26);
            this.destPanel.TabIndex = 7;
            // 
            // destinationDropDown
            // 
            this.destinationDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationDropDown.FormattingEnabled = true;
            this.destinationDropDown.Location = new System.Drawing.Point(77, 2);
            this.destinationDropDown.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.destinationDropDown.Name = "destinationDropDown";
            this.destinationDropDown.Size = new System.Drawing.Size(121, 21);
            this.destinationDropDown.Sort = false;
            this.destinationDropDown.TabIndex = 14;
            this.destinationDropDown.ValueChanged += new System.EventHandler(this.destinationDropDown_ValueChanged);
            // 
            // modSep
            // 
            this.modSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.modSep.Location = new System.Drawing.Point(3, 78);
            this.modSep.Name = "modSep";
            this.modSep.Size = new System.Drawing.Size(198, 2);
            this.modSep.TabIndex = 13;
            this.modSep.Text = "label4";
            // 
            // gateSep
            // 
            this.gateSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gateSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gateSep.Location = new System.Drawing.Point(3, 197);
            this.gateSep.Name = "gateSep";
            this.gateSep.Size = new System.Drawing.Size(198, 2);
            this.gateSep.TabIndex = 12;
            this.gateSep.Text = "label4";
            // 
            // levelSep
            // 
            this.levelSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.levelSep.Location = new System.Drawing.Point(3, 397);
            this.levelSep.Name = "levelSep";
            this.levelSep.Size = new System.Drawing.Size(198, 2);
            this.levelSep.TabIndex = 13;
            this.levelSep.Text = "label4";
            // 
            // expertSep
            // 
            this.expertSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expertSep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.expertSep.Location = new System.Drawing.Point(3, 508);
            this.expertSep.Name = "expertSep";
            this.expertSep.Size = new System.Drawing.Size(198, 2);
            this.expertSep.TabIndex = 16;
            this.expertSep.Text = "label4";
            // 
            // waveformView
            // 
            this.waveformView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformView.AutoSize = true;
            this.waveformView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.waveformView.IPD = 0F;
            this.waveformView.IsDichotic = false;
            this.waveformView.Location = new System.Drawing.Point(8, 35);
            this.waveformView.Name = "waveformView";
            this.waveformView.Size = new System.Drawing.Size(193, 40);
            this.waveformView.TabIndex = 4;
            this.waveformView.Value = null;
            this.waveformView.WavFolder = null;
            this.waveformView.IPDChanged += new System.EventHandler(this.waveformView_IPDChanged);
            this.waveformView.ValueChanged += new System.EventHandler(this.waveformView_ValueChanged);
            // 
            // modulationView
            // 
            this.modulationView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modulationView.AutoSize = true;
            this.modulationView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.modulationView.Location = new System.Drawing.Point(18, 83);
            this.modulationView.Name = "modulationView";
            this.modulationView.Size = new System.Drawing.Size(183, 111);
            this.modulationView.TabIndex = 7;
            this.modulationView.Value = null;
            this.modulationView.ValueChanged += new System.EventHandler(this.modulationView_ValueChanged);
            // 
            // gateView
            // 
            this.gateView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gateView.AutoSize = true;
            this.gateView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gateView.Location = new System.Drawing.Point(47, 202);
            this.gateView.Name = "gateView";
            this.gateView.Size = new System.Drawing.Size(154, 192);
            this.gateView.TabIndex = 7;
            this.gateView.Value = null;
            this.gateView.ValueChanged += new System.EventHandler(this.gateView_ValueChanged);
            // 
            // levelView
            // 
            this.levelView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.levelView.AutoSize = true;
            this.levelView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.levelView.ILD = 0F;
            this.levelView.IsDichotic = false;
            this.levelView.Location = new System.Drawing.Point(71, 402);
            this.levelView.MBL = 0F;
            this.levelView.Name = "levelView";
            this.levelView.Size = new System.Drawing.Size(130, 103);
            this.levelView.TabIndex = 5;
            this.levelView.Value = null;
            this.levelView.BinauralChanged += new System.EventHandler(this.levelView_BinauralChanged);
            this.levelView.ValueChanged += new System.EventHandler(this.levelView_ValueChanged);
            // 
            // expertControl
            // 
            this.expertControl.AutoSize = true;
            this.expertControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.expertControl.Location = new System.Drawing.Point(3, 513);
            this.expertControl.Name = "expertControl";
            this.expertControl.Size = new System.Drawing.Size(194, 101);
            this.expertControl.TabIndex = 17;
            this.expertControl.Value = null;
            this.expertControl.ValueChanged += new System.EventHandler(this.expertControl_ValueChanged);
            // 
            // ChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ChannelView";
            this.Size = new System.Drawing.Size(213, 623);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.destPanel.ResumeLayout(false);
            this.destPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Signals.WaveformView waveformView;
        private Signals.LevelView levelView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label gateSep;
        private System.Windows.Forms.Label modSep;
        private Signals.ModulationView modulationView;
        private System.Windows.Forms.Panel destPanel;
        private Signals.GateView gateView;
        private System.Windows.Forms.Label levelSep;
        private KLib.Controls.EnumDropDown destinationDropDown;
        private System.Windows.Forms.Label expertSep;
        private Signals.ChannelAdvancedControl expertControl;
    }
}
