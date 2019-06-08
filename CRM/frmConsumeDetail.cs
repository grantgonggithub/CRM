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
    public partial class frmConsumeDetail : skinBase
    {
        private DataRow row;
        public frmConsumeDetail()
        {
            InitializeComponent();
        }

        public frmConsumeDetail(DataRow dr)
        {
            InitializeComponent();
            txtUserName.Focus();
            try
            {
                this.row = dr;
                txtCardId.Text = row["CardId"] == null ? "" : row["CardId"].ToString();
                txtCurrTime.Text = row["ConsumeTime"] == null ? "" : row["ConsumeTime"].ToString();
                txtMoney.Text = row["ConsumeMoney"] == null ? "" : row["ConsumeMoney"].ToString();
                txtNum.Text = row["BillID"] == null ? "" : row["BillID"].ToString();
                txtUserName.Text = row["UserName"] == null ? "" : row["UserName"].ToString();
                txtUserType.Text = row["UserType"] == null ? "" : row["UserType"].ToString();
                dgvList.AutoGenerateColumns = false;
                InItList();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeDetail));
            }

        }
        public void InItList()
        {
            try
            {
                string sql = "select * from ConsumeHistory where ConsumeBillId='" + row["BillID"].ToString() + "'";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                DataTable dt = null;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    dt = ds.Tables[0];
                dgvList.DataSource = dt;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeDetail));
            }
        }
    }
}
