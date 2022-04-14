using Microsoft.Win32;

namespace JX3BOX.JX3.Interact.ClientHelper
{
    public class RegisteryReader
    {
        /// <summary>
        /// 从注册表HKLM中读取指定的注册表键的值
        /// </summary>
        /// <param name="path">注册表键的路径</param>
        /// <param name="name">注册表键的名字</param>
        /// <param name="defaultVaule">默认值，在无法获得时返回</param>
        /// <returns>注册表键的值，失败返回defaultValue</returns>
        public static object GetLocalMachineRegistData(string path, string name, object defaultVaule)
        {
            RegistryKey subKey = Registry.LocalMachine.OpenSubKey(path);
            if (subKey is null)
                return defaultVaule;
            return subKey.GetValue(name, defaultVaule);
        }

        /// <summary>
        /// 判断注册表HKLM中是否存在指定的注册表键
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRegistExist(string path, string name)
        {
            RegistryKey rootKey = Registry.LocalMachine;
            RegistryKey subKey = rootKey.OpenSubKey(path, true);
            string[] subkeyNames = subKey.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
                if (keyName == name)
                    return true;
            return false;
        }
    }
}
