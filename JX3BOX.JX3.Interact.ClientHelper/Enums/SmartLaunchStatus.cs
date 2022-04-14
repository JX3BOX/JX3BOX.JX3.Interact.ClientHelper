namespace JX3BOX.JX3.Interact.ClientHelper.Enums
{
    public enum SmartLaunchStatus
    {
        /// <summary>
        /// 版本最新，启动客户端
        /// </summary>
        OK,
        /// <summary>
        /// 存在更新版本，启动XLauncher
        /// </summary>
        RemoteHigher,
        /// <summary>
        /// 本地版本高于远程，启动客户端（一般是出错或远程回滚版本）
        /// </summary>
        LocalHigher,
    }
}
