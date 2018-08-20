using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FSLib.App.SimpleUpdater;

namespace RC.Software.DevTools
{
    internal static class Program
    {
        private static Mutex _singleton; 

        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AutoUpdata();
            var has = Check();
            if (has)
            {
                var form = new MainForm();
                form.FormClosed += form_FormClosed;
                Application.Run(form);
            }
            else
            {
                MessageBox.Show("程序已在运行，请勿再运行！", "代码生成工具提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_singleton != null) _singleton.Close();
        }

        private static bool Check()
        {
            var has = false;
            _singleton = new Mutex(false, Assembly.GetExecutingAssembly().FullName, out has);
            return has;
        }

        #region 实现自动更新程序

        private static void AutoUpdata()
        {
            var updater = Updater.Instance;
            //开始检查更新-这是最简单的模式.请现在 assemblyInfo.cs 中配置更新地址,参见对应的文件.
            //--添加这行标记表示支持自动更新, 后面的网址为自动更新的根目录.
            //[assembly: FSLib.App.SimpleUpdater.Updateable("http://update.easypm.org/update.xml")]
            updater.BeginCheckUpdateInProcess();
            //当检查发生错误时,这个事件会触发
            updater.Error += UpdaterError;
            //没有找到更新的事件
            updater.NoUpdatesFound += UpdaterNoUpdatesFound;
            //找到更新的事件.但在此实例中,找到更新会自动进行处理,所以这里并不需要操作
            //updater.UpdatesFound += new EventHandler(updater_UpdatesFound);
            updater.UpdatesFound += (sender, e) => updater.StartExternalUpdater();
        }

        private static void UpdaterNoUpdatesFound(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("没有找到更新");
        }

        private static void UpdaterError(object sender, EventArgs e)
        {
            var updater = sender as Updater;
        }

        #endregion
    }
}