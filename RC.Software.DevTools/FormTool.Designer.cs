namespace RC.Software.DevTools
{
    partial class FormTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTool));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageEncode = new System.Windows.Forms.TabPage();
            this.splitEncode = new System.Windows.Forms.SplitContainer();
            this.btnBase64Decode = new System.Windows.Forms.Button();
            this.btnMd5 = new System.Windows.Forms.Button();
            this.btnBase64 = new System.Windows.Forms.Button();
            this.btnHtmlDecode = new System.Windows.Forms.Button();
            this.btnHtmlEncode = new System.Windows.Forms.Button();
            this.btnUrlDecode = new System.Windows.Forms.Button();
            this.btnUrlEncode = new System.Windows.Forms.Button();
            this.txtEncodeInput = new System.Windows.Forms.RichTextBox();
            this.txtEncodeOutput = new System.Windows.Forms.RichTextBox();
            this.tabPageJson = new System.Windows.Forms.TabPage();
            this.jsonViewer = new EPocalipse.Json.Viewer.JsonViewer();
            this.tabPageXMLFormat = new System.Windows.Forms.TabPage();
            this.splitFormat = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl.SuspendLayout();
            this.tabPageEncode.SuspendLayout();
            this.splitEncode.Panel1.SuspendLayout();
            this.splitEncode.Panel2.SuspendLayout();
            this.splitEncode.SuspendLayout();
            this.tabPageJson.SuspendLayout();
            this.tabPageXMLFormat.SuspendLayout();
            this.splitFormat.Panel1.SuspendLayout();
            this.splitFormat.Panel2.SuspendLayout();
            this.splitFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageEncode);
            this.tabControl.Controls.Add(this.tabPageJson);
            this.tabControl.Controls.Add(this.tabPageXMLFormat);
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Location = new System.Drawing.Point(2, 3);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(883, 609);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageEncode
            // 
            this.tabPageEncode.Controls.Add(this.splitEncode);
            this.tabPageEncode.ImageIndex = 1;
            this.tabPageEncode.Location = new System.Drawing.Point(4, 26);
            this.tabPageEncode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageEncode.Name = "tabPageEncode";
            this.tabPageEncode.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageEncode.Size = new System.Drawing.Size(875, 579);
            this.tabPageEncode.TabIndex = 1;
            this.tabPageEncode.Text = "编码&解码";
            this.tabPageEncode.UseVisualStyleBackColor = true;
            // 
            // splitEncode
            // 
            this.splitEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEncode.Location = new System.Drawing.Point(3, 4);
            this.splitEncode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitEncode.Name = "splitEncode";
            this.splitEncode.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitEncode.Panel1
            // 
            this.splitEncode.Panel1.Controls.Add(this.btnBase64Decode);
            this.splitEncode.Panel1.Controls.Add(this.btnMd5);
            this.splitEncode.Panel1.Controls.Add(this.btnBase64);
            this.splitEncode.Panel1.Controls.Add(this.btnHtmlDecode);
            this.splitEncode.Panel1.Controls.Add(this.btnHtmlEncode);
            this.splitEncode.Panel1.Controls.Add(this.btnUrlDecode);
            this.splitEncode.Panel1.Controls.Add(this.btnUrlEncode);
            this.splitEncode.Panel1.Controls.Add(this.txtEncodeInput);
            // 
            // splitEncode.Panel2
            // 
            this.splitEncode.Panel2.Controls.Add(this.txtEncodeOutput);
            this.splitEncode.Size = new System.Drawing.Size(869, 571);
            this.splitEncode.SplitterDistance = 285;
            this.splitEncode.SplitterWidth = 6;
            this.splitEncode.TabIndex = 1;
            // 
            // btnBase64Decode
            // 
            this.btnBase64Decode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBase64Decode.AutoSize = true;
            this.btnBase64Decode.Location = new System.Drawing.Point(464, 243);
            this.btnBase64Decode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBase64Decode.Name = "btnBase64Decode";
            this.btnBase64Decode.Size = new System.Drawing.Size(105, 27);
            this.btnBase64Decode.TabIndex = 7;
            this.btnBase64Decode.Text = "Base64Decode";
            this.btnBase64Decode.UseVisualStyleBackColor = true;
            this.btnBase64Decode.Click += new System.EventHandler(this.btnBase64Decode_Click);
            // 
            // btnMd5
            // 
            this.btnMd5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMd5.AutoSize = true;
            this.btnMd5.Location = new System.Drawing.Point(572, 243);
            this.btnMd5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMd5.Name = "btnMd5";
            this.btnMd5.Size = new System.Drawing.Size(45, 27);
            this.btnMd5.TabIndex = 6;
            this.btnMd5.Text = "Md5";
            this.btnMd5.UseVisualStyleBackColor = true;
            this.btnMd5.Click += new System.EventHandler(this.btnMd5_Click);
            // 
            // btnBase64
            // 
            this.btnBase64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBase64.AutoSize = true;
            this.btnBase64.Location = new System.Drawing.Point(358, 244);
            this.btnBase64.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBase64.Name = "btnBase64";
            this.btnBase64.Size = new System.Drawing.Size(103, 27);
            this.btnBase64.TabIndex = 5;
            this.btnBase64.Text = "Base64Encode";
            this.btnBase64.UseVisualStyleBackColor = true;
            this.btnBase64.Click += new System.EventHandler(this.btnBase64_Click);
            // 
            // btnHtmlDecode
            // 
            this.btnHtmlDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHtmlDecode.AutoSize = true;
            this.btnHtmlDecode.Location = new System.Drawing.Point(262, 244);
            this.btnHtmlDecode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHtmlDecode.Name = "btnHtmlDecode";
            this.btnHtmlDecode.Size = new System.Drawing.Size(90, 27);
            this.btnHtmlDecode.TabIndex = 4;
            this.btnHtmlDecode.Text = "HtmlDecode";
            this.btnHtmlDecode.UseVisualStyleBackColor = true;
            this.btnHtmlDecode.Click += new System.EventHandler(this.btnHtmlDecode_Click);
            // 
            // btnHtmlEncode
            // 
            this.btnHtmlEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHtmlEncode.AutoSize = true;
            this.btnHtmlEncode.Location = new System.Drawing.Point(171, 244);
            this.btnHtmlEncode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHtmlEncode.Name = "btnHtmlEncode";
            this.btnHtmlEncode.Size = new System.Drawing.Size(88, 27);
            this.btnHtmlEncode.TabIndex = 3;
            this.btnHtmlEncode.Text = "HtmlEncode";
            this.btnHtmlEncode.UseVisualStyleBackColor = true;
            this.btnHtmlEncode.Click += new System.EventHandler(this.btnHtmlEncode_Click);
            // 
            // btnUrlDecode
            // 
            this.btnUrlDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUrlDecode.AutoSize = true;
            this.btnUrlDecode.Location = new System.Drawing.Point(88, 244);
            this.btnUrlDecode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUrlDecode.Name = "btnUrlDecode";
            this.btnUrlDecode.Size = new System.Drawing.Size(80, 27);
            this.btnUrlDecode.TabIndex = 2;
            this.btnUrlDecode.Text = "UrlDecode";
            this.btnUrlDecode.UseVisualStyleBackColor = true;
            this.btnUrlDecode.Click += new System.EventHandler(this.btnUrlDecode_Click);
            // 
            // btnUrlEncode
            // 
            this.btnUrlEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUrlEncode.AutoSize = true;
            this.btnUrlEncode.Location = new System.Drawing.Point(6, 244);
            this.btnUrlEncode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUrlEncode.Name = "btnUrlEncode";
            this.btnUrlEncode.Size = new System.Drawing.Size(78, 27);
            this.btnUrlEncode.TabIndex = 1;
            this.btnUrlEncode.Text = "UrlEncode";
            this.btnUrlEncode.UseVisualStyleBackColor = true;
            this.btnUrlEncode.Click += new System.EventHandler(this.btnUrlEncode_Click);
            // 
            // txtEncodeInput
            // 
            this.txtEncodeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncodeInput.Location = new System.Drawing.Point(3, 0);
            this.txtEncodeInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEncodeInput.Name = "txtEncodeInput";
            this.txtEncodeInput.Size = new System.Drawing.Size(861, 238);
            this.txtEncodeInput.TabIndex = 0;
            this.txtEncodeInput.Text = "";
            // 
            // txtEncodeOutput
            // 
            this.txtEncodeOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEncodeOutput.Location = new System.Drawing.Point(0, 0);
            this.txtEncodeOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEncodeOutput.Name = "txtEncodeOutput";
            this.txtEncodeOutput.Size = new System.Drawing.Size(869, 280);
            this.txtEncodeOutput.TabIndex = 1;
            this.txtEncodeOutput.Text = "";
            // 
            // tabPageJson
            // 
            this.tabPageJson.Controls.Add(this.jsonViewer);
            this.tabPageJson.ImageIndex = 0;
            this.tabPageJson.Location = new System.Drawing.Point(4, 26);
            this.tabPageJson.Name = "tabPageJson";
            this.tabPageJson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJson.Size = new System.Drawing.Size(875, 579);
            this.tabPageJson.TabIndex = 2;
            this.tabPageJson.Text = "JSON 格式化";
            this.tabPageJson.UseVisualStyleBackColor = true;
            // 
            // jsonViewer
            // 
            this.jsonViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonViewer.Json = null;
            this.jsonViewer.Location = new System.Drawing.Point(0, 0);
            this.jsonViewer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jsonViewer.Name = "jsonViewer";
            this.jsonViewer.Size = new System.Drawing.Size(872, 575);
            this.jsonViewer.TabIndex = 1;
            // 
            // tabPageXMLFormat
            // 
            this.tabPageXMLFormat.Controls.Add(this.splitFormat);
            this.tabPageXMLFormat.ImageIndex = 0;
            this.tabPageXMLFormat.Location = new System.Drawing.Point(4, 26);
            this.tabPageXMLFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageXMLFormat.Name = "tabPageXMLFormat";
            this.tabPageXMLFormat.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageXMLFormat.Size = new System.Drawing.Size(875, 579);
            this.tabPageXMLFormat.TabIndex = 0;
            this.tabPageXMLFormat.Text = "XML 格式化";
            this.tabPageXMLFormat.UseVisualStyleBackColor = true;
            // 
            // splitFormat
            // 
            this.splitFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFormat.Location = new System.Drawing.Point(3, 4);
            this.splitFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitFormat.Name = "splitFormat";
            this.splitFormat.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFormat.Panel1
            // 
            this.splitFormat.Panel1.Controls.Add(this.button3);
            this.splitFormat.Panel1.Controls.Add(this.btnXml);
            this.splitFormat.Panel1.Controls.Add(this.txtInput);
            // 
            // splitFormat.Panel2
            // 
            this.splitFormat.Panel2.Controls.Add(this.txtOutput);
            this.splitFormat.Size = new System.Drawing.Size(869, 571);
            this.splitFormat.SplitterDistance = 285;
            this.splitFormat.SplitterWidth = 6;
            this.splitFormat.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(96, 244);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 27);
            this.button3.TabIndex = 3;
            this.button3.Text = "HTML 格式化";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnXml
            // 
            this.btnXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXml.AutoSize = true;
            this.btnXml.Location = new System.Drawing.Point(6, 244);
            this.btnXml.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(84, 27);
            this.btnXml.TabIndex = 1;
            this.btnXml.Text = "XML 格式化";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(3, 0);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(861, 238);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "";
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(869, 280);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "text_indent.png");
            this.imageList.Images.SetKeyName(1, "doc_convert.png");
            // 
            // FormTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTool";
            this.Text = "FormTool";
            this.Load += new System.EventHandler(this.FormTool_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageEncode.ResumeLayout(false);
            this.splitEncode.Panel1.ResumeLayout(false);
            this.splitEncode.Panel1.PerformLayout();
            this.splitEncode.Panel2.ResumeLayout(false);
            this.splitEncode.ResumeLayout(false);
            this.tabPageJson.ResumeLayout(false);
            this.tabPageXMLFormat.ResumeLayout(false);
            this.splitFormat.Panel1.ResumeLayout(false);
            this.splitFormat.Panel1.PerformLayout();
            this.splitFormat.Panel2.ResumeLayout(false);
            this.splitFormat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageXMLFormat;
        private System.Windows.Forms.TabPage tabPageEncode;
        private System.Windows.Forms.SplitContainer splitFormat;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SplitContainer splitEncode;
        private System.Windows.Forms.Button btnHtmlEncode;
        private System.Windows.Forms.Button btnUrlDecode;
        private System.Windows.Forms.Button btnUrlEncode;
        private System.Windows.Forms.RichTextBox txtEncodeInput;
        private System.Windows.Forms.RichTextBox txtEncodeOutput;
        private System.Windows.Forms.Button btnHtmlDecode;
        private System.Windows.Forms.Button btnMd5;
        private System.Windows.Forms.Button btnBase64;
        private System.Windows.Forms.TabPage tabPageJson;
        private EPocalipse.Json.Viewer.JsonViewer jsonViewer;
        private System.Windows.Forms.Button btnBase64Decode;
        private System.Windows.Forms.ImageList imageList;
    }
}