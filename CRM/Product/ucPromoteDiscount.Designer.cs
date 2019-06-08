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
    partial class ucPromoteDiscount
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveTimeSpan = new System.Windows.Forms.Button();
            this.panelDayPart = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.radioButtonTimeSpan = new System.Windows.Forms.RadioButton();
            this.txtDiscountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ColPromoteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMarketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiscountTimeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonDay = new System.Windows.Forms.RadioButton();
            this.txtDateSelected = new System.Windows.Forms.TextBox();
            this.pictureBoxShowDatePic = new System.Windows.Forms.PictureBox();
            this.panelDay = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.ucCommProductPrice1 = new CRM.ucCommProductPrice();
            this.groupBox1.SuspendLayout();
            this.panelDayPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowDatePic)).BeginInit();
            this.panelDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveTimeSpan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panelDayPart);
            this.groupBox1.Controls.Add(this.panelDay);
            this.groupBox1.Controls.Add(this.radioButtonTimeSpan);
            this.groupBox1.Controls.Add(this.radioButtonDay);
            this.groupBox1.Controls.Add(this.txtDiscountName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 589);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "促销时间";
            // 
            // btnSaveTimeSpan
            // 
            this.btnSaveTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveTimeSpan.Location = new System.Drawing.Point(623, 79);
            this.btnSaveTimeSpan.Name = "btnSaveTimeSpan";
            this.btnSaveTimeSpan.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTimeSpan.TabIndex = 7;
            this.btnSaveTimeSpan.Text = "保存";
            this.btnSaveTimeSpan.UseVisualStyleBackColor = true;
            this.btnSaveTimeSpan.Click += new System.EventHandler(this.btnSaveTimeSpan_Click);
            // 
            // panelDayPart
            // 
            this.panelDayPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelDayPart.Controls.Add(this.label5);
            this.panelDayPart.Controls.Add(this.dateTimePickerEnd);
            this.panelDayPart.Controls.Add(this.dateTimePickerStart);
            this.panelDayPart.Location = new System.Drawing.Point(152, 78);
            this.panelDayPart.Name = "panelDayPart";
            this.panelDayPart.Size = new System.Drawing.Size(438, 26);
            this.panelDayPart.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "≈";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "yyyy年MM月dd日";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(232, 2);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerEnd.TabIndex = 0;
            this.dateTimePickerEnd.Value = new System.DateTime(2014, 7, 11, 0, 0, 0, 0);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "yyyy年MM月dd日";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(2, 2);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerStart.TabIndex = 0;
            this.dateTimePickerStart.Value = new System.DateTime(2014, 7, 11, 0, 0, 0, 0);
            // 
            // radioButtonTimeSpan
            // 
            this.radioButtonTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonTimeSpan.AutoSize = true;
            this.radioButtonTimeSpan.Checked = true;
            this.radioButtonTimeSpan.Location = new System.Drawing.Point(60, 84);
            this.radioButtonTimeSpan.Name = "radioButtonTimeSpan";
            this.radioButtonTimeSpan.Size = new System.Drawing.Size(83, 16);
            this.radioButtonTimeSpan.TabIndex = 2;
            this.radioButtonTimeSpan.TabStop = true;
            this.radioButtonTimeSpan.Text = "按时段促销";
            this.radioButtonTimeSpan.UseVisualStyleBackColor = true;
            this.radioButtonTimeSpan.Click += new System.EventHandler(this.radioButtonTimeSpan_CheckedChanged);
            // 
            // txtDiscountName
            // 
            this.txtDiscountName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiscountName.Location = new System.Drawing.Point(154, 27);
            this.txtDiscountName.Name = "txtDiscountName";
            this.txtDiscountName.Size = new System.Drawing.Size(200, 21);
            this.txtDiscountName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "促销名称";
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
            this.ColPromoteName,
            this.ColMarketPrice,
            this.ColDiscountTimeType});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvList.Location = new System.Drawing.Point(0, 21);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(874, 193);
            this.dgvList.TabIndex = 6;
            this.dgvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseDoubleClick);
            // 
            // ColPromoteName
            // 
            this.ColPromoteName.DataPropertyName = "DiscountName";
            this.ColPromoteName.HeaderText = "促销名称";
            this.ColPromoteName.Name = "ColPromoteName";
            this.ColPromoteName.ReadOnly = true;
            // 
            // ColMarketPrice
            // 
            this.ColMarketPrice.DataPropertyName = "MarketPrice";
            this.ColMarketPrice.HeaderText = "基本价格";
            this.ColMarketPrice.Name = "ColMarketPrice";
            this.ColMarketPrice.ReadOnly = true;
            // 
            // ColDiscountTimeType
            // 
            this.ColDiscountTimeType.DataPropertyName = "DiscountTime";
            this.ColDiscountTimeType.HeaderText = "促销时间";
            this.ColDiscountTimeType.Name = "ColDiscountTimeType";
            this.ColDiscountTimeType.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 21);
            this.panel2.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddNew,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(874, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddNew
            // 
            this.toolStripButtonAddNew.Image = global::CRM.Properties.Resources.png_0084;
            this.toolStripButtonAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddNew.Name = "toolStripButtonAddNew";
            this.toolStripButtonAddNew.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonAddNew.Text = "新增促销价格";
            this.toolStripButtonAddNew.Click += new System.EventHandler(this.toolStripButtonAddNew_Click);
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
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::CRM.Properties.Resources.png_0652;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonDelete.Text = "删除";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 578);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 11);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 10);
            this.panel3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(388, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 61);
            this.label2.TabIndex = 6;
            this.label2.Text = "1、给本次促销起个名称，便于和其他促销计划区分，如“5月1日促销”；\r\n2、\"促销时间\"是指这个促销的起止日期，如果只有一天，起止日期相同；\r\n3、促销计划必须前" +
                "一天设置，第二天生效。\r\n";
            // 
            // radioButtonDay
            // 
            this.radioButtonDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonDay.AutoSize = true;
            this.radioButtonDay.Location = new System.Drawing.Point(60, 53);
            this.radioButtonDay.Name = "radioButtonDay";
            this.radioButtonDay.Size = new System.Drawing.Size(71, 16);
            this.radioButtonDay.TabIndex = 2;
            this.radioButtonDay.Text = "按天促销";
            this.radioButtonDay.UseVisualStyleBackColor = true;
            this.radioButtonDay.Click += new System.EventHandler(this.radioButtonDay_CheckedChanged);
            // 
            // txtDateSelected
            // 
            this.txtDateSelected.Location = new System.Drawing.Point(2, 2);
            this.txtDateSelected.Name = "txtDateSelected";
            this.txtDateSelected.Size = new System.Drawing.Size(200, 21);
            this.txtDateSelected.TabIndex = 0;
            // 
            // pictureBoxShowDatePic
            // 
            this.pictureBoxShowDatePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxShowDatePic.Image = global::CRM.Properties.Resources.monthCalendar;
            this.pictureBoxShowDatePic.Location = new System.Drawing.Point(210, 0);
            this.pictureBoxShowDatePic.Name = "pictureBoxShowDatePic";
            this.pictureBoxShowDatePic.Size = new System.Drawing.Size(26, 24);
            this.pictureBoxShowDatePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShowDatePic.TabIndex = 1;
            this.pictureBoxShowDatePic.TabStop = false;
            this.pictureBoxShowDatePic.Click += new System.EventHandler(this.pictureBoxShowDatePic_Click);
            // 
            // panelDay
            // 
            this.panelDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelDay.Controls.Add(this.pictureBoxShowDatePic);
            this.panelDay.Controls.Add(this.txtDateSelected);
            this.panelDay.Location = new System.Drawing.Point(152, 49);
            this.panelDay.Name = "panelDay";
            this.panelDay.Size = new System.Drawing.Size(238, 26);
            this.panelDay.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.monthCalendar1.Location = new System.Drawing.Point(394, 480);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // ucCommProductPrice1
            // 
            this.ucCommProductPrice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCommProductPrice1.Location = new System.Drawing.Point(0, 224);
            this.ucCommProductPrice1.Name = "ucCommProductPrice1";
            this.ucCommProductPrice1.Size = new System.Drawing.Size(874, 354);
            this.ucCommProductPrice1.TabIndex = 1;
            // 
            // ucPromoteDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.ucCommProductPrice1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.panel2);
            this.Name = "ucPromoteDiscount";
            this.Size = new System.Drawing.Size(874, 714);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelDayPart.ResumeLayout(false);
            this.panelDayPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowDatePic)).EndInit();
            this.panelDay.ResumeLayout(false);
            this.panelDay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTimeSpan;
        private System.Windows.Forms.TextBox txtDiscountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDayPart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveTimeSpan;
        private ucCommProductPrice ucCommProductPrice1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPromoteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMarketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiscountTimeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDay;
        private System.Windows.Forms.PictureBox pictureBoxShowDatePic;
        private System.Windows.Forms.TextBox txtDateSelected;
        private System.Windows.Forms.RadioButton radioButtonDay;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
