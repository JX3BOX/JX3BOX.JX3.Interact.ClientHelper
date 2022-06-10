using JX3BOX.JX3.Interact.ClientHelper.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JX3BOX.JX3.Interact.ClientHelper.Models
{
    public class ClientInfo
    {
        /// <summary>
        /// 不同客户端分支与其显示名称的对应
        /// </summary>
        public static Dictionary<ClientType, string> VersionName = new Dictionary<ClientType, string>()
        {
            { ClientType.zhcn_hd, "重制版正式服" },
            { ClientType.zhcn_exp, "重制版测试服" },
            { ClientType.zhcn_tw, "重制版国际服" },
            { ClientType.classic_yq, "缘起正式服" },
            { ClientType.classic_exp, "缘起测试服" }
        };

        /// <summary>
        /// 客户端分支版本
        /// </summary>
        public ClientType Type { get; set; }

        /// <summary>
        /// 注册表的客户端安装路径
        /// </summary>
        public string InstallPath { get; set; }

        /// <summary>
        /// 可执行文件如 JX3ClientX64.exe 的路径
        /// </summary>
        public string BinaryPath { get; set; }

        /// <summary>
        /// 客户端显示名称
        /// </summary>
        public string Name { get => GetName(); }

        /// <summary>
        /// 客户端工作目录
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// 客户端用户数据目录
        /// </summary>
        public string UserdataPath { get; set; }

        /// <summary>
        /// 获得客户端显示名称
        /// </summary>
        /// <returns>与分支版本对应的显示名称</returns>
        public string GetName() => VersionName[Type];

        /// <summary>
        /// 客户端版本号
        /// </summary>
        public Version Version { get; set; }
    }
}
