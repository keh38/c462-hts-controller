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
            this.label1 = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // interactiveSettingsListBox
            // 
            this.interactiveSettingsListBox.FormattingEnabled = true;
            this.interactiveSettingsListBox.Location = new System.Drawing.Point(14, 34);
            this.interactiveSettingsListBox.Name = "interactiveSettingsListBox";
            this.interactiveSettingsListBox.Size = new System.Drawing.Size(144, 82);
            this.interactiveSettingsListBox.TabIndex = 3;
            this.interactiveSettingsListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.interactiveSettingsListBox_KeyUp);
            // 
            // interactiveButton
            // 
            this.interactiveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.interactiveButton.ForeColor = System.Drawing.Color.White;
            this.interactiveButton.Location = new System.Drawing.Point(14, 122);
            this.interactiveButton.Name = "interactiveButton";
            this.interactiveButton.Size = new System.Drawing.Size(144, 36);
            this.interactiveButton.TabIndex = 2;
            this.interactiveButton.Text = "Start";
            this.interactiveButton.UseVisualStyleBackColor = false;
            this.interactiveButton.Click += new System.EventHandler(this.interactiveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Interactive control";
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.copyButton.ForeColor = System.Drawing.Color.White;
            this.copyButton.Location = new System.Drawing.Point(14, 164);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(144, 36);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "Transfer to tablet";
            this.copyButton.UseVisualStyleBackColor = false;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageLabel.Location = new System.Drawing.Point(14, 226);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(295, 23);
            this.messageLabel.TabIndex = 6;
            this.messageLabel.Text = "message";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.messageLabel.Visible = false;
            // 
            // TurandotPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.interactiveSettingsListBox);
            this.Controls.Add(this.interactiveButton);
            this.Name = "TurandotPage";
            this.Size = new System.Drawing.Size(332, 271);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox interactiveSettingsListBox;
        private System.Windows.Forms.Button interactiveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label messageLabel;
    }
}
