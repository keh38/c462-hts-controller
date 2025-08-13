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
            this.matlabStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sceneNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuPanel = new System.Windows.Forms.Panel();
            this.basicButton = new System.Windows.Forms.CheckBox();
            this.lightsButton = new System.Windows.Forms.CheckBox();
            this.protocolButton = new System.Windows.Forms.CheckBox();
            this.pupilButton = new System.Windows.Forms.CheckBox();
            this.adminButton = new System.Windows.Forms.CheckBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.turandotButton = new System.Windows.Forms.CheckBox();
            this.subjectButton = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.subjectPage = new System.Windows.Forms.TabPage();
            this.turandotSettingsPage = new System.Windows.Forms.TabPage();
            this.messagePage = new System.Windows.Forms.TabPage();
            this.runTurandotPage = new System.Windows.Forms.TabPage();
            this.adminPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.projectRootBrowser = new KLib.Controls.FileBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.driveDropDown = new System.Windows.Forms.ComboBox();
            this.localLogButton = new System.Windows.Forms.Button();
            this.tabletLogButton = new System.Windows.Forms.Button();
            this.pupilPage = new System.Windows.Forms.TabPage();
            this.basicPageContainer = new System.Windows.Forms.TabPage();
            this.ipcPanel = new System.Windows.Forms.Panel();
            this.ipcLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionTimer = new System.Windows.Forms.Timer(this.components);
            this.subjectPageControl = new HTSController.Pages.SubjectPage();
            this.turandotPageControl = new HTSController.Pages.TurandotPage();
            this.protocolControl = new HTSController.Pages.ProtocolControl();
            this.statusStrip.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.subjectPage.SuspendLayout();
            this.turandotSettingsPage.SuspendLayout();
            this.adminPage.SuspendLayout();
            this.ipcPanel.SuspendLayout();
            this.ipcLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLabel,
            this.matlabStatusLabel,
            this.sceneNameLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 505);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(905, 24);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.connectionStatusLabel.DoubleClickEnabled = true;
            this.connectionStatusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(90, 19);
            this.connectionStatusLabel.Text = "Not connected";
            // 
            // matlabStatusLabel
            // 
            this.matlabStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.matlabStatusLabel.Image = global::HTSController.Properties.Resources.Matlab_Logo_32;
            this.matlabStatusLabel.Name = "matlabStatusLabel";
            this.matlabStatusLabel.Size = new System.Drawing.Size(125, 24);
            this.matlabStatusLabel.Text = "MATLAB available";
            this.matlabStatusLabel.Visible = false;
            // 
            // sceneNameLabel
            // 
            this.sceneNameLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sceneNameLabel.Name = "sceneNameLabel";
            this.sceneNameLabel.Size = new System.Drawing.Size(45, 19);
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
            this.menuPanel.Controls.Add(this.basicButton);
            this.menuPanel.Controls.Add(this.lightsButton);
            this.menuPanel.Controls.Add(this.protocolButton);
            this.menuPanel.Controls.Add(this.pupilButton);
            this.menuPanel.Controls.Add(this.adminButton);
            this.menuPanel.Controls.Add(this.homeButton);
            this.menuPanel.Controls.Add(this.turandotButton);
            this.menuPanel.Controls.Add(this.subjectButton);
            this.menuPanel.Location = new System.Drawing.Point(3, 3);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(149, 499);
            this.menuPanel.TabIndex = 5;
            // 
            // basicButton
            // 
            this.basicButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.basicButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.basicButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.basicButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.basicButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.basicButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.basicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.basicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.basicButton.ForeColor = System.Drawing.Color.Black;
            this.basicButton.Image = global::HTSController.Properties.Resources.graph;
            this.basicButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.basicButton.Location = new System.Drawing.Point(16, 94);
            this.basicButton.Margin = new System.Windows.Forms.Padding(0);
            this.basicButton.Name = "basicButton";
            this.basicButton.Padding = new System.Windows.Forms.Padding(12, 0, 4, 0);
            this.basicButton.Size = new System.Drawing.Size(133, 43);
            this.basicButton.TabIndex = 9;
            this.basicButton.Text = "Basic";
            this.basicButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.basicButton.UseVisualStyleBackColor = false;
            this.basicButton.CheckedChanged += new System.EventHandler(this.basicButton_CheckedChanged);
            // 
            // lightsButton
            // 
            this.lightsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.lightsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.lightsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.lightsButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.lightsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.lightsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.lightsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightsButton.ForeColor = System.Drawing.Color.Black;
            this.lightsButton.Image = global::HTSController.Properties.Resources.Light_24;
            this.lightsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lightsButton.Location = new System.Drawing.Point(16, 332);
            this.lightsButton.Margin = new System.Windows.Forms.Padding(0);
            this.lightsButton.Name = "lightsButton";
            this.lightsButton.Padding = new System.Windows.Forms.Padding(6, 0, 8, 0);
            this.lightsButton.Size = new System.Drawing.Size(133, 43);
            this.lightsButton.TabIndex = 8;
            this.lightsButton.Text = "Lights";
            this.lightsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lightsButton.UseVisualStyleBackColor = false;
            // 
            // protocolButton
            // 
            this.protocolButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.protocolButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.protocolButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.protocolButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.protocolButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.protocolButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.protocolButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.protocolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protocolButton.ForeColor = System.Drawing.Color.Black;
            this.protocolButton.Image = global::HTSController.Properties.Resources.checklist_32;
            this.protocolButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.protocolButton.Location = new System.Drawing.Point(16, 263);
            this.protocolButton.Margin = new System.Windows.Forms.Padding(0);
            this.protocolButton.Name = "protocolButton";
            this.protocolButton.Padding = new System.Windows.Forms.Padding(12, 0, 4, 0);
            this.protocolButton.Size = new System.Drawing.Size(133, 43);
            this.protocolButton.TabIndex = 7;
            this.protocolButton.Text = "Protocols";
            this.protocolButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.protocolButton.UseVisualStyleBackColor = false;
            this.protocolButton.CheckedChanged += new System.EventHandler(this.protocolButton_CheckedChanged);
            // 
            // pupilButton
            // 
            this.pupilButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.pupilButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.pupilButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.pupilButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.pupilButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.pupilButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.pupilButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pupilButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pupilButton.ForeColor = System.Drawing.Color.Black;
            this.pupilButton.Image = global::HTSController.Properties.Resources.eye_24;
            this.pupilButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pupilButton.Location = new System.Drawing.Point(16, 180);
            this.pupilButton.Margin = new System.Windows.Forms.Padding(0);
            this.pupilButton.Name = "pupilButton";
            this.pupilButton.Padding = new System.Windows.Forms.Padding(12, 0, 4, 0);
            this.pupilButton.Size = new System.Drawing.Size(133, 43);
            this.pupilButton.TabIndex = 6;
            this.pupilButton.Text = "Pupillometry";
            this.pupilButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pupilButton.UseVisualStyleBackColor = false;
            this.pupilButton.CheckedChanged += new System.EventHandler(this.pupilButton_CheckedChanged);
            // 
            // adminButton
            // 
            this.adminButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.adminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.adminButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.adminButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.adminButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.adminButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminButton.ForeColor = System.Drawing.Color.Black;
            this.adminButton.Image = global::HTSController.Properties.Resources.Tools_24;
            this.adminButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adminButton.Location = new System.Drawing.Point(12, 375);
            this.adminButton.Margin = new System.Windows.Forms.Padding(0);
            this.adminButton.Name = "adminButton";
            this.adminButton.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.adminButton.Size = new System.Drawing.Size(136, 43);
            this.adminButton.TabIndex = 5;
            this.adminButton.Text = "Admin";
            this.adminButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adminButton.UseVisualStyleBackColor = false;
            this.adminButton.CheckedChanged += new System.EventHandler(this.adminButton_CheckedChanged);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.homeButton.ForeColor = System.Drawing.Color.White;
            this.homeButton.Location = new System.Drawing.Point(31, 433);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(90, 36);
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
            this.turandotButton.Location = new System.Drawing.Point(16, 137);
            this.turandotButton.Margin = new System.Windows.Forms.Padding(0);
            this.turandotButton.Name = "turandotButton";
            this.turandotButton.Padding = new System.Windows.Forms.Padding(12, 0, 4, 0);
            this.turandotButton.Size = new System.Drawing.Size(133, 43);
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
            this.subjectButton.Location = new System.Drawing.Point(16, 51);
            this.subjectButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.subjectButton.Name = "subjectButton";
            this.subjectButton.Padding = new System.Windows.Forms.Padding(12, 0, 4, 0);
            this.subjectButton.Size = new System.Drawing.Size(133, 43);
            this.subjectButton.TabIndex = 3;
            this.subjectButton.Text = "Subject";
            this.subjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.subjectButton.UseVisualStyleBackColor = false;
            this.subjectButton.CheckedChanged += new System.EventHandler(this.menuButton_CheckedChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel.Controls.Add(this.menuPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tabControl, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.ipcPanel, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.protocolControl, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(905, 505);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.subjectPage);
            this.tabControl.Controls.Add(this.turandotSettingsPage);
            this.tabControl.Controls.Add(this.messagePage);
            this.tabControl.Controls.Add(this.runTurandotPage);
            this.tabControl.Controls.Add(this.adminPage);
            this.tabControl.Controls.Add(this.pupilPage);
            this.tabControl.Controls.Add(this.basicPageContainer);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(346, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(368, 499);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 6;
            // 
            // subjectPage
            // 
            this.subjectPage.Controls.Add(this.subjectPageControl);
            this.subjectPage.Location = new System.Drawing.Point(4, 5);
            this.subjectPage.Name = "subjectPage";
            this.subjectPage.Padding = new System.Windows.Forms.Padding(3);
            this.subjectPage.Size = new System.Drawing.Size(360, 490);
            this.subjectPage.TabIndex = 0;
            this.subjectPage.Text = "tabPage1";
            this.subjectPage.UseVisualStyleBackColor = true;
            // 
            // turandotSettingsPage
            // 
            this.turandotSettingsPage.Controls.Add(this.turandotPageControl);
            this.turandotSettingsPage.Location = new System.Drawing.Point(4, 5);
            this.turandotSettingsPage.Name = "turandotSettingsPage";
            this.turandotSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.turandotSettingsPage.Size = new System.Drawing.Size(360, 490);
            this.turandotSettingsPage.TabIndex = 1;
            this.turandotSettingsPage.Text = "tabPage2";
            this.turandotSettingsPage.UseVisualStyleBackColor = true;
            // 
            // messagePage
            // 
            this.messagePage.Location = new System.Drawing.Point(4, 5);
            this.messagePage.Name = "messagePage";
            this.messagePage.Padding = new System.Windows.Forms.Padding(3);
            this.messagePage.Size = new System.Drawing.Size(360, 490);
            this.messagePage.TabIndex = 2;
            this.messagePage.Text = "tabPage1";
            this.messagePage.UseVisualStyleBackColor = true;
            // 
            // runTurandotPage
            // 
            this.runTurandotPage.Location = new System.Drawing.Point(4, 5);
            this.runTurandotPage.Name = "runTurandotPage";
            this.runTurandotPage.Padding = new System.Windows.Forms.Padding(3);
            this.runTurandotPage.Size = new System.Drawing.Size(360, 490);
            this.runTurandotPage.TabIndex = 3;
            this.runTurandotPage.Text = "tabPage1";
            this.runTurandotPage.UseVisualStyleBackColor = true;
            // 
            // adminPage
            // 
            this.adminPage.Controls.Add(this.label3);
            this.adminPage.Controls.Add(this.projectRootBrowser);
            this.adminPage.Controls.Add(this.label2);
            this.adminPage.Controls.Add(this.driveDropDown);
            this.adminPage.Controls.Add(this.localLogButton);
            this.adminPage.Controls.Add(this.tabletLogButton);
            this.adminPage.Location = new System.Drawing.Point(4, 5);
            this.adminPage.Name = "adminPage";
            this.adminPage.Padding = new System.Windows.Forms.Padding(3);
            this.adminPage.Size = new System.Drawing.Size(360, 490);
            this.adminPage.TabIndex = 4;
            this.adminPage.Text = "tabPage1";
            this.adminPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Root project folder";
            // 
            // projectRootBrowser
            // 
            this.projectRootBrowser.AutoSize = true;
            this.projectRootBrowser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.projectRootBrowser.DefaultFolder = null;
            this.projectRootBrowser.FileMustExist = false;
            this.projectRootBrowser.Filter = null;
            this.projectRootBrowser.FoldersOnly = true;
            this.projectRootBrowser.HideFolder = false;
            this.projectRootBrowser.Location = new System.Drawing.Point(104, 63);
            this.projectRootBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.projectRootBrowser.Name = "projectRootBrowser";
            this.projectRootBrowser.ReadOnly = false;
            this.projectRootBrowser.ShowSaveButton = false;
            this.projectRootBrowser.Size = new System.Drawing.Size(235, 21);
            this.projectRootBrowser.TabIndex = 6;
            this.projectRootBrowser.UseEllipsis = false;
            this.projectRootBrowser.Value = "";
            this.projectRootBrowser.ValueChanged += new System.EventHandler(this.projectRootBrowser_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data drive";
            // 
            // driveDropDown
            // 
            this.driveDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveDropDown.FormattingEnabled = true;
            this.driveDropDown.Location = new System.Drawing.Point(104, 37);
            this.driveDropDown.Name = "driveDropDown";
            this.driveDropDown.Size = new System.Drawing.Size(52, 21);
            this.driveDropDown.TabIndex = 4;
            this.driveDropDown.SelectedIndexChanged += new System.EventHandler(this.driveDropDown_SelectedIndexChanged);
            // 
            // localLogButton
            // 
            this.localLogButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.localLogButton.ForeColor = System.Drawing.Color.White;
            this.localLogButton.Location = new System.Drawing.Point(6, 403);
            this.localLogButton.Name = "localLogButton";
            this.localLogButton.Size = new System.Drawing.Size(118, 36);
            this.localLogButton.TabIndex = 3;
            this.localLogButton.Text = "Get local log";
            this.localLogButton.UseVisualStyleBackColor = false;
            this.localLogButton.Click += new System.EventHandler(this.localLogButton_Click);
            // 
            // tabletLogButton
            // 
            this.tabletLogButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.tabletLogButton.ForeColor = System.Drawing.Color.White;
            this.tabletLogButton.Location = new System.Drawing.Point(6, 361);
            this.tabletLogButton.Name = "tabletLogButton";
            this.tabletLogButton.Size = new System.Drawing.Size(118, 36);
            this.tabletLogButton.TabIndex = 2;
            this.tabletLogButton.Text = "Get tablet log";
            this.tabletLogButton.UseVisualStyleBackColor = false;
            this.tabletLogButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // pupilPage
            // 
            this.pupilPage.Location = new System.Drawing.Point(4, 5);
            this.pupilPage.Name = "pupilPage";
            this.pupilPage.Padding = new System.Windows.Forms.Padding(3);
            this.pupilPage.Size = new System.Drawing.Size(360, 490);
            this.pupilPage.TabIndex = 5;
            this.pupilPage.Text = "tabPage1";
            this.pupilPage.UseVisualStyleBackColor = true;
            // 
            // basicPageContainer
            // 
            this.basicPageContainer.Location = new System.Drawing.Point(4, 5);
            this.basicPageContainer.Name = "basicPageContainer";
            this.basicPageContainer.Padding = new System.Windows.Forms.Padding(3);
            this.basicPageContainer.Size = new System.Drawing.Size(360, 490);
            this.basicPageContainer.TabIndex = 6;
            this.basicPageContainer.Text = "tabPage1";
            this.basicPageContainer.UseVisualStyleBackColor = true;
            // 
            // ipcPanel
            // 
            this.ipcPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipcPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipcPanel.Controls.Add(this.ipcLayoutPanel);
            this.ipcPanel.Location = new System.Drawing.Point(720, 3);
            this.ipcPanel.Name = "ipcPanel";
            this.ipcPanel.Size = new System.Drawing.Size(182, 499);
            this.ipcPanel.TabIndex = 7;
            // 
            // ipcLayoutPanel
            // 
            this.ipcLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ipcLayoutPanel.Controls.Add(this.label1);
            this.ipcLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipcLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ipcLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ipcLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ipcLayoutPanel.Name = "ipcLayoutPanel";
            this.ipcLayoutPanel.Size = new System.Drawing.Size(180, 497);
            this.ipcLayoutPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data streams";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectionTimer
            // 
            this.connectionTimer.Interval = 1000;
            this.connectionTimer.Tick += new System.EventHandler(this.connectionTimer_Tick);
            // 
            // subjectPageControl
            // 
            this.subjectPageControl.AutoSize = true;
            this.subjectPageControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subjectPageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectPageControl.Location = new System.Drawing.Point(3, 3);
            this.subjectPageControl.Margin = new System.Windows.Forms.Padding(4);
            this.subjectPageControl.Name = "subjectPageControl";
            this.subjectPageControl.OnProjectChanged = null;
            this.subjectPageControl.Size = new System.Drawing.Size(354, 484);
            this.subjectPageControl.TabIndex = 0;
            this.subjectPageControl.ValueChanged += new System.EventHandler(this.subjectPageControl_ValueChanged);
            // 
            // turandotPageControl
            // 
            this.turandotPageControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.turandotPageControl.Location = new System.Drawing.Point(6, 3);
            this.turandotPageControl.Margin = new System.Windows.Forms.Padding(4);
            this.turandotPageControl.Name = "turandotPageControl";
            this.turandotPageControl.Size = new System.Drawing.Size(357, 331);
            this.turandotPageControl.TabIndex = 0;
            this.turandotPageControl.StartInteractiveClick += new System.EventHandler<string>(this.turandotPageControl_InteractiveClick);
            this.turandotPageControl.StartTurandotClick += new System.EventHandler<string>(this.turandotPageControl_StartTurandotClick);
            // 
            // protocolControl
            // 
            this.protocolControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.protocolControl.Location = new System.Drawing.Point(159, 4);
            this.protocolControl.Margin = new System.Windows.Forms.Padding(4);
            this.protocolControl.Name = "protocolControl";
            this.protocolControl.Size = new System.Drawing.Size(180, 497);
            this.protocolControl.TabIndex = 8;
            this.protocolControl.AdvanceProtocol += new System.EventHandler<HTSController.Pages.ProtocolControl.ProtocolItem>(this.protocolControl_AdvanceProtocol);
            this.protocolControl.ProtocolStateChange += new System.EventHandler<HTSController.Pages.ProtocolControl.ProtocolStateChangeEventArgs>(this.protocolControl_ProtocolStateChange);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 529);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 463);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hearing Test Suite Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.subjectPage.ResumeLayout(false);
            this.subjectPage.PerformLayout();
            this.turandotSettingsPage.ResumeLayout(false);
            this.adminPage.ResumeLayout(false);
            this.adminPage.PerformLayout();
            this.ipcPanel.ResumeLayout(false);
            this.ipcLayoutPanel.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage subjectPage;
        private System.Windows.Forms.TabPage turandotSettingsPage;
        private System.Windows.Forms.Panel ipcPanel;
        private System.Windows.Forms.TabPage messagePage;
        private Pages.SubjectPage subjectPageControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox turandotButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Timer connectionTimer;
        private Pages.TurandotPage turandotPageControl;
        private System.Windows.Forms.TabPage runTurandotPage;
        private System.Windows.Forms.FlowLayoutPanel ipcLayoutPanel;
        private System.Windows.Forms.CheckBox adminButton;
        private System.Windows.Forms.TabPage adminPage;
        private System.Windows.Forms.Button tabletLogButton;
        private System.Windows.Forms.CheckBox pupilButton;
        private System.Windows.Forms.TabPage pupilPage;
        private System.Windows.Forms.ToolStripStatusLabel matlabStatusLabel;
        private System.Windows.Forms.CheckBox protocolButton;
        private Pages.ProtocolControl protocolControl1;
        private Pages.ProtocolControl protocolControl;
        private System.Windows.Forms.Button localLogButton;
        private System.Windows.Forms.ComboBox driveDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private KLib.Controls.FileBrowser projectRootBrowser;
        private System.Windows.Forms.CheckBox lightsButton;
        private System.Windows.Forms.CheckBox basicButton;
        private System.Windows.Forms.TabPage basicPageContainer;
    }
}

