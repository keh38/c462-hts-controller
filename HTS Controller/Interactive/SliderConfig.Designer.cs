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
            this.SuspendLayout();
            // 
            // sliderPropertyDropDown
            // 
            this.propertyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyDropDown.FormattingEnabled = true;
            this.propertyDropDown.Location = new System.Drawing.Point(10, 251);
            this.propertyDropDown.Name = "sliderPropertyDropDown";
            this.propertyDropDown.Size = new System.Drawing.Size(164, 21);
            this.propertyDropDown.Sorted = true;
            this.propertyDropDown.TabIndex = 14;
            this.propertyDropDown.SelectedIndexChanged += new System.EventHandler(this.sliderPropertyDropDown_SelectedIndexChanged);
            // 
            // channelDropDown
            // 
            this.channelDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelDropDown.FormattingEnabled = true;
            this.channelDropDown.Location = new System.Drawing.Point(10, 224);
            this.channelDropDown.Name = "channelDropDown";
            this.channelDropDown.Size = new System.Drawing.Size(164, 21);
            this.channelDropDown.Sorted = true;
            this.channelDropDown.TabIndex = 13;
            this.channelDropDown.SelectedIndexChanged += new System.EventHandler(this.channelDropDown_SelectedIndexChanged);
            // 
            // propertyGrid
            // 
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(188, 2);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid.Size = new System.Drawing.Size(214, 283);
            this.propertyGrid.TabIndex = 11;
            // 
            // sliderListBox
            // 
            this.sliderListBox.FormattingEnabled = true;
            this.sliderListBox.Location = new System.Drawing.Point(10, 32);
            this.sliderListBox.Name = "sliderListBox";
            this.sliderListBox.Size = new System.Drawing.Size(162, 121);
            this.sliderListBox.Sorted = true;
            this.sliderListBox.TabIndex = 15;
            this.sliderListBox.SelectedIndexChanged += new System.EventHandler(this.sliderListBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(10, 159);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(58, 24);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // SliderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sliderListBox);
            this.Controls.Add(this.propertyDropDown);
            this.Controls.Add(this.channelDropDown);
            this.Controls.Add(this.propertyGrid);
            this.Name = "SliderConfig";
            this.Size = new System.Drawing.Size(404, 287);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox propertyDropDown;
        private System.Windows.Forms.ComboBox channelDropDown;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ListBox sliderListBox;
        private System.Windows.Forms.Button addButton;
    }
}
