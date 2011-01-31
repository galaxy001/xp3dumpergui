using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Clowwindy.XP3Dumper.Controller;
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
            dumper.CodePage = tbCodePage.Text;
            dumper.Delay = (int)numDelay.Value;

            if (rbUseSoraApp.Checked)
                dumper.UseLoader = Xp3Dumper.UseStartLoader.SoraApp;
            else if (rbUseNTLEA.Checked)
                dumper.UseLoader = Xp3Dumper.UseStartLoader.NTLEA;
            else
                dumper.UseLoader = Xp3Dumper.UseStartLoader.None;
        }

        private string startDumper()
        {
            return dumper.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            initDumper();

            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            var result = startDumper();
            lbStatus.Text = result;

            result = dumper.WaitForFinish();
            lbStatus.Text = result;
            btnStart.Enabled = true;
            btnCancel.Enabled = false;

            this.Activate();
            this.Focus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FlushConfigFile();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += String.Format(" {0}.{1}", version.Major, version.Minor);
            openDialog = new OpenFileDialog();
            openDialog.RestoreDirectory = true;
            folderDialog = new FolderBrowserDialog();

            tbNTLEAPath.Text = Properties.Settings.Default.NTLEAPath;
        }

        private void FlushConfigFile()
        {
            string configFileName = System.Windows.Forms.Application.ExecutablePath + ".config";
            if (!File.Exists(configFileName))
            {
                StreamWriter bw = new StreamWriter(new FileStream(configFileName, FileMode.Create), System.Text.Encoding.UTF8);
                bw.Write(Properties.Resources.app_config);
                bw.Close();
            }
        }

        private void rbUseNone_CheckedChanged(object sender, EventArgs e)
        {
            tbCodePage.Enabled = !rbUseNone.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dumper != null)
            {
                var result = dumper.Cancel();
                lbStatus.Text = result;
                btnStart.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        private void btnBootFilename_Click(object sender, EventArgs e)
        {
            openDialog.FileName = tbBootFilename.Text;
            openDialog.Filter = "*.exe|*.exe|*.*|*.*";
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
            openDialog.Filter = "*.exe|*.exe|*.*|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                tbExcuteFilename.Text = FileUtils.GetFileName(openDialog.FileName);
            }
        }

        private void btnExtractFilename_Click(object sender, EventArgs e)
        {
            openDialog.FileName = tbBootFilename.Text;
            openDialog.Filter = "*.xp3|*.xp3|*.*|*.*";
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

        private void buttonNTLEA_Click(object sender, EventArgs e)
        {
            openDialog.FileName = tbNTLEAPath.Text;
            openDialog.Filter = "ntleac.exe|ntleac.exe";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                tbNTLEAPath.Text = openDialog.FileName;
            }
        }

        private void tbNTLEAPath_TextChanged(object sender, EventArgs e)
        {
            SettingUtils.Change("NTLEAPath", tbNTLEAPath.Text);
        }
    }
}