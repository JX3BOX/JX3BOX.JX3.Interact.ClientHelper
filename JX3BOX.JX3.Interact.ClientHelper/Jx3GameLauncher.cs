using JX3BOX.JX3.Interact.ClientHelper.Enums;
using JX3BOX.JX3.Interact.Model;
using System;
using System.Diagnostics;
using System.IO;

namespace JX3BOX.JX3.Interact.ClientHelper
{
    public class JX3GameLauncher
    {
        /// <summary>
        /// 启动游戏客户端
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        public static void Launch(ClientType type) =>
            Launch(JX3PathHelper.GetBinaryPath(type), JX3PathHelper.GetWorkingDirectory(type), JX3PathHelper.InstallInfos[type].BinaryLaunchParam);

        /// <summary>
        /// 启动游戏客户端
        /// </summary>
        /// <param name="binaryPath">可执行文件路径</param>
        /// <param name="argument">启动参数</param>
        /// <exception cref="FileNotFoundException"></exception>
        public static void Launch(string binaryPath, string workDir, string argument = "DOTNOTSTARTGAMEBYJX3CLIENT.EXE")
        {
            if (!File.Exists(binaryPath))
                throw new FileNotFoundException("启动客户端失败，找不到可执行文件");
            // start the process at binaryPath
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                WorkingDirectory = workDir,
                Arguments = argument,
                FileName = binaryPath,
            };
            Process.Start(processStartInfo);
        }

        /// <summary>
        /// 启动游戏启动器
        /// </summary>
        /// <param name="type">游戏版本分支</param>
        public static void LaunchXLauncher(ClientType type) =>
            LaunchXLauncher(JX3PathHelper.GetXLauncherPath(type));

        /// <summary>
        /// 启动游戏启动器
        /// </summary>
        /// <param name="launcherPath">启动器路径</param>
        /// <param name="workDir">启动器工作目录</param>
        /// <param name="argument">启动器的启动参数</param>
        /// <exception cref="FileNotFoundException">无法找到XLauncher可执行文件</exception>
        public static void LaunchXLauncher(string launcherPath, string workDir = null, string argument = "")
        {
            workDir = workDir ?? launcherPath;
            if (!File.Exists(launcherPath))
                throw new FileNotFoundException("打开启动器失败，找不到可执行文件");
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                WorkingDirectory = workDir,
                Arguments = argument,
                FileName = launcherPath,
            };
            Process.Start(processStartInfo);
        }

        /// <summary>
        /// 根据传入的远程版本判断客户端版本是否为最新决定启动客户端还是 XLauncher
        /// </summary>
        /// <param name="type">客户端分支</param>
        /// <param name="remoteVersion">远程版本，一般为官方最新版本</param>
        /// <returns>启动的结果</returns>
        public static SmartLaunchResult SmartLaunch(ClientType type, Version remoteVersion)
        {
            Version gameVersion = JX3PathHelper.GetClientVersion(type);
            SmartLaunchResult result = new SmartLaunchResult();
            result.GameVersion = gameVersion;
            result.RemoteVersion = remoteVersion;
            if (gameVersion == remoteVersion)
            {
                Launch(type);
                result.Status = SmartLaunchStatus.OK;
            }
            else if (gameVersion > remoteVersion)
            {
                Launch(type);
                result.Status = SmartLaunchStatus.LocalHigher;
            }
            else
            {
                LaunchXLauncher(type);
                result.Status = SmartLaunchStatus.RemoteHigher;
            }
            return result;
        }
    }
}
