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
    public partial class frmConsumeHistory : skinBase
    {
        private DataTable orgDt;
        private readonly string notVip = "非会员";
        public frmConsumeHistory()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
            InItList();
            InitEmployee();
            InitUserType();
            //InitProduct();
            InitAdmin();
            CommStatic.TxtBoxCardId = txtCardId;
            txtUserName.Focus();
        }

        private void InItList()
        {
            try
            {
                string sql = "select * from ConsumeBill order by ConsumeTime desc";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                orgDt = ds.Tables[0];
                dgvList.DataSource = orgDt;
                object o = orgDt.Compute("SUM(ConsumeMoney)", "");
                toolStripLabelCount.Text = "总计消费" + orgDt.Rows.Count + "笔，总计金额" + ((o == null || o.ToString() == "") ? "0" : o.ToString()) + "元";
                //o = orgDt.Compute("SUM(ConsumeMoney)", "CardId<>'' and CardId is not null");
                //toolStripLabelCount.Text += "，会员消费" + ((o == null || o.ToString() == "") ? "0" : o.ToString()) + "元";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeHistory));
            }
        }

        private void InitEmployee()
        {
            try
            {
                string sql = "select Id,EmployeeName from Employee";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];

                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                cmbxEmployeeName.DataSource = ds.Tables[0];
                cmbxEmployeeName.ValueMember = "Id";
                cmbxEmployeeName.DisplayMember = "EmployeeName";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeHistory));
            }
        }

        private void InitUserType()
        {
            try
            {
                string sql = "select Id,UserTypeName from UserType where Sort=@Sort";
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@Sort" }, new object[] { 1 });
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];

                DataRow row = dt.NewRow();
                row["Id"] = -100;
                row["UserTypeName"] = notVip;
                dt.Rows.InsertAt(row, 0);

                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                cbxUserType.DataSource = dt;
                cbxUserType.DisplayMember = "UserTypeName";
                cbxUserType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeHistory));
            }
        }

        //private void InitProduct()
        //{
        //    string sql = "select Id,ProductName from product";
        //    DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
        //    if (ds == null || ds.Tables[0].Rows.Count < 1) return;
        //    DataTable dt = ds.Tables[0];
        //    DataRow row = dt.NewRow();
        //    dt.Rows.InsertAt(row, 0);
        //    cmbxProduct.DataSource = dt;
        //    cmbxProduct.DisplayMember = "ProductName";
        //    cmbxProduct.ValueMember = "Id";
        //}

        private void InitAdmin()
        {
            try
            {
                string sql = "select Id,AdminName from Admin";
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];
                DataRow row = dt.NewRow();
                dt.Rows.InsertAt(row, 0);
                cmbxAdmin.DataSource = dt;
                cmbxAdmin.DisplayMember = "AdminName";
                cmbxAdmin.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeHistory));
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder(" 1=1 ");
                string userName = txtUserName.Text;
                string cardId = txtCardId.Text;
                if (!string.IsNullOrEmpty(userName))
                    sbSql.Append(" and UserName='" + userName + "'");
                if (!string.IsNullOrEmpty(cardId))
                    sbSql.Append(" and CardId='" + cardId + "'");
                if (!string.IsNullOrEmpty(txtTel.Text))
                    sbSql.Append(" and Tel='" + txtTel.Text + "'");
                if (!string.IsNullOrEmpty(cbxUserType.Text))
                {
                    string userType = cbxUserType.Text;
                    if (userType == notVip)
                        sbSql.Append(" and (CardId='' or CardId=null)");
                    else
                        sbSql.Append(" and UserType='" + cbxUserType.Text + "'");
                }
                if (dateTimePickerStart.Checked && dateTimePickerEnd.Checked)
                {
                    if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
                    {
                        MessageBox.Show("截止时间必须大于开始时间");
                        return;
                    }
                    sbSql.Append(" and (ConsumeTime>='" + dateTimePickerStart.Value.ToShortDateString() + "' and ConsumeTime<'" + dateTimePickerEnd.Value.AddDays(1).ToShortDateString() + "')");
                }
                else
                {
                    if (dateTimePickerStart.Checked)
                        sbSql.Append(" and ConsumeTime>='" + dateTimePickerStart.Value.ToShortDateString() + "'");
                    if (dateTimePickerEnd.Checked)
                        sbSql.Append(" and ConsumeTime<'" + dateTimePickerEnd.Value.AddDays(1).ToShortDateString() + "'");
                }
                if (!string.IsNullOrEmpty(cmbxEmployeeName.Text))
                    sbSql.Append(" and EmployeeName='" + cmbxEmployeeName.Text + "'");
                if (!string.IsNullOrEmpty(cmbxAdmin.Text))
                    sbSql.Append(" and AdminName='" + cmbxAdmin.Text + "'");
                if (!string.IsNullOrEmpty(txtConsumeMoney.Text))
                    sbSql.Append(" and ConsumeMoney>=" + txtConsumeMoney.Text);
                if (sbSql.ToString() == " 1=1 ")
                {
                    InItList();
                    return;
                }
                DataRow[] rows = orgDt.Select(sbSql.ToString());
                DataTable dt = orgDt.Clone();
                foreach (DataRow dr in rows)
                {
                    DataRow r = dt.NewRow();
                    r.ItemArray = dr.ItemArray;
                    dt.Rows.Add(r);
                }
                dgvList.DataSource = dt;
                object o = dt.Compute("SUM(ConsumeMoney)", "");
                toolStripLabelCount.Text = "共计消费" + dt.Rows.Count + "笔，总计金额" + ((o == null || o.ToString() == "") ? "0" : o.ToString()) + "元";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeHistory));
            }
        }

        private void toolStripButtonDetail_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
            //if (col.Count < 1)
            //{
            //    MessageBox.Show("请选择要查看的记录!");
            //    return;
            //}
            //int index = col[0].Index;
            //DataTable dt = dgvList.DataSource as DataTable;
            //DataRow row = dt.Rows[index];
            dgvList_MouseDoubleClick(null, null);
        }

        private void dgvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要查看的记录!");
                    return;
                }
                int index = col[0].Index;
                DataTable dt = dgvList.DataSource as DataTable;
                DataRow row = dt.Rows[index];
                frmConsumeDetail detail = new frmConsumeDetail(row);
                detail.ShowDialog();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmConsumeHistory));
            }
        }

        private void toolStripButtonOutPut_Click(object sender, EventArgs e)
        {
            CommStatic.DataGridViewToExcel(this.dgvList);
        }

        private void frmConsumeHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.TxtBoxCardId = null;
        }
    }
}
