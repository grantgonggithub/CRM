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
    partial class frmSystemSetting
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("企业信息设置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("管理员角色管理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("上下班时间");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("会员类型设置");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("员工类型设置");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("数据备份与还原");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("其他设置");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemSetting));
            this.tvList = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvList.HideSelection = false;
            this.tvList.ItemHeight = 30;
            this.tvList.Location = new System.Drawing.Point(0, 0);
            this.tvList.Name = "tvList";
            treeNode1.Name = "节点0";
            treeNode1.Text = "企业信息设置";
            treeNode2.Name = "tnRoleMgr";
            treeNode2.Text = "管理员角色管理";
            treeNode3.Name = "TnWorkTime";
            treeNode3.Text = "上下班时间";
            treeNode4.Name = "节点0";
            treeNode4.Text = "会员类型设置";
            treeNode5.Name = "节点1";
            treeNode5.Text = "员工类型设置";
            treeNode6.Name = "节点0";
            treeNode6.Text = "数据备份与还原";
            treeNode7.Name = "节点0";
            treeNode7.Text = "其他设置";
            this.tvList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.tvList.Size = new System.Drawing.Size(212, 497);
            this.tvList.TabIndex = 0;
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(212, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(6);
            this.panelRight.Size = new System.Drawing.Size(598, 497);
            this.panelRight.TabIndex = 1;
            // 
            // frmSystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 497);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.tvList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSystemSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSystemSetting_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.Panel panelRight;


    }
}