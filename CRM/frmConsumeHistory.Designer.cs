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
    partial class frmConsumeHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumeHistory));
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ColBillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColConsumeMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdminName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColConsumeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOutPut = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxAdmin = new System.Windows.Forms.ComboBox();
            this.cmbxEmployeeName = new System.Windows.Forms.ComboBox();
            this.cbxUserType = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtCardId = new System.Windows.Forms.TextBox();
            this.txtConsumeMoney = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CRM.Properties.Resources.detail1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "详情";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvList);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 313);
            this.panel1.TabIndex = 1;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColBillID,
            this.ColCardId,
            this.ColUserName,
            this.ColUserType,
            this.ColConsumeMoney,
            this.ColAdminName,
            this.ColEmployeeName,
            this.ColConsumeTime});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 25);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(790, 288);
            this.dgvList.TabIndex = 1;
            this.dgvList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvList_MouseDoubleClick);
            // 
            // ColBillID
            // 
            this.ColBillID.DataPropertyName = "BillID";
            this.ColBillID.HeaderText = "编号";
            this.ColBillID.Name = "ColBillID";
            this.ColBillID.ReadOnly = true;
            // 
            // ColCardId
            // 
            this.ColCardId.DataPropertyName = "CardId";
            this.ColCardId.HeaderText = "卡号";
            this.ColCardId.Name = "ColCardId";
            this.ColCardId.ReadOnly = true;
            // 
            // ColUserName
            // 
            this.ColUserName.DataPropertyName = "UserName";
            this.ColUserName.HeaderText = "会员姓名";
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            // 
            // ColUserType
            // 
            this.ColUserType.DataPropertyName = "UserType";
            this.ColUserType.HeaderText = "会员类型";
            this.ColUserType.Name = "ColUserType";
            this.ColUserType.ReadOnly = true;
            // 
            // ColConsumeMoney
            // 
            this.ColConsumeMoney.DataPropertyName = "ConsumeMoney";
            this.ColConsumeMoney.HeaderText = "消费金额";
            this.ColConsumeMoney.Name = "ColConsumeMoney";
            this.ColConsumeMoney.ReadOnly = true;
            // 
            // ColAdminName
            // 
            this.ColAdminName.DataPropertyName = "AdminName";
            this.ColAdminName.HeaderText = "收费员";
            this.ColAdminName.Name = "ColAdminName";
            this.ColAdminName.ReadOnly = true;
            // 
            // ColEmployeeName
            // 
            this.ColEmployeeName.DataPropertyName = "EmployeeName";
            this.ColEmployeeName.HeaderText = "接待员工";
            this.ColEmployeeName.Name = "ColEmployeeName";
            this.ColEmployeeName.ReadOnly = true;
            // 
            // ColConsumeTime
            // 
            this.ColConsumeTime.DataPropertyName = "ConsumeTime";
            this.ColConsumeTime.HeaderText = "消费时间";
            this.ColConsumeTime.Name = "ColConsumeTime";
            this.ColConsumeTime.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDetail,
            this.toolStripLabelCount,
            this.toolStripSeparator1,
            this.toolStripButtonOutPut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDetail
            // 
            this.toolStripButtonDetail.Image = global::CRM.Properties.Resources.detail1;
            this.toolStripButtonDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDetail.Name = "toolStripButtonDetail";
            this.toolStripButtonDetail.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonDetail.Text = "明细";
            this.toolStripButtonDetail.Click += new System.EventHandler(this.toolStripButtonDetail_Click);
            // 
            // toolStripLabelCount
            // 
            this.toolStripLabelCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelCount.Name = "toolStripLabelCount";
            this.toolStripLabelCount.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePickerEnd);
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbxAdmin);
            this.groupBox1.Controls.Add(this.cmbxEmployeeName);
            this.groupBox1.Controls.Add(this.cbxUserType);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.txtCardId);
            this.groupBox1.Controls.Add(this.txtConsumeMoney);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "消费查询";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "≈";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Checked = false;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(295, 58);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowCheckBox = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(144, 21);
            this.dateTimePickerEnd.TabIndex = 8;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Checked = false;
            this.dateTimePickerStart.Location = new System.Drawing.Point(86, 58);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowCheckBox = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(139, 21);
            this.dateTimePickerStart.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "消费时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "收费员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "员工姓名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(470, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "手机号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "卡    号";
            // 
            // cmbxAdmin
            // 
            this.cmbxAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAdmin.FormattingEnabled = true;
            this.cmbxAdmin.Location = new System.Drawing.Point(295, 95);
            this.cmbxAdmin.Name = "cmbxAdmin";
            this.cmbxAdmin.Size = new System.Drawing.Size(147, 20);
            this.cmbxAdmin.TabIndex = 3;
            // 
            // cmbxEmployeeName
            // 
            this.cmbxEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxEmployeeName.FormattingEnabled = true;
            this.cmbxEmployeeName.Location = new System.Drawing.Point(85, 94);
            this.cmbxEmployeeName.Name = "cmbxEmployeeName";
            this.cmbxEmployeeName.Size = new System.Drawing.Size(139, 20);
            this.cmbxEmployeeName.TabIndex = 3;
            // 
            // cbxUserType
            // 
            this.cbxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserType.FormattingEnabled = true;
            this.cbxUserType.Location = new System.Drawing.Point(514, 59);
            this.cbxUserType.Name = "cbxUserType";
            this.cbxUserType.Size = new System.Drawing.Size(149, 20);
            this.cbxUserType.TabIndex = 3;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(694, 45);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 53);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "会员类型";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(514, 25);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(149, 21);
            this.txtTel.TabIndex = 1;
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(295, 24);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(144, 21);
            this.txtCardId.TabIndex = 1;
            // 
            // txtConsumeMoney
            // 
            this.txtConsumeMoney.Location = new System.Drawing.Point(515, 97);
            this.txtConsumeMoney.Name = "txtConsumeMoney";
            this.txtConsumeMoney.Size = new System.Drawing.Size(148, 21);
            this.txtConsumeMoney.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "金额不小于";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(86, 24);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(139, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员姓名";
            // 
            // frmConsumeHistory
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsumeHistory";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消费记录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsumeHistory_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxUserType;
        private System.Windows.Forms.TextBox txtCardId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbxEmployeeName;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbxAdmin;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConsumeMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdminName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConsumeTime;
        private System.Windows.Forms.ToolStripButton toolStripButtonDetail;
        private System.Windows.Forms.TextBox txtConsumeMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutPut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTel;
    }
}