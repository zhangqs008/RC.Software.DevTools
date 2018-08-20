using System;
using System.IO;
using System.Text;

namespace RC.Software.Framework.Helper
{
    public class FileHelper
    {
        /// <summary>
        ///     读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath)
        {
            return ReadFile(filePath, Encoding.Default);
        }

        /// <summary>
        ///     读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath, Encoding encoding)
        {
            using (var sr = new StreamReader(filePath, encoding))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        ///     取得文件编码方式
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private Encoding GetEncode(byte[] buffer)
        {
            if (buffer.Length <= 0 || buffer[0] < 239)
                return Encoding.Default;
            if (buffer[0] == 239 && buffer[1] == 187 && buffer[2] == 191)
                return Encoding.UTF8;
            if (buffer[0] == 254 && buffer[1] == byte.MaxValue)
                return Encoding.BigEndianUnicode;
            if (buffer[0] == byte.MaxValue && buffer[1] == 254)
                return Encoding.Unicode;
            return Encoding.Default;
        }

        /// <summary>
        ///     按指定编码方式读取文本
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private string GetTxt(byte[] buffer, Encoding encoding)
        {
            if (Equals(encoding, Encoding.UTF8))
                return encoding.GetString(buffer, 3, buffer.Length - 3);
            if (Equals(encoding, Encoding.BigEndianUnicode) || Equals(encoding, Encoding.Unicode))
                return encoding.GetString(buffer, 2, buffer.Length - 2);
            return encoding.GetString(buffer);
        }

        /// <summary>
        ///     读取文本（自适应编码方式）
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private string GetTxt(byte[] buffer)
        {
            return GetTxt(buffer, GetEncode(buffer));
        }

        /// <summary>
        ///     写入文本
        /// </summary>
        /// <param name="filepath">写入文件</param>
        /// <param name="body">写入内容</param>
        /// <param name="encoding">编码方式</param>
        public static void WriteFile(string filepath, string body, Encoding encoding)
        {
            if (File.Exists(filepath))
                File.Delete(filepath);
            var bytes = encoding.GetBytes(body);
            var fileStream = File.Open(filepath, FileMode.CreateNew, FileAccess.Write);
            if (Equals(encoding, Encoding.UTF8))
            {
                fileStream.WriteByte(239);
                fileStream.WriteByte(187);
                fileStream.WriteByte(191);
            }
            else if (Equals(encoding, Encoding.BigEndianUnicode))
            {
                fileStream.WriteByte(254);
                fileStream.WriteByte(byte.MaxValue);
            }
            else if (Equals(encoding, Encoding.Unicode))
            {
                fileStream.WriteByte(byte.MaxValue);
                fileStream.WriteByte(254);
            }

            fileStream.Write(bytes, 0, bytes.Length);
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
        }

        public static void DeleteFolder(string directoryPath)
        {
            try
            {
                foreach (string d in Directory.GetFileSystemEntries(directoryPath))
                {
                    if (File.Exists(d))
                    {
                        var fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly", StringComparison.Ordinal) != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d); //删除文件   
                    }
                    else
                        DeleteFolder(d); //删除文件夹
                }
                Directory.Delete(directoryPath); //删除空文件夹
            }
            catch (Exception ex)
            {
            }
        }

        public static void CopyDirectory(String sourcePath, String destinationPath)
        {
            var info = new DirectoryInfo(sourcePath);
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
            {
                String destName = Path.Combine(destinationPath, fsi.Name);

                if (fsi is FileInfo) //如果是文件，复制文件
                    File.Copy(fsi.FullName, destName, true);
                else //如果是文件夹，新建文件夹，递归
                {
                    Directory.CreateDirectory(destName);
                    CopyDirectory(fsi.FullName, destName);
                }
            }
        }
    }
}