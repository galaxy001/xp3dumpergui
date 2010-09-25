using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Clowwindy.XP3Dumper.Utils
{
    internal static class LogUtils
    {
        private const string LOG_FILENAME = @"xp3dumper_gui.log";

        internal static void Log(string content)
        {
            using (var f = File.Open(LOG_FILENAME, FileMode.Append, FileAccess.Write))
            {
                FileUtils.WriteText(f, DateTime.Now.ToString() + "\r\n");
                FileUtils.WriteText(f, content + "\r\n\r\n");
            }
        }
    }
}
