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
    partial class UCBackAndReBack
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
            this.panelAutoBack = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.dateTimePickerAutoTime = new System.Windows.Forms.DateTimePicker();
            this.radioButtonAutoBackUp = new System.Windows.Forms.RadioButton();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.radioButtonMenueBackUp = new System.Windows.Forms.RadioButton();
            this.btnBrower = new System.Windows.Forms.Button();
            this.txtBackUpPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReStore = new System.Windows.Forms.TextBox();
            this.btnReStore = new System.Windows.Forms.Button();
            this.btnBrower1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panelAutoBack.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelAutoBack);
            this.groupBox1.Controls.Add(this.radioButtonAutoBackUp);
            this.groupBox1.Controls.Add(this.btnBackUp);
            this.groupBox1.Controls.Add(this.radioButtonMenueBackUp);
            this.groupBox1.Controls.Add(this.btnBrower);
            this.groupBox1.Controls.Add(this.txtBackUpPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据备份";
            // 
            // panelAutoBack
            // 
            this.panelAutoBack.Controls.Add(this.btnSave);
            this.panelAutoBack.Controls.Add(this.dateTimePickerAutoTime);
            this.panelAutoBack.Location = new System.Drawing.Point(202, 72);
            this.panelAutoBack.Name = "panelAutoBack";
            this.panelAutoBack.Size = new System.Drawing.Size(338, 33);
            this.panelAutoBack.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTimePickerAutoTime
            // 
            this.dateTimePickerAutoTime.CustomFormat = "HH时mm分";
            this.dateTimePickerAutoTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAutoTime.Location = new System.Drawing.Point(41, 6);
            this.dateTimePickerAutoTime.Name = "dateTimePickerAutoTime";
            this.dateTimePickerAutoTime.ShowUpDown = true;
            this.dateTimePickerAutoTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerAutoTime.TabIndex = 4;
            // 
            // radioButtonAutoBackUp
            // 
            this.radioButtonAutoBackUp.AutoSize = true;
            this.radioButtonAutoBackUp.Location = new System.Drawing.Point(128, 81);
            this.radioButtonAutoBackUp.Name = "radioButtonAutoBackUp";
            this.radioButtonAutoBackUp.Size = new System.Drawing.Size(71, 16);
            this.radioButtonAutoBackUp.TabIndex = 3;
            this.radioButtonAutoBackUp.TabStop = true;
            this.radioButtonAutoBackUp.Text = "自动备份";
            this.radioButtonAutoBackUp.UseVisualStyleBackColor = true;
            this.radioButtonAutoBackUp.CheckedChanged += new System.EventHandler(this.radioButtonAutoBackUp_CheckedChanged);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(465, 118);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 23);
            this.btnBackUp.TabIndex = 6;
            this.btnBackUp.Text = "开始备份";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // radioButtonMenueBackUp
            // 
            this.radioButtonMenueBackUp.AutoSize = true;
            this.radioButtonMenueBackUp.Location = new System.Drawing.Point(128, 118);
            this.radioButtonMenueBackUp.Name = "radioButtonMenueBackUp";
            this.radioButtonMenueBackUp.Size = new System.Drawing.Size(71, 16);
            this.radioButtonMenueBackUp.TabIndex = 3;
            this.radioButtonMenueBackUp.TabStop = true;
            this.radioButtonMenueBackUp.Text = "手动备份";
            this.radioButtonMenueBackUp.UseVisualStyleBackColor = true;
            this.radioButtonMenueBackUp.CheckedChanged += new System.EventHandler(this.radioButtonMenueBackUp_CheckedChanged);
            // 
            // btnBrower
            // 
            this.btnBrower.Location = new System.Drawing.Point(465, 37);
            this.btnBrower.Name = "btnBrower";
            this.btnBrower.Size = new System.Drawing.Size(75, 23);
            this.btnBrower.TabIndex = 2;
            this.btnBrower.Text = "浏览";
            this.btnBrower.UseVisualStyleBackColor = true;
            this.btnBrower.Click += new System.EventHandler(this.btnBrower_Click);
            // 
            // txtBackUpPath
            // 
            this.txtBackUpPath.Location = new System.Drawing.Point(131, 37);
            this.txtBackUpPath.Name = "txtBackUpPath";
            this.txtBackUpPath.ReadOnly = true;
            this.txtBackUpPath.Size = new System.Drawing.Size(312, 21);
            this.txtBackUpPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "备份到这里";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReStore);
            this.groupBox2.Controls.Add(this.btnReStore);
            this.groupBox2.Controls.Add(this.btnBrower1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(10, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 122);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据还原";
            // 
            // txtReStore
            // 
            this.txtReStore.Location = new System.Drawing.Point(131, 52);
            this.txtReStore.Name = "txtReStore";
            this.txtReStore.ReadOnly = true;
            this.txtReStore.Size = new System.Drawing.Size(229, 21);
            this.txtReStore.TabIndex = 1;
            // 
            // btnReStore
            // 
            this.btnReStore.Location = new System.Drawing.Point(465, 51);
            this.btnReStore.Name = "btnReStore";
            this.btnReStore.Size = new System.Drawing.Size(75, 23);
            this.btnReStore.TabIndex = 2;
            this.btnReStore.Text = "开始还原";
            this.btnReStore.UseVisualStyleBackColor = true;
            this.btnReStore.Click += new System.EventHandler(this.btnReStore_Click);
            // 
            // btnBrower1
            // 
            this.btnBrower1.Location = new System.Drawing.Point(368, 51);
            this.btnBrower1.Name = "btnBrower1";
            this.btnBrower1.Size = new System.Drawing.Size(75, 23);
            this.btnBrower1.TabIndex = 2;
            this.btnBrower1.Text = "浏览";
            this.btnBrower1.UseVisualStyleBackColor = true;
            this.btnBrower1.Click += new System.EventHandler(this.btnBrower1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "从这里还原";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 15);
            this.panel1.TabIndex = 1;
            // 
            // UCBackAndReBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCBackAndReBack";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(649, 340);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelAutoBack.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonAutoBackUp;
        private System.Windows.Forms.RadioButton radioButtonMenueBackUp;
        private System.Windows.Forms.Button btnBrower;
        private System.Windows.Forms.TextBox txtBackUpPath;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerAutoTime;
        private System.Windows.Forms.Panel panelAutoBack;
        private System.Windows.Forms.TextBox txtReStore;
        private System.Windows.Forms.Button btnReStore;
        private System.Windows.Forms.Button btnBrower1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
