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
    public partial class frmRechargecs : skinBase
    {
        private DataRow row;
        public uint sn;
        public frmRechargecs()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            ucUserInfo1.btnOk_Click(sender, e);
            this.row = ucUserInfo1.Row;
            if (this.row == null)
            {
                clear();
                return;
            }
            txtCardId.Text = row["VipCardId"] == null ? "" : row["VipCardId"].ToString();
            txtCountMoney.Text = row["Money"] == null ? "" : row["Money"].ToString();
            txtSex.Text = (row["Sex"] == null ? "" : row["Sex"].ToString())=="1"?"男":"女";
            txtStatus.Text = (row["Active"] == null ? "" : row["Active"].ToString()) == "1" ? "启用" : "停用";
            txtTel.Text = row["Tel"] == null ? "" : row["Tel"].ToString();
            txtUserName.Text = row["UserName"] == null ? "" : row["UserName"].ToString();
            sn = uint.Parse(row["VipCardId"].ToString());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.row == null)
                {
                    MessageBox.Show("请先查找要充值的用户信息");
                    return;
                }
                string money = txtReChargeMoney.Text;
                if (string.IsNullOrEmpty(money))
                {
                    MessageBox.Show("请输入充值金额");
                    return;
                }
                float m;
                if (!float.TryParse(money, out m))
                {
                    MessageBox.Show("充值金额必须是半角数字，请重新输入");
                    return;
                }
                string sql = "Update User set Money=" + (float.Parse(row["Money"].ToString()) + m) + " where Id='" + row["Id"].ToString() + "'";
                if (DBHelper.ExecuteNonQuery(sql) > 0)
                {
                    btnQuery_Click(sender, e);
                    txtReChargeMoney.Text = "";
                    MessageBox.Show("充值成功！最新余额" + txtCountMoney.Text+"元");
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmRechargecs));
                MessageBox.Show(ex.Message);
            }
        }

        private void clear()
        {
            txtCardId.Text ="";
            txtCountMoney.Text ="";
            txtSex.Text ="";
            txtStatus.Text ="";
            txtTel.Text ="";
            txtUserName.Text ="";
            sn =0;
        }

        private void frmRechargecs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            CommStatic.TxtBoxCardId = null;
        }
    }
}
