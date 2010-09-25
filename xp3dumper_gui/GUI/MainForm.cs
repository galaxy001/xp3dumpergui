using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Clowwindy.XP3Dumper.Controller;
using System.Reflection;
using Clowwindy.XP3Dumper.Utils;

namespace Clowwindy.XP3Dumper.GUI
{
    internal partial class MainForm : Form
    {
        private Xp3Dumper dumper;
        private OpenFileDialog openDialog;
        private FolderBrowserDialog folderDialog;

        internal MainForm()
        {
            InitializeComponent();
        }

        private void initDumper()
        {
            dumper = new Xp3Dumper();
            dumper.BootFilename = tbBootFilename.Text;
            dumper.ExecuteFilename = tbExcuteFilename.Text;
            dumper.Xp3Filename = tbXp3Filename.Text;
            dumper.SavePath = tbSavePath.Text;
            dumper.UseSoraApp = rbUseSoraApp.Checked;
            dumper.CodePage = tbCodePage.Text;
        }

        private string startDumper()
        {
            return dumper.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            initDumper();
            var result = startDumper();
            lbStatus.Text = result;
            btnFinish.Enabled = true;
            this.Activate();
            this.Focus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += String.Format(" {0}.{1}", version.Major, version.Minor);
            openDialog = new OpenFileDialog();
            openDialog.RestoreDirectory = true;
            folderDialog = new FolderBrowserDialog();
        }

        private void rbUseNone_CheckedChanged(object sender, EventArgs e)
        {
            tbCodePage.Enabled = !rbUseNone.Checked;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (dumper != null)
            {
                var result = dumper.Finish();
                lbStatus.Text = result;
            }
        }

        private void btnBootFilename_Click(object sender, EventArgs e)
        {
            openDialog.FileName = tbBootFilename.Text;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                tbBootFilename.Text = openDialog.FileName;
                if (string.IsNullOrEmpty(tbExcuteFilename.Text))
                {
                    tbExcuteFilename.Text = FileUtils.GetFileName(openDialog.FileName);
                }
                if (string.IsNullOrEmpty(tbSavePath.Text))
                {
                    tbSavePath.Text = FileUtils.CombinePath(FileUtils.GetDirectoryName(openDialog.FileName), "dump");
                }
            }
        }

        private void btnExcuteFilename_Click(object sender, EventArgs e)
        {
            openDialog.FileName = tbBootFilename.Text;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                tbExcuteFilename.Text = FileUtils.GetFileName(openDialog.FileName);
            }
        }

        private void btnExtractFilename_Click(object sender, EventArgs e)
        {
            openDialog.FileName = tbBootFilename.Text;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                tbXp3Filename.Text = FileUtils.GetFileName(openDialog.FileName);
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            folderDialog.SelectedPath = tbSavePath.Text;
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                tbSavePath.Text = folderDialog.SelectedPath;
            }
        }
    }
}
