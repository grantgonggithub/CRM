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
    public partial class frmCheckOnMgr : skinBase
    {
        private DataTable orgDt;
        DataRow row0;
        DataRow row1;
        public frmCheckOnMgr()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
            InitEmployee();
            InitList();
            Init();
            CommStatic.TxtBoxCardId = txtCardId;
            txtCardId.Focus();
        }

        private void Init()
        {
            try
            {
                string sql = "select * from SysConfig where key='StartWorkTimeSetting' or key='GoOffWorkTimeSetting'";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 2) return;
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0]["key"].ToString() == "StartWorkTimeSetting")
                {
                    row0 = dt.Rows[0];
                    row1 = dt.Rows[1];
                }
                else
                {
                    row0 = dt.Rows[1];
                    row1 = dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCheckOnMgr));
            }
        }

        private void InitList()
        {
            try
            {
                string sql = "select Id,CardId,CurrTime,EmployeeId,EmployeeName from EmployeeCheckOn order by CurrTime desc";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null) return;
                orgDt = ds.Tables[0];
                dgvList.DataSource = orgDt;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCheckOnMgr));
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
                DataRow row = dt.NewRow();
                dt.Rows.InsertAt(row, 0);
                cmbxUserName.DataSource = ds.Tables[0];
                cmbxUserName.ValueMember = "Id";
                cmbxUserName.DisplayMember = "EmployeeName";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCheckOnMgr));
            }
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = cmbxUserName.Text;
                string cardid = txtCardId.Text;
                string sql = " 1=1 ";
                if (!string.IsNullOrEmpty(userName))
                    sql += "and EmployeeName='" + userName + "'";
                if (!string.IsNullOrEmpty(cardid))
                    sql += " and CardId='" + cardid + "'";
                if (dateTimePickerStart.Checked && dateTimePickerEnd.Checked)
                {
                    if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
                    {
                        MessageBox.Show("截止时间必须大于开始时间");
                        return;
                    }
                    sql += " and CurrTime>=datetime('" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "') and CurrTime<datetime('" + dateTimePickerEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "')";
                }
                else
                {
                    if (dateTimePickerStart.Checked)
                        sql += " and CurrTime>=datetime('" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "')";
                    if (dateTimePickerEnd.Checked)
                        sql += " and CurrTime<datetime('" + dateTimePickerEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "')";
                }

                if (sql == " 1=1 " && !radioButtonBeLate.Checked && !radioButtonActive.Checked && !radioButtonAll.Checked)
                    dgvList.DataSource = orgDt;
                else
                {
                    DataTable dt = null;
                    string temp = "";
                    if (radioButtonAll.Checked)
                        temp = "select Id,CardId,CurrTime,EmployeeId,EmployeeName from EmployeeCheckOn {0} order by CurrTime desc";
                    if (radioButtonActive.Checked)
                    {
                        temp = @"select * from (select  max(CurrTime) as CurrTime,Date(CurrTime) as day,Id,CardId, EmployeeName,EmployeeId
                              from EmployeeCheckOn  group by day
                            UNION
                            select  min(CurrTime) as CurrTime ,Date(CurrTime) as day,Id,CardId, EmployeeName,EmployeeId
                             from EmployeeCheckOn  group by day){0}";
                    }
                    if (radioButtonBeLate.Checked)
                    {
                        string start = (row0["Value3"].ToString().Length < 2 ? "0" + row0["Value3"].ToString() : row0["Value3"].ToString()) + ":" + (row0["Value4"].ToString().Length < 2 ? "0" + row0["Value4"].ToString() : row0["Value4"].ToString());
                        string end = (row1["Value3"].ToString().Length < 2 ? "0" + row1["Value3"].ToString() : row1["Value3"].ToString()) + ":" + (row1["Value4"].ToString().Length < 2 ? "0" + row1["Value4"].ToString() : row1["Value4"].ToString());
                        temp = @"select * from (select  max(CurrTime) as CurrTime,Date(CurrTime) as day,Id,CardId, EmployeeName,EmployeeId
                              from EmployeeCheckOn   where  time(CurrTime)>time('{0}')  group by day
                            UNION
                            select  min(CurrTime) as CurrTime ,Date(CurrTime) as day,Id,CardId, EmployeeName,EmployeeId
                             from EmployeeCheckOn    where  time(CurrTime)<time('{1}')    group by day)";
                        temp = string.Format(temp, start + ":00", end + ":00") + "{0}";
                    }
                    DataSet ds = DBHelper.ExecuteDataSet(string.Format(temp, sql == " 1=1 " ? "" : " where " + sql));
                    if (ds != null)
                        dt = ds.Tables[0];
                    dgvList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCheckOnMgr));
            }
        }

        private void toolStripButtonOutPut_Click(object sender, EventArgs e)
        {
            CommStatic.DataGridViewToExcel(this.dgvList);
        }

        private void frmCheckOnMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.TxtBoxCardId = null;
        }

        //private DataTable getUnion(DataTable dt)
        //{ 
        //    if (radioButtonActive.Checked)
        //    { 
        //        DataRow[] rows=dt.Select(""
        //    }
        //    if (radioButtonBeLate.Checked)
        //    { 

        //    }
        //}
    }
}
