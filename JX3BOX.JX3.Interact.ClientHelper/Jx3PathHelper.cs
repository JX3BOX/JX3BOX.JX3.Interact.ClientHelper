using JX3BOX.JX3.Interact.ClientHelper.Enums;
using JX3BOX.JX3.Interact.ClientHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace JX3BOX.JX3.Interact.ClientHelper
{
    /// <summary>
    /// 用于处理剑三客户端路径的工具类
    /// </summary>
    public class JX3PathHelper
    {
        /// <summary>
        /// 不同客户端分支的注册表子路径
        /// </summary>
        public static readonly Dictionary<ClientType, InstallInfo> InstallInfos = new Dictionary<ClientType, InstallInfo>()
        {
            { ClientType.zhcn_hd, new InstallInfo("JX3", "zhcn_hd")},
            { ClientType.zhcn_exp, new InstallInfo("JX3_EXP", "zhcn_exp")},
            { ClientType.zhcn_tw, new InstallInfo("zhcn_tw","zhcn_tw"){ RegParent = @"SOFTWARE\WOW6432Node\kingsoft\JX3"}},
            { ClientType.classic_yq, new InstallInfo("JX3_CLASSIC", "classic_yq")},
            { ClientType.classic_exp, new InstallInfo("JX3_CLASSIC_EXP", "classic_exp")},
        };

        /// <summary>
        /// 获取注册表内安装路径
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        /// <returns>安装路径</returns>
        /// <exception cref="DirectoryNotFoundException">路径无法找到或无效</exception>
        public static string GetInstallPath(ClientType type)
        {
            string path = RegisteryReader.GetLocalMachineRegistData(
                $@"{InstallInfos[type].RegParent}\{InstallInfos[type].RegName}",
                "InstallPath", "").ToString();
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException("无法找到对应客户端，请检查客户端安装");
            }
            return path;
        }

        /// <summary>
        /// 获取注册表内记录的客户端版本
        /// 其值将在启动器更新完游戏提示“客户端已是最新版本，无需更新”时刷新
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        /// <returns>客户端版本</returns>
        /// <exception cref="FormatException">版本格式无效</exception>
        public static Version GetClientVersion(ClientType type)
        {
            string verStr = RegisteryReader.GetLocalMachineRegistData(
                $@"{InstallInfos[type].RegParent}\{InstallInfos[type].RegName}",
                "Version", "").ToString();
            if (!Version.TryParse(verStr, out Version version))
            {
                throw new FormatException("无法从注册表读取对应游戏版本");
            }
            return version;
        }

        /// <summary>
        /// 从分支信息获取可执行文件路径
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        /// <returns>可执行路径</returns>
        /// <exception cref="FileNotFoundException">可执行文件无法找到或无效</exception>
        public static string GetBinaryPath(ClientType type)
        {
            InstallInfo info = InstallInfos[type];
            string binaryPath = Path.Combine(GetInstallPath(type), info.InstallParent, info.InstallName, info.BinaryFolderPath, info.BinaryName);
            if (!File.Exists(binaryPath))
            {
                throw new FileNotFoundException("无法找到客户端可执行，请检查客户端安装");
            }
            return binaryPath;
        }
        /// <summary>
        /// 从分支信息获取用户数据目录
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        /// <returns>用户数据目录</returns>
        /// <exception cref="DirectoryNotFoundException">用户数据目录无法找到或无效</exception>
        public static string GetUserdataPath(ClientType type)
        {
            InstallInfo info = InstallInfos[type];
            string userdataPath = Path.Combine(GetInstallPath(type), info.InstallParent, info.InstallName, info.UserdataFolderPath);
            if (!Directory.Exists(userdataPath))
            {
                throw new DirectoryNotFoundException("无法找到用户数据目录，请检查客户端安装");
            }
            return userdataPath;
        }

        /// <summary>
        /// 从分支获取期望工作路径
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        /// <returns>工作路径</returns>
        /// <exception cref="DirectoryNotFoundException">工作路径无法找到或无效</exception>
        public static string GetWorkingDirectory(ClientType type)
        {
            InstallInfo info = InstallInfos[type];
            string workdir = Path.Combine(GetInstallPath(type), info.InstallParent, info.InstallName);
            if (!Directory.Exists(workdir))
            {
                throw new DirectoryNotFoundException("无法找到工作目录，请检查客户端安装");
            }
            return workdir;
        }

        /// <summary>
        /// 从分支获取游戏启动器可执行路径
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        /// <returns>XLauncher路径</returns>
        /// <exception cref="FileNotFoundException">工作路径无法找到或无效</exception>
        public static string GetXLauncherPath(ClientType type)
        {
            string path = Directory.GetParent(GetInstallPath(type)).Parent.Parent.FullName;
            path = Path.Combine(path, "XLauncher.exe");
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("无法找到启动器目录，请检查客户端安装与分支版本");
            }
            return path;
        }
    }
}
