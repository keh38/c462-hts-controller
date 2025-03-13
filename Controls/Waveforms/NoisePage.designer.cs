namespace KLib.Unity.Controls.Signals
{
    partial class NoisePage
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
            this.seedNumeric = new KLib.Controls.KNumericBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filterSpecView = new KLib.Unity.Controls.Signals.FilterSpecView();
            this.SuspendLayout();
            // 
            // seedNumeric
            // 
            this.seedNumeric.AutoSize = true;
            this.seedNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.seedNumeric.FloatValue = 0F;
            this.seedNumeric.IntValue = 0;
            this.seedNumeric.IsInteger = true;
            this.seedNumeric.Location = new System.Drawing.Point(105, 2);
            this.seedNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.seedNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.seedNumeric.MaxValue = double.PositiveInfinity;
            this.seedNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.seedNumeric.MinValue = 0D;
            this.seedNumeric.Name = "seedNumeric";
            this.seedNumeric.Size = new System.Drawing.Size(75, 20);
            this.seedNumeric.TabIndex = 1;
            this.seedNumeric.TextFormat = "F";
            this.seedNumeric.Units = "";
            this.seedNumeric.Value = 0D;
            this.seedNumeric.ValueChanged += new System.EventHandler(this.seedNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seed";
            // 
            // filterSpecView
            // 
            this.filterSpecView.AutoSize = true;
            this.filterSpecView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filterSpecView.Location = new System.Drawing.Point(8, 28);
            this.filterSpecView.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.filterSpecView.Name = "filterSpecView";
            this.filterSpecView.Size = new System.Drawing.Size(172, 103);
            this.filterSpecView.TabIndex = 3;
            this.filterSpecView.ValueChanged += new System.EventHandler(this.filterSpecView_ValueChanged);
            // 
            // NoisePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.filterSpecView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seedNumeric);
            this.Name = "NoisePage";
            this.Size = new System.Drawing.Size(180, 131);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private KLib.Controls.KNumericBox seedNumeric;
        private System.Windows.Forms.Label label1;
        private FilterSpecView filterSpecView;
    }
}
