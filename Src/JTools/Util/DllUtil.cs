using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TierneyJohn.MiChangSheng.JTools.Util
{
    /// <summary>
    /// Dll 加载工具类
    /// </summary>
    public static class DllUtil
    {
        /// <summary>
        /// 手动加载外部 DLL 方法
        /// </summary>
        /// <param name="fileName">DLL 文件名称</param>
        /// <param name="path">DLL 文件存放路径</param>
        public static void LoadDllFile(this string fileName, string path)
        {
            var builder = new StringBuilder(255);
            GetDllDirectory(builder.Length, builder);
            SetDllDirectory(path);
            LoadLibrary(fileName);
            SetDllDirectory(builder.ToString());
        }

        /// <summary>
        /// 委托 kernel32 获取 DLL 加载路径
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetDllDirectory(int bufferSize, StringBuilder builder);

        /// <summary>
        /// 委托 kernel32 设置 DLL 加载路径
        /// </summary>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string dir);

        /// <summary>
        /// 委托 kernel32 加载 DLL 文件
        /// </summary>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string fileName);
    }
}