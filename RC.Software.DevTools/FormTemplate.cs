using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using RC.Software.Framework.Helper;

namespace RC.Software.DevTools
{
    public partial class FormTemplate : Form
    {
        private readonly string Tips = "请选择模板分类";

        public FormTemplate()
        {
            InitializeComponent();
        }

        private void FormTemplate_Load(object sender, EventArgs e)
        {
            //绘图标
            listFiles.DrawMode = DrawMode.OwnerDrawFixed;
            listFiles.ItemHeight = 20;

            InitCate(); 
            var config = ConfigHelper.GetConfig<AppConfig>();
             
            if (cmbCate.Items.Contains(config.LastCate ?? ""))
            {
                cmbCate.SelectedItem = config.LastCate;
            }
        }
        public static void Highlight(string path, TextEditorControl textEditor)
        {
            string extension = Path.GetExtension(path);
            if (extension != null)
            {
                switch (extension.ToLower())
                {
                    case ".cs":
                        textEditor.Document.HighlightingStrategy =
                            HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
                        break;
                    case ".xml":
                    case ".configstring":
                    case ".config":
                        textEditor.Document.HighlightingStrategy =
                            HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
                        break;
                    case ".aspx":
                    case ".html":
                    case ".htm":
                    case ".css":
                        textEditor.Document.HighlightingStrategy =
                            HighlightingStrategyFactory.CreateHighlightingStrategy("HTML");
                        break;
                }
            }
        }

        private void InitCate()
        {
            cmbCate.Items.Clear();
            cmbCate.Items.Add(Tips);
            var dirs = FormTemplateService.GetCaties();
            foreach (var dir in dirs) cmbCate.Items.Add(new DirectoryInfo(dir).Name);

            cmbCate.SelectedIndex = 0;
        }

        private void lblRefulsh_Click(object sender, EventArgs e)
        {
            InitCate();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process.Start(FormTemplateService.TemplateDir);
        }

        private void cmbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCate.SelectedItem != null && cmbCate.SelectedItem.ToString() != Tips)
            {  
                //保存最后使用项
                var config = ConfigHelper.GetConfig<AppConfig>();
                config.LastCate = cmbCate.SelectedItem.ToString();
                ConfigHelper.UpdateConfig(config);

                listFiles.Items.Clear();
                var files = FormTemplateService.GetFiles(Path.Combine(FormTemplateService.TemplateDir,
                    cmbCate.SelectedItem.ToString()));
                foreach (var file in files) listFiles.Items.Add(new FileInfo(file).Name);
            }
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCate.SelectedItem != null && cmbCate.SelectedItem.ToString() != Tips && listFiles.SelectedItem != null)
            {
                var dir = Path.Combine(FormTemplateService.TemplateDir,
                    cmbCate.SelectedItem.ToString());
                var file = Path.Combine(dir, listFiles.SelectedItem.ToString());
                var txt = FileHelper.ReadFile(file);
                txtEditer.Text = txt;
                Highlight(file, txtEditer);
                txtEditer.Refresh();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCate.SelectedItem != null && listFiles.SelectedItem != null)
                {
                    var dir = Path.Combine(FormTemplateService.TemplateDir, cmbCate.SelectedItem.ToString());
                    var file = Path.Combine(dir, listFiles.SelectedItem.ToString());
                    FileHelper.WriteFile(file, txtEditer.Text, Encoding.Default);
                    MessageBox.Show("文件保存成功！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message,"提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void listFiles_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (e.Index > -1)
            {
                Color color = Color.FromArgb(150, 200, 250); //选择项目颜色
                Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? new SolidBrush(color)
                    : new SolidBrush(Color.White);
                e.Graphics.FillRectangle(brush, e.Bounds);
                e.DrawFocusRectangle(); //焦点框 

                //绘制图标   
                Image image = imageList.Images[0];
                Graphics g = e.Graphics;
                Rectangle bounds = e.Bounds;
                Rectangle imageRect = new Rectangle(
                    bounds.X + 2,
                    bounds.Y + 2,
                    image.Height,
                    image.Height);
                Rectangle textRect = new Rectangle(
                    imageRect.Right,
                    bounds.Y,
                    bounds.Width - imageRect.Right,
                    bounds.Height);
                g.DrawImage(
                    image,
                    imageRect,
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel);
                //文本 
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(listFiles.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), textRect,
                    format);
            }
        }
    }
}