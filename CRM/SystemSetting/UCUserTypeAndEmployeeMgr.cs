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
    public partial class UCUserTypeAndEmployeeMgr : UserControl
    {
        private int sort;
        public UCUserTypeAndEmployeeMgr()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
        }

        public UCUserTypeAndEmployeeMgr(int _sort)
        {
            InitializeComponent();
            InitData(_sort);
        }

        public void InitData(int _sort)
        {
            this.sort = _sort;
            dgvList.AutoGenerateColumns = false;
            InitList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string typeName = txtName.Text;
                if (string.IsNullOrEmpty(typeName))
                {
                    MessageBox.Show("请输入类型名称");
                    return;
                }
                string remark = txtRemark.Text;
                string sql = "select * from UserType where UserTypeName=@UserTypeName";
                string[] prm = new string[] { "@UserTypeName" };
                object[] obj = new object[] { typeName };
                if (btnSave.Tag == null)//新增
                {
                    DataSet ds = DBHelper.ExecuteDataSet(sql, prm, obj);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("此类型已经存在无需添加");
                        return;
                    }
                    sql = "Insert into UserType(ID,UserTypeName,Remark,Sort)values(@ID,@UserTypeName,@Remark,@Sort)";
                    prm = new string[] { "@ID", "@UserTypeName", "@Remark", "@Sort" };
                    obj = new object[] { Guid.NewGuid().ToString("N"), typeName, remark, this.sort };
                }
                else
                {
                    sql = "Update UserType Set UserTypeName=@UserTypeName,Remark=@Remark where ID=@ID";
                    prm = new string[] { "@UserTypeName", "@Remark", "@ID" };
                    obj = new object[] { typeName, remark, btnSave.Tag.ToString() };
                }
                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    MessageBox.Show("保存成功！");
                    clear();
                    InitList();
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCUserTypeAndEmployeeMgr));
            }
        }

        private void InitList()
        {
            try
            {
                string sql = "select * from UserType where sort=@sort";
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@sort" }, new object[] { this.sort });
                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                dgvList.DataSource = dt;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCUserTypeAndEmployeeMgr));
            }
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
            if (col.Count < 1)
            {
                MessageBox.Show("请选择要编辑的项目"); ;
                return;
            }

            DataGridViewRow row = col[0];
            DataTable dt = dgvList.DataSource as DataTable;
            DataRow dr = dt.Rows[row.Index];

            txtName.Text =dr["UserTypeName"].ToString();
            txtName.Tag = txtName.Text;
            txtRemark.Text = dr["Remark"]==null?"":dr["Remark"].ToString();
            txtRemark.Tag = txtRemark.Text;
            btnSave.Tag = dr["ID"].ToString();
        }

        private void clear()
        {
            txtName.Text = "";
            txtName.Tag = null;
            txtRemark.Text = "";
            txtRemark.Tag = null;
            btnSave.Tag = null;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要删除的项目"); ;
                    return;
                }
                if (MessageBox.Show("确定要删除所选项目吗？删除后数据将不能恢复，【是】继续删除，【否】不删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                DataGridViewRow row = col[0];
                DataTable dt = dgvList.DataSource as DataTable;
                DataRow dr = dt.Rows[row.Index];
                string sql = "delete from UserType where ID=@ID";
                if (DBHelper.ExecuteNonQuery(sql, new string[] { "@ID" }, new object[] { dr["ID"].ToString() }) > 0)
                {
                    MessageBox.Show("删除成功！");
                    InitList();
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCUserTypeAndEmployeeMgr));
            }
        }

        private void frmUserTypeMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
