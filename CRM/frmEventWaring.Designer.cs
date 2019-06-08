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
    partial class frmEventWaring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventWaring));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelWaringEveryMoth = new System.Windows.Forms.Panel();
            this.dateTimePickerWaringMothTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbxWaringMothDate = new System.Windows.Forms.ComboBox();
            this.panelWaringEveryWeek = new System.Windows.Forms.Panel();
            this.dateTimePickerWaringWeekTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbxWaringWeek = new System.Windows.Forms.ComboBox();
            this.panelWaringEveryDate = new System.Windows.Forms.Panel();
            this.dateTimePickerEveryDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panelWaringOneTime = new System.Windows.Forms.Panel();
            this.dateTimePickerOneDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWaringContent = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxWaringType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ColWaringTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWaringType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWaringContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWaringDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWaringCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWaringExprie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonOutPut = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelWaringEveryMoth.SuspendLayout();
            this.panelWaringEveryWeek.SuspendLayout();
            this.panelWaringEveryDate.SuspendLayout();
            this.panelWaringOneTime.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panelWaringEveryMoth);
            this.groupBox1.Controls.Add(this.panelWaringEveryWeek);
            this.groupBox1.Controls.Add(this.panelWaringEveryDate);
            this.groupBox1.Controls.Add(this.panelWaringOneTime);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 238);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 38);
            this.panel3.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(421, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "清空";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(209, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelWaringEveryMoth
            // 
            this.panelWaringEveryMoth.Controls.Add(this.dateTimePickerWaringMothTime);
            this.panelWaringEveryMoth.Controls.Add(this.label8);
            this.panelWaringEveryMoth.Controls.Add(this.label9);
            this.panelWaringEveryMoth.Controls.Add(this.cmbxWaringMothDate);
            this.panelWaringEveryMoth.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWaringEveryMoth.Location = new System.Drawing.Point(3, 207);
            this.panelWaringEveryMoth.Name = "panelWaringEveryMoth";
            this.panelWaringEveryMoth.Size = new System.Drawing.Size(712, 31);
            this.panelWaringEveryMoth.TabIndex = 5;
            // 
            // dateTimePickerWaringMothTime
            // 
            this.dateTimePickerWaringMothTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerWaringMothTime.CustomFormat = "HH时mm分";
            this.dateTimePickerWaringMothTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWaringMothTime.Location = new System.Drawing.Point(432, 4);
            this.dateTimePickerWaringMothTime.Name = "dateTimePickerWaringMothTime";
            this.dateTimePickerWaringMothTime.ShowUpDown = true;
            this.dateTimePickerWaringMothTime.Size = new System.Drawing.Size(135, 21);
            this.dateTimePickerWaringMothTime.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "时    间";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "日    期";
            // 
            // cmbxWaringMothDate
            // 
            this.cmbxWaringMothDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxWaringMothDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxWaringMothDate.FormattingEnabled = true;
            this.cmbxWaringMothDate.Location = new System.Drawing.Point(186, 3);
            this.cmbxWaringMothDate.Name = "cmbxWaringMothDate";
            this.cmbxWaringMothDate.Size = new System.Drawing.Size(133, 20);
            this.cmbxWaringMothDate.TabIndex = 8;
            // 
            // panelWaringEveryWeek
            // 
            this.panelWaringEveryWeek.Controls.Add(this.dateTimePickerWaringWeekTime);
            this.panelWaringEveryWeek.Controls.Add(this.label7);
            this.panelWaringEveryWeek.Controls.Add(this.label6);
            this.panelWaringEveryWeek.Controls.Add(this.cmbxWaringWeek);
            this.panelWaringEveryWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWaringEveryWeek.Location = new System.Drawing.Point(3, 176);
            this.panelWaringEveryWeek.Name = "panelWaringEveryWeek";
            this.panelWaringEveryWeek.Size = new System.Drawing.Size(712, 31);
            this.panelWaringEveryWeek.TabIndex = 4;
            // 
            // dateTimePickerWaringWeekTime
            // 
            this.dateTimePickerWaringWeekTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerWaringWeekTime.CustomFormat = "HH时mm分";
            this.dateTimePickerWaringWeekTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWaringWeekTime.Location = new System.Drawing.Point(432, 3);
            this.dateTimePickerWaringWeekTime.Name = "dateTimePickerWaringWeekTime";
            this.dateTimePickerWaringWeekTime.ShowUpDown = true;
            this.dateTimePickerWaringWeekTime.Size = new System.Drawing.Size(135, 21);
            this.dateTimePickerWaringWeekTime.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(376, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "时    间";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "星    期";
            // 
            // cmbxWaringWeek
            // 
            this.cmbxWaringWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxWaringWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxWaringWeek.FormattingEnabled = true;
            this.cmbxWaringWeek.Items.AddRange(new object[] {
            "",
            "周一",
            "周二",
            "周三",
            "周四",
            "周五",
            "周六",
            "周日"});
            this.cmbxWaringWeek.Location = new System.Drawing.Point(186, 3);
            this.cmbxWaringWeek.Name = "cmbxWaringWeek";
            this.cmbxWaringWeek.Size = new System.Drawing.Size(133, 20);
            this.cmbxWaringWeek.TabIndex = 6;
            // 
            // panelWaringEveryDate
            // 
            this.panelWaringEveryDate.Controls.Add(this.dateTimePickerEveryDate);
            this.panelWaringEveryDate.Controls.Add(this.label5);
            this.panelWaringEveryDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWaringEveryDate.Location = new System.Drawing.Point(3, 145);
            this.panelWaringEveryDate.Name = "panelWaringEveryDate";
            this.panelWaringEveryDate.Size = new System.Drawing.Size(712, 31);
            this.panelWaringEveryDate.TabIndex = 3;
            // 
            // dateTimePickerEveryDate
            // 
            this.dateTimePickerEveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEveryDate.CustomFormat = "HH时mm分";
            this.dateTimePickerEveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEveryDate.Location = new System.Drawing.Point(186, 4);
            this.dateTimePickerEveryDate.Name = "dateTimePickerEveryDate";
            this.dateTimePickerEveryDate.ShowUpDown = true;
            this.dateTimePickerEveryDate.Size = new System.Drawing.Size(187, 21);
            this.dateTimePickerEveryDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "提醒时间";
            // 
            // panelWaringOneTime
            // 
            this.panelWaringOneTime.Controls.Add(this.dateTimePickerOneDate);
            this.panelWaringOneTime.Controls.Add(this.label4);
            this.panelWaringOneTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWaringOneTime.Location = new System.Drawing.Point(3, 114);
            this.panelWaringOneTime.Name = "panelWaringOneTime";
            this.panelWaringOneTime.Size = new System.Drawing.Size(712, 31);
            this.panelWaringOneTime.TabIndex = 2;
            // 
            // dateTimePickerOneDate
            // 
            this.dateTimePickerOneDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerOneDate.CustomFormat = "yyyy年MM月dd日 HH时mm分";
            this.dateTimePickerOneDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOneDate.Location = new System.Drawing.Point(186, 4);
            this.dateTimePickerOneDate.Name = "dateTimePickerOneDate";
            this.dateTimePickerOneDate.Size = new System.Drawing.Size(187, 21);
            this.dateTimePickerOneDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "提醒时间";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtWaringContent);
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbxWaringType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 97);
            this.panel2.TabIndex = 1;
            // 
            // txtWaringContent
            // 
            this.txtWaringContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWaringContent.Location = new System.Drawing.Point(186, 36);
            this.txtWaringContent.Multiline = true;
            this.txtWaringContent.Name = "txtWaringContent";
            this.txtWaringContent.Size = new System.Drawing.Size(381, 53);
            this.txtWaringContent.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(186, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(136, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "提醒内容";
            // 
            // cmbxWaringType
            // 
            this.cmbxWaringType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxWaringType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxWaringType.FormattingEnabled = true;
            this.cmbxWaringType.Items.AddRange(new object[] {
            "一次提醒",
            "每日提醒",
            "每周提醒",
            "每月提醒"});
            this.cmbxWaringType.Location = new System.Drawing.Point(429, 5);
            this.cmbxWaringType.Name = "cmbxWaringType";
            this.cmbxWaringType.Size = new System.Drawing.Size(138, 20);
            this.cmbxWaringType.TabIndex = 2;
            this.cmbxWaringType.SelectedIndexChanged += new System.EventHandler(this.cmbxWaringType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "提醒类型";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "提醒标题";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvList);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 337);
            this.panel1.TabIndex = 1;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColWaringTitle,
            this.ColWaringType,
            this.ColWaringContent,
            this.ColWaringDateTime,
            this.ColAddTime,
            this.ColWaringCount,
            this.ColWaringExprie});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 25);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(718, 312);
            this.dgvList.TabIndex = 1;
            // 
            // ColWaringTitle
            // 
            this.ColWaringTitle.DataPropertyName = "WaringTitle";
            this.ColWaringTitle.HeaderText = "标题";
            this.ColWaringTitle.Name = "ColWaringTitle";
            this.ColWaringTitle.ReadOnly = true;
            // 
            // ColWaringType
            // 
            this.ColWaringType.DataPropertyName = "WaringTypeName";
            this.ColWaringType.HeaderText = "类型";
            this.ColWaringType.Name = "ColWaringType";
            this.ColWaringType.ReadOnly = true;
            // 
            // ColWaringContent
            // 
            this.ColWaringContent.DataPropertyName = "EventContent";
            this.ColWaringContent.HeaderText = "提醒内容";
            this.ColWaringContent.Name = "ColWaringContent";
            this.ColWaringContent.ReadOnly = true;
            // 
            // ColWaringDateTime
            // 
            this.ColWaringDateTime.DataPropertyName = "WaringDateTime";
            this.ColWaringDateTime.HeaderText = "提醒时间";
            this.ColWaringDateTime.Name = "ColWaringDateTime";
            this.ColWaringDateTime.ReadOnly = true;
            // 
            // ColAddTime
            // 
            this.ColAddTime.DataPropertyName = "CreateTime";
            this.ColAddTime.HeaderText = "添加时间";
            this.ColAddTime.Name = "ColAddTime";
            this.ColAddTime.ReadOnly = true;
            // 
            // ColWaringCount
            // 
            this.ColWaringCount.DataPropertyName = "WaringCount";
            this.ColWaringCount.HeaderText = "提醒次数";
            this.ColWaringCount.Name = "ColWaringCount";
            this.ColWaringCount.ReadOnly = true;
            // 
            // ColWaringExprie
            // 
            this.ColWaringExprie.DataPropertyName = "Expired";
            this.ColWaringExprie.HeaderText = "状态";
            this.ColWaringExprie.Name = "ColWaringExprie";
            this.ColWaringExprie.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddNew,
            this.toolStripSeparator1,
            this.toolStripButtonDelete,
            this.toolStripSeparator2,
            this.toolStripButtonOutPut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(718, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::CRM.Properties.Resources.png_0652;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonDelete.Text = "删除";
            this.toolStripButtonDelete.ToolTipText = "删除";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // frmEventWaring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 528);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEventWaring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "事件提醒管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEventWaring_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelWaringEveryMoth.ResumeLayout(false);
            this.panelWaringEveryMoth.PerformLayout();
            this.panelWaringEveryWeek.ResumeLayout(false);
            this.panelWaringEveryWeek.PerformLayout();
            this.panelWaringEveryDate.ResumeLayout(false);
            this.panelWaringEveryDate.PerformLayout();
            this.panelWaringOneTime.ResumeLayout(false);
            this.panelWaringOneTime.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox cmbxWaringType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWaringContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelWaringOneTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerOneDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelWaringEveryDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelWaringEveryWeek;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbxWaringWeek;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelWaringEveryMoth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbxWaringMothDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerEveryDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerWaringWeekTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerWaringMothTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWaringTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWaringType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWaringContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWaringDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWaringCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWaringExprie;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutPut;
    }
}