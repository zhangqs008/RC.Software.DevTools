using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using RC.Software.Framework.DbService;
using RC.Software.Framework.Helper;

namespace RC.Software.DevTools
{
    public partial class FormCode : Form
    {
        private readonly string TipsCate = "请选择模板分类";
        private readonly string TipsDB = "请选择数据库";
        private readonly string TipsDbTable = "请选择数据表";
        private readonly string TipsFile = "请选择代码模板";
        private const String DefaultTxt = "Please enter your words.";
        public FormCode()
        {
            InitializeComponent();
        }

        private void FormCode_Load(object sender, EventArgs e)
        {
            txtKeyword.Text = DefaultTxt;
            txtKeyword.ForeColor = Color.Gray;

            InitDb();
            InitCate();
            listBox.Items.Add(TipsDbTable);
            listBox.SelectedIndex = 0;
            //绘图标
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.ItemHeight = 20;

            cmbFile.Items.Add(TipsFile);
            cmbFile.SelectedIndex = 0;

            var config = ConfigHelper.GetConfig<AppConfig>();

            if (cmbDatabase.Items.Contains(config.LastDb ?? ""))
            {
                cmbDatabase.SelectedItem = config.LastDb;
            }
            if (listBox.Items.Contains(config.LastTable ?? ""))
            {
                listBox.SelectedItem = config.LastTable;
            }
            if (cmbCate.Items.Contains(config.LastCate ?? ""))
            {
                cmbCate.SelectedItem = config.LastCate;
            }
            if (cmbFile.Items.Contains(config.LaseFile ?? ""))
            {
                cmbFile.SelectedItem = config.LaseFile;
            }
        }

        private void InitCate()
        {
            cmbCate.Items.Clear();
            cmbCate.Items.Add(TipsCate);
            var dirs = FormTemplateService.GetCaties();
            foreach (var dir in dirs) cmbCate.Items.Add(new DirectoryInfo(dir).Name);
            cmbCate.SelectedIndex = 0;
        }

        private void InitDb()
        {
            var config = ConfigHelper.GetConfig<FormDbService.DbConfig>();

            cmbDatabase.Items.Clear();
            cmbDatabase.Items.Add(TipsDB);
            foreach (var info in config.Dbs)
                cmbDatabase.Items.Add(info.Id + " " + info.Server + "-" + info.Database);
            cmbDatabase.SelectedIndex = 0;
        }

