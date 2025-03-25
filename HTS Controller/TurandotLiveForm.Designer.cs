namespace HTSController
{
    partial class TurandotLiveForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataFileLabel = new System.Windows.Forms.Label();
            this.receivedMessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(22, 64);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 26);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataFileLabel
            // 
            this.dataFileLabel.AutoSize = true;
            this.dataFileLabel.Location = new System.Drawing.Point(28, 26);
            this.dataFileLabel.Name = "dataFileLabel";
            this.dataFileLabel.Size = new System.Drawing.Size(35, 13);
            this.dataFileLabel.TabIndex = 4;
            this.dataFileLabel.Text = "label1";
            // 
            // receivedMessageTextBox
            // 
            this.receivedMessageTextBox.Location = new System.Drawing.Point(22, 110);
            this.receivedMessageTextBox.Name = "receivedMessageTextBox";
            this.receivedMessageTextBox.ReadOnly = true;
            this.receivedMessageTextBox.Size = new System.Drawing.Size(291, 20);
            this.receivedMessageTextBox.TabIndex = 5;
            // 
            // TurandotLiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 668);
            this.Controls.Add(this.receivedMessageTextBox);
            this.Controls.Add(this.dataFileLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startButton);
            this.Name = "TurandotLiveForm";
            this.Text = "TurandotLiveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dataFileLabel;
        private System.Windows.Forms.TextBox receivedMessageTextBox;
    }
}