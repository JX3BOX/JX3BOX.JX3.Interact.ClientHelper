namespace JX3BOX.JX3.Interact.ClientHelper.Models
{
    public class InstallInfo
    {
        /// <summary>
        /// 注册表头部路径
        /// </summary>
        public string RegParent { get; set; } = @"SOFTWARE\Kingsoft";
        /// <summary>
        /// 注册表子路径
        /// </summary>
        public string RegName { get; set; }
        /// <summary>
        /// 在安装路径后的路径名
        /// </summary>
        public string InstallParent { get; set; } = @"bin";
        /// <summary>
        /// 版本分支名
        /// </summary>
        public string InstallName { get; set; }
        /// <summary>
        /// 可执行文件夹名
        /// </summary>
        public string BinaryFolderPath { get; set; } = "bin64";
        /// <summary>
        /// 可执行文件名
        /// </summary>
        public string BinaryName { get; set; } = "JX3ClientX64.exe";
        /// <summary>
        /// 运行参数
        /// </summary>
        public string BinaryLaunchParam { get; set; } = "DOTNOTSTARTGAMEBYJX3CLIENT.EXE";
        /// <summary>
        /// 用户数据的文件夹名
        /// </summary>
        public string UserdataFolderPath { get; set; } = "userdata";
        /// <summary>
        /// 插件数据的文件夹名
        /// </summary>
        public string InterfaceFolderPath { get; set; } = "interface";

        /// <summary>
        /// 实例化客户端安装信息
        /// </summary>
        /// <param name="RegName">注册表子路径</param>
        /// <param name="InstallName">客户端分支名</param>
        public InstallInfo(string RegName, string InstallName)
        {
            this.RegName = RegName;
            this.InstallName = InstallName;
        }

    }
}
