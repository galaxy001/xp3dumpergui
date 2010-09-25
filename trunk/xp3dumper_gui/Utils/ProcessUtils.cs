using System.Diagnostics;
using System.IO;
using System.Threading;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Clowwindy.XP3Dumper.Utils
{
    internal static class ProcessUtils
    {

        internal static readonly int BM_CLICK = 0x00F5;
        internal static readonly int WM_SETTEXT = 0x000C;
        internal static readonly int WM_GETTEXT = 0x000D;

        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern bool SetWindowText(IntPtr hwnd, string lpString);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessageAsText(IntPtr hWnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);


        internal static IntPtr PostMessage(IntPtr targetHWnd, int msg)
        {
            Message message = Message.Create(targetHWnd, msg, new IntPtr(0), new IntPtr(0));
            return PostMessage(message.HWnd, message.Msg, message.WParam, message.LParam);
        }

        internal static int SetText(IntPtr hwnd, string text)
        {
            return SendMessageAsText(hwnd, WM_SETTEXT, 0, text);
        }

        internal static Process StartProcess(string filename, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(filename, arguments);
            var fi = new FileInfo(filename);
            startInfo.WorkingDirectory = fi.DirectoryName;
            startInfo.FileName = fi.FullName;
            return Process.Start(startInfo);
        }

        internal static bool ExistsProcess(string imageName)
        {
            return Process.GetProcessesByName(imageName.Split('.')[0]).Length > 0;
        }

        internal static Process GetProcess(string imageName)
        {
            var ps = Process.GetProcessesByName(imageName.Split('.')[0]);
            if (ps.Length > 0)
            {
                return ps[0];
            }
            return null;
        }

        internal static void Kill(string imageName)
        {
            var ps = Process.GetProcessesByName(imageName.Split('.')[0]);
            foreach (var p in ps)
            {
                p.Kill();
            }
        }

        internal static void Sleep(int interval)
        {
            Thread.Sleep(interval);
        }
    }
}
