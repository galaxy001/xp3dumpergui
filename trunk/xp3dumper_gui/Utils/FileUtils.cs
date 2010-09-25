using System.IO;
using System.Text;

namespace Clowwindy.XP3Dumper.Utils
{
    internal static class FileUtils
    {
        internal static bool ExistFile(string filename)
        {
            return File.Exists(filename);
        }

        internal static void MakeDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        internal static void Copy(string sourceFilename, string destFilename)
        {
            File.Copy(sourceFilename, destFilename, true);
        }

        internal static void Delete(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        internal static string GetDirectoryName(string filename)
        {
            return new FileInfo(filename).DirectoryName;
        }

        internal static string GetFileName(string filename)
        {
            return new FileInfo(filename).Name;
        }

        internal static string CombinePath(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        internal static string ReadTextFile(string filename)
        {
            using (var f = File.OpenText(filename))
            {
                return f.ReadToEnd();
            }
        }

        internal static void WriteTextFile(string filename, string content)
        {
            File.WriteAllText(filename, content, Encoding.Default);
        }

        internal static string GetWinDir()
        {
            return System.Environment.ExpandEnvironmentVariables("%WinDir%");
        }

        internal static void WriteText(FileStream f, string content)
        {
            var l = Encoding.UTF8.GetBytes(content);
            f.Write(l, 0, l.Length);
        }
    }
}
