using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Clowwindy.XP3Dumper.Utils
{
    internal static class Win32APIUtils
    {
        static Dictionary<string, int> dictNameToCodePage = new Dictionary<string, int>()
        {
            {"擔杮岅",932},//Japanese
            {"いゅ(羉砰)",950},//Trad. Chs.
            {"English",1252},//English
            {"中文(简体)",936},//Simp. Chs.
        };

        /// <summary>
        /// GetLocaleInfo API
        /// </summary>
        /// <param name="d">LCID</param>
        /// <param name="s">LCTYPE</param>
        /// <param name="k">CodePageString</param>
        /// <param name="dd">SizeOf(CodePageString)</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int GetLocaleInfo(int d, int s, StringBuilder k, int dd);

        /// <summary>
        /// Get Codepage id form LCID
        /// </summary>
        /// <param name="lcid">LCID</param>
        /// <returns>Codepage</returns>
        internal static int GetLocaleCP(int lcid)
        {
            StringBuilder S = new StringBuilder(255);
            int LCTYPE = 4;

            int d = GetLocaleInfo(lcid, LCTYPE, S, 255);

            int ret = 932;
            try
            {
                ret = dictNameToCodePage[S.ToString()];
            }
            catch (Exception) { }

            return ret;
        }
    }
}