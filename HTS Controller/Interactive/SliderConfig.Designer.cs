namespace HTSController.Interactive
{
    partial class SliderConfig
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
            this.propertyDropDown = new System.Windows.Forms.ComboBox();
            this.channelDropDown = new System.Windows.Forms.ComboBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.sliderListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.showCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // propertyDropDown
            // 
            this.propertyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyDropDown.FormattingEnabled = true;
            this.propertyDropDown.Location = new System.Drawing.Point(13, 309);
            this.propertyDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.propertyDropDown.Name = "propertyDropDown";
            this.propertyDropDown.Size = new System.Drawing.Size(217, 24);
            this.propertyDropDown.Sorted = true;
            this.propertyDropDown.TabIndex = 14;
            this.propertyDropDown.SelectedIndexChanged += new System.EventHandler(this.sliderPropertyDropDown_SelectedIndexChanged);
            // 
            // channelDropDown
            // 
            this.channelDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelDropDown.FormattingEnabled = true;
            this.channelDropDown.Location = new System.Drawing.Point(13, 276);
            this.channelDropDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.channelDropDown.Name = "channelDropDown";
            this.channelDropDown.Size = new System.Drawing.Size(217, 24);
            this.channelDropDown.Sorted = true;
            this.channelDropDown.TabIndex = 13;
            this.channelDropDown.SelectedIndexChanged += new System.EventHandler(this.channelDropDown_SelectedIndexChanged);
            // 
            // propertyGrid
            // 
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(251, 2);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid.Size = new System.Drawing.Size(285, 348);
            this.propertyGrid.TabIndex = 11;
            // 
            // sliderListBox
            // 
            this.sliderListBox.FormattingEnabled = true;
            this.sliderListBox.ItemHeight = 16;
            this.sliderListBox.Location = new System.Drawing.Point(13, 39);
            this.sliderListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sliderListBox.Name = "sliderListBox";
            this.sliderListBox.Size = new System.Drawing.Size(215, 148);
            this.sliderListBox.Sorted = true;
            this.sliderListBox.TabIndex = 15;
            this.sliderListBox.SelectedIndexChanged += new System.EventHandler(this.sliderListBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(13, 196);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(77, 30);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(99, 196);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(77, 30);
            this.removeButton.TabIndex = 17;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // showCheckBox
            // 
            this.showCheckBox.AutoSize = true;
            this.showCheckBox.Location = new System.Drawing.Point(13, 11);
            this.showCheckBox.Name = "showCheckBox";
            this.showCheckBox.Size = new System.Drawing.Size(109, 21);
            this.showCheckBox.TabIndex = 18;
            this.showCheckBox.Text = "Show sliders";
            this.showCheckBox.UseVisualStyleBackColor = true;
            this.showCheckBox.CheckedChanged += new System.EventHandler(this.showCheckBox_CheckedChanged);
            // 
            // SliderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.showCheckBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sliderListBox);
            this.Controls.Add(this.propertyDropDown);
            this.Controls.Add(this.channelDropDown);
            this.Controls.Add(this.propertyGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SliderConfig";
            this.Size = new System.Drawing.Size(539, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox propertyDropDown;
        private System.Windows.Forms.ComboBox channelDropDown;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ListBox sliderListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.CheckBox showCheckBox;
    }
}
