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
    partial class frmCardMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardMgr));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgvCardList = new System.Windows.Forms.DataGridView();
            this.ColCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxStatus = new System.Windows.Forms.ComboBox();
            this.txtCardId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCardList
            // 
            this.dgvCardList.AllowUserToAddRows = false;
            this.dgvCardList.AllowUserToDeleteRows = false;
            this.dgvCardList.AllowUserToOrderColumns = true;
            this.dgvCardList.AllowUserToResizeColumns = false;
            this.dgvCardList.AllowUserToResizeRows = false;
            this.dgvCardList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCardList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCardId,
            this.ColStatus,
            this.ColCreateTime});
            this.dgvCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardList.Location = new System.Drawing.Point(8, 167);
            this.dgvCardList.MultiSelect = false;
            this.dgvCardList.Name = "dgvCardList";
            this.dgvCardList.ReadOnly = true;
            this.dgvCardList.RowHeadersVisible = false;
            this.dgvCardList.RowTemplate.Height = 23;
            this.dgvCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCardList.Size = new System.Drawing.Size(596, 296);
            this.dgvCardList.TabIndex = 1;
            // 
            // ColCardId
            // 
            this.ColCardId.DataPropertyName = "CardId";
            this.ColCardId.HeaderText = "卡号";
            this.ColCardId.Name = "ColCardId";
            this.ColCardId.ReadOnly = true;
            // 
            // ColStatus
            // 
            this.ColStatus.DataPropertyName = "status";
            this.ColStatus.HeaderText = "使用状态";
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.ReadOnly = true;
            // 
            // ColCreateTime
            // 
            this.ColCreateTime.DataPropertyName = "CreateTime";
            this.ColCreateTime.HeaderText = "导入时间";
            this.ColCreateTime.Name = "ColCreateTime";
            this.ColCreateTime.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbxStatus);
            this.groupBox2.Controls.Add(this.txtCardId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(8, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存卡查询";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(487, 28);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "使用状态";
            // 
            // cmbxStatus
            // 
            this.cmbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxStatus.FormattingEnabled = true;
            this.cmbxStatus.Items.AddRange(new object[] {
            "",
            "已使用",
            "未使用"});
            this.cmbxStatus.Location = new System.Drawing.Point(299, 30);
            this.cmbxStatus.Name = "cmbxStatus";
            this.cmbxStatus.Size = new System.Drawing.Size(151, 20);
            this.cmbxStatus.TabIndex = 2;
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(61, 30);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(151, 21);
            this.txtCardId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡号";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 14);
            this.panel1.TabIndex = 2;
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.btnImport);
            this.groupbox1.Controls.Add(this.btnSelect);
            this.groupbox1.Controls.Add(this.txtFilePath);
            this.groupbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox1.Location = new System.Drawing.Point(8, 8);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(596, 58);
            this.groupbox1.TabIndex = 0;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "导入卡库";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(487, 20);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(374, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(61, 23);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(297, 21);
            this.txtFilePath.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(8, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 13);
            this.panel2.TabIndex = 3;
            // 
            // frmCardMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 471);
            this.Controls.Add(this.dgvCardList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupbox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCardMgr";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员卡管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCardMgr_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.DataGridView dgvCardList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxStatus;
        private System.Windows.Forms.TextBox txtCardId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreateTime;
        private System.Windows.Forms.Panel panel2;
    }
}