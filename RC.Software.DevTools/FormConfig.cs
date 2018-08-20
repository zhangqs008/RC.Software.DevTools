using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using RC.Software.Framework.Helper;

namespace RC.Software.DevTools
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigHelper.GetConfig<AppConfig>();
                config.Author = txtAuthor.Text;
                config.NameSpace = txtNamespace.Text;
                config.ExceptFields = txtExceptFields.Text;
                ConfigHelper.UpdateConfig(config);
                MessageBox.Show("保存成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message,"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            var config = ConfigHelper.GetConfig<AppConfig>();
            txtAuthor.Text = config.Author;
            txtNamespace.Text = config.NameSpace;
            config.ExceptFields = txtExceptFields.Text = config.ExceptFields;

            string fileName = Path.Combine(Thread.GetDomain().BaseDirectory, @"InsideStaticLabel.cs");
            if (File.Exists(fileName))
            {
                txtEditer.Text = FileHelper.ReadFile(fileName);
                txtEditer.Document.HighlightingStrategy =HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            }
        }
    }
}
