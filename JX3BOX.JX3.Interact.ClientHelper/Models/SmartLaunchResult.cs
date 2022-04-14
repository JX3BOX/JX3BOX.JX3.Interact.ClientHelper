using JX3BOX.JX3.Interact.ClientHelper.Enums;
using System;

namespace JX3BOX.JX3.Interact.Model
{
    public class SmartLaunchResult
    {
        /// <summary>
        /// 启动状态
        /// </summary>
        public SmartLaunchStatus Status { get; set; }
        /// <summary>
        /// 本地游戏版本
        /// </summary>
        public Version GameVersion { get; set; }
        /// <summary>
        /// 远程游戏版本
        /// </summary>
        public Version RemoteVersion { get; set; }
    }
}