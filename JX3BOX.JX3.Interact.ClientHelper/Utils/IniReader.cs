using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace JX3BOX.JX3.Interact.ClientHelper.Utils
{
    public static class IniReader
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 获取 ini 中数据
        /// </summary>
        /// <param name="section">段落名</param>
        /// <param name="key">键名</param>
        /// <param name="def">没有找到时返回的默认值</param>
        /// <param name="filename">ini 文件路径</param>
        /// <returns>若获取到则返回获取到的值，否则返回默认值</returns>
        public static string GetString(string section, string key, string def, string filename, int size = 127)
        {
            StringBuilder sb = new StringBuilder(size);
            GetPrivateProfileString(section, key, def, sb, sb.Capacity, Path.GetFullPath(filename));
            return sb.ToString();
        }
    }
}
