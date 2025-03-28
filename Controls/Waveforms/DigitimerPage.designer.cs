namespace KLib.Unity.Controls.Signals
{
    partial class DigitimerPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.rateNumeric = new KLib.Controls.KNumericBox();
            this.modeDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.polarityDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.widthNumeric = new KLib.Controls.KNumericBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recoveryNumeric = new KLib.Controls.KNumericBox();
            this.dwellNumeric = new KLib.Controls.KNumericBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sourceDropDown = new System.Windows.Forms.ComboBox();
            this.demandLabel = new System.Windows.Forms.Label();
            this.demandNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pulse rate (Hz)";
            // 
            // rateNumeric
            // 
            this.rateNumeric.AllowInf = false;
            this.rateNumeric.AutoSize = true;
            this.rateNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rateNumeric.ClearOnDisable = false;
            this.rateNumeric.FloatValue = 0F;
            this.rateNumeric.IntValue = 0;
            this.rateNumeric.IsInteger = false;
            this.rateNumeric.Location = new System.Drawing.Point(96, 54);
            this.rateNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.rateNumeric.MaxCoerce = false;
            this.rateNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.rateNumeric.MaxValue = double.PositiveInfinity;
            this.rateNumeric.MinCoerce = false;
            this.rateNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.rateNumeric.MinValue = 0D;
            this.rateNumeric.Name = "rateNumeric";
            this.rateNumeric.Size = new System.Drawing.Size(75, 20);
            this.rateNumeric.TabIndex = 0;
            this.rateNumeric.TextFormat = "K4";
            this.rateNumeric.ToolTip = "";
            this.rateNumeric.Units = "";
            this.rateNumeric.Value = 0D;
            this.rateNumeric.ValueChanged += new System.EventHandler(this.rateNumeric_ValueChanged);
            // 
            // modeDropDown
            // 
            this.modeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeDropDown.FormattingEnabled = true;
            this.modeDropDown.Items.AddRange(new object[] {
            "Monophasic",
            "Biphasic"});
            this.modeDropDown.Location = new System.Drawing.Point(79, 3);
            this.modeDropDown.Name = "modeDropDown";
            this.modeDropDown.Size = new System.Drawing.Size(92, 21);
            this.modeDropDown.TabIndex = 2;
            this.modeDropDown.SelectedIndexChanged += new System.EventHandler(this.modeDropDown_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mode";
            // 
            // polarityDropDown
            // 
            this.polarityDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.polarityDropDown.FormattingEnabled = true;
            this.polarityDropDown.Items.AddRange(new object[] {
            "Positive",
            "Negative",
            "Alternating"});
            this.polarityDropDown.Location = new System.Drawing.Point(79, 30);
            this.polarityDropDown.Name = "polarityDropDown";
            this.polarityDropDown.Size = new System.Drawing.Size(92, 21);
            this.polarityDropDown.TabIndex = 4;
            this.polarityDropDown.SelectedIndexChanged += new System.EventHandler(this.polarityDropDown_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Polarity";
            // 
            // widthNumeric
            // 
            this.widthNumeric.AllowInf = false;
            this.widthNumeric.AutoSize = true;
            this.widthNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.widthNumeric.ClearOnDisable = false;
            this.widthNumeric.FloatValue = 50F;
            this.widthNumeric.IntValue = 50;
            this.widthNumeric.IsInteger = true;
            this.widthNumeric.Location = new System.Drawing.Point(96, 77);
            this.widthNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.widthNumeric.MaxCoerce = true;
            this.widthNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.widthNumeric.MaxValue = 2000D;
            this.widthNumeric.MinCoerce = true;
            this.widthNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.widthNumeric.MinValue = 50D;
            this.widthNumeric.Name = "widthNumeric";
            this.widthNumeric.Size = new System.Drawing.Size(75, 20);
            this.widthNumeric.TabIndex = 6;
            this.widthNumeric.TextFormat = "K4";
            this.widthNumeric.ToolTip = "";
            this.widthNumeric.Units = "";
            this.widthNumeric.Value = 50D;
            this.widthNumeric.ValueChanged += new System.EventHandler(this.widthNumeric_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pulse width (us)";
            // 
            // recoveryNumeric
            // 
            this.recoveryNumeric.AllowInf = false;
            this.recoveryNumeric.AutoSize = true;
            this.recoveryNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.recoveryNumeric.ClearOnDisable = false;
            this.recoveryNumeric.FloatValue = 50F;
            this.recoveryNumeric.IntValue = 50;
            this.recoveryNumeric.IsInteger = true;
            this.recoveryNumeric.Location = new System.Drawing.Point(96, 100);
            this.recoveryNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.recoveryNumeric.MaxCoerce = true;
            this.recoveryNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.recoveryNumeric.MaxValue = 100D;
            this.recoveryNumeric.MinCoerce = true;
            this.recoveryNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.recoveryNumeric.MinValue = 10D;
            this.recoveryNumeric.Name = "recoveryNumeric";
            this.recoveryNumeric.Size = new System.Drawing.Size(75, 20);
            this.recoveryNumeric.TabIndex = 8;
            this.recoveryNumeric.TextFormat = "K4";
            this.recoveryNumeric.ToolTip = "";
            this.recoveryNumeric.Units = "";
            this.recoveryNumeric.Value = 50D;
            this.recoveryNumeric.ValueChanged += new System.EventHandler(this.recoveryNumeric_ValueChanged);
            // 
            // dwellNumeric
            // 
            this.dwellNumeric.AllowInf = false;
            this.dwellNumeric.AutoSize = true;
            this.dwellNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dwellNumeric.ClearOnDisable = false;
            this.dwellNumeric.FloatValue = 50F;
            this.dwellNumeric.IntValue = 50;
            this.dwellNumeric.IsInteger = true;
            this.dwellNumeric.Location = new System.Drawing.Point(96, 123);
            this.dwellNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.dwellNumeric.MaxCoerce = true;
            this.dwellNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.dwellNumeric.MaxValue = 990D;
            this.dwellNumeric.MinCoerce = true;
            this.dwellNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.dwellNumeric.MinValue = 1D;
            this.dwellNumeric.Name = "dwellNumeric";
            this.dwellNumeric.Size = new System.Drawing.Size(75, 20);
            this.dwellNumeric.TabIndex = 9;
            this.dwellNumeric.TextFormat = "K4";
            this.dwellNumeric.ToolTip = "";
            this.dwellNumeric.Units = "";
            this.dwellNumeric.Value = 50D;
            this.dwellNumeric.ValueChanged += new System.EventHandler(this.dwellNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Recovery (%)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Dwell (us)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Source";
            // 
            // sourceDropDown
            // 
            this.sourceDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceDropDown.FormattingEnabled = true;
            this.sourceDropDown.Items.AddRange(new object[] {
            "Internal",
            "External"});
            this.sourceDropDown.Location = new System.Drawing.Point(79, 149);
            this.sourceDropDown.Name = "sourceDropDown";
            this.sourceDropDown.Size = new System.Drawing.Size(92, 21);
            this.sourceDropDown.TabIndex = 12;
            this.sourceDropDown.SelectedIndexChanged += new System.EventHandler(this.demandDropDown_SelectedIndexChanged);
            // 
            // demandLabel
            // 
            this.demandLabel.AutoSize = true;
            this.demandLabel.Location = new System.Drawing.Point(17, 179);
            this.demandLabel.Name = "demandLabel";
            this.demandLabel.Size = new System.Drawing.Size(71, 13);
            this.demandLabel.TabIndex = 15;
            this.demandLabel.Text = "Demand (mA)";
            // 
            // demandNumeric
            // 
            this.demandNumeric.AllowInf = false;
            this.demandNumeric.AutoSize = true;
            this.demandNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.demandNumeric.ClearOnDisable = false;
            this.demandNumeric.FloatValue = 0F;
            this.demandNumeric.IntValue = 0;
            this.demandNumeric.IsInteger = false;
            this.demandNumeric.Location = new System.Drawing.Point(96, 175);
            this.demandNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.demandNumeric.MaxCoerce = false;
            this.demandNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.demandNumeric.MaxValue = double.PositiveInfinity;
            this.demandNumeric.MinCoerce = false;
            this.demandNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.demandNumeric.MinValue = 0D;
            this.demandNumeric.Name = "demandNumeric";
            this.demandNumeric.Size = new System.Drawing.Size(75, 20);
            this.demandNumeric.TabIndex = 14;
            this.demandNumeric.TextFormat = "K4";
            this.demandNumeric.ToolTip = "";
            this.demandNumeric.Units = "";
            this.demandNumeric.Value = 0D;
            this.demandNumeric.ValueChanged += new System.EventHandler(this.demandNumeric_ValueChanged);
            // 
            // DigitimerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.demandLabel);
            this.Controls.Add(this.demandNumeric);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sourceDropDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dwellNumeric);
            this.Controls.Add(this.recoveryNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.widthNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.polarityDropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modeDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rateNumeric);
            this.Name = "DigitimerPage";
            this.Size = new System.Drawing.Size(174, 198);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLib.Controls.KNumericBox rateNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modeDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox polarityDropDown;
        private System.Windows.Forms.Label label3;
        private KLib.Controls.KNumericBox widthNumeric;
        private System.Windows.Forms.Label label4;
        private KLib.Controls.KNumericBox recoveryNumeric;
        private KLib.Controls.KNumericBox dwellNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox sourceDropDown;
        private System.Windows.Forms.Label demandLabel;
        private KLib.Controls.KNumericBox demandNumeric;
    }
}
