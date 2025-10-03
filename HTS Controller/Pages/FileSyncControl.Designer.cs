namespace HTSController.Pages
{
    partial class FileSyncControl
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
            this.syncOptionDropDown = new System.Windows.Forms.ComboBox();
            this.fileBrowser = new KLib.Controls.FileBrowser();
            this.startButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.logBox = new System.Windows.Forms.TextBox();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // syncOptionDropDown
            // 
            this.syncOptionDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.syncOptionDropDown.FormattingEnabled = true;
            this.syncOptionDropDown.Items.AddRange(new object[] {
            "Resources",
            "Data",
            "Update"});
            this.syncOptionDropDown.Location = new System.Drawing.Point(19, 32);
            this.syncOptionDropDown.Name = "syncOptionDropDown";
            this.syncOptionDropDown.Size = new System.Drawing.Size(121, 24);
            this.syncOptionDropDown.TabIndex = 0;
            this.syncOptionDropDown.SelectedIndexChanged += new System.EventHandler(this.syncOptionDropDown_SelectedIndexChanged);
            // 
            // fileBrowser
            // 
            this.fileBrowser.AutoSize = true;
            this.fileBrowser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileBrowser.DefaultFolder = null;
            this.fileBrowser.FileMustExist = true;
            this.fileBrowser.Filter = null;
            this.fileBrowser.FoldersOnly = false;
            this.fileBrowser.HideFolder = false;
            this.fileBrowser.Location = new System.Drawing.Point(148, 33);
            this.fileBrowser.Margin = new System.Windows.Forms.Padding(5);
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.ReadOnly = false;
            this.fileBrowser.ShowSaveButton = false;
            this.fileBrowser.Size = new System.Drawing.Size(328, 26);
            this.fileBrowser.TabIndex = 7;
            this.fileBrowser.UseEllipsis = true;
            this.fileBrowser.Value = "";
            this.fileBrowser.ValueChanged += new System.EventHandler(this.fileBrowser_ValueChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(19, 74);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(121, 31);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(19, 74);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(121, 31);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(148, 90);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(324, 15);
            this.progressBar.TabIndex = 10;
            // 
            // logBox
            // 
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Location = new System.Drawing.Point(19, 123);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(453, 222);
            this.logBox.TabIndex = 11;
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.Location = new System.Drawing.Point(146, 71);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(349, 23);
            this.progressBarLabel.TabIndex = 12;
            this.progressBarLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sync";
            // 
            // FileSyncControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.fileBrowser);
            this.Controls.Add(this.syncOptionDropDown);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBarLabel);
            this.Name = "FileSyncControl";
            this.Size = new System.Drawing.Size(475, 375);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox syncOptionDropDown;
        private KLib.Controls.FileBrowser fileBrowser;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label progressBarLabel;
        private System.Windows.Forms.Label label1;
    }
}
