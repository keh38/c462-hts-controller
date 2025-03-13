namespace KLib.Unity.Controls.Signals
{
    partial class ModulationView
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.shapeDropDown = new KLib.Controls.EnumDropDown();
            this.samPage = new KLib.Unity.Controls.Signals.SAMPage();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.shapeDropDown);
            this.flowLayoutPanel1.Controls.Add(this.samPage);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(178, 108);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // shapeDropDown
            // 
            this.shapeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shapeDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapeDropDown.FormattingEnabled = true;
            this.shapeDropDown.Location = new System.Drawing.Point(57, 3);
            this.shapeDropDown.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.shapeDropDown.Name = "shapeDropDown";
            this.shapeDropDown.Size = new System.Drawing.Size(121, 24);
            this.shapeDropDown.Sort = false;
            this.shapeDropDown.TabIndex = 13;
            this.shapeDropDown.ValueChanged += new System.EventHandler(this.shapeDropDown_ValueChanged);
            // 
            // samPage
            // 
            this.samPage.AutoSize = true;
            this.samPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.samPage.Location = new System.Drawing.Point(3, 33);
            this.samPage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.samPage.Name = "samPage";
            this.samPage.Size = new System.Drawing.Size(175, 72);
            this.samPage.TabIndex = 0;
            this.samPage.Value = null;
            this.samPage.ValueChanged += new System.EventHandler(this.amTabPage_ValueChanged);
            // 
            // ModulationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ModulationView";
            this.Size = new System.Drawing.Size(183, 111);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SAMPage samPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private KLib.Controls.EnumDropDown shapeDropDown;
    }
}
