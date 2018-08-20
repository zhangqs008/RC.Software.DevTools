namespace RC.Software.DevTools
{
    partial class FormDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDb));
            this.groupExsit = new System.Windows.Forms.GroupBox();
            this.listExsit = new System.Windows.Forms.ListBox();
            this.groupEdit = new System.Windows.Forms.GroupBox();
            this.BtnDocument = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSetAdd = new System.Windows.Forms.LinkLabel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSqlDataBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSqlPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSqlUserName = new System.Windows.Forms.TextBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.TxtSqlServer = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupExsit.SuspendLayout();
            this.groupEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupExsit
            // 
            this.groupExsit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupExsit.Controls.Add(this.listExsit);
            this.groupExsit.Location = new System.Drawing.Point(8, 8);
            this.groupExsit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupExsit.Name = "groupExsit";
            this.groupExsit.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupExsit.Size = new System.Drawing.Size(325, 578);
            this.groupExsit.TabIndex = 2;
            this.groupExsit.TabStop = false;
            this.groupExsit.Text = "已有数据库";
            // 
            // listExsit
            // 
            this.listExsit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listExsit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listExsit.FormattingEnabled = true;
            this.listExsit.ItemHeight = 17;
            this.listExsit.Location = new System.Drawing.Point(7, 28);
            this.listExsit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listExsit.Name = "listExsit";
            this.listExsit.Size = new System.Drawing.Size(311, 514);
            this.listExsit.TabIndex = 0;
            this.listExsit.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listExsit_DrawItem);
            this.listExsit.SelectedIndexChanged += new System.EventHandler(this.listExsit_SelectedIndexChanged);
            // 
            // groupEdit
            // 
            this.groupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEdit.Controls.Add(this.BtnDocument);
            this.groupEdit.Controls.Add(this.pictureBox1);
            this.groupEdit.Controls.Add(this.btnSetAdd);
            this.groupEdit.Controls.Add(this.btnTest);
            this.groupEdit.Controls.Add(this.btnDel);
            this.groupEdit.Controls.Add(this.txtId);
            this.groupEdit.Controls.Add(this.label1);
            this.groupEdit.Controls.Add(this.btnSave);
            this.groupEdit.Controls.Add(this.label4);
            this.groupEdit.Controls.Add(this.TxtSqlDataBase);
            this.groupEdit.Controls.Add(this.label3);
            this.groupEdit.Controls.Add(this.TxtSqlPwd);
            this.groupEdit.Controls.Add(this.label2);
            this.groupEdit.Controls.Add(this.TxtSqlUserName);
            this.groupEdit.Controls.Add(this.lable1);
            this.groupEdit.Controls.Add(this.TxtSqlServer);
            this.groupEdit.Location = new System.Drawing.Point(346, 7);
            this.groupEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupEdit.Size = new System.Drawing.Size(524, 578);
            this.groupEdit.TabIndex = 3;
            this.groupEdit.TabStop = false;
            this.groupEdit.Text = "编辑配置";
            // 
            // BtnDocument
            // 
            this.BtnDocument.Image = ((System.Drawing.Image)(resources.GetObject("BtnDocument.Image")));
            this.BtnDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDocument.Location = new System.Drawing.Point(314, 230);
            this.BtnDocument.Name = "BtnDocument";
            this.BtnDocument.Size = new System.Drawing.Size(57, 27);
            this.BtnDocument.TabIndex = 120;
            this.BtnDocument.Text = "文档";
            this.BtnDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDocument.UseVisualStyleBackColor = true;
            this.BtnDocument.Click += new System.EventHandler(this.BtnDocument_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(146, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnSetAdd
            // 
            this.btnSetAdd.AutoSize = true;
            this.btnSetAdd.Location = new System.Drawing.Point(163, 53);
            this.btnSetAdd.Name = "btnSetAdd";
            this.btnSetAdd.Size = new System.Drawing.Size(32, 17);
            this.btnSetAdd.TabIndex = 118;
            this.btnSetAdd.TabStop = true;
            this.btnSetAdd.Text = "新建";
            this.btnSetAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSetAdd_LinkClicked);
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = true;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(230, 230);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(81, 27);
            this.btnTest.TabIndex = 117;
            this.btnTest.Text = "测试连接";
            this.btnTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(168, 230);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 27);
            this.btnDel.TabIndex = 116;
            this.btnDel.Text = "删除";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Location = new System.Drawing.Point(103, 53);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(15, 17);
            this.txtId.TabIndex = 115;
            this.txtId.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 114;
            this.label1.Text = "编  号:";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(106, 230);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 27);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 108;
            this.label4.Text = "数据库:";
            // 
            // TxtSqlDataBase
            // 
            this.TxtSqlDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSqlDataBase.Location = new System.Drawing.Point(106, 193);
            this.TxtSqlDataBase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSqlDataBase.Name = "TxtSqlDataBase";
            this.TxtSqlDataBase.Size = new System.Drawing.Size(265, 23);
            this.TxtSqlDataBase.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 107;
            this.label3.Text = "密  码:";
            // 
            // TxtSqlPwd
            // 
            this.TxtSqlPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSqlPwd.Location = new System.Drawing.Point(106, 156);
            this.TxtSqlPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSqlPwd.Name = "TxtSqlPwd";
            this.TxtSqlPwd.PasswordChar = '*';
            this.TxtSqlPwd.Size = new System.Drawing.Size(265, 23);
            this.TxtSqlPwd.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 106;
            this.label2.Text = "用户名:";
            // 
            // TxtSqlUserName
            // 
            this.TxtSqlUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSqlUserName.Location = new System.Drawing.Point(106, 118);
            this.TxtSqlUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSqlUserName.Name = "TxtSqlUserName";
            this.TxtSqlUserName.Size = new System.Drawing.Size(265, 23);
            this.TxtSqlUserName.TabIndex = 110;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(41, 86);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(47, 17);
            this.lable1.TabIndex = 105;
            this.lable1.Text = "服务器:";
            // 
            // TxtSqlServer
            // 
            this.TxtSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSqlServer.Location = new System.Drawing.Point(106, 82);
            this.TxtSqlServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSqlServer.Name = "TxtSqlServer";
            this.TxtSqlServer.Size = new System.Drawing.Size(265, 23);
            this.TxtSqlServer.TabIndex = 109;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(32, 17);
            this.lblStatus.Text = "状态";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "database.png");
            // 
            // FormDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupEdit);
            this.Controls.Add(this.groupExsit);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDb";
            this.Text = "FormDb";
            this.Load += new System.EventHandler(this.FormDb_Load);
            this.groupExsit.ResumeLayout(false);
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupExsit;
        private System.Windows.Forms.ListBox listExsit;
        private System.Windows.Forms.GroupBox groupEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSqlDataBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSqlPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSqlUserName;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.TextBox TxtSqlServer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.LinkLabel btnSetAdd;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnDocument;
    }
}