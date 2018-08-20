using System.IO;
using System.Threading;

namespace RC.Software.DevTools
{
    public class FormTemplateService
    {
        public static string TemplateDir = Thread.GetDomain().BaseDirectory + "Templates";

        public static void InitTemplateDir()
        {
            if (!Directory.Exists(TemplateDir)) Directory.CreateDirectory(TemplateDir);
        }

        public static string[] GetCaties()
        {
            InitTemplateDir();
            return Directory.GetDirectories(TemplateDir);
        }

        public static string[] GetFiles(string dirPath)
        {
            return Directory.GetFiles(dirPath);
        }
    }
}