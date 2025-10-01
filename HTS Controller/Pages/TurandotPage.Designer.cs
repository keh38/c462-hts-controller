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
            this.components = new System.ComponentModel.Container();
            this.listBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.fileTypeDropDown = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.messageTimer = new System.Windows.Forms.Timer(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.newButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(19, 42);
            this.listBox.Margin = new System.Windows.Forms.Padding(4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(191, 116);
            this.listBox.TabIndex = 3;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.interactiveSettingsListBox_KeyUp);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(19, 167);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(192, 44);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.copyButton.ForeColor = System.Drawing.Color.White;
            this.copyButton.Location = new System.Drawing.Point(19, 220);
            this.copyButton.Margin = new System.Windows.Forms.Padding(4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(192, 44);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "Transfer to tablet";
            this.copyButton.UseVisualStyleBackColor = false;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageLabel.Location = new System.Drawing.Point(19, 337);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.messageLabel.Size = new System.Drawing.Size(66, 26);
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
            "Turandot",
            "TScript"});
            this.fileTypeDropDown.Location = new System.Drawing.Point(19, 11);
            this.fileTypeDropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileTypeDropDown.Name = "fileTypeDropDown";
            this.fileTypeDropDown.Size = new System.Drawing.Size(192, 24);
            this.fileTypeDropDown.TabIndex = 7;
            this.fileTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.fileTypeDropDown_SelectedIndexChanged);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(19, 272);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(192, 44);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // messageTimer
            // 
            this.messageTimer.Interval = 3000;
            this.messageTimer.Tick += new System.EventHandler(this.messageTimer_Tick);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(230, 42);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(245, 304);
            this.propertyGrid.TabIndex = 9;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(230, 352);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 29);
            this.newButton.TabIndex = 10;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(311, 352);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 29);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TurandotPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.fileTypeDropDown);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TurandotPage";
            this.Size = new System.Drawing.Size(509, 398);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ComboBox fileTypeDropDown;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Timer messageTimer;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button saveButton;
    }
}
