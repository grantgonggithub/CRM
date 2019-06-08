/*----------------------------------------------------------------
Copyright (C) 2014 宏图会员管理系统（Grant 巩建春）

项目名称： 宏图会员管理系统
创建者：   grant (巩建春 emaill : nnn987@126.com ; QQ:406333743;Tel:+86 15619212255)
CLR版本：  4.0.30319.42000
时间：     2014/8/28 18:16:22

功能描述：本软件为本人业余时间所写，其所有源码都可以进行免费的学习交流，切勿用于商业用途

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM
{
    public partial class frmSystemSetting : skinBase
    {
        public frmSystemSetting()
        {
            InitializeComponent();
            tvList.SelectedNode = tvList.Nodes[0];
        }

        public frmSystemSetting(string txt)
        {
            InitializeComponent();
            foreach (TreeNode node in tvList.Nodes)
            { 
                if(node.Text==txt)
                {
                    tvList.SelectedNode = node;
                    break;
                }
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tvList.SelectedNode;
            if (node == null) return;
            Control cnt = null;
            switch (node.Text)
            {
                case "管理员角色管理":
                    cnt = new UCRoleSetting();
                    break;
                case "上下班时间":
                    cnt = new UcWorkTime();
                    break;
                case "数据备份与还原":
                    cnt = new UCBackAndReBack();
                    break;
                case "会员类型设置":
                    cnt =new UCUserTypeAndEmployeeMgr(1);
                    break;
                case "员工类型设置":
                    cnt = new UCUserTypeAndEmployeeMgr(2);
                    break;
                case "企业信息设置":
                    cnt = new UCCompanyInfo();
                    break;
                case "其他设置":
                    cnt = new UCOtherSetting();
                    break;
                default:
                    break;
            }
            if (cnt == null) return;
            panelRight.Controls.Clear();
            cnt.Dock = DockStyle.Fill;
            cnt.BringToFront();
            panelRight.Controls.Add(cnt);
        }

        private void frmSystemSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
