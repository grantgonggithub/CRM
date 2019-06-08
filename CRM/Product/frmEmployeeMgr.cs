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
using System.Text;
using System.Windows.Forms;
using Tools;

namespace CRM
{
    public partial class frmEmployeeMgr : skinBase
    {
        private DataTable dtOrg;
        public frmEmployeeMgr()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
            InitList();
            InitUserType();
            CommStatic.TxtBoxCardId = txtCardId;
            txtEmpleeyName.Focus();
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            frmAddEmployee addEmployee = new frmAddEmployee();
            //CommStatic.FrmAddEmployee = addEmployee;
            if (addEmployee.ShowDialog() == DialogResult.OK)
                InitList();
            CommStatic.TxtBoxCardId = txtCardId;
        }

        private void InitList()
        {
            try
            {
                string sql = "select a.Id,a.EmployeeName,a.Tel,a.Address,b.UserTypeName as EmployeeType,(case a.Active when 1 then '启用' when 2 then '停用' end) as Active,a.CardId,(case a.Sex when 1 then '男' when 2 then '女' end) as Sex,BirthDay,CreateTime,EmployeeNum  from Employee as a left join UserType as b on a.EmployeeType=b.ID where b.Sort=2 order by a.CreateTime desc";
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                dtOrg = ds.Tables[0];
                dgvList.DataSource = dtOrg;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmEmployeeMgr));
            }
        }
        private void InitUserType()
        {
            try
            {
                string sql = "select * from UserType where Sort=@Sort";
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@Sort" }, new object[] { 2 });
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];
                DataRow row = dt.NewRow();
                dt.Rows.InsertAt(row, 0);
                cbxUserType.DataSource = dt;
                cbxUserType.DisplayMember = "UserTypeName";
                cbxUserType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmEmployeeMgr));
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
            if (col.Count < 1)
            {
                MessageBox.Show("请选择要编辑的项目！");
                return;
            }
            DataTable dt = dgvList.DataSource as DataTable;
            DataRow row = dt.Rows[col[0].Index];
            frmAddEmployee editEmployee = new frmAddEmployee(row);
            //CommStatic.FrmAddEmployee = editEmployee;
            if (editEmployee.ShowDialog() == DialogResult.OK)
            {
                InitList();
            }
            CommStatic.TxtBoxCardId = txtCardId;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "1=1";
                if (!string.IsNullOrEmpty(txtEmpleeyName.Text))
                    sql += " and EmployeeName like'%" + txtEmpleeyName.Text + "%'";
                if (!string.IsNullOrEmpty(txtEmpleeyNum.Text))
                    sql += " and EmployeeNum='" + txtEmpleeyNum.Text + "'";
                if (!string.IsNullOrEmpty(txtCardId.Text))
                    sql += " and CardId like'%" + txtCardId.Text + "%'";
                if (!string.IsNullOrEmpty(cbxUserType.Text))
                    sql += " and EmployeeType='" + cbxUserType.Text + "'";
                if (!string.IsNullOrEmpty(cbxActive.Text))
                    sql += " and Active='" + cbxActive.Text + "'";
                if (dateTimePickerStart.Checked && dateTimePickerEnd.Checked)
                {
                    if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
                    {
                        MessageBox.Show("开始时间不能大于截止时间，请重新选择");
                    }
                    else
                    {
                        sql += " and (CreateTime>='" + dateTimePickerStart.Value.ToShortDateString() + "' and CreateTime<'" + dateTimePickerEnd.Value.AddDays(1).ToShortDateString() + "') ";
                    }
                }
                else
                {
                    if (dateTimePickerStart.Checked)
                        sql += " and CreateTime>='" + dateTimePickerStart.Value.ToShortDateString() + "'";
                    if (dateTimePickerEnd.Checked)
                        sql += " and CreateTime<'" + dateTimePickerEnd.Value.AddDays(1).ToShortDateString() + "'";
                }
                if (sql == "1=1")
                {
                    InitList();
                    return;
                }
                DataRow[] rows = dtOrg.Select(sql);
                DataTable temp = dtOrg.Clone();
                foreach (DataRow row in rows)
                {
                    DataRow dr = temp.NewRow();
                    dr.ItemArray = row.ItemArray;
                    temp.Rows.Add(dr);
                }
                dgvList.DataSource = temp;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmEmployeeMgr));
            }
        }

        private void frmEmployeeMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.FrmMain.InitSystemInfo();
            CommStatic.TxtBoxCardId = null;
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButtonOutPut_Click(object sender, EventArgs e)
        {
            CommStatic.DataGridViewToExcel(this.dgvList);
        }
    }
}
