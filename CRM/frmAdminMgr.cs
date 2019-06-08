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
using System.IO;

using Tools;

namespace CRM
{
    public partial class frmAdminMgr : skinBase
    {
        public frmAdminMgr()
        {
            InitializeComponent();
            dgvAdminList.AutoGenerateColumns = false;
            InitList();
            cbxActive.Text = "启用";
            InitCmbx();
            if (!Caps.HasCaps(((int)Caps.Roles.AdminMgr).ToString()))
            {
                toolStripButtonAddNew.Enabled = false;
                toolStripButtonDelete.Enabled = false;
            }
            txtAdminName.Focus();
        }

        private void InitCmbx()
        {
            try
            {
                string sql = "select Id,Name from AdminRole";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                DataRow row = dt.NewRow();
                dt.Rows.InsertAt(row, 0);
                dt.AcceptChanges();
                cbxAdminType.DataSource = dt;
                cbxAdminType.DisplayMember = "Name";
                cbxAdminType.ValueMember = "Id";
            }
            catch (Exception ex)
            { 
                TracingHelper.Error(ex,typeof(frmAdminMgr));
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAdminName.Text))
                {
                    MessageBox.Show("管理员真实姓名不能为空！");
                    return;
                }
                string adminName = txtAdminName.Text.Trim();
                if (string.IsNullOrEmpty(txtLoginName.Text))
                {
                    MessageBox.Show("管理员登陆名不能为空！");
                    return;
                }
                string loginName = txtLoginName.Text.Trim();
               
                if (cbxAdminType.SelectedValue == null || string.IsNullOrEmpty(cbxAdminType.SelectedValue.ToString()))
                {
                    MessageBox.Show("请选择管理类型！");
                    return;
                }
                string adminType = cbxAdminType.SelectedValue.ToString();
                string remark = txtRemark.Text == "" ? "" : txtRemark.Text;
                string pwd = txtPwd.Text.Trim();

                string sql = "select * from Admin where LoginName=@LoginName";
                string[] prm = new string[] { "@LoginName" };
                object[] obj = new object[] { loginName };
                if (btnSave.Tag == null)//新增
                {
                    if (string.IsNullOrEmpty(pwd))
                    {
                        MessageBox.Show("管理员登陆密码不能为空！");
                        return;
                    }
                    DataSet ds = DBHelper.ExecuteDataSet(sql, prm, obj);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("登陆名已经存在，请重新输入一个登陆名");
                        return;
                    }
                    sql = "Insert into Admin(ID,AdminName,Tel,LoginName,LoginPwd,Rights,CreateTime,Active,Remark)values(@ID,@AdminName,@Tel,@LoginName,@LoginPwd,@Rights,@CreateTime,@Active,@Remark)";
                    prm = new string[] { "@ID", "@AdminName", "@Tel", "@LoginName", "@LoginPwd", "@Rights", "@CreateTime", "@Active", "@Remark" };
                    obj = new object[] { Guid.NewGuid().ToString("N"), adminName, txtTel.Text.Trim(), loginName, Tools.Tools.GetMD5(pwd), adminType, DateTime.Now, cbxActive.Text == "启用" ? "1" : "2", remark };
                }
                else//编辑
                {
                    StringBuilder sbsql = new StringBuilder();
                    StringBuilder sbprm = new StringBuilder();
                    List<object> objList = new List<object>();
                    if (adminName != txtAdminName.Tag.ToString())
                    {
                        sbsql.Append("AdminName=@AdminName,");
                        sbprm.Append("@AdminName,");
                        objList.Add(adminName);
                    }
                    if (txtTel.Tag.ToString() != txtTel.Text)
                    {
                        sbsql.Append("Tel=@Tel,");
                        sbprm.Append("@Tel,");
                        objList.Add(txtTel.Text.Trim());
                    }
                    if (pwd != "")//编辑的时候如果pwd为空的话就说明没有改密码
                    {
                        //if (Tools.Tools.GetMD5pwd != txtPwd.Tag.ToString())//编辑赋值是MD5，只是显示的是*，如果用户修改了，就会不一致，但是修改的是明文，下面需要做MD5处理
                        //{
                        sbsql.Append("LoginPwd=@LoginPwd,");
                        sbprm.Append("@LoginPwd,");
                        objList.Add(Tools.Tools.GetMD5(pwd));
                        //}
                    }
                    if (adminType != cbxAdminType.Tag.ToString())
                    {
                        sbsql.Append("Rights=@Rights,");
                        sbprm.Append("@Rights,");
                        objList.Add(adminType);
                    }
                    if (cbxActive.Text != cbxActive.Tag.ToString())
                    {
                        sbsql.Append("Active=@Active,");
                        sbprm.Append("@Active,");
                        objList.Add(cbxActive.Text == "启用" ? "1" : "2");
                    }
                    if (remark != txtRemark.Tag.ToString())
                    {
                        sbsql.Append("Remark=@Remark,");
                        sbprm.Append("@Remark,");
                        objList.Add(txtRemark.Text);
                    }
                    if (objList.Count < 1)
                    {
                        MessageBox.Show("您没做任何修改，不需要保存！");
                        return;
                    }
                    sql = "Update Admin Set " + sbsql.ToString().TrimEnd(',') + " where ID=@ID";
                    sbprm.Append("@ID");
                    objList.Add(toolStripButtonEdit.Tag.ToString());

                    prm = sbprm.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    obj = new object[objList.Count];
                    objList.CopyTo(obj);
                }

                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    MessageBox.Show("保存成功！");
                    clear();
                    InitList();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmAdminMgr));
            }
        }
        private void InitList()
        {
            try
            {
                string sql = "select a.*,b.Name as AdminType from Admin as a left join AdminRole as b on a.rights=b.Id {0} order by a.CreateTime desc";
                string wherePart="";
                if (!Caps.HasCaps(((int)Caps.Roles.AdminMgr).ToString()))//拥有这个权限才能看全部，没有的只能看自己；
                    wherePart = " where a.Id='"+CommStatic.MyCache.Login.Id+"' ";
                sql = string.Format(sql, wherePart);
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];
                DataColumn col = dt.Columns.Add("state", typeof(Byte[]));
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //row["Rights"] = row["Rights"].ToString() == "1" ? "超级管理员" : "普通管理员";
                    row["state"] = row["Active"].ToString() == "1" ? BitmapToBytes(Properties.Resources.OK) : BitmapToBytes(Properties.Resources.stop);
                }
                dgvAdminList.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmAdminMgr));
            }
        }
        private static byte[] BitmapToBytes(Bitmap Bitmap)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap.Save(ms, Bitmap.RawFormat);
                    byte[] byteImage = new Byte[ms.Length];
                    byteImage = ms.ToArray();
                    return byteImage;
                }
            }
            catch (ArgumentNullException ex)
            {
                //TracingHelper.Error(ex, typeof(EquType), "序列化表格图标状态错误");
            }
            return null;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvAdminList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要删除的管理员！");
                    return;
                }
                if (MessageBox.Show("确定要删除选中管理员吗？数据删除后将不能恢复，【是】删除，【否】不删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                int index = col[0].Index;
                DataTable dt = dgvAdminList.DataSource as DataTable;
                DataRow row = dt.Rows[index];
                string Id = row["ID"].ToString();
                if (Id ==CommStatic.AdministratorId)
                {
                    MessageBox.Show("系统预置的管理员不能删除");
                    return;
                }
                if (Id == CommStatic.MyCache.Login.Id)
                {
                    MessageBox.Show("不能删除自己的账号，要删除请让其他有权限的账号进行删除");
                    return;
                }
                string sql = "delete from Admin where ID=@ID";
                if (DBHelper.ExecuteNonQuery(sql, new string[] { "@ID" }, new object[] { Id }) > 0)
                {
                    InitList();
                    MessageBox.Show("删除成功！");
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmAdminMgr));
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvAdminList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要编辑的项目！");
                    return;
                }
                int index = col[0].Index;
                DataTable dt = dgvAdminList.DataSource as DataTable;
                DataRow row = dt.Rows[index];
                btnSave.Tag = row;

                toolStripButtonEdit.Tag = row["ID"].ToString();
                txtAdminName.Text = row["AdminName"] == null ? "" : row["adminName"].ToString();
                txtAdminName.Tag = txtAdminName.Text;
                txtLoginName.Text = row["LoginName"].ToString();
                txtLoginName.ReadOnly = true;//登陆名不让改
                txtTel.Text = row["Tel"] == null ? "" : row["Tel"].ToString();
                txtTel.Tag = txtTel.Text;
                txtRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
                txtRemark.Tag = txtRemark.Text;
                cbxAdminType.SelectedValue = row["Rights"].ToString();
                cbxAdminType.Tag = cbxAdminType.SelectedValue;
                cbxActive.Text = row["Active"].ToString() == "1" ? "启用" : "停用";
                cbxActive.Tag = cbxActive.Text;
                txtPwd.Text ="";
                txtPwd.Tag =row["LoginPwd"].ToString();

                txtAdminName.Enabled = false;
                txtLoginName.Enabled = false;
                txtRemark.Enabled = false;
                txtTel.Enabled = false;
                cbxActive.Enabled = false;
                cbxAdminType.Enabled = false;
                pbxAddAdminType.Enabled = false;

                if (Caps.HasCaps(((int)Caps.Roles.AdminMgr).ToString()))
                {
                    txtAdminName.Enabled = true;
                    txtLoginName.Enabled = true;
                    txtRemark.Enabled = true;
                    txtTel.Enabled = true;
                    cbxActive.Enabled = true;
                    cbxAdminType.Enabled = true;
                    pbxAddAdminType.Enabled = true;
                }
                if (row["Id"].ToString() == CommStatic.AdministratorId)
                {
                    cbxActive.Enabled = false;
                    cbxAdminType.Enabled = false;
                    pbxAddAdminType.Enabled = false;
                }
               
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmAdminMgr));
            }
        }

        private void dgvAdminList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButtonEdit_Click(sender, null);
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            btnSave.Tag = null;
            toolStripButtonEdit.Tag = null;
            txtAdminName.Text = "";
            txtAdminName.Tag = null;
            txtLoginName.Text = "";
            txtLoginName.ReadOnly = false;
            txtPwd.Text = "";
            txtPwd.Tag = null;
            txtTel.Text = "";
            txtTel.Tag = null;
            txtRemark.Text = "";
            txtRemark.Tag = null;
            cbxActive.Text = "启用";
            cbxActive.Tag = null;
            cbxAdminType.Text = "";
            cbxAdminType.Tag = null;

            txtAdminName.Enabled = true;
            txtLoginName.Enabled = true;
            txtRemark.Enabled = true;
            txtTel.Enabled = true;
            cbxActive.Enabled = true;
            cbxAdminType.Enabled = true;
            pbxAddAdminType.Enabled = true;
        }

        private void pbxAddAdminType_Click(object sender, EventArgs e)
        {
            frmSystemSetting set = new frmSystemSetting("管理员角色管理");
            if (set.ShowDialog() == DialogResult.OK)
                InitCmbx();
        }

        private void toolStripButtonOutPut_Click(object sender, EventArgs e)
        {
            CommStatic.DataGridViewToExcel(this.dgvAdminList);
        }
    }
}
