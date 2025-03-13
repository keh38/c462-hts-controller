namespace KLib.Unity.Controls.Signals
{
    partial class SinusoidPage
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
            this.freqNumeric = new KLib.Controls.KNumericBox();
            this.ipdLabel = new System.Windows.Forms.Label();
            this.ipdNumeric = new KLib.Controls.KNumericBox();
            this.label2 = new System.Windows.Forms.Label();
            this.phaseNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frequency (Hz)";
            // 
            // freqNumeric
            // 
            this.freqNumeric.AutoSize = true;
            this.freqNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.freqNumeric.FloatValue = 0F;
            this.freqNumeric.IntValue = 0;
            this.freqNumeric.IsInteger = false;
            this.freqNumeric.Location = new System.Drawing.Point(99, 2);
            this.freqNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.freqNumeric.MaxCoerce = false;
            this.freqNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.freqNumeric.MaxValue = double.PositiveInfinity;
            this.freqNumeric.MinCoerce = false;
            this.freqNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.freqNumeric.MinValue = 0D;
            this.freqNumeric.Name = "freqNumeric";
            this.freqNumeric.Size = new System.Drawing.Size(75, 20);
            this.freqNumeric.TabIndex = 0;
            this.freqNumeric.TextFormat = "K4";
            this.freqNumeric.Units = "";
            this.freqNumeric.Value = 0D;
            this.freqNumeric.ValueChanged += new System.EventHandler(this.freqNumeric_ValueChanged);
            // 
            // ipdLabel
            // 
            this.ipdLabel.AutoSize = true;
            this.ipdLabel.Location = new System.Drawing.Point(48, 52);
            this.ipdLabel.Name = "ipdLabel";
            this.ipdLabel.Size = new System.Drawing.Size(49, 13);
            this.ipdLabel.TabIndex = 3;
            this.ipdLabel.Text = "IPD (0-1)";
            // 
            // ipdNumeric
            // 
            this.ipdNumeric.AutoSize = true;
            this.ipdNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ipdNumeric.FloatValue = 0F;
            this.ipdNumeric.IntValue = 0;
            this.ipdNumeric.IsInteger = false;
            this.ipdNumeric.Location = new System.Drawing.Point(99, 49);
            this.ipdNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.ipdNumeric.MaxCoerce = false;
            this.ipdNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.ipdNumeric.MaxValue = double.PositiveInfinity;
            this.ipdNumeric.MinCoerce = false;
            this.ipdNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.ipdNumeric.MinValue = 0D;
            this.ipdNumeric.Name = "ipdNumeric";
            this.ipdNumeric.Size = new System.Drawing.Size(75, 20);
            this.ipdNumeric.TabIndex = 2;
            this.ipdNumeric.TextFormat = "K4";
            this.ipdNumeric.Units = "";
            this.ipdNumeric.Value = 0D;
            this.ipdNumeric.ValueChanged += new System.EventHandler(this.ipdNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Phase (0-1)";
            // 
            // phaseNumeric
            // 
            this.phaseNumeric.AutoSize = true;
            this.phaseNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.phaseNumeric.FloatValue = 0F;
            this.phaseNumeric.IntValue = 0;
            this.phaseNumeric.IsInteger = false;
            this.phaseNumeric.Location = new System.Drawing.Point(99, 25);
            this.phaseNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.phaseNumeric.MaxCoerce = false;
            this.phaseNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.phaseNumeric.MaxValue = double.PositiveInfinity;
            this.phaseNumeric.MinCoerce = false;
            this.phaseNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.phaseNumeric.MinValue = 0D;
            this.phaseNumeric.Name = "phaseNumeric";
            this.phaseNumeric.Size = new System.Drawing.Size(75, 20);
            this.phaseNumeric.TabIndex = 4;
            this.phaseNumeric.TextFormat = "K4";
            this.phaseNumeric.Units = "";
            this.phaseNumeric.Value = 0D;
            this.phaseNumeric.ValueChanged += new System.EventHandler(this.phaseNumeric_ValueChanged);
            // 
            // SinusoidPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.phaseNumeric);
            this.Controls.Add(this.ipdLabel);
            this.Controls.Add(this.ipdNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.freqNumeric);
            this.Name = "SinusoidPage";
            this.Size = new System.Drawing.Size(174, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLib.Controls.KNumericBox freqNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ipdLabel;
        private KLib.Controls.KNumericBox ipdNumeric;
        private System.Windows.Forms.Label label2;
        private KLib.Controls.KNumericBox phaseNumeric;
    }
}
