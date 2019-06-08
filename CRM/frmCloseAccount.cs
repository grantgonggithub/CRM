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
    public partial class frmCloseAccount : skinBase
    {
        /// <summary>
        /// 在这里必须保证是用户sn，而不是员工
        /// </summary>
        public uint sn;
        public frmCloseAccount()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ucUserInfo1.btnOk_Click(sender, e);
            DataRow row = ucUserInfo1.Row;
            if (row == null) return;
            if (row["VipCardId"] == null || row["VipCardId"].ToString() == "")
            {
                MessageBox.Show("用户信息不完整，无法进行结账");
                return;
            }
            sn = uint.Parse(row["VipCardId"].ToString());
            this.DialogResult = DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCloseAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.TxtBoxCardId = null;
        }
    }
}
