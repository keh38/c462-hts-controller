namespace KLib.Unity.Controls.Signals
{
    partial class WaveformView
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wfDropDown = new KLib.Controls.EnumDropDown();
            this.noisePage = new KLib.Unity.Controls.Signals.NoisePage();
            this.sinePage = new KLib.Unity.Controls.Signals.SinusoidPage();
            this.digitimerPage = new KLib.Unity.Controls.Signals.DigitimerPage();
            this.userFilePage = new KLib.Unity.Controls.Signals.UserFilePage();
            this.fmPage = new KLib.Unity.Controls.Signals.Waveforms.FMPage();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Waveform";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.noisePage);
            this.flowLayoutPanel1.Controls.Add(this.sinePage);
            this.flowLayoutPanel1.Controls.Add(this.digitimerPage);
            this.flowLayoutPanel1.Controls.Add(this.userFilePage);
            this.flowLayoutPanel1.Controls.Add(this.fmPage);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 443);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.wfDropDown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 31);
            this.panel1.TabIndex = 10;
            // 
            // wfDropDown
            // 
            this.wfDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wfDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wfDropDown.Location = new System.Drawing.Point(66, 4);
            this.wfDropDown.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.wfDropDown.Name = "wfDropDown";
            this.wfDropDown.Size = new System.Drawing.Size(121, 24);
            this.wfDropDown.Sort = true;
            this.wfDropDown.TabIndex = 0;
            this.wfDropDown.ValueChanged += new System.EventHandler(this.wfDropDown_ValueChanged);
            // 
            // noisePage
            // 
            this.noisePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noisePage.AutoSize = true;
            this.noisePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.noisePage.Location = new System.Drawing.Point(10, 37);
            this.noisePage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.noisePage.Name = "noisePage";
            this.noisePage.Size = new System.Drawing.Size(180, 152);
            this.noisePage.TabIndex = 10;
            this.noisePage.Value = null;
            this.noisePage.ValueChanged += new System.EventHandler(this.noisePage_ValueChanged);
            // 
            // sinePage
            // 
            this.sinePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sinePage.AutoSize = true;
            this.sinePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sinePage.IPD = 0F;
            this.sinePage.IsDichotic = false;
            this.sinePage.Location = new System.Drawing.Point(16, 195);
            this.sinePage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.sinePage.Name = "sinePage";
            this.sinePage.Size = new System.Drawing.Size(174, 48);
            this.sinePage.TabIndex = 0;
            this.sinePage.Value = null;
            this.sinePage.IPDChanged += new System.EventHandler(this.sinePage_IPDChanged);
            this.sinePage.ValueChanged += new System.EventHandler(this.sinePage_ValueChanged);
            // 
            // digitimerPage
            // 
            this.digitimerPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.digitimerPage.AutoSize = true;
            this.digitimerPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.digitimerPage.Location = new System.Drawing.Point(16, 249);
            this.digitimerPage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.digitimerPage.Name = "digitimerPage";
            this.digitimerPage.Size = new System.Drawing.Size(174, 25);
            this.digitimerPage.TabIndex = 11;
            this.digitimerPage.Value = null;
            this.digitimerPage.ValueChanged += new System.EventHandler(this.digitimerPage_ValueChanged);
            // 
            // userFilePage
            // 
            this.userFilePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userFilePage.AutoSize = true;
            this.userFilePage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userFilePage.DefaultFolder = null;
            this.userFilePage.Location = new System.Drawing.Point(12, 280);
            this.userFilePage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.userFilePage.Name = "userFilePage";
            this.userFilePage.Size = new System.Drawing.Size(178, 63);
            this.userFilePage.TabIndex = 10;
            this.userFilePage.Value = null;
            this.userFilePage.ValueChanged += new System.EventHandler(this.userFilePage_ValueChanged);
            // 
            // fmPage
            // 
            this.fmPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fmPage.AutoSize = true;
            this.fmPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fmPage.Location = new System.Drawing.Point(27, 349);
            this.fmPage.Name = "fmPage";
            this.fmPage.Size = new System.Drawing.Size(160, 91);
            this.fmPage.TabIndex = 10;
            this.fmPage.Value = null;
            this.fmPage.ValueChanged += new System.EventHandler(this.fmPage_ValueChanged);
            // 
            // WaveformView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "WaveformView";
            this.Size = new System.Drawing.Size(193, 449);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private SinusoidPage sinePage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private NoisePage noisePage;
        private UserFilePage userFilePage;
        private KLib.Controls.EnumDropDown wfDropDown;
        private Waveforms.FMPage fmPage;
        private DigitimerPage digitimerPage;
    }
}
