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
using Tools;

namespace CRM
{
    public partial class UCUserInfo : UserControl
    {
        public DataRow Row;
        public UCUserInfo()
        {
            InitializeComponent();
            CommStatic.TxtBoxCardId = txtCardId;
            txtUserName.Focus();
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                string cardId = txtCardId.Text;
                string tel = txtTel.Text;
                Row = null;//清掉上一次
                if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(cardId) && string.IsNullOrEmpty(tel))
                {
                    MessageBox.Show("请至少输入一项信息！");
                    return;
                }
                string sql = "select * from User where 1=1 ";
                if (!string.IsNullOrEmpty(userName))
                    sql += " and UserName='" + userName + "'";
                if (!string.IsNullOrEmpty(cardId))
                    sql += " and VipCardId='" + cardId + "'";
                if (!string.IsNullOrEmpty(tel))
                    sql += " and Tel='" + tel + "'";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("没有找到和输入信息完全匹配的用户，请再次核对输入信息");
                    return;
                }
                Row = ds.Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCUserInfo));
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtCardId.Text = "";
            txtTel.Text = "";
            txtUserName.Text = "";
        }
    }
}
