using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RC.Software.DevTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenForm(new FormIndex());
        }

        #region 切换操作面板

        /// <summary>
        ///     切换操作面板
        /// </summary>
        /// <param name="form"></param>
        public void OpenForm(Form form)
        {
            panRight.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            form.Dock = DockStyle.Fill;
            panRight.Controls.Add(form);
            form.Show();

            //还原样式
            foreach (Control control in panLeft.Controls)
                if (control.GetType() == typeof(Label))
                {
                    control.ForeColor = Color.Black;
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size, FontStyle.Regular);
                }

            //设置选中项
            var lbl = "lbl" + form.Text.Replace("Form", "");
            var lable = (Label) panLeft.Controls.Find(lbl, false)[0];
            if (lable != null)
            {
                lable.ForeColor = Color.OrangeRed;
                lable.Font = new Font(lable.Font.FontFamily, lable.Font.Size, FontStyle.Bold);
            }
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var process = Process.GetProcessById(Process.GetCurrentProcess().Id);
            process.Kill();
        }

        #region 切换操作面板

        private void PicDb_Click(object sender, EventArgs e)
        {
            OpenForm(new FormDb());
        }

        private void picTemplate_Click(object sender, EventArgs e)
        {
            OpenForm(new FormTemplate());
        }

        private void picCode_Click(object sender, EventArgs e)
        {
            OpenForm(new FormCode());
        }

        private void picTool_Click(object sender, EventArgs e)
        {
            OpenForm(new FormTool());
        }

        private void picConfig_Click(object sender, EventArgs e)
        {
            OpenForm(new FormConfig());
        }


        private void picAbout_Click(object sender, EventArgs e)
        {
            OpenForm(new FormIndex());
        }

        #endregion

        private void lblDb_Click(object sender, EventArgs e)
        {

            OpenForm(new FormDb());
        }

        private void lblTemplate_Click(object sender, EventArgs e)
        {

            OpenForm(new FormTemplate());
        }

        private void lblCode_Click(object sender, EventArgs e)
        {

            OpenForm(new FormCode());
        }

        private void lblTool_Click(object sender, EventArgs e)
        {

            OpenForm(new FormTool());
        }

        private void lblConfig_Click(object sender, EventArgs e)
        {

            OpenForm(new FormConfig());
        }

        private void lblIndex_Click(object sender, EventArgs e)
        {

            OpenForm(new FormIndex());
        }

    }
}