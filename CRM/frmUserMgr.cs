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
    public partial class frmUserMgr : skinBase
    {
        private DataTable dtOrg;
        private string id;
        public frmUserMgr()
        {
            InitializeComponent();
            dgvUserList.AutoGenerateColumns = false;
            InitList();
            try
            {
                string sql = "select * from UserType where Sort=1";
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow row = dt.NewRow();
                    dt.Rows.InsertAt(row, 0);
                    cbxUserType.DataSource = dt;
                    cbxUserType.DisplayMember = "UserTypeName";
                    cbxUserType.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmUserMgr));
                MessageBox.Show(ex.Message);
            }
            CommStatic.TxtBoxCardId = txtCardId;
            txtUserName.Focus();
        }

        public void SelectView(string _id)
        {
            this.id = _id;
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            frmAddUser add = new frmAddUser();
            //CommStatic.FrmAddUser= add;
            if (add.ShowDialog() == DialogResult.OK)
            {
                InitList();
            }
            CommStatic.TxtBoxCardId = txtCardId;
        }

        private void InitList()
        {
            try
            {
                string sql = "select (case a.Sex when 1 then '男' when 2 then '女' end) as Sex , a.ID,a.VipCardID,a.UserName,a.Tel,a.CreateTime,a.Money,(case a.Active when 1 then '启用' when 2 then '停用' end) as Active , a.Address,a.Remark,b.UserTypeName from User a left join UserType b on a.UserType=b.ID where b.sort=1 order by a.CreateTime desc";
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                dtOrg = ds.Tables[0];
                dgvUserList.DataSource = dtOrg;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmUserMgr));
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection col = dgvUserList.SelectedRows;
            if (col.Count < 1)
            {
                MessageBox.Show("请选择要编辑的项目");
                return;
            }
            DataTable dt = dgvUserList.DataSource as DataTable;
            DataRow row = dt.Rows[col[0].Index];
            frmAddUser edit = new frmAddUser(row);
           // CommStatic.FrmAddUser = edit;
            if (edit.ShowDialog() == DialogResult.OK)
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
                if (txtUserName.Text.Trim() != "")
                    sql += " and UserName like'%" + txtUserName.Text.Trim() + "%'";
                if (txtCardId.Text.Trim() != "")
                    sql += " and VipCardId like'%" + txtCardId.Text.Trim() + "%'";
                if (txtTel.Text.Trim() != "")
                    sql += " and Tel like'%"+txtTel.Text.Trim()+"%'";
                if (cmbStatus.Text != "")
                    sql += " and Active='" + cmbStatus.Text + "'";
                if (cbxUserType.Text != "")
                    sql += " and UserTypeName='" + cbxUserType.Text + "'";

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
                if (txtCountStart.Text != "" && txtCountEnd.Text != "")
                {
                    sql += " and (Money>=" + txtCountStart.Text + " and Money<=" + txtCountEnd.Text + ")";
                }
                else
                {
                    if (txtCountStart.Text != "")
                        sql += " and Money>=" + txtCountStart.Text;
                    if (txtCountEnd.Text != "")
                        sql += " and Money<=" + txtCountEnd.Text;
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
                dgvUserList.DataSource = temp;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmUserMgr));
                MessageBox.Show(ex.Message);
            }
        }

        private void frmUserMgr_Shown(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return;
                DataRow[] rows = dtOrg.Select("Id='" + id + "'");
                if (rows.Length < 1) return;
                int index = Array.IndexOf<DataRow>(dtOrg.Select("1=1", "CreateTime desc"), rows[0]);

                dgvUserList.Rows[index].Selected = true;
                dgvUserList.FirstDisplayedScrollingRowIndex = dgvUserList.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmUserMgr));
                MessageBox.Show(ex.Message);
            }
        }

        private void frmUserMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.FrmMain.InitSystemInfo();
            CommStatic.TxtBoxCardId = null;
        }

        private void toolStripButtonOutPut_Click(object sender, EventArgs e)
        {
            CommStatic.DataGridViewToExcel(this.dgvUserList);
        }


    }
}
