namespace HTSController
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sceneNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.homeButton = new System.Windows.Forms.Button();
            this.turandotButton = new System.Windows.Forms.CheckBox();
            this.subjectButton = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.subjectPage = new System.Windows.Forms.TabPage();
            this.subjectPageControl = new HTSController.Pages.SubjectPage();
            this.turandotPage = new System.Windows.Forms.TabPage();
            this.turandotPageControl = new HTSController.Pages.TurandotPage();
            this.messagePage = new System.Windows.Forms.TabPage();
            this.ipcPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.subjectPage.SuspendLayout();
            this.turandotPage.SuspendLayout();
            this.ipcPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLabel,
            this.sceneNameLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 525);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1067, 29);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.connectionStatusLabel.DoubleClickEnabled = true;
            this.connectionStatusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(111, 24);
            this.connectionStatusLabel.Text = "Not connected";
            this.connectionStatusLabel.DoubleClick += new System.EventHandler(this.connectionStatusLabel_DoubleClick);
            // 
            // sceneNameLabel
            // 
            this.sceneNameLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sceneNameLabel.Name = "sceneNameLabel";
            this.sceneNameLabel.Size = new System.Drawing.Size(55, 24);
            this.sceneNameLabel.Text = "Scene:";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "nav_plain_red.png");
            this.imageList.Images.SetKeyName(1, "nav_plain_green.png");
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.menuPanel.Controls.Add(this.homeButton);
            this.menuPanel.Controls.Add(this.turandotButton);
            this.menuPanel.Controls.Add(this.subjectButton);
            this.menuPanel.Location = new System.Drawing.Point(4, 4);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(199, 517);
            this.menuPanel.TabIndex = 5;
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.homeButton.ForeColor = System.Drawing.Color.White;
            this.homeButton.Location = new System.Drawing.Point(41, 433);
            this.homeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(120, 44);
            this.homeButton.TabIndex = 1;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // turandotButton
            // 
            this.turandotButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.turandotButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.turandotButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.turandotButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.turandotButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.turandotButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.turandotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.turandotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turandotButton.ForeColor = System.Drawing.Color.Black;
            this.turandotButton.Image = global::HTSController.Properties.Resources.Turandot_Black_24;
            this.turandotButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.turandotButton.Location = new System.Drawing.Point(41, 116);
            this.turandotButton.Margin = new System.Windows.Forms.Padding(0);
            this.turandotButton.Name = "turandotButton";
            this.turandotButton.Padding = new System.Windows.Forms.Padding(16, 0, 11, 0);
            this.turandotButton.Size = new System.Drawing.Size(157, 53);
            this.turandotButton.TabIndex = 4;
            this.turandotButton.Text = "Turandot";
            this.turandotButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.turandotButton.UseVisualStyleBackColor = false;
            this.turandotButton.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // subjectButton
            // 
            this.subjectButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.subjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.subjectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.subjectButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.subjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.subjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.subjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.subjectButton.Image = global::HTSController.Properties.Resources.subject_24;
            this.subjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subjectButton.Location = new System.Drawing.Point(41, 63);
            this.subjectButton.Margin = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.subjectButton.Name = "subjectButton";
            this.subjectButton.Padding = new System.Windows.Forms.Padding(16, 0, 11, 0);
            this.subjectButton.Size = new System.Drawing.Size(157, 53);
            this.subjectButton.TabIndex = 3;
            this.subjectButton.Text = "Subject";
            this.subjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.subjectButton.UseVisualStyleBackColor = false;
            this.subjectButton.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.menuPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ipcPanel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 525);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.subjectPage);
            this.tabControl.Controls.Add(this.turandotPage);
            this.tabControl.Controls.Add(this.messagePage);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(211, 4);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(652, 517);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 6;
            // 
            // subjectPage
            // 
            this.subjectPage.Controls.Add(this.subjectPageControl);
            this.subjectPage.Location = new System.Drawing.Point(4, 5);
            this.subjectPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subjectPage.Name = "subjectPage";
            this.subjectPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subjectPage.Size = new System.Drawing.Size(644, 508);
            this.subjectPage.TabIndex = 0;
            this.subjectPage.Text = "tabPage1";
            this.subjectPage.UseVisualStyleBackColor = true;
            // 
            // subjectPageControl
            // 
            this.subjectPageControl.AutoSize = true;
            this.subjectPageControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subjectPageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectPageControl.Location = new System.Drawing.Point(4, 4);
            this.subjectPageControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.subjectPageControl.Name = "subjectPageControl";
            this.subjectPageControl.Size = new System.Drawing.Size(636, 500);
            this.subjectPageControl.TabIndex = 0;
            this.subjectPageControl.ValueChanged += new System.EventHandler(this.subjectPageControl_ValueChanged);
            // 
            // turandotPage
            // 
            this.turandotPage.Controls.Add(this.turandotPageControl);
            this.turandotPage.Location = new System.Drawing.Point(4, 5);
            this.turandotPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.turandotPage.Name = "turandotPage";
            this.turandotPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.turandotPage.Size = new System.Drawing.Size(644, 508);
            this.turandotPage.TabIndex = 1;
            this.turandotPage.Text = "tabPage2";
            this.turandotPage.UseVisualStyleBackColor = true;
            // 
            // turandotPageControl
            // 
            this.turandotPageControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.turandotPageControl.Location = new System.Drawing.Point(8, 4);
            this.turandotPageControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.turandotPageControl.Name = "turandotPageControl";
            this.turandotPageControl.Size = new System.Drawing.Size(476, 350);
            this.turandotPageControl.TabIndex = 0;
            this.turandotPageControl.InteractiveClick += new System.EventHandler<string>(this.turandotPageControl_InteractiveClick);
            // 
            // messagePage
            // 
            this.messagePage.Location = new System.Drawing.Point(4, 5);
            this.messagePage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messagePage.Name = "messagePage";
            this.messagePage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messagePage.Size = new System.Drawing.Size(644, 508);
            this.messagePage.TabIndex = 2;
            this.messagePage.Text = "tabPage1";
            this.messagePage.UseVisualStyleBackColor = true;
            // 
            // ipcPanel
            // 
            this.ipcPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipcPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipcPanel.Controls.Add(this.label1);
            this.ipcPanel.Location = new System.Drawing.Point(871, 4);
            this.ipcPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipcPanel.Name = "ipcPanel";
            this.ipcPanel.Size = new System.Drawing.Size(192, 517);
            this.ipcPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data streams";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectionTimer
            // 
            this.connectionTimer.Interval = 500;
            this.connectionTimer.Tick += new System.EventHandler(this.connectionTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1061, 574);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hearing Test Suite Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.subjectPage.ResumeLayout(false);
            this.subjectPage.PerformLayout();
            this.turandotPage.ResumeLayout(false);
            this.ipcPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripStatusLabel sceneNameLabel;
        private System.Windows.Forms.CheckBox subjectButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage subjectPage;
        private System.Windows.Forms.TabPage turandotPage;
        private System.Windows.Forms.Panel ipcPanel;
        private System.Windows.Forms.TabPage messagePage;
        private Pages.SubjectPage subjectPageControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox turandotButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Timer connectionTimer;
        private Pages.TurandotPage turandotPageControl;
    }
}

