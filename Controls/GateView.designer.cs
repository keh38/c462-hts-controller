namespace KLib.Unity.Controls.Signals
{
    partial class GateView
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
            this.activeComboBox = new System.Windows.Forms.ComboBox();
            this.delayNumeric = new KLib.Controls.KNumericBox();
            this.rampNumeric = new KLib.Controls.KNumericBox();
            this.durationNumeric = new KLib.Controls.KNumericBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.rampLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.intervalNumeric = new KLib.Controls.KNumericBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.burstDurNumeric = new KLib.Controls.KNumericBox();
            this.burstPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.burstNumNumeric = new KLib.Controls.KNumericBox();
            this.burstDurLabel = new System.Windows.Forms.Label();
            this.burstCheckbox = new System.Windows.Forms.CheckBox();
            this.burstPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // activeComboBox
            // 
            this.activeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeComboBox.FormattingEnabled = true;
            this.activeComboBox.Items.AddRange(new object[] {
            "Gate OFF",
            "Gate ON"});
            this.activeComboBox.Location = new System.Drawing.Point(33, 3);
            this.activeComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.activeComboBox.Name = "activeComboBox";
            this.activeComboBox.Size = new System.Drawing.Size(121, 24);
            this.activeComboBox.TabIndex = 0;
            this.activeComboBox.SelectedIndexChanged += new System.EventHandler(this.activeComboBox_SelectedIndexChanged);
            // 
            // delayNumeric
            // 
            this.delayNumeric.AutoSize = true;
            this.delayNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delayNumeric.FloatValue = 0F;
            this.delayNumeric.IntValue = 0;
            this.delayNumeric.IsInteger = false;
            this.delayNumeric.Location = new System.Drawing.Point(79, 30);
            this.delayNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.delayNumeric.MaxCoerce = false;
            this.delayNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.delayNumeric.MaxValue = double.PositiveInfinity;
            this.delayNumeric.MinCoerce = false;
            this.delayNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.delayNumeric.MinValue = 0D;
            this.delayNumeric.Name = "delayNumeric";
            this.delayNumeric.Size = new System.Drawing.Size(75, 20);
            this.delayNumeric.TabIndex = 1;
            this.delayNumeric.TextFormat = "K4";
            this.delayNumeric.Units = "";
            this.delayNumeric.Value = 0D;
            this.delayNumeric.ValueChanged += new System.EventHandler(this.delayNumeric_ValueChanged);
            // 
            // rampNumeric
            // 
            this.rampNumeric.AutoSize = true;
            this.rampNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rampNumeric.FloatValue = 0F;
            this.rampNumeric.IntValue = 0;
            this.rampNumeric.IsInteger = false;
            this.rampNumeric.Location = new System.Drawing.Point(79, 53);
            this.rampNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.rampNumeric.MaxCoerce = false;
            this.rampNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.rampNumeric.MaxValue = double.PositiveInfinity;
            this.rampNumeric.MinCoerce = false;
            this.rampNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.rampNumeric.MinValue = 0D;
            this.rampNumeric.Name = "rampNumeric";
            this.rampNumeric.Size = new System.Drawing.Size(75, 20);
            this.rampNumeric.TabIndex = 2;
            this.rampNumeric.TextFormat = "K4";
            this.rampNumeric.Units = "";
            this.rampNumeric.Value = 0D;
            this.rampNumeric.ValueChanged += new System.EventHandler(this.rampNumeric_ValueChanged);
            // 
            // durationNumeric
            // 
            this.durationNumeric.AutoSize = true;
            this.durationNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.durationNumeric.FloatValue = 0F;
            this.durationNumeric.IntValue = 0;
            this.durationNumeric.IsInteger = false;
            this.durationNumeric.Location = new System.Drawing.Point(79, 76);
            this.durationNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.durationNumeric.MaxCoerce = false;
            this.durationNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.durationNumeric.MaxValue = double.PositiveInfinity;
            this.durationNumeric.MinCoerce = false;
            this.durationNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.durationNumeric.MinValue = 0D;
            this.durationNumeric.Name = "durationNumeric";
            this.durationNumeric.Size = new System.Drawing.Size(75, 20);
            this.durationNumeric.TabIndex = 3;
            this.durationNumeric.TextFormat = "K4";
            this.durationNumeric.Units = "";
            this.durationNumeric.Value = 0D;
            this.durationNumeric.ValueChanged += new System.EventHandler(this.durationNumeric_ValueChanged);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(20, 33);
            this.delayLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(56, 13);
            this.delayLabel.TabIndex = 4;
            this.delayLabel.Text = "Delay (ms)";
            // 
            // rampLabel
            // 
            this.rampLabel.AutoSize = true;
            this.rampLabel.Location = new System.Drawing.Point(19, 56);
            this.rampLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.rampLabel.Name = "rampLabel";
            this.rampLabel.Size = new System.Drawing.Size(57, 13);
            this.rampLabel.TabIndex = 5;
            this.rampLabel.Text = "Ramp (ms)";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(7, 79);
            this.durationLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(69, 13);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "Duration (ms)";
            // 
            // intervalNumeric
            // 
            this.intervalNumeric.AutoSize = true;
            this.intervalNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.intervalNumeric.FloatValue = 0F;
            this.intervalNumeric.IntValue = 0;
            this.intervalNumeric.IsInteger = false;
            this.intervalNumeric.Location = new System.Drawing.Point(79, 99);
            this.intervalNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.intervalNumeric.MaxCoerce = false;
            this.intervalNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.intervalNumeric.MaxValue = double.PositiveInfinity;
            this.intervalNumeric.MinCoerce = false;
            this.intervalNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.intervalNumeric.MinValue = 0D;
            this.intervalNumeric.Name = "intervalNumeric";
            this.intervalNumeric.Size = new System.Drawing.Size(75, 20);
            this.intervalNumeric.TabIndex = 7;
            this.intervalNumeric.TextFormat = "K4";
            this.intervalNumeric.Units = "";
            this.intervalNumeric.Value = 0D;
            this.intervalNumeric.ValueChanged += new System.EventHandler(this.intervalNumeric_ValueChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(12, 102);
            this.intervalLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(64, 13);
            this.intervalLabel.TabIndex = 8;
            this.intervalLabel.Text = "Interval (ms)";
            // 
            // burstDurNumeric
            // 
            this.burstDurNumeric.AutoSize = true;
            this.burstDurNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.burstDurNumeric.FloatValue = 0F;
            this.burstDurNumeric.IntValue = 0;
            this.burstDurNumeric.IsInteger = false;
            this.burstDurNumeric.Location = new System.Drawing.Point(74, 28);
            this.burstDurNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.burstDurNumeric.MaxCoerce = false;
            this.burstDurNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.burstDurNumeric.MaxValue = double.PositiveInfinity;
            this.burstDurNumeric.MinCoerce = false;
            this.burstDurNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.burstDurNumeric.MinValue = 0D;
            this.burstDurNumeric.Name = "burstDurNumeric";
            this.burstDurNumeric.Size = new System.Drawing.Size(75, 20);
            this.burstDurNumeric.TabIndex = 9;
            this.burstDurNumeric.TextFormat = "K4";
            this.burstDurNumeric.Units = "";
            this.burstDurNumeric.Value = 0D;
            this.burstDurNumeric.ValueChanged += new System.EventHandler(this.burstDurNumeric_ValueChanged);
            // 
            // burstPanel
            // 
            this.burstPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.burstPanel.AutoSize = true;
            this.burstPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.burstPanel.Controls.Add(this.label1);
            this.burstPanel.Controls.Add(this.burstNumNumeric);
            this.burstPanel.Controls.Add(this.burstDurLabel);
            this.burstPanel.Controls.Add(this.burstDurNumeric);
            this.burstPanel.Location = new System.Drawing.Point(5, 138);
            this.burstPanel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.burstPanel.Name = "burstPanel";
            this.burstPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.burstPanel.Size = new System.Drawing.Size(149, 51);
            this.burstPanel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Number";
            // 
            // burstNumNumeric
            // 
            this.burstNumNumeric.AutoSize = true;
            this.burstNumNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.burstNumNumeric.FloatValue = 1F;
            this.burstNumNumeric.IntValue = 1;
            this.burstNumNumeric.IsInteger = true;
            this.burstNumNumeric.Location = new System.Drawing.Point(74, 4);
            this.burstNumNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.burstNumNumeric.MaxCoerce = false;
            this.burstNumNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.burstNumNumeric.MaxValue = double.PositiveInfinity;
            this.burstNumNumeric.MinCoerce = true;
            this.burstNumNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.burstNumNumeric.MinValue = 1D;
            this.burstNumNumeric.Name = "burstNumNumeric";
            this.burstNumNumeric.Size = new System.Drawing.Size(75, 20);
            this.burstNumNumeric.TabIndex = 12;
            this.burstNumNumeric.TextFormat = "K4";
            this.burstNumNumeric.Units = "";
            this.burstNumNumeric.Value = 1D;
            this.burstNumNumeric.ValueChanged += new System.EventHandler(this.burstNumNumeric_ValueChanged);
            // 
            // burstDurLabel
            // 
            this.burstDurLabel.AutoSize = true;
            this.burstDurLabel.Location = new System.Drawing.Point(3, 31);
            this.burstDurLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.burstDurLabel.Name = "burstDurLabel";
            this.burstDurLabel.Size = new System.Drawing.Size(69, 13);
            this.burstDurLabel.TabIndex = 11;
            this.burstDurLabel.Text = "Duration (ms)";
            // 
            // burstCheckbox
            // 
            this.burstCheckbox.AutoSize = true;
            this.burstCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.burstCheckbox.Location = new System.Drawing.Point(31, 122);
            this.burstCheckbox.Name = "burstCheckbox";
            this.burstCheckbox.Size = new System.Drawing.Size(62, 17);
            this.burstCheckbox.TabIndex = 10;
            this.burstCheckbox.Text = "Bursted";
            this.burstCheckbox.UseVisualStyleBackColor = true;
            this.burstCheckbox.CheckedChanged += new System.EventHandler(this.burstCheckbox_CheckedChanged);
            // 
            // GateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.burstPanel);
            this.Controls.Add(this.burstCheckbox);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.intervalNumeric);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.rampLabel);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.durationNumeric);
            this.Controls.Add(this.rampNumeric);
            this.Controls.Add(this.delayNumeric);
            this.Controls.Add(this.activeComboBox);
            this.Name = "GateView";
            this.Size = new System.Drawing.Size(154, 192);
            this.burstPanel.ResumeLayout(false);
            this.burstPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox activeComboBox;
        private KLib.Controls.KNumericBox delayNumeric;
        private KLib.Controls.KNumericBox rampNumeric;
        private KLib.Controls.KNumericBox durationNumeric;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label rampLabel;
        private System.Windows.Forms.Label durationLabel;
        private KLib.Controls.KNumericBox intervalNumeric;
        private System.Windows.Forms.Label intervalLabel;
        private KLib.Controls.KNumericBox burstDurNumeric;
        private System.Windows.Forms.Panel burstPanel;
        private System.Windows.Forms.Label burstDurLabel;
        private System.Windows.Forms.CheckBox burstCheckbox;
        private System.Windows.Forms.Label label1;
        private KLib.Controls.KNumericBox burstNumNumeric;
    }
}
