namespace KLib.Unity.Controls.Signals
{
    partial class ChannelAdvancedControl
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
            this.imTextBox = new System.Windows.Forms.TextBox();
            this.imCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // imTextBox
            // 
            this.imTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imTextBox.Location = new System.Drawing.Point(2, 26);
            this.imTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.imTextBox.Multiline = true;
            this.imTextBox.Name = "imTextBox";
            this.imTextBox.Size = new System.Drawing.Size(192, 72);
            this.imTextBox.TabIndex = 15;
            this.imTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imTextBox_KeyPress);
            this.imTextBox.Leave += new System.EventHandler(this.imTextBox_Leave);
            // 
            // imCheckBox
            // 
            this.imCheckBox.AutoSize = true;
            this.imCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.imCheckBox.Location = new System.Drawing.Point(59, 3);
            this.imCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.imCheckBox.Name = "imCheckBox";
            this.imCheckBox.Size = new System.Drawing.Size(132, 17);
            this.imCheckBox.TabIndex = 16;
            this.imCheckBox.Text = "Vary across repetitions";
            this.imCheckBox.UseVisualStyleBackColor = true;
            this.imCheckBox.CheckedChanged += new System.EventHandler(this.imCheckBox_CheckedChanged);
            // 
            // ChannelAdvancedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.imCheckBox);
            this.Controls.Add(this.imTextBox);
            this.Name = "ChannelAdvancedControl";
            this.Size = new System.Drawing.Size(194, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imTextBox;
        private System.Windows.Forms.CheckBox imCheckBox;
    }
}
