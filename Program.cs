using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clowwindy.XP3Dumper.GUI;

namespace xp3dumper_gui
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメインエントリポイント。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
