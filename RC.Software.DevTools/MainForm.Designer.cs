namespace RC.Software.DevTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTool = new System.Windows.Forms.Label();
            this.picTool = new System.Windows.Forms.PictureBox();
            this.lblConfig = new System.Windows.Forms.Label();
            this.picConfig = new System.Windows.Forms.PictureBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.picCode = new System.Windows.Forms.PictureBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.picTemplate = new System.Windows.Forms.PictureBox();
            this.lblDb = new System.Windows.Forms.Label();
            this.PicDb = new System.Windows.Forms.PictureBox();
            this.panRight = new System.Windows.Forms.Panel();
            this.panLeft = new System.Windows.Forms.Panel();
            this.lblIndex = new System.Windows.Forms.Label();
            this.picIndex = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDb)).BeginInit();
            this.panLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTool.Location = new System.Drawing.Point(27, 353);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(56, 17);
            this.lblTool.TabIndex = 9;
            this.lblTool.Text = "其它工具";
            this.lblTool.Click += new System.EventHandler(this.lblTool_Click);
            // 
            // picTool
            // 
            this.picTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTool.Image = ((System.Drawing.Image)(resources.GetObject("picTool.Image")));
            this.picTool.Location = new System.Drawing.Point(29, 302);
            this.picTool.Name = "picTool";
            this.picTool.Size = new System.Drawing.Size(48, 48);
            this.picTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTool.TabIndex = 8;
            this.picTool.TabStop = false;
            this.picTool.Click += new System.EventHandler(this.picTool_Click);
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblConfig.Location = new System.Drawing.Point(28, 452);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(56, 17);
            this.lblConfig.TabIndex = 7;
            this.lblConfig.Text = "系统设置";
            this.lblConfig.Click += new System.EventHandler(this.lblConfig_Click);
            // 
            // picConfig
            // 
            this.picConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picConfig.Image = ((System.Drawing.Image)(resources.GetObject("picConfig.Image")));
            this.picConfig.Location = new System.Drawing.Point(30, 401);
            this.picConfig.Name = "picConfig";
            this.picConfig.Size = new System.Drawing.Size(48, 48);
            this.picConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picConfig.TabIndex = 6;
            this.picConfig.TabStop = false;
            this.picConfig.Click += new System.EventHandler(this.picConfig_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCode.Location = new System.Drawing.Point(27, 255);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(56, 17);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "生成代码";
            this.lblCode.Click += new System.EventHandler(this.lblCode_Click);
            // 
            // picCode
            // 
            this.picCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCode.Image = ((System.Drawing.Image)(resources.GetObject("picCode.Image")));
            this.picCode.Location = new System.Drawing.Point(29, 204);
            this.picCode.Name = "picCode";
            this.picCode.Size = new System.Drawing.Size(48, 48);
            this.picCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCode.TabIndex = 4;
            this.picCode.TabStop = false;
            this.picCode.Click += new System.EventHandler(this.picCode_Click);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTemplate.Location = new System.Drawing.Point(32, 166);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(44, 17);
            this.lblTemplate.TabIndex = 3;
            this.lblTemplate.Text = "模板库";
            this.lblTemplate.Click += new System.EventHandler(this.lblTemplate_Click);
            // 
            // picTemplate
            // 
            this.picTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTemplate.Image = ((System.Drawing.Image)(resources.GetObject("picTemplate.Image")));
            this.picTemplate.Location = new System.Drawing.Point(29, 117);
            this.picTemplate.Name = "picTemplate";
            this.picTemplate.Size = new System.Drawing.Size(48, 48);
            this.picTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTemplate.TabIndex = 2;
            this.picTemplate.TabStop = false;
            this.picTemplate.Click += new System.EventHandler(this.picTemplate_Click);
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDb.Location = new System.Drawing.Point(31, 80);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(44, 17);
            this.lblDb.TabIndex = 1;
            this.lblDb.Text = "数据源";
            this.lblDb.Click += new System.EventHandler(this.lblDb_Click);
            // 
            // PicDb
            // 
            this.PicDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicDb.Image = ((System.Drawing.Image)(resources.GetObject("PicDb.Image")));
            this.PicDb.Location = new System.Drawing.Point(29, 30);
            this.PicDb.Name = "PicDb";
            this.PicDb.Size = new System.Drawing.Size(48, 48);
            this.PicDb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicDb.TabIndex = 0;
            this.PicDb.TabStop = false;
            this.PicDb.Click += new System.EventHandler(this.PicDb_Click);
            // 
            // panRight
            // 
            this.panRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panRight.Location = new System.Drawing.Point(110, 3);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(894, 605);
            this.panRight.TabIndex = 0;
            // 
            // panLeft
            // 
            this.panLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLeft.Controls.Add(this.lblIndex);
            this.panLeft.Controls.Add(this.picIndex);
            this.panLeft.Controls.Add(this.lblTool);
            this.panLeft.Controls.Add(this.PicDb);
            this.panLeft.Controls.Add(this.picTool);
            this.panLeft.Controls.Add(this.lblDb);
            this.panLeft.Controls.Add(this.lblConfig);
            this.panLeft.Controls.Add(this.picTemplate);
            this.panLeft.Controls.Add(this.picConfig);
            this.panLeft.Controls.Add(this.lblTemplate);
            this.panLeft.Controls.Add(this.lblCode);
            this.panLeft.Controls.Add(this.picCode);
            this.panLeft.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panLeft.Location = new System.Drawing.Point(-4, -5);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(108, 623);
            this.panLeft.TabIndex = 0;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIndex.Location = new System.Drawing.Point(40, 547);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(32, 17);
            this.lblIndex.TabIndex = 11;
            this.lblIndex.Text = "关于";
            this.lblIndex.Click += new System.EventHandler(this.lblIndex_Click);
            // 
            // picIndex
            // 
            this.picIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIndex.Image = ((System.Drawing.Image)(resources.GetObject("picIndex.Image")));
            this.picIndex.Location = new System.Drawing.Point(31, 496);
            this.picIndex.Name = "picIndex";
            this.picIndex.Size = new System.Drawing.Size(48, 48);
            this.picIndex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIndex.TabIndex = 10;
            this.picIndex.TabStop = false;
            this.picIndex.Click += new System.EventHandler(this.picAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.panLeft);
            this.Controls.Add(this.panRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDb)).EndInit();
            this.panLeft.ResumeLayout(false);
            this.panLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDb;
        private System.Windows.Forms.PictureBox PicDb;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.PictureBox picTemplate;
        private System.Windows.Forms.Label lblTool;
        private System.Windows.Forms.PictureBox picTool;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.PictureBox picConfig;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.PictureBox picCode;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.PictureBox picIndex;
    }
}

