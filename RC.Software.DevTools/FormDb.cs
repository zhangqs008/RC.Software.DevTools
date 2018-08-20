using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using JinianNet.JNTemplate;
using RC.Software.Framework.DbService;
using RC.Software.Framework.Helper;
using RC.Software.Presentation;

namespace RC.Software.DevTools
{
    public partial class FormDb : Form
    {
        public FormDb()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new FormDbService.DbInfo();
                db.Id = Convert.ToInt32(txtId.Text);
                db.Server = TxtSqlServer.Text;
                db.UserName = TxtSqlUserName.Text;
                db.Password = TxtSqlPwd.Text;
                db.Database = TxtSqlDataBase.Text;
                if (db.Server.Length == 0 ||
                    db.UserName.Length == 0 ||
                    db.Password.Length == 0 ||
                    db.Database.Length == 0)
                {
                    MessageBox.Show("抱歉，以上所有项均不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                btnSave.Enabled = false;
                string connection = GetConnectionString();
                var thread = new Thread(() =>
                {
                    UpdateUI(() => { lblStatus.Text = "测试连接中，请稍后..."; });
                    if (CheckConnection(connection))
                    {
                        FormDbService.EditDb(db);
                        UpdateUI(() =>
                        {
                            lblStatus.Text = "";
                            btnSave.Enabled = true;
                            MessageBox.Show("操作成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                    else
                    {
                        UpdateUI(() =>
                        {
                            lblStatus.Text = "";
                            btnSave.Enabled = true;
                            MessageBox.Show("抱歉，数据库连接失败，数据未保存\n请检查配置参数准确性后再试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                        return;
                    }

                    UpdateUI(() =>
                    {
                        btnSave.Enabled = true;
                        Bind();
                    });

                });
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void FormDb_Load(object sender, EventArgs e)
        {
            Bind();
            //绘图标
            listExsit.DrawMode = DrawMode.OwnerDrawFixed;
            listExsit.ItemHeight = 20;
            btnDel.Enabled = false;
        }

        public void Bind()
        {
            listExsit.Items.Clear();
            var dbs = FormDbService.GetDbs();
            foreach (FormDbService.DbInfo db in dbs)
            {
                listExsit.Items.Add(db.Id + " " + db.Server.Trim() + "-" + db.Database.Trim());
            }
        }

        private void listExsit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listExsit.SelectedItem != null)
            {
                var id = listExsit.SelectedItem.ToString().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                var db = FormDbService.GetDb(Convert.ToInt32(id));
                if (db != null)
                {
                    txtId.Text = db.Id.ToString();
                    TxtSqlServer.Text = db.Server;
                    TxtSqlDataBase.Text = db.Database;
                    TxtSqlUserName.Text = db.UserName;
                    TxtSqlPwd.Text = db.Password;
                    btnDel.Enabled = true;
                }
                else
                {
                    btnDel.Enabled = false;

                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(txtId.Text);
                if (id > 0)
                {
                    DialogResult re = MessageBox.Show("确定要删除该项吗？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (re == DialogResult.OK)
                    {
                        FormDbService.DelDb(id);
                        Bind();
                        TxtSqlServer.Text = "";
                        TxtSqlDataBase.Text = "";
                        TxtSqlUserName.Text = "";
                        TxtSqlPwd.Text = "";
                        txtId.Text = "";
                        MessageBox.Show("操作成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connection = GetConnectionString();
            if (!string.IsNullOrEmpty(connection))
            {
                var threadDelegate = new ThreadStart(delegate
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    Invoke(new MethodInvoker(() => { lblStatus.Text = @"连接中，请稍候..."; }));
                    var text = "";
                    try
                    {
                        text = CheckConnection(connection) ? "连接成功！" : "抱歉，连接失败！";
                        Invoke(new MethodInvoker(() => { MessageBox.Show(text, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); }));
                    }
                    catch (Exception ex)
                    {
                        text = ex.Message;
                    }
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours,
                        ts.Minutes,
                        ts.Seconds,
                        ts.Milliseconds / 10);
                    Invoke(new MethodInvoker(() =>
                    {
                        lblStatus.Text = string.Format(text + "耗时：" + elapsedTime);
                    }));
                });
                new Thread(threadDelegate).Start();
            }
        }
        public static bool CheckConnection(string con)
        {
            bool flag;
            var conn = new SqlConnection(con);
            try
            {
                conn.Open();
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        private string GetConnectionString()
        {
            if (string.IsNullOrEmpty(TxtSqlServer.Text.Trim()) ||
                string.IsNullOrEmpty(TxtSqlDataBase.Text.Trim()) ||
                string.IsNullOrEmpty(TxtSqlUserName.Text.Trim()) ||
                string.IsNullOrEmpty(TxtSqlPwd.Text.Trim())
            )
            {
                MessageBox.Show("抱歉，以上所有项均不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return string.Empty;
            }
            string conn = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};";
            conn = string.Format(conn, TxtSqlServer.Text.Trim(), TxtSqlDataBase.Text.Trim(), TxtSqlUserName.Text.Trim(), TxtSqlPwd.Text.Trim());
            return conn;
        }

        private void btnSetAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InitAdd();
        }

        private void InitAdd()
        {
            var db = new FormDbService.DbInfo();
            txtId.Text = db.Id.ToString();
            TxtSqlServer.Text = db.Server;
            TxtSqlDataBase.Text = db.Database;
            TxtSqlUserName.Text = db.UserName;
            TxtSqlPwd.Text = db.Password;
            btnDel.Enabled = false;
        }

        private void listExsit_DrawItem(object sender, DrawItemEventArgs e)
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
                e.Graphics.DrawString(listExsit.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor),
                    textRect, format);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InitAdd();
        }

        private void BtnDocument_Click(object sender, EventArgs e)
        {
            string connection = GetConnectionString();

            var dbName = new Regex(
                "(?i)(database|Initial Catalog)=(?<db>[^;]*?);",
                RegexOptions.CultureInvariant
                | RegexOptions.Compiled
            ).Match(connection).Groups["db"].Value;

            if (!string.IsNullOrEmpty(connection))
            {
                var threadDelegate = new ThreadStart(delegate
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    Invoke(new MethodInvoker(() =>
                    {
                        btnDel.Enabled = false;
                        btnSave.Enabled = false;
                        btnTest.Enabled = false;
                        BtnDocument.Enabled = false;

                        lblStatus.Text = @"处理中，请稍候...";
                    }));

                    List<TableInfo> tables = SqlserverHelper.GetTables(connection);
                    var tempalte = PathHelper.AppPath.Combine("DbDocument").Combine("table.html");

                    //文档存放路径
                    var savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Combine(dbName + "-数据库文档");
                    var saveTablesPath = savePath.Combine("tables");
                    try
                    {
                        if (Directory.Exists(savePath))
                        {
                            FileHelper.DeleteFolder(savePath);
                        }

                        if (!Directory.Exists(saveTablesPath))
                        {
                            Directory.CreateDirectory(saveTablesPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            btnDel.Enabled = true;
                            btnSave.Enabled = true;
                            btnTest.Enabled = true;
                            BtnDocument.Enabled = true;
                            lblStatus.Text = @"初始化文档存放目录异常：" + ex.Message;
                            MessageBox.Show(ex.Message, "提示信息");
                        }));
                    }

                    var config = ConfigHelper.GetConfig<AppConfig>();
                    ITemplate template = BuildManager.CreateTemplate(tempalte);
                    template.Context.CurrentPath = PathHelper.AppPath.Combine("DbDocument");
                    template.Context.TempData["datetime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    template.Context.TempData["conn"] = connection;
                    template.Context.TempData["author"] = config.Author;
                    template.Context.TempData["namespace"] = config.NameSpace;
                    var count = 0;
                    foreach (TableInfo table in tables)
                    {
                        count++;
                        var tableName = table.TableName;

                        #region 表实体

                        string className = table.TableName.Contains("_")
                                               ? tableName.Substring(tableName.LastIndexOf("_", StringComparison.Ordinal) + 1)
                                               : tableName;
                        string note = SqlserverHelper.GetTableNote(connection, tableName);
                        var tableInfo = new TableInfo
                        {
                            TableNote = note,
                            ClassName = className,
                            TableName = tableName
                        };

                        #endregion

                        #region 字段

                        List<FieldInfo> fieldList = SqlserverHelper.GetFieldInfoList(connection, tableName);
                        var list = new List<FieldInfo>();
                        var excepts = new List<string>();
                        excepts.AddRange(config.ExceptFields.Replace("，", ",").ToLower().Trim().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                        foreach (FieldInfo fieldInfo in fieldList)
                        {
                            if (!excepts.Contains(fieldInfo.Name.ToLower()))
                            {
                                list.Add(fieldInfo);
                            }
                            if (fieldInfo.IsPrimaryKey)
                            {
                                tableInfo.PrimaryKey = fieldInfo.Name;
                            }
                        }
                        #endregion

                        template.Context.TempData["table"] = tableInfo;
                        template.Context.TempData["fields"] = list;

                        string html = template.Render();
                        var path = saveTablesPath.Combine(table.TableName + ".html");
                        FileHelper.WriteFile(path, html, Encoding.UTF8);
                        Invoke(new MethodInvoker(() => { lblStatus.Text = @"正在生成(" + count + "/" + tables.Count + ")：" + tableName; }));
                    }

                    //生成首页
                    var indexPath = PathHelper.AppPath.Combine("DbDocument").Combine("index.html");
                    var txt = FileHelper.ReadFile(indexPath, Encoding.Default);

                    var tableHtml = "";
                    foreach (TableInfo table in tables)
                    {
                        tableHtml += "<li><span class=\"file\"><a href=\"tables/" + table.TableName + ".html\" target=\"right\">" + table.TableName + "</a></span></li>" + Environment.NewLine;
                    }
                    txt = txt.Replace("{$tables}", tableHtml);
                    txt = txt.Replace("{$dataBase}", dbName.Trim());
                    FileHelper.WriteFile(savePath.Combine("index.html"), txt, Encoding.UTF8);

                    //主框架页
                    var mainPath = PathHelper.AppPath.Combine("DbDocument").Combine("main.html");
                    txt = FileHelper.ReadFile(mainPath, Encoding.Default);
                    txt = txt.Replace("{$tables}", tableHtml);
                    txt = txt.Replace("{$dataBase}", dbName.Trim());
                    txt = txt.Replace("{$tableCount}", tables.Count.ToString());
                    txt = txt.Replace("{$createuser}", config.Author.Trim());
                    txt = txt.Replace("{$datetime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    FileHelper.WriteFile(savePath.Combine("main.html"), txt, Encoding.UTF8);

                    //样式文件
                    FileHelper.CopyDirectory(PathHelper.AppPath.Combine("DbDocument").Combine("style"), savePath.Combine("style"));
                    FileHelper.CopyDirectory(PathHelper.AppPath.Combine("DbDocument").Combine("script"), savePath.Combine("script"));
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                    Invoke(new MethodInvoker(() =>
                    {
                        btnDel.Enabled = true;
                        btnSave.Enabled = true;
                        btnTest.Enabled = true;
                        BtnDocument.Enabled = true;
                        lblStatus.Text = @"生成成功，文件已保存到：" + savePath + " 耗时：" + elapsedTime;
                        Help.ShowHelp(this, savePath.Combine("index.html"));
                    }));

                });
                new Thread(threadDelegate).Start();
            }
            else
            {
                lblStatus.Text = @"抱歉，数据库连接字符串构造异常";
            }
        }

    }

}