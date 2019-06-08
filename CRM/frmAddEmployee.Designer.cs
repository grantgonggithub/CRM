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
    partial class frmAddEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEmployee));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.radioButtonWen = new System.Windows.Forms.RadioButton();
            this.cbxUserType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardId = new System.Windows.Forms.TextBox();
            this.radioButtonMan = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerBithDay = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBoxAddUserType = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonStop = new System.Windows.Forms.RadioButton();
            this.radioButtonOK = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmployeeNum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddUserType)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓   名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(222, 21);
            this.txtName.TabIndex = 1;
            // 
            // radioButtonWen
            // 
            this.radioButtonWen.AutoSize = true;
            this.radioButtonWen.Location = new System.Drawing.Point(213, 175);
            this.radioButtonWen.Name = "radioButtonWen";
            this.radioButtonWen.Size = new System.Drawing.Size(35, 16);
            this.radioButtonWen.TabIndex = 5;
            this.radioButtonWen.Text = "女";
            this.radioButtonWen.UseVisualStyleBackColor = true;
            // 
            // cbxUserType
            // 
            this.cbxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserType.FormattingEnabled = true;
            this.cbxUserType.Location = new System.Drawing.Point(78, 245);
            this.cbxUserType.Name = "cbxUserType";
            this.cbxUserType.Size = new System.Drawing.Size(222, 20);
            this.cbxUserType.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(67, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "卡   号";
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(78, 62);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.ReadOnly = true;
            this.txtCardId.Size = new System.Drawing.Size(222, 21);
            this.txtCardId.TabIndex = 2;
            // 
            // radioButtonMan
            // 
            this.radioButtonMan.AutoSize = true;
            this.radioButtonMan.Checked = true;
            this.radioButtonMan.Location = new System.Drawing.Point(102, 175);
            this.radioButtonMan.Name = "radioButtonMan";
            this.radioButtonMan.Size = new System.Drawing.Size(35, 16);
            this.radioButtonMan.TabIndex = 4;
            this.radioButtonMan.TabStop = true;
            this.radioButtonMan.Text = "男";
            this.radioButtonMan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "电   话";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(78, 138);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(222, 21);
            this.txtTel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "性   别";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "住   址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(78, 206);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(222, 21);
            this.txtAddress.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "员工类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "生   日";
            // 
            // dateTimePickerBithDay
            // 
            this.dateTimePickerBithDay.Location = new System.Drawing.Point(78, 281);
            this.dateTimePickerBithDay.Name = "dateTimePickerBithDay";
            this.dateTimePickerBithDay.Size = new System.Drawing.Size(222, 21);
            this.dateTimePickerBithDay.TabIndex = 8;
            this.dateTimePickerBithDay.Value = new System.DateTime(2014, 7, 8, 0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "清空";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBoxAddUserType
            // 
            this.pictureBoxAddUserType.Image = global::CRM.Properties.Resources.png_0084;
            this.pictureBoxAddUserType.Location = new System.Drawing.Point(307, 245);
            this.pictureBoxAddUserType.Name = "pictureBoxAddUserType";
            this.pictureBoxAddUserType.Size = new System.Drawing.Size(18, 19);
            this.pictureBoxAddUserType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAddUserType.TabIndex = 7;
            this.pictureBoxAddUserType.TabStop = false;
            this.pictureBoxAddUserType.Click += new System.EventHandler(this.pictureBoxAddUserType_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "状   态";
            // 
            // radioButtonStop
            // 
            this.radioButtonStop.AutoSize = true;
            this.radioButtonStop.Location = new System.Drawing.Point(131, 8);
            this.radioButtonStop.Name = "radioButtonStop";
            this.radioButtonStop.Size = new System.Drawing.Size(47, 16);
            this.radioButtonStop.TabIndex = 5;
            this.radioButtonStop.Text = "停用";
            this.radioButtonStop.UseVisualStyleBackColor = true;
            // 
            // radioButtonOK
            // 
            this.radioButtonOK.AutoSize = true;
            this.radioButtonOK.Checked = true;
            this.radioButtonOK.Location = new System.Drawing.Point(20, 8);
            this.radioButtonOK.Name = "radioButtonOK";
            this.radioButtonOK.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOK.TabIndex = 4;
            this.radioButtonOK.TabStop = true;
            this.radioButtonOK.Text = "启用";
            this.radioButtonOK.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonOK);
            this.panel1.Controls.Add(this.radioButtonStop);
            this.panel1.Location = new System.Drawing.Point(80, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 32);
            this.panel1.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "员工编号";
            // 
            // txtEmployeeNum
            // 
            this.txtEmployeeNum.Location = new System.Drawing.Point(78, 100);
            this.txtEmployeeNum.Name = "txtEmployeeNum";
            this.txtEmployeeNum.Size = new System.Drawing.Size(222, 21);
            this.txtEmployeeNum.TabIndex = 3;
            // 
            // frmAddEmployee
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 414);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxAddUserType);
            this.Controls.Add(this.dateTimePickerBithDay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxUserType);
            this.Controls.Add(this.radioButtonMan);
            this.Controls.Add(this.radioButtonWen);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmployeeNum);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCardId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddEmployee_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddUserType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton radioButtonWen;
        private System.Windows.Forms.ComboBox cbxUserType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonMan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerBithDay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBoxAddUserType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonStop;
        private System.Windows.Forms.RadioButton radioButtonOK;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtCardId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmployeeNum;
    }
}