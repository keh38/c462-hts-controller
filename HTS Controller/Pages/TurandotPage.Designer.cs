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
            this.listBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.fileTypeDropDown = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(14, 34);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(144, 95);
            this.listBox.TabIndex = 3;
            this.listBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.interactiveSettingsListBox_KeyUp);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(14, 136);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(144, 36);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.copyButton.ForeColor = System.Drawing.Color.White;
            this.copyButton.Location = new System.Drawing.Point(14, 179);
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
            this.messageLabel.Location = new System.Drawing.Point(14, 274);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(295, 23);
            this.messageLabel.TabIndex = 6;
            this.messageLabel.Text = "message";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.messageLabel.Visible = false;
            // 
            // fileTypeDropDown
            // 
            this.fileTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileTypeDropDown.FormattingEnabled = true;
            this.fileTypeDropDown.Items.AddRange(new object[] {
            "Interactive",
            "Turandot"});
            this.fileTypeDropDown.Location = new System.Drawing.Point(14, 9);
            this.fileTypeDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileTypeDropDown.Name = "fileTypeDropDown";
            this.fileTypeDropDown.Size = new System.Drawing.Size(145, 21);
            this.fileTypeDropDown.TabIndex = 7;
            this.fileTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.fileTypeDropDown_SelectedIndexChanged);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(14, 221);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(144, 36);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // TurandotPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.fileTypeDropDown);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.startButton);
            this.Name = "TurandotPage";
            this.Size = new System.Drawing.Size(332, 323);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ComboBox fileTypeDropDown;
        private System.Windows.Forms.Button editButton;
    }
}
