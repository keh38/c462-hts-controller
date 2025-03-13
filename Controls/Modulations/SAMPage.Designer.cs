namespace KLib.Unity.Controls.Signals
{
    partial class SAMPage
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
            this.label5 = new System.Windows.Forms.Label();
            this.depthNumeric = new KLib.Controls.KNumericBox();
            this.label3 = new System.Windows.Forms.Label();
            this.phaseNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Frequency (Hz)";
            // 
            // freqNumeric
            // 
            this.freqNumeric.AutoSize = true;
            this.freqNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.freqNumeric.FloatValue = 0F;
            this.freqNumeric.IntValue = 0;
            this.freqNumeric.IsInteger = false;
            this.freqNumeric.Location = new System.Drawing.Point(100, 0);
            this.freqNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.freqNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.freqNumeric.MaxValue = double.PositiveInfinity;
            this.freqNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.freqNumeric.MinValue = 0D;
            this.freqNumeric.Name = "freqNumeric";
            this.freqNumeric.Size = new System.Drawing.Size(75, 20);
            this.freqNumeric.TabIndex = 1;
            this.freqNumeric.TextFormat = "K4";
            this.freqNumeric.Units = "";
            this.freqNumeric.Value = 0D;
            this.freqNumeric.ValueChanged += new System.EventHandler(this.freqNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Depth (0-1)";
            // 
            // depthNumeric
            // 
            this.depthNumeric.AutoSize = true;
            this.depthNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.depthNumeric.FloatValue = 0F;
            this.depthNumeric.IntValue = 0;
            this.depthNumeric.IsInteger = false;
            this.depthNumeric.Location = new System.Drawing.Point(100, 26);
            this.depthNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.depthNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.depthNumeric.MaxValue = 1D;
            this.depthNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.depthNumeric.MinValue = 0D;
            this.depthNumeric.Name = "depthNumeric";
            this.depthNumeric.Size = new System.Drawing.Size(75, 20);
            this.depthNumeric.TabIndex = 5;
            this.depthNumeric.TextFormat = "K4";
            this.depthNumeric.Units = "";
            this.depthNumeric.Value = 0D;
            this.depthNumeric.ValueChanged += new System.EventHandler(this.depthNumeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phase (0-1)";
            // 
            // phaseNumeric
            // 
            this.phaseNumeric.AutoSize = true;
            this.phaseNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.phaseNumeric.FloatValue = 0F;
            this.phaseNumeric.IntValue = 0;
            this.phaseNumeric.IsInteger = false;
            this.phaseNumeric.Location = new System.Drawing.Point(100, 52);
            this.phaseNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.phaseNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.phaseNumeric.MaxValue = 1D;
            this.phaseNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.phaseNumeric.MinValue = 0D;
            this.phaseNumeric.Name = "phaseNumeric";
            this.phaseNumeric.Size = new System.Drawing.Size(75, 20);
            this.phaseNumeric.TabIndex = 5;
            this.phaseNumeric.TextFormat = "K4";
            this.phaseNumeric.Units = "";
            this.phaseNumeric.Value = 0D;
            this.phaseNumeric.ValueChanged += new System.EventHandler(this.phaseNumeric_ValueChanged);
            // 
            // SAMPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phaseNumeric);
            this.Controls.Add(this.depthNumeric);
            this.Controls.Add(this.freqNumeric);
            this.Name = "SAMPage";
            this.Size = new System.Drawing.Size(175, 72);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private KLib.Controls.KNumericBox freqNumeric;
        private System.Windows.Forms.Label label5;
        private KLib.Controls.KNumericBox depthNumeric;
        private System.Windows.Forms.Label label3;
        private KLib.Controls.KNumericBox phaseNumeric;
    }
}
