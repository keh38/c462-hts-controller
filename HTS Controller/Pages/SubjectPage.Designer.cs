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
            this.subjectDropDown.FormattingEnabled = true;
            this.subjectDropDown.Location = new System.Drawing.Point(40, 98);
            this.subjectDropDown.Name = "subjectDropDown";
            this.subjectDropDown.Size = new System.Drawing.Size(121, 21);
            this.subjectDropDown.TabIndex = 4;
            this.subjectDropDown.SelectedIndexChanged += new System.EventHandler(this.subjectDropDown_SelectedIndexChanged);
            // 
            // SubjectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
    }
}
