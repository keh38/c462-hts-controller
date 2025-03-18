namespace HTSController
{
    partial class PropertyControl
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
            this.propertyLabel = new System.Windows.Forms.Label();
            this.propertyNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // propertyLabel
            // 
            this.propertyLabel.Location = new System.Drawing.Point(3, 4);
            this.propertyLabel.Name = "propertyLabel";
            this.propertyLabel.Size = new System.Drawing.Size(148, 16);
            this.propertyLabel.TabIndex = 0;
            this.propertyLabel.Text = "label1";
            this.propertyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // propertyNumeric
            // 
            this.propertyNumeric.AllowInf = false;
            this.propertyNumeric.AutoSize = true;
            this.propertyNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.propertyNumeric.ClearOnDisable = false;
            this.propertyNumeric.FloatValue = 0F;
            this.propertyNumeric.IntValue = 0;
            this.propertyNumeric.IsInteger = false;
            this.propertyNumeric.Location = new System.Drawing.Point(157, 3);
            this.propertyNumeric.MaxCoerce = false;
            this.propertyNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.propertyNumeric.MaxValue = 1.7976931348623157E+308D;
            this.propertyNumeric.MinCoerce = false;
            this.propertyNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.propertyNumeric.MinValue = 0D;
            this.propertyNumeric.Name = "propertyNumeric";
            this.propertyNumeric.Size = new System.Drawing.Size(79, 20);
            this.propertyNumeric.TabIndex = 1;
            this.propertyNumeric.TextFormat = "K4";
            this.propertyNumeric.ToolTip = "";
            this.propertyNumeric.Units = "";
            this.propertyNumeric.Value = 0D;
            this.propertyNumeric.ValueChanged += new System.EventHandler(this.propertyNumeric_ValueChanged);
            // 
            // PropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.propertyNumeric);
            this.Controls.Add(this.propertyLabel);
            this.Name = "PropertyControl";
            this.Size = new System.Drawing.Size(239, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label propertyLabel;
        private KLib.Controls.KNumericBox propertyNumeric;
    }
}
