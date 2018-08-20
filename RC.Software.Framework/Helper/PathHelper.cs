using System.IO;
using System.Linq;
using System.Threading;

namespace RC.Software.Framework.Helper
{
    /// <summary>
    /// 路径辅助类
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// 应用程序根目录
        /// </summary>
        public static string AppPath
        {
            get { return Thread.GetDomain().BaseDirectory; }
        }

        /// <summary>
        /// 根据目录名称创建目录，并返回路径
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string InitDirectory(string name)
        {
            name = GetSafeFileName(name);
            string path = Path.Combine(AppPath, name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        /// <summary>
        /// Windows文件命名规则：不能以空格为开头和结束,不能用//:*?"<>|作为文件名称,文件名称为1-255位
        /// </summary>
        /// <param name="name">路径名称</param>
        /// <returns>安全路径名称</returns>
        public static string GetSafeFileName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            name = new[] {"//", ":", "*", "?", "<", ",", ">", "|", "'", "\""}.Aggregate(name,
                                                                                        (current, badChar) =>
                                                                                        current.Replace(badChar, ""));
            name = name.Length > 255 ? name.Substring(0, 250) : name;
            return name.Trim();
        }

        /// <summary>
        /// 合并拼接路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string Combine(this string path, string append)
        {
            return Path.Combine(path, append);
        }
    }
}