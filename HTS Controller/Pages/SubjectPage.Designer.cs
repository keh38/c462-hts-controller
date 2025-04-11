namespace HTSController.Pages
{
    partial class SubjectPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.projectDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectDropDown = new System.Windows.Forms.ComboBox();
            this.createButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.transducerDropDown = new System.Windows.Forms.ComboBox();
            this.colorBox = new KLib.Controls.KColorBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Projects";
            // 
            // projectDropDown
            // 
            this.projectDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.projectDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.projectDropDown.FormattingEnabled = true;
            this.projectDropDown.Location = new System.Drawing.Point(40, 44);
            this.projectDropDown.Name = "projectDropDown";
            this.projectDropDown.Size = new System.Drawing.Size(121, 21);
            this.projectDropDown.TabIndex = 2;
            this.projectDropDown.SelectedIndexChanged += new System.EventHandler(this.projectDropDown_SelectedIndexChanged);
            this.projectDropDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.projectDropDown_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subjects";
            // 
            // subjectDropDown
            // 
            this.subjectDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subjectDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.subjectDropDown.FormattingEnabled = true;
            this.subjectDropDown.Location = new System.Drawing.Point(40, 98);
            this.subjectDropDown.Name = "subjectDropDown";
            this.subjectDropDown.Size = new System.Drawing.Size(121, 21);
            this.subjectDropDown.TabIndex = 4;
            this.subjectDropDown.SelectedIndexChanged += new System.EventHandler(this.subjectDropDown_SelectedIndexChanged);
            this.subjectDropDown.TextChanged += new System.EventHandler(this.subjectDropDown_TextChanged);
            this.subjectDropDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subjectDropDown_KeyDown);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(167, 96);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(73, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Create new";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Visible = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Transducer";
            // 
            // transducerDropDown
            // 
            this.transducerDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.transducerDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.transducerDropDown.FormattingEnabled = true;
            this.transducerDropDown.Location = new System.Drawing.Point(40, 157);
            this.transducerDropDown.Name = "transducerDropDown";
            this.transducerDropDown.Size = new System.Drawing.Size(121, 21);
            this.transducerDropDown.TabIndex = 8;
            this.transducerDropDown.SelectedIndexChanged += new System.EventHandler(this.transducerDropDown_SelectedIndexChanged);
            // 
            // colorBox
            // 
            this.colorBox.Location = new System.Drawing.Point(40, 218);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(121, 20);
            this.colorBox.TabIndex = 10;
            this.colorBox.Value = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colorBox.ValueAsUInt = ((uint)(4294967295u));
            this.colorBox.ValueChanged += new System.EventHandler(this.colorBox_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Background color";
            // 
            // SubjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.transducerDropDown);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectDropDown);
            this.Name = "SubjectPage";
            this.Size = new System.Drawing.Size(391, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox projectDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox subjectDropDown;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox transducerDropDown;
        private KLib.Controls.KColorBox colorBox;
        private System.Windows.Forms.Label label4;
    }
}
