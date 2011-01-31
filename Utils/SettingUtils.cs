using System;
using System.Collections.Generic;
using System.Text;

namespace Clowwindy.XP3Dumper.Utils
{
    internal class SettingUtils
    {
        /// <summary>
        /// 改变某一设置的值并保存
        /// </summary>
        /// <param name="name">名</param>
        /// <param name="value">新值</param>
        internal static void Change(string name, string value)
        {
            string configFileName = System.Windows.Forms.Application.ExecutablePath + ".config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(configFileName);
            string configString = @"configuration/applicationSettings/Clowwindy.XP3Dumper.Properties.Settings/setting[@name='" + name + "']/value";
            System.Xml.XmlNode configNode = doc.SelectSingleNode(configString);
            if (configNode != null)
            {
                configNode.InnerText = value;
                doc.Save(configFileName);
                // 刷新应用程序设置
                Properties.Settings.Default.Reload();
            }
        }
    }
}