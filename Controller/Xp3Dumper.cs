using System;
using System.IO;
using Clowwindy.XP3Dumper.Resources;
using Clowwindy.XP3Dumper.Utils;

namespace Clowwindy.XP3Dumper.Controller
{
    internal class Xp3Dumper
    {
        private const string XP3HELPERS_PATH = @"xp3dumper\helpers\";
        private const string EXPORTER_FILENAME = @"!exporteraddr.tpm";
        private const string EXPORTER_FULL_FILENAME = XP3HELPERS_PATH + EXPORTER_FILENAME;

        private const string XP3DUMPER_PATH = @"xp3dumper\xp3dumper\";
        private const string DUMPER_FILENAME = @"~xp3dumper0.12d.tpm";
        private const string DUMPER_FULL_FILENAME = XP3DUMPER_PATH + DUMPER_FILENAME;

        private const string ARC_LIST_FILENAME = "arc_list.txt";
        private const string ADDRESS_FILENAME = "exporter_address.txt";
        private const string DLLLOADER_FULL_FILENAME = XP3HELPERS_PATH + "DllLoader.exe";

        private const string SORAAPP_FILENAME = @"\SoraApp\SoraApp.exe";
        private string NTLEA_PATH = @"D:\Program Files (x86)\NTLEA\ntleac.exe";

        private const string DUMPER_BUTTON_CLASS = "Button";
        private const string DUMPER_BUTTON_TITLE = "模式3启动";

        private const string DUMPER_GROUP_EDIT_ADDRESS_CLASS = "Button";
        private const string DUMPER_GROUP_EDIT_ADDRESS_TITLE = "特殊功能（模式3）";

        private const string DUMPER_EDIT_ADDRESS_CLASS = "EDIT";

        private const string DUMPER_WINDOW_TITLE = "xp3dumper 0.12d";
        private const string DUMPER_FINISHED_WINDOW_TITLE = "xp3dumper hint";

        private const int WAIT_SLEEP_INTERVAL = 40;

        private string address;

        private string bootFilename;

        private bool finished = true;

        internal enum UseStartLoader
        {
            None,
            SoraApp,
            NTLEA
        }

        internal Xp3Dumper()
        {
            useLoader = UseStartLoader.None;
            delay = 4;
            codePage = "0411";
        }

        internal string BootFilename
        {
            get { return bootFilename; }
            set { bootFilename = value; }
        }

        private string executeFilename;

        internal string ExecuteFilename
        {
            get { return executeFilename; }
            set { executeFilename = value; }
        }

        private string xp3Filename;

        internal string Xp3Filename
        {
            get { return xp3Filename; }
            set { xp3Filename = value; }
        }

        private string savePath;

        internal string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        internal string NTLEAPath
        {
            get { return NTLEA_PATH; }
            set { NTLEA_PATH = value; }
        }

        private string getGamePath()
        {
            return FileUtils.GetDirectoryName(bootFilename);
        }

        private UseStartLoader useLoader;

        internal UseStartLoader UseLoader
        {
            get { return useLoader; }
            set { useLoader = value; }
        }

        private int delay;

        internal int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        private string codePage;

        internal string CodePage
        {
            get { return codePage; }
            set { codePage = value; }
        }

        internal string Start()
        {
            try
            {
                finished = false;

                //获取导出地址
                killGame();
                delDumperPlugin();
                copyExportPlugin();
                delAddressFile();
                startGame();
                waitUtilTrue(FileUtils.ExistFile, FileUtils.CombinePath(getGamePath(), ADDRESS_FILENAME));
                killGame();
                delExportPlugin();
                this.address = getExportAddr().TrimEnd();

                //启动游戏并注入解包插件
                startGame();
                ProcessUtils.Sleep(delay * 1000);
                copyDumperPlugin();
                createArcList();
                runDllLoader();

                //填写解包信息，解包
                FileUtils.MakeDir(this.savePath);
                ProcessUtils.Sleep(1000);
                waitUtilTrue(setWindowTextThenClickButton, null);
                return Resource.Started;
            }
            catch (Exception e)
            {
                LogUtils.Log(e.ToString());
                return e.Message + " " + Resource.SeeLog;
            }
        }

        internal string WaitForFinish()
        {
            try
            {
                waitUtilTrue(dumpFinished, null);

                Finish();
            }
            catch (Exception e)
            {
                LogUtils.Log(e.ToString());
                return e.Message + " " + Resource.SeeLog;
            }
            return Resource.Finished;
        }

        internal string Finish()
        {
            try
            {
                killGame();
                delDumperPlugin();
                delExportPlugin();
                delAddressFile();
                finished = true;
                return Resource.Finished;
            }
            catch (Exception e)
            {
                LogUtils.Log(e.ToString());
                return e.Message + " " + Resource.SeeLog;
            }
        }

        internal string Cancel()
        {
            try
            {
                killGame();
                delDumperPlugin();
                delExportPlugin();
                delAddressFile();
                finished = true;
                return Resource.Canceled;
            }
            catch (Exception e)
            {
                LogUtils.Log(e.ToString());
                return e.Message + " " + Resource.SeeLog;
            }
        }

        protected void startGame()
        {
            try
            {
                if (useLoader == UseStartLoader.SoraApp)
                {
                    ProcessUtils.StartProcess(FileUtils.GetWinDir() + SORAAPP_FILENAME, codePage.Trim() + " " + this.bootFilename);
                }
                else if (useLoader == UseStartLoader.NTLEA)
                {
                    int iLCID = Convert.ToInt32(codePage.Trim(), 16);
                    ProcessUtils.StartProcess(NTLEA_PATH, String.Format("\"{0}\" C{1} L{2}", this.bootFilename, Win32APIUtils.GetLocaleCP(iLCID), iLCID));
                }
                else
                {
                    ProcessUtils.StartProcess(this.bootFilename, null);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException(Resource.LoaderNotFound, e);
            }

            waitUtilTrue(ProcessUtils.ExistsProcess, this.executeFilename);
        }

        protected int getGamePID()
        {
            return 0;
        }

        protected void killGame()
        {
            ProcessUtils.Kill(this.executeFilename);
            waitUtilFalse(ProcessUtils.ExistsProcess, this.executeFilename);
        }

        protected void copyExportPlugin()
        {
            FileUtils.Copy(EXPORTER_FULL_FILENAME, FileUtils.CombinePath(getGamePath(), EXPORTER_FILENAME));
        }

        protected void delExportPlugin()
        {
            FileUtils.Delete(FileUtils.CombinePath(getGamePath(), EXPORTER_FILENAME));
        }

        protected void delAddressFile()
        {
            FileUtils.Delete(FileUtils.CombinePath(getGamePath(), ADDRESS_FILENAME));
        }

        protected string getExportAddr()
        {
            return FileUtils.ReadTextFile(FileUtils.CombinePath(getGamePath(), ADDRESS_FILENAME));
        }

        protected void copyDumperPlugin()
        {
            FileUtils.Copy(DUMPER_FULL_FILENAME, FileUtils.CombinePath(getGamePath(), DUMPER_FILENAME));
        }

        protected void delDumperPlugin()
        {
            FileUtils.Delete(FileUtils.CombinePath(getGamePath(), DUMPER_FILENAME));
        }

        protected void runDllLoader()
        {
            int pid = ProcessUtils.GetProcess(this.executeFilename).Id;
            ProcessUtils.StartProcess(DLLLOADER_FULL_FILENAME, pid.ToString() + " " + DUMPER_FILENAME);
        }

        protected void createArcList()
        {
            FileUtils.WriteTextFile(FileUtils.CombinePath(getGamePath(), ARC_LIST_FILENAME), this.xp3Filename.Replace(",", "\r\n"));
        }

        protected bool setWindowTextThenClickButton(String notUsed)
        {
            IntPtr hwndWin;
            IntPtr hwndButton;
            IntPtr hwndEditPath;
            IntPtr hwndEditAddress;

            hwndWin = ProcessUtils.FindWindow(null, DUMPER_WINDOW_TITLE);
            if (hwndWin.ToInt32() == 0)
            {
                return false;
            }
            hwndEditPath = ProcessUtils.FindWindowEx(hwndWin, new IntPtr(0), DUMPER_EDIT_ADDRESS_CLASS, null);
            hwndEditAddress = ProcessUtils.FindWindowEx(hwndWin, hwndEditPath, DUMPER_EDIT_ADDRESS_CLASS, null);
            hwndButton = ProcessUtils.FindWindowEx(hwndWin, new IntPtr(0), DUMPER_BUTTON_CLASS, DUMPER_BUTTON_TITLE);

            ProcessUtils.SetText(hwndEditPath, this.savePath);
            ProcessUtils.SetText(hwndEditAddress, this.address);
            ProcessUtils.PostMessage(hwndButton, ProcessUtils.BM_CLICK);
            return true;
        }

        protected bool dumpFinished(string notUsed)
        {
            IntPtr hwndWin = ProcessUtils.FindWindow(null, DUMPER_FINISHED_WINDOW_TITLE);
            if (hwndWin.ToInt32() == 0)
            {
                return false;
            }
            return true;
        }

        protected delegate bool StringToBoolMethod(string argument);

        protected void waitUtilTrue(StringToBoolMethod condition, string argument)
        {
            while (!condition(argument) && !finished)
            {
                ProcessUtils.Sleep(WAIT_SLEEP_INTERVAL);
                ProcessUtils.DoEvents();
            }
        }

        protected void waitUtilFalse(StringToBoolMethod condition, string argument)
        {
            while (condition(argument) && !finished)
            {
                ProcessUtils.Sleep(WAIT_SLEEP_INTERVAL);
                ProcessUtils.DoEvents();
            }
        }
    }
}