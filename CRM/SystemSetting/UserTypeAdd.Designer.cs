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
    partial class UserTypeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTypeAdd));
            this.ucUserTypeAndEmployeeMgr1 = new CRM.UCUserTypeAndEmployeeMgr();
            this.SuspendLayout();
            // 
            // ucUserTypeAndEmployeeMgr1
            // 
            this.ucUserTypeAndEmployeeMgr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucUserTypeAndEmployeeMgr1.Location = new System.Drawing.Point(0, 0);
            this.ucUserTypeAndEmployeeMgr1.Name = "ucUserTypeAndEmployeeMgr1";
            this.ucUserTypeAndEmployeeMgr1.Size = new System.Drawing.Size(391, 352);
            this.ucUserTypeAndEmployeeMgr1.TabIndex = 0;
            // 
            // UserTypeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 356);
            this.Controls.Add(this.ucUserTypeAndEmployeeMgr1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserTypeAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserTypeAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserTypeAdd_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private UCUserTypeAndEmployeeMgr ucUserTypeAndEmployeeMgr1;
    }
}