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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 4);
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
            this.rateNumeric.Location = new System.Drawing.Point(99, 2);
            this.rateNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.rateNumeric.MaxCoerce = false;
            this.rateNumeric.MaximumSize = new System.Drawing.Size(15000, 16);
            this.rateNumeric.MaxValue = double.PositiveInfinity;
            this.rateNumeric.MinCoerce = false;
            this.rateNumeric.MinimumSize = new System.Drawing.Size(8, 16);
            this.rateNumeric.MinValue = 0D;
            this.rateNumeric.Name = "rateNumeric";
            this.rateNumeric.Size = new System.Drawing.Size(75, 16);
            this.rateNumeric.TabIndex = 0;
            this.rateNumeric.TextFormat = "K4";
            this.rateNumeric.ToolTip = "";
            this.rateNumeric.Units = "";
            this.rateNumeric.Value = 0D;
            this.rateNumeric.ValueChanged += new System.EventHandler(this.rateNumeric_ValueChanged);
            // 
            // DigitimerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rateNumeric);
            this.Name = "DigitimerPage";
            this.Size = new System.Drawing.Size(174, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLib.Controls.KNumericBox rateNumeric;
        private System.Windows.Forms.Label label1;
    }
}
