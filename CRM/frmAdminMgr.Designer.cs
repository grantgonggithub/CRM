/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
namespace CRM
{
    partial class frmAdminMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminMgr));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAdminList = new System.Windows.Forms.DataGridView();
            this.ColAdminName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdminType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActive = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxAddAdminType = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxActive = new System.Windows.Forms.ComboBox();
            this.cbxAdminType = new System.Windows.Forms.ComboBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAdminName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripButtonOutPut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddAdminType)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 259);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAdminList);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 239);
            this.panel2.TabIndex = 2;
            // 
            // dgvAdminList
            // 
            this.dgvAdminList.AllowUserToAddRows = false;
            this.dgvAdminList.AllowUserToDeleteRows = false;
            this.dgvAdminList.AllowUserToResizeColumns = false;
            this.dgvAdminList.AllowUserToResizeRows = false;
            this.dgvAdminList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdminList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAdminList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdminList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdminList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAdminName,
            this.ColLoginName,
            this.ColTel,
            this.ColCreateTime,
            this.ColAdminType,
            this.ColActive});
            this.dgvAdminList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdminList.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvAdminList.Location = new System.Drawing.Point(0, 25);
            this.dgvAdminList.MultiSelect = false;
            this.dgvAdminList.Name = "dgvAdminList";
            this.dgvAdminList.ReadOnly = true;
            this.dgvAdminList.RowHeadersVisible = false;
            this.dgvAdminList.RowTemplate.Height = 23;
            this.dgvAdminList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdminList.Size = new System.Drawing.Size(667, 214);
            this.dgvAdminList.TabIndex = 1;
            this.dgvAdminList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdminList_CellDoubleClick);
            // 
            // ColAdminName
            // 
            this.ColAdminName.DataPropertyName = "AdminName";
            this.ColAdminName.HeaderText = "真实姓名";
            this.ColAdminName.Name = "ColAdminName";
            this.ColAdminName.ReadOnly = true;
            // 
            // ColLoginName
            // 
            this.ColLoginName.DataPropertyName = "LoginName";
            this.ColLoginName.HeaderText = "登陆名";
            this.ColLoginName.Name = "ColLoginName";
            this.ColLoginName.ReadOnly = true;
            // 
            // ColTel
            // 
            this.ColTel.DataPropertyName = "Tel";
            this.ColTel.HeaderText = "电话号码";
            this.ColTel.Name = "ColTel";
            this.ColTel.ReadOnly = true;
            // 
            // ColCreateTime
            // 
            this.ColCreateTime.DataPropertyName = "CreateTime";
            this.ColCreateTime.HeaderText = "添加时间";
            this.ColCreateTime.Name = "ColCreateTime";
            this.ColCreateTime.ReadOnly = true;
            // 
            // ColAdminType
            // 
            this.ColAdminType.DataPropertyName = "AdminType";
            this.ColAdminType.HeaderText = "管理员类型";
            this.ColAdminType.Name = "ColAdminType";
            this.ColAdminType.ReadOnly = true;
            // 
            // ColActive
            // 
            this.ColActive.DataPropertyName = "state";
            this.ColActive.HeaderText = "状态";
            this.ColActive.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColActive.Name = "ColActive";
            this.ColActive.ReadOnly = true;
            this.ColActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(5);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddNew,
            this.toolStripSeparator2,
            this.toolStripButtonEdit,
            this.toolStripSeparator1,
            this.toolStripButtonDelete,
            this.toolStripSeparator3,
            this.toolStripButtonOutPut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // toolStripButtonAddNew
            // 
            this.toolStripButtonAddNew.Image = global::CRM.Properties.Resources.png_0084;
            this.toolStripButtonAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddNew.Name = "toolStripButtonAddNew";
            this.toolStripButtonAddNew.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonAddNew.Text = "新增";
            this.toolStripButtonAddNew.Click += new System.EventHandler(this.toolStripButtonAddNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.Image = global::CRM.Properties.Resources.png_0535;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonEdit.Text = "编辑";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::CRM.Properties.Resources.png_0652;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonDelete.Text = "删除";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 167);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbxAddAdminType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cbxActive);
            this.panel1.Controls.Add(this.cbxAdminType);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtLoginName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.txtAdminName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 147);
            this.panel1.TabIndex = 0;
            // 
            // pbxAddAdminType
            // 
            this.pbxAddAdminType.Image = global::CRM.Properties.Resources.png_0084;
            this.pbxAddAdminType.Location = new System.Drawing.Point(408, 50);
            this.pbxAddAdminType.Name = "pbxAddAdminType";
            this.pbxAddAdminType.Size = new System.Drawing.Size(26, 20);
            this.pbxAddAdminType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAddAdminType.TabIndex = 9;
            this.pbxAddAdminType.TabStop = false;
            this.pbxAddAdminType.Click += new System.EventHandler(this.pbxAddAdminType_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "状    态";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(497, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 26);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxActive
            // 
            this.cbxActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActive.FormattingEnabled = true;
            this.cbxActive.Items.AddRange(new object[] {
            "启用",
            "停用"});
            this.cbxActive.Location = new System.Drawing.Point(497, 50);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(130, 20);
            this.cbxActive.TabIndex = 6;
            // 
            // cbxAdminType
            // 
            this.cbxAdminType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAdminType.FormattingEnabled = true;
            this.cbxAdminType.Location = new System.Drawing.Point(277, 49);
            this.cbxAdminType.Name = "cbxAdminType";
            this.cbxAdminType.Size = new System.Drawing.Size(130, 20);
            this.cbxAdminType.TabIndex = 5;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(497, 9);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(130, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备    注";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "电话号码";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(277, 10);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(130, 21);
            this.txtLoginName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "登陆名";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(74, 87);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(333, 48);
            this.txtRemark.TabIndex = 7;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(74, 48);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(130, 21);
            this.txtTel.TabIndex = 4;
            // 
            // txtAdminName
            // 
            this.txtAdminName.Location = new System.Drawing.Point(74, 10);
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.Size = new System.Drawing.Size(130, 21);
            this.txtAdminName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "登陆密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "管理员类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "真实姓名";
            // 
            // toolStripButtonOutPut
            // 
            this.toolStripButtonOutPut.Image = global::CRM.Properties.Resources.OutPut;
            this.toolStripButtonOutPut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutPut.Name = "toolStripButtonOutPut";
            this.toolStripButtonOutPut.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonOutPut.Text = "导出";
            this.toolStripButtonOutPut.Click += new System.EventHandler(this.toolStripButtonOutPut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // frmAdminMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdminMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员";
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdminList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAddAdminType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAdminList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxAdminType;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAdminName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdminName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdminType;
        private System.Windows.Forms.DataGridViewImageColumn ColActive;
        private System.Windows.Forms.PictureBox pbxAddAdminType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutPut;
    }
}