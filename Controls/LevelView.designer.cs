namespace KLib.Unity.Controls.Signals
{
    partial class LevelView
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
            this.levelNumeric = new KLib.Controls.KNumericBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.unitsDropDown = new KLib.Controls.EnumDropDown();
            this.refDropDown = new KLib.Controls.EnumDropDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mblPanel = new System.Windows.Forms.Panel();
            this.mblLabel = new System.Windows.Forms.Label();
            this.ildPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ildNumeric = new KLib.Controls.KNumericBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.mblPanel.SuspendLayout();
            this.ildPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // levelNumeric
            // 
            this.levelNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.levelNumeric.AutoSize = true;
            this.levelNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.levelNumeric.FloatValue = 0.375F;
            this.levelNumeric.IntValue = 0;
            this.levelNumeric.IsInteger = false;
            this.levelNumeric.Location = new System.Drawing.Point(46, 0);
            this.levelNumeric.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.levelNumeric.MaxCoerce = false;
            this.levelNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.levelNumeric.MaxValue = double.PositiveInfinity;
            this.levelNumeric.MinCoerce = false;
            this.levelNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.levelNumeric.MinValue = double.NegativeInfinity;
            this.levelNumeric.Name = "levelNumeric";
            this.levelNumeric.Size = new System.Drawing.Size(75, 20);
            this.levelNumeric.TabIndex = 0;
            this.levelNumeric.TextFormat = "";
            this.levelNumeric.Units = "";
            this.levelNumeric.Value = 0.375D;
            this.levelNumeric.ValueChanged += new System.EventHandler(this.levelNumeric_ValueChanged);
            // 
            // maxTextBox
            // 
            this.maxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.maxTextBox.Location = new System.Drawing.Point(49, 74);
            this.maxTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.ReadOnly = true;
            this.maxTextBox.Size = new System.Drawing.Size(75, 20);
            this.maxTextBox.TabIndex = 2;
            this.maxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // unitsDropDown
            // 
            this.unitsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitsDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsDropDown.FormattingEnabled = true;
            this.unitsDropDown.Location = new System.Drawing.Point(3, 0);
            this.unitsDropDown.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.unitsDropDown.Name = "unitsDropDown";
            this.unitsDropDown.Size = new System.Drawing.Size(121, 24);
            this.unitsDropDown.Sort = false;
            this.unitsDropDown.TabIndex = 4;
            this.unitsDropDown.ValueChanged += new System.EventHandler(this.unitsDropDown_ValueChanged);
            // 
            // refDropDown
            // 
            this.refDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.refDropDown.FormattingEnabled = true;
            this.refDropDown.Location = new System.Drawing.Point(3, 27);
            this.refDropDown.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.refDropDown.Name = "refDropDown";
            this.refDropDown.Size = new System.Drawing.Size(121, 21);
            this.refDropDown.Sort = false;
            this.refDropDown.TabIndex = 5;
            this.refDropDown.ValueChanged += new System.EventHandler(this.refDropDown_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.unitsDropDown);
            this.flowLayoutPanel1.Controls.Add(this.refDropDown);
            this.flowLayoutPanel1.Controls.Add(this.mblPanel);
            this.flowLayoutPanel1.Controls.Add(this.maxTextBox);
            this.flowLayoutPanel1.Controls.Add(this.ildPanel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(124, 117);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // mblPanel
            // 
            this.mblPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mblPanel.AutoSize = true;
            this.mblPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mblPanel.Controls.Add(this.mblLabel);
            this.mblPanel.Controls.Add(this.levelNumeric);
            this.mblPanel.Location = new System.Drawing.Point(3, 51);
            this.mblPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mblPanel.Name = "mblPanel";
            this.mblPanel.Size = new System.Drawing.Size(121, 23);
            this.mblPanel.TabIndex = 6;
            // 
            // mblLabel
            // 
            this.mblLabel.AutoSize = true;
            this.mblLabel.Location = new System.Drawing.Point(16, 4);
            this.mblLabel.Name = "mblLabel";
            this.mblLabel.Size = new System.Drawing.Size(29, 13);
            this.mblLabel.TabIndex = 1;
            this.mblLabel.Text = "MBL";
            // 
            // ildPanel
            // 
            this.ildPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ildPanel.AutoSize = true;
            this.ildPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ildPanel.Controls.Add(this.label1);
            this.ildPanel.Controls.Add(this.ildNumeric);
            this.ildPanel.Location = new System.Drawing.Point(3, 97);
            this.ildPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ildPanel.Name = "ildPanel";
            this.ildPanel.Size = new System.Drawing.Size(121, 20);
            this.ildPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ILD";
            // 
            // ildNumeric
            // 
            this.ildNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ildNumeric.AutoSize = true;
            this.ildNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ildNumeric.FloatValue = 0.375F;
            this.ildNumeric.IntValue = 0;
            this.ildNumeric.IsInteger = false;
            this.ildNumeric.Location = new System.Drawing.Point(46, 0);
            this.ildNumeric.Margin = new System.Windows.Forms.Padding(0);
            this.ildNumeric.MaxCoerce = false;
            this.ildNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.ildNumeric.MaxValue = double.PositiveInfinity;
            this.ildNumeric.MinCoerce = false;
            this.ildNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.ildNumeric.MinValue = double.NegativeInfinity;
            this.ildNumeric.Name = "ildNumeric";
            this.ildNumeric.Size = new System.Drawing.Size(75, 20);
            this.ildNumeric.TabIndex = 0;
            this.ildNumeric.TextFormat = "";
            this.ildNumeric.Units = "";
            this.ildNumeric.Value = 0.375D;
            this.ildNumeric.ValueChanged += new System.EventHandler(this.ildNumeric_ValueChanged);
            // 
            // LevelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "LevelView";
            this.Size = new System.Drawing.Size(130, 123);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.mblPanel.ResumeLayout(false);
            this.mblPanel.PerformLayout();
            this.ildPanel.ResumeLayout(false);
            this.ildPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLib.Controls.KNumericBox levelNumeric;
        private System.Windows.Forms.TextBox maxTextBox;
        private KLib.Controls.EnumDropDown unitsDropDown;
        private KLib.Controls.EnumDropDown refDropDown;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel mblPanel;
        private System.Windows.Forms.Label mblLabel;
        private System.Windows.Forms.Panel ildPanel;
        private System.Windows.Forms.Label label1;
        private KLib.Controls.KNumericBox ildNumeric;
    }
}