        private void cmbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCate.SelectedItem != null && cmbCate.SelectedItem.ToString() != TipsCate)
            {
                //保存最后使用项
                var config = ConfigHelper.GetConfig<AppConfig>();
                config.LastCate = cmbCate.SelectedItem.ToString();
                ConfigHelper.UpdateConfig(config);

                //联动加载模板
                cmbFile.Items.Clear();
                cmbFile.Items.Add(TipsFile);
                var files = FormTemplateService.GetFiles(Path.Combine(FormTemplateService.TemplateDir,
                    cmbCate.SelectedItem.ToString()));
                foreach (var file in files) cmbFile.Items.Add(new FileInfo(file).Name);
                cmbFile.SelectedIndex = cmbFile.Items.Count > 1 ? 1 : 0;
            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedItem != null && cmbDatabase.SelectedItem.ToString() != TipsDB)
            {
                //保存最后使用项
                var config = ConfigHelper.GetConfig<AppConfig>();
                config.LastDb = cmbDatabase.SelectedItem.ToString();
                ConfigHelper.UpdateConfig(config);

                //联动加载表
                var id = cmbDatabase.SelectedItem.ToString().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                listBox.Items.Clear();
                //listBox.Items.Add(TipsDbTable); 

                var thread = new Thread(() =>
                {
                    UpdateUI(() => { lblStatus.Text = "正在读取数据库架构，请稍候..."; });
                    var conn = FormDbService.GetConnectionString(Convert.ToInt32(id));
                    var tables = SqlserverHelper.GetTableNames(conn);
                    if (tables.Count > 0)
                    {
                        if (tables[0] == "Error")
                        {
                            UpdateUI(() => { lblStatus.Text = "数据库连接失败，请检查数据连接配置是否正确"; });
                        }
                        else
                        {
                            UpdateUI(() =>
                            {
                                foreach (var s in tables)
                                {
                                    listBox.Items.Add(s);
                                }

                                lblStatus.Text = "共" + listBox.Items.Count + "张表";
                                listBox.SelectedIndex = 0;
                            });
                        }
                    }
                }) { IsBackground = true };
                thread.Start();
            }
        }
        public void UpdateUI(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateCode();
        }

        private void CreateCode()
        {
            if (cmbDatabase.SelectedItem == null || cmbDatabase.SelectedItem.ToString() == TipsDB)
            {
                lblStatus.Text = "请选择数据库";
                return;
            }
            if (listBox.SelectedItem == null || listBox.SelectedItem.ToString() == TipsDbTable)
            {
                lblStatus.Text = "请选择数据表";
                return;
            }
            if (cmbCate.SelectedItem == null || cmbCate.SelectedItem.ToString() == TipsCate)
            {
                lblStatus.Text = "请选择模板分类";
                return;
            }
            if (cmbFile.SelectedItem == null || cmbFile.SelectedItem.ToString() == TipsFile)
            {
                lblStatus.Text = "请选择模板";
                return;
            }
            if (cmbDatabase.SelectedItem != null && cmbDatabase.SelectedItem.ToString() != TipsDB &&
                listBox.SelectedItem != null && listBox.SelectedItem.ToString() != TipsDbTable &&
                cmbCate.SelectedItem != null && cmbCate.SelectedItem.ToString() != TipsCate &&
                cmbFile.SelectedItem != null && cmbFile.SelectedItem.ToString() != TipsFile
            )
            {
                var id = cmbDatabase.SelectedItem.ToString().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                var dir = Path.Combine(FormTemplateService.TemplateDir, cmbCate.SelectedItem.ToString());
                var file = Path.Combine(dir, cmbFile.SelectedItem.ToString());
                var table = listBox.SelectedItem.ToString();
                var thread = new Thread(() =>
                {
                    try
                    {
                        UpdateUI(() =>
                        {
                            cmbDatabase.Enabled = false;
                            cmbFile.Enabled = false;
                            cmbCate.Enabled = false;
                            btnCreate.Enabled = false;
                            lblStatus.Text = "处理中，请稍候...";
                        });
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        var code = FormCodeService.CreateCode(Convert.ToInt32(id), table, file);
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes,
                            ts.Seconds, ts.Milliseconds / 10);
                        UpdateUI(() =>
                        {
                            textEditor.Text = code;
                            FormTemplate.Highlight(file, textEditor);
                            textEditor.Refresh();
                            btnCreate.Enabled = true;
                            cmbDatabase.Enabled = true;
                            cmbFile.Enabled = true;
                            cmbCate.Enabled = true;
                            lblStatus.Text = "生成成功，耗时：" + elapsedTime;
                        });
                    }
                    catch (Exception ex)
                    {
                        UpdateUI(() => { lblStatus.Text = ex.Message; });
                    }
                }) { IsBackground = true };
                thread.Start();


            }
        }

        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFile.SelectedItem != null && cmbFile.SelectedItem.ToString() != TipsFile)
            {
                //保存最后使用项
                var config = ConfigHelper.GetConfig<AppConfig>();
                config.LaseFile = cmbFile.SelectedItem.ToString();
                ConfigHelper.UpdateConfig(config);
                CreateCode();
            }
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(textEditor);
        }
        private void CopyToClipboard(TextEditorControl riTxt)
        {
            if (riTxt.Text != "")
            {
                try
                {
                    Clipboard.SetDataObject(riTxt.Text, true);
                    MessageBox.Show("代码已复制到粘贴板", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null && listBox.SelectedItem.ToString() != TipsDbTable)
            {
                //保存最后使用项
                var config = ConfigHelper.GetConfig<AppConfig>();
                config.LastTable = listBox.SelectedItem.ToString();
                ConfigHelper.UpdateConfig(config);
                CreateCode();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SearchTable();
        }

        private void SearchTable()
        {
            var key = txtKeyword.Text.Trim();
            for (var i = 0; i < listBox.Items.Count; i++)
            {
                var item = listBox.Items[i];
                if (item.ToString().ToLower().Contains(key.ToLower()))
                {
                    listBox.SelectedItem = item;
                    listBox.Refresh();
                    break;
                }
            }
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
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
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), textRect,
                    format);
            }
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                SearchTable();
            }
        }



        private void txtKeyword_Leave(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "")
            {
                txtKeyword.Text = DefaultTxt;
                txtKeyword.ForeColor = Color.Gray;
            }
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            if (txtKeyword.Text == DefaultTxt)
            {
                txtKeyword.Text = "";
                txtKeyword.ForeColor = Color.Black;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKeyword.Text = DefaultTxt;
            txtKeyword.ForeColor = Color.Gray;
        }


    }
}