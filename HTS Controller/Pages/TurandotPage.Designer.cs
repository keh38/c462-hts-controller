namespace HTSController.Pages
{
    partial class TurandotPage
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
            this.interactiveSettingsListBox = new System.Windows.Forms.ListBox();
            this.interactiveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // interactiveSettingsListBox
            // 
            this.interactiveSettingsListBox.FormattingEnabled = true;
            this.interactiveSettingsListBox.Location = new System.Drawing.Point(13, 13);
            this.interactiveSettingsListBox.Name = "interactiveSettingsListBox";
            this.interactiveSettingsListBox.Size = new System.Drawing.Size(144, 82);
            this.interactiveSettingsListBox.TabIndex = 3;
            this.interactiveSettingsListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.interactiveSettingsListBox_KeyUp);
            // 
            // interactiveButton
            // 
            this.interactiveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.interactiveButton.ForeColor = System.Drawing.Color.White;
            this.interactiveButton.Location = new System.Drawing.Point(13, 112);
            this.interactiveButton.Name = "interactiveButton";
            this.interactiveButton.Size = new System.Drawing.Size(144, 36);
            this.interactiveButton.TabIndex = 2;
            this.interactiveButton.Text = "Interactive";
            this.interactiveButton.UseVisualStyleBackColor = false;
            this.interactiveButton.Click += new System.EventHandler(this.interactiveButton_Click);
            // 
            // TurandotPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.interactiveSettingsListBox);
            this.Controls.Add(this.interactiveButton);
            this.Name = "TurandotPage";
            this.Size = new System.Drawing.Size(313, 244);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox interactiveSettingsListBox;
        private System.Windows.Forms.Button interactiveButton;
    }
}
