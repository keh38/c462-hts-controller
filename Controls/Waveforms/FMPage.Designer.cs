namespace KLib.Unity.Controls.Signals.Waveforms
{
    partial class FMPage
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
            this.carrierNumeric = new KLib.Controls.KNumericBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modFreqNumeric = new KLib.Controls.KNumericBox();
            this.label3 = new System.Windows.Forms.Label();
            this.depthNumeric = new KLib.Controls.KNumericBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phaseNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Carrier (Hz)";
            // 
            // carrierNumeric
            // 
            this.carrierNumeric.AutoSize = true;
            this.carrierNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.carrierNumeric.FloatValue = 0F;
            this.carrierNumeric.IntValue = 0;
            this.carrierNumeric.IsInteger = false;
            this.carrierNumeric.Location = new System.Drawing.Point(85, 0);
            this.carrierNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.carrierNumeric.MaxCoerce = false;
            this.carrierNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.carrierNumeric.MaxValue = double.PositiveInfinity;
            this.carrierNumeric.MinCoerce = false;
            this.carrierNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.carrierNumeric.MinValue = 0D;
            this.carrierNumeric.Name = "carrierNumeric";
            this.carrierNumeric.Size = new System.Drawing.Size(75, 20);
            this.carrierNumeric.TabIndex = 2;
            this.carrierNumeric.TextFormat = "K4";
            this.carrierNumeric.Units = "";
            this.carrierNumeric.Value = 0D;
            this.carrierNumeric.ValueChanged += new System.EventHandler(this.carrierNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mod freq (Hz)";
            // 
            // modFreqNumeric
            // 
            this.modFreqNumeric.AutoSize = true;
            this.modFreqNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.modFreqNumeric.FloatValue = 0F;
            this.modFreqNumeric.IntValue = 0;
            this.modFreqNumeric.IsInteger = false;
            this.modFreqNumeric.Location = new System.Drawing.Point(85, 23);
            this.modFreqNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.modFreqNumeric.MaxCoerce = false;
            this.modFreqNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.modFreqNumeric.MaxValue = double.PositiveInfinity;
            this.modFreqNumeric.MinCoerce = false;
            this.modFreqNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.modFreqNumeric.MinValue = 0D;
            this.modFreqNumeric.Name = "modFreqNumeric";
            this.modFreqNumeric.Size = new System.Drawing.Size(75, 20);
            this.modFreqNumeric.TabIndex = 4;
            this.modFreqNumeric.TextFormat = "K4";
            this.modFreqNumeric.Units = "";
            this.modFreqNumeric.Value = 0D;
            this.modFreqNumeric.ValueChanged += new System.EventHandler(this.modFreqNumeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Depth (Hz)";
            // 
            // depthNumeric
            // 
            this.depthNumeric.AutoSize = true;
            this.depthNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.depthNumeric.FloatValue = 0F;
            this.depthNumeric.IntValue = 0;
            this.depthNumeric.IsInteger = false;
            this.depthNumeric.Location = new System.Drawing.Point(85, 45);
            this.depthNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.depthNumeric.MaxCoerce = false;
            this.depthNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.depthNumeric.MaxValue = double.PositiveInfinity;
            this.depthNumeric.MinCoerce = false;
            this.depthNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.depthNumeric.MinValue = 0D;
            this.depthNumeric.Name = "depthNumeric";
            this.depthNumeric.Size = new System.Drawing.Size(75, 20);
            this.depthNumeric.TabIndex = 6;
            this.depthNumeric.TextFormat = "K4";
            this.depthNumeric.Units = "";
            this.depthNumeric.Value = 0D;
            this.depthNumeric.ValueChanged += new System.EventHandler(this.depthNumeric_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phase (0-1)";
            // 
            // phaseNumeric
            // 
            this.phaseNumeric.AutoSize = true;
            this.phaseNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.phaseNumeric.FloatValue = 0F;
            this.phaseNumeric.IntValue = 0;
            this.phaseNumeric.IsInteger = false;
            this.phaseNumeric.Location = new System.Drawing.Point(85, 68);
            this.phaseNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.phaseNumeric.MaxCoerce = true;
            this.phaseNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.phaseNumeric.MaxValue = 1D;
            this.phaseNumeric.MinCoerce = true;
            this.phaseNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.phaseNumeric.MinValue = -1D;
            this.phaseNumeric.Name = "phaseNumeric";
            this.phaseNumeric.Size = new System.Drawing.Size(75, 20);
            this.phaseNumeric.TabIndex = 8;
            this.phaseNumeric.TextFormat = "K4";
            this.phaseNumeric.Units = "";
            this.phaseNumeric.Value = 0D;
            this.phaseNumeric.ValueChanged += new System.EventHandler(this.phaseNumeric_ValueChanged);
            // 
            // FMPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.phaseNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.depthNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modFreqNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carrierNumeric);
            this.Name = "FMPage";
            this.Size = new System.Drawing.Size(160, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private KLib.Controls.KNumericBox carrierNumeric;
        private System.Windows.Forms.Label label2;
        private KLib.Controls.KNumericBox modFreqNumeric;
        private System.Windows.Forms.Label label3;
        private KLib.Controls.KNumericBox depthNumeric;
        private System.Windows.Forms.Label label4;
        private KLib.Controls.KNumericBox phaseNumeric;
    }
}
