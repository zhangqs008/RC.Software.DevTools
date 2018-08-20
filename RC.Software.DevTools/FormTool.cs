using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace RC.Software.DevTools
{
    public partial class FormTool : Form
    {
        public FormTool()
        {
            InitializeComponent();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            var txt = FormToolService.FormatXml(txtInput.Text);
            txtOutput.Text = txt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var txt = FormToolService.FormatHtml(txtInput.Text, true);
            txtOutput.Text = txt;
        }

        private void FormTool_Load(object sender, EventArgs e)
        {
        }

        private void btnUrlEncode_Click(object sender, EventArgs e)
        {
            try
            {
                txtEncodeOutput.Text = HttpUtility.UrlEncode(txtEncodeInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUrlDecode_Click(object sender, EventArgs e)
        {
            try
            {
                txtEncodeOutput.Text = HttpUtility.UrlEncode(txtEncodeInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHtmlEncode_Click(object sender, EventArgs e)
        {
            try
            {
                txtEncodeOutput.Text = HttpUtility.HtmlEncode(txtEncodeInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHtmlDecode_Click(object sender, EventArgs e)
        {
            try
            {
                txtEncodeOutput.Text = HttpUtility.HtmlDecode(txtEncodeInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBase64_Click(object sender, EventArgs e)
        {
            try
            {
                txtEncodeOutput.Text = Base64StringEncode(txtEncodeInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     对输入的Base64字符串进行解码
        /// </summary>
        /// <param name="input">输入的Base64字符串</param>
        /// <returns>解码后的字符串</returns>
        public static string Base64StringDecode(string input)
        {
            var decbuff = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(decbuff);
        }

        /// <summary>
        ///     对输入字符串进行Base64编码
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>Base64编码后的字符串</returns>
        public static string Base64StringEncode(string input)
        {
            var encbuff = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(encbuff);
        }

        private void btnBase64Decode_Click(object sender, EventArgs e)
        {
            try
            {
                txtEncodeOutput.Text = Base64StringDecode(txtEncodeInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMd5_Click(object sender, EventArgs e)
        {
            try
            {
                var sor = Encoding.UTF8.GetBytes(txtEncodeInput.Text);
                var md5 = MD5.Create();
                var result = md5.ComputeHash(sor);
                var strbul = new StringBuilder(40);
                for (var i = 0; i < result.Length; i++)
                    strbul.Append(result[i].ToString("x2")); //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                txtEncodeOutput.Text = strbul.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}