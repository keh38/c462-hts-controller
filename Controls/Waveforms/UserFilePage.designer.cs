namespace KLib.Unity.Controls.Signals
{
    partial class UserFilePage
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowser = new KLib.Controls.FileBrowser();
            this.oneShotCheckBox = new System.Windows.Forms.CheckBox();
            this.formatTextBox = new System.Windows.Forms.TextBox();
            this.canComputeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fileBrowser
            // 
            this.fileBrowser.AutoSize = true;
            this.fileBrowser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileBrowser.DefaultFolder = null;
            this.fileBrowser.FileMustExist = false;
            this.fileBrowser.Filter = "Wav files|*.wav";
            this.fileBrowser.FoldersOnly = false;
            this.fileBrowser.HideFolder = true;
            this.fileBrowser.Location = new System.Drawing.Point(3, 3);
            this.fileBrowser.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.ReadOnly = false;
            this.fileBrowser.ShowSaveButton = true;
            this.fileBrowser.Size = new System.Drawing.Size(175, 21);
            this.fileBrowser.TabIndex = 0;
            this.fileBrowser.UseEllipsis = true;
            this.fileBrowser.Value = "";
            this.fileBrowser.ValueChanged += new System.EventHandler(this.fileBrowser_ValueChanged);
            // 
            // oneShotCheckBox
            // 
            this.oneShotCheckBox.AutoSize = true;
            this.oneShotCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.oneShotCheckBox.Location = new System.Drawing.Point(109, 26);
            this.oneShotCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.oneShotCheckBox.Name = "oneShotCheckBox";
            this.oneShotCheckBox.Size = new System.Drawing.Size(69, 17);
            this.oneShotCheckBox.TabIndex = 1;
            this.oneShotCheckBox.Text = "One shot";
            this.oneShotCheckBox.UseVisualStyleBackColor = true;
            this.oneShotCheckBox.CheckedChanged += new System.EventHandler(this.oneShotCheckBox_CheckedChanged);
            // 
            // formatTextBox
            // 
            this.formatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.formatTextBox.Location = new System.Drawing.Point(3, 25);
            this.formatTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.formatTextBox.Name = "formatTextBox";
            this.formatTextBox.ReadOnly = true;
            this.formatTextBox.Size = new System.Drawing.Size(103, 18);
            this.formatTextBox.TabIndex = 3;
            this.formatTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // canComputeCheckBox
            // 
            this.canComputeCheckBox.AutoSize = true;
            this.canComputeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.canComputeCheckBox.Location = new System.Drawing.Point(16, 46);
            this.canComputeCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.canComputeCheckBox.Name = "canComputeCheckBox";
            this.canComputeCheckBox.Size = new System.Drawing.Size(162, 17);
            this.canComputeCheckBox.TabIndex = 4;
            this.canComputeCheckBox.Text = "Can compute reference level";
            this.canComputeCheckBox.UseVisualStyleBackColor = true;
            this.canComputeCheckBox.CheckedChanged += new System.EventHandler(this.canComputeCheckBox_CheckedChanged);
            // 
            // UserFilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.canComputeCheckBox);
            this.Controls.Add(this.formatTextBox);
            this.Controls.Add(this.oneShotCheckBox);
            this.Controls.Add(this.fileBrowser);
            this.Name = "UserFilePage";
            this.Size = new System.Drawing.Size(178, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private KLib.Controls.FileBrowser fileBrowser;
        private System.Windows.Forms.CheckBox oneShotCheckBox;
        private System.Windows.Forms.TextBox formatTextBox;
        private System.Windows.Forms.CheckBox canComputeCheckBox;
    }
}
