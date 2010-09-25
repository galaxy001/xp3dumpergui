namespace Clowwindy.XP3Dumper.GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBootFilename = new System.Windows.Forms.TextBox();
            this.tbExcuteFilename = new System.Windows.Forms.TextBox();
            this.tbXp3Filename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.rbUseSoraApp = new System.Windows.Forms.RadioButton();
            this.rbUseNTLEA = new System.Windows.Forms.RadioButton();
            this.rbUseNone = new System.Windows.Forms.RadioButton();
            this.btnBootFilename = new System.Windows.Forms.Button();
            this.btnExcuteFilename = new System.Windows.Forms.Button();
            this.btnExtractFilename = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCodePage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbBootFilename
            // 
            resources.ApplyResources(this.tbBootFilename, "tbBootFilename");
            this.tbBootFilename.Name = "tbBootFilename";
            // 
            // tbExcuteFilename
            // 
            resources.ApplyResources(this.tbExcuteFilename, "tbExcuteFilename");
            this.tbExcuteFilename.Name = "tbExcuteFilename";
            // 
            // tbXp3Filename
            // 
            resources.ApplyResources(this.tbXp3Filename, "tbXp3Filename");
            this.tbXp3Filename.Name = "tbXp3Filename";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbSavePath
            // 
            resources.ApplyResources(this.tbSavePath, "tbSavePath");
            this.tbSavePath.Name = "tbSavePath";
            // 
            // rbUseSoraApp
            // 
            resources.ApplyResources(this.rbUseSoraApp, "rbUseSoraApp");
            this.rbUseSoraApp.Name = "rbUseSoraApp";
            this.rbUseSoraApp.UseVisualStyleBackColor = true;
            // 
            // rbUseNTLEA
            // 
            resources.ApplyResources(this.rbUseNTLEA, "rbUseNTLEA");
            this.rbUseNTLEA.Name = "rbUseNTLEA";
            this.rbUseNTLEA.UseVisualStyleBackColor = true;
            // 
            // rbUseNone
            // 
            resources.ApplyResources(this.rbUseNone, "rbUseNone");
            this.rbUseNone.Checked = true;
            this.rbUseNone.Name = "rbUseNone";
            this.rbUseNone.TabStop = true;
            this.rbUseNone.UseVisualStyleBackColor = true;
            this.rbUseNone.CheckedChanged += new System.EventHandler(this.rbUseNone_CheckedChanged);
            // 
            // btnBootFilename
            // 
            resources.ApplyResources(this.btnBootFilename, "btnBootFilename");
            this.btnBootFilename.Name = "btnBootFilename";
            this.btnBootFilename.UseVisualStyleBackColor = true;
            this.btnBootFilename.Click += new System.EventHandler(this.btnBootFilename_Click);
            // 
            // btnExcuteFilename
            // 
            resources.ApplyResources(this.btnExcuteFilename, "btnExcuteFilename");
            this.btnExcuteFilename.Name = "btnExcuteFilename";
            this.btnExcuteFilename.UseVisualStyleBackColor = true;
            this.btnExcuteFilename.Click += new System.EventHandler(this.btnExcuteFilename_Click);
            // 
            // btnExtractFilename
            // 
            resources.ApplyResources(this.btnExtractFilename, "btnExtractFilename");
            this.btnExtractFilename.Name = "btnExtractFilename";
            this.btnExtractFilename.UseVisualStyleBackColor = true;
            this.btnExtractFilename.Click += new System.EventHandler(this.btnExtractFilename_Click);
            // 
            // btnSavePath
            // 
            resources.ApplyResources(this.btnSavePath, "btnSavePath");
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // numDelay
            // 
            resources.ApplyResources(this.numDelay, "numDelay");
            this.numDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbCodePage
            // 
            resources.ApplyResources(this.tbCodePage, "tbCodePage");
            this.tbCodePage.Name = "tbCodePage";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbBootFilename);
            this.groupBox1.Controls.Add(this.tbExcuteFilename);
            this.groupBox1.Controls.Add(this.tbXp3Filename);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSavePath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnExtractFilename);
            this.groupBox1.Controls.Add(this.tbSavePath);
            this.groupBox1.Controls.Add(this.btnExcuteFilename);
            this.groupBox1.Controls.Add(this.btnBootFilename);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbUseSoraApp);
            this.groupBox2.Controls.Add(this.rbUseNTLEA);
            this.groupBox2.Controls.Add(this.tbCodePage);
            this.groupBox2.Controls.Add(this.numDelay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rbUseNone);
            this.groupBox2.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lbStatus
            // 
            resources.ApplyResources(this.lbStatus, "lbStatus");
            this.lbStatus.Name = "lbStatus";
            // 
            // btnFinish
            // 
            resources.ApplyResources(this.btnFinish, "btnFinish");
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnStart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBootFilename;
        private System.Windows.Forms.TextBox tbExcuteFilename;
        private System.Windows.Forms.TextBox tbXp3Filename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.RadioButton rbUseSoraApp;
        private System.Windows.Forms.RadioButton rbUseNTLEA;
        private System.Windows.Forms.RadioButton rbUseNone;
        private System.Windows.Forms.Button btnBootFilename;
        private System.Windows.Forms.Button btnExcuteFilename;
        private System.Windows.Forms.Button btnExtractFilename;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCodePage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnFinish;
    }
}