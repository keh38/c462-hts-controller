namespace KLib.Unity.Controls.Signals
{
    partial class FilterSpecView
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
            this.bwMethodDropDown = new KLib.Controls.EnumDropDown();
            this.label1 = new System.Windows.Forms.Label();
            this.FminNumeric = new KLib.Controls.KNumericBox();
            this.FminLabel = new System.Windows.Forms.Label();
            this.FmaxLabel = new System.Windows.Forms.Label();
            this.FmaxNumeric = new KLib.Controls.KNumericBox();
            this.shapeDropDown = new KLib.Controls.EnumDropDown();
            this.brickwallCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bwMethodDropDown
            // 
            this.bwMethodDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bwMethodDropDown.FormattingEnabled = true;
            this.bwMethodDropDown.Location = new System.Drawing.Point(97, 82);
            this.bwMethodDropDown.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.bwMethodDropDown.Name = "bwMethodDropDown";
            this.bwMethodDropDown.Size = new System.Drawing.Size(75, 21);
            this.bwMethodDropDown.Sort = false;
            this.bwMethodDropDown.TabIndex = 0;
            this.bwMethodDropDown.ValueChanged += new System.EventHandler(this.bwMethodDropDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter";
            // 
            // FminNumeric
            // 
            this.FminNumeric.AutoSize = true;
            this.FminNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FminNumeric.FloatValue = 0F;
            this.FminNumeric.IntValue = 0;
            this.FminNumeric.IsInteger = false;
            this.FminNumeric.Location = new System.Drawing.Point(97, 30);
            this.FminNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.FminNumeric.MaxCoerce = false;
            this.FminNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.FminNumeric.MaxValue = double.PositiveInfinity;
            this.FminNumeric.MinCoerce = false;
            this.FminNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.FminNumeric.MinValue = 0D;
            this.FminNumeric.Name = "FminNumeric";
            this.FminNumeric.Size = new System.Drawing.Size(75, 20);
            this.FminNumeric.TabIndex = 3;
            this.FminNumeric.TextFormat = "K4";
            this.FminNumeric.Units = "";
            this.FminNumeric.Value = 0D;
            this.FminNumeric.ValueChanged += new System.EventHandler(this.FminNumeric_ValueChanged);
            // 
            // FminLabel
            // 
            this.FminLabel.Location = new System.Drawing.Point(13, 34);
            this.FminLabel.Name = "FminLabel";
            this.FminLabel.Size = new System.Drawing.Size(80, 13);
            this.FminLabel.TabIndex = 4;
            this.FminLabel.Text = "Fmin (Hz)";
            this.FminLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FmaxLabel
            // 
            this.FmaxLabel.Location = new System.Drawing.Point(13, 59);
            this.FmaxLabel.Name = "FmaxLabel";
            this.FmaxLabel.Size = new System.Drawing.Size(80, 13);
            this.FmaxLabel.TabIndex = 6;
            this.FmaxLabel.Text = "Fmax (Hz)";
            this.FmaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FmaxNumeric
            // 
            this.FmaxNumeric.AutoSize = true;
            this.FmaxNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FmaxNumeric.FloatValue = 0F;
            this.FmaxNumeric.IntValue = 0;
            this.FmaxNumeric.IsInteger = false;
            this.FmaxNumeric.Location = new System.Drawing.Point(97, 56);
            this.FmaxNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.FmaxNumeric.MaxCoerce = false;
            this.FmaxNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.FmaxNumeric.MaxValue = double.PositiveInfinity;
            this.FmaxNumeric.MinCoerce = false;
            this.FmaxNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.FmaxNumeric.MinValue = 0D;
            this.FmaxNumeric.Name = "FmaxNumeric";
            this.FmaxNumeric.Size = new System.Drawing.Size(75, 20);
            this.FmaxNumeric.TabIndex = 5;
            this.FmaxNumeric.TextFormat = "K4";
            this.FmaxNumeric.Units = "";
            this.FmaxNumeric.Value = 0D;
            this.FmaxNumeric.ValueChanged += new System.EventHandler(this.FminNumeric_ValueChanged);
            // 
            // shapeDropDown
            // 
            this.shapeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shapeDropDown.FormattingEnabled = true;
            this.shapeDropDown.Items.AddRange(new object[] {
            "OFF",
            "Lowpass",
            "Highpass",
            "Bandpass",
            "Bandstop"});
            this.shapeDropDown.Location = new System.Drawing.Point(65, 3);
            this.shapeDropDown.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.shapeDropDown.Name = "shapeDropDown";
            this.shapeDropDown.Size = new System.Drawing.Size(107, 21);
            this.shapeDropDown.Sort = false;
            this.shapeDropDown.TabIndex = 7;
            this.shapeDropDown.ValueChanged += new System.EventHandler(this.shapeDropDown_ValueChanged);
            // 
            // brickwallCheckbox
            // 
            this.brickwallCheckbox.AutoSize = true;
            this.brickwallCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brickwallCheckbox.Location = new System.Drawing.Point(42, 107);
            this.brickwallCheckbox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.brickwallCheckbox.Name = "brickwallCheckbox";
            this.brickwallCheckbox.Size = new System.Drawing.Size(68, 17);
            this.brickwallCheckbox.TabIndex = 8;
            this.brickwallCheckbox.Text = "Brickwall";
            this.brickwallCheckbox.UseVisualStyleBackColor = true;
            this.brickwallCheckbox.CheckedChanged += new System.EventHandler(this.brickwallCheckbox_CheckedChanged);
            // 
            // FilterSpecView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.brickwallCheckbox);
            this.Controls.Add(this.shapeDropDown);
            this.Controls.Add(this.FmaxLabel);
            this.Controls.Add(this.FmaxNumeric);
            this.Controls.Add(this.bwMethodDropDown);
            this.Controls.Add(this.FminNumeric);
            this.Controls.Add(this.FminLabel);
            this.Controls.Add(this.label1);
            this.Name = "FilterSpecView";
            this.Size = new System.Drawing.Size(172, 124);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLib.Controls.EnumDropDown bwMethodDropDown;
        private System.Windows.Forms.Label label1;
        private KLib.Controls.KNumericBox FminNumeric;
        private System.Windows.Forms.Label FminLabel;
        private System.Windows.Forms.Label FmaxLabel;
        private KLib.Controls.KNumericBox FmaxNumeric;
        private KLib.Controls.EnumDropDown shapeDropDown;
        private System.Windows.Forms.CheckBox brickwallCheckbox;
    }
}
