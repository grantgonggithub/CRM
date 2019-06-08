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
    partial class UCCompanyInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboxProvince = new System.Windows.Forms.ComboBox();
            this.txtDetailAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmboxCity = new System.Windows.Forms.ComboBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmboxeare = new System.Windows.Forms.ComboBox();
            this.cmboxroud = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtLeaderName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "省份";
            // 
            // cmboxProvince
            // 
            this.cmboxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxProvince.FormattingEnabled = true;
            this.cmboxProvince.Location = new System.Drawing.Point(109, 83);
            this.cmboxProvince.Name = "cmboxProvince";
            this.cmboxProvince.Size = new System.Drawing.Size(159, 20);
            this.cmboxProvince.TabIndex = 1;
            this.cmboxProvince.SelectedIndexChanged += new System.EventHandler(this.cmboxProvince_SelectedIndexChanged);
            // 
            // txtDetailAddress
            // 
            this.txtDetailAddress.Location = new System.Drawing.Point(110, 151);
            this.txtDetailAddress.Name = "txtDetailAddress";
            this.txtDetailAddress.Size = new System.Drawing.Size(380, 21);
            this.txtDetailAddress.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(253, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmboxCity
            // 
            this.cmboxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxCity.FormattingEnabled = true;
            this.cmboxCity.Location = new System.Drawing.Point(331, 83);
            this.cmboxCity.Name = "cmboxCity";
            this.cmboxCity.Size = new System.Drawing.Size(159, 20);
            this.cmboxCity.TabIndex = 1;
            this.cmboxCity.SelectedIndexChanged += new System.EventHandler(this.cmboxCity_SelectedIndexChanged);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(109, 17);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(381, 21);
            this.txtCompanyName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地市";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "区县";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "乡镇";
            // 
            // cmboxeare
            // 
            this.cmboxeare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxeare.FormattingEnabled = true;
            this.cmboxeare.Location = new System.Drawing.Point(109, 117);
            this.cmboxeare.Name = "cmboxeare";
            this.cmboxeare.Size = new System.Drawing.Size(159, 20);
            this.cmboxeare.TabIndex = 1;
            this.cmboxeare.SelectedIndexChanged += new System.EventHandler(this.cmboxeare_SelectedIndexChanged);
            // 
            // cmboxroud
            // 
            this.cmboxroud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxroud.FormattingEnabled = true;
            this.cmboxroud.Location = new System.Drawing.Point(331, 117);
            this.cmboxroud.Name = "cmboxroud";
            this.cmboxroud.Size = new System.Drawing.Size(159, 20);
            this.cmboxroud.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "详细地址";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "企业名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(341, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "注意：以上信息务必详细准确填写，便于我们及时跟进售后服务";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "联系电话";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(109, 50);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(159, 21);
            this.txtTel.TabIndex = 2;
            // 
            // txtLeaderName
            // 
            this.txtLeaderName.Location = new System.Drawing.Point(331, 50);
            this.txtLeaderName.Name = "txtLeaderName";
            this.txtLeaderName.Size = new System.Drawing.Size(159, 21);
            this.txtLeaderName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "负责人";
            // 
            // UCCompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLeaderName);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtDetailAddress);
            this.Controls.Add(this.cmboxroud);
            this.Controls.Add(this.cmboxeare);
            this.Controls.Add(this.cmboxCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmboxProvince);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCCompanyInfo";
            this.Size = new System.Drawing.Size(566, 281);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboxProvince;
        private System.Windows.Forms.TextBox txtDetailAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmboxCity;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmboxeare;
        private System.Windows.Forms.ComboBox cmboxroud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtLeaderName;
        private System.Windows.Forms.Label label9;
    }
}
