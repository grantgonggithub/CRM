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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools;

namespace CRM
{
    public partial class UCRoleSetting : UserControl
    {
        public UCRoleSetting()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
            InItList();
        }

        private void InItList()
        {
            try
            {
                string sql = "select Id,Name,RoleList from AdminRole";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                DataColumn col = new DataColumn("RoleNameList", typeof(string));
                dt.Columns.Add(col);
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["RoleList"] == null || row["RoleList"].ToString() == "") continue;
                    string[] li = row["RoleList"].ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (li.Length < 1) continue;
                    foreach (string s in li)
                        sb.Append(Caps.GetCapsName(s) + ",");
                    if (sb.ToString().EndsWith(","))
                        sb.Remove(sb.Length - 1, 1);
                    row["RoleNameList"] = sb.ToString();
                    sb.Clear();
                }
                dt.AcceptChanges();
                dgvList.DataSource = dt;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCRoleSetting));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRoleName.Text))
                {
                    MessageBox.Show("请输入角色名称");
                    return;
                }
                TableLayoutControlCollection controls = tableLayoutPanelGrid.Controls;
                if (controls.Count < 1) return;
                StringBuilder sb = new StringBuilder();
                foreach (Control ct in controls)
                    GetChild(sb, ct, null);
                if (sb.Length < 1)
                {
                    MessageBox.Show("请选择此角色拥有的权限");
                    return;
                }
                if (sb.ToString().EndsWith(","))
                    sb.Remove(sb.Length - 1, 1);
                string Id = btnSave.Tag == null ? Guid.NewGuid().ToString("N") : btnSave.Tag.ToString();
                string sql = "select * from AdminRole where Name='" + txtRoleName.Text + "'" + (btnSave.Tag == null ? "" : " and Id<>'" + Id + "'");
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("此角色名称已经存在，不能重复");
                    return;
                }
                if (btnSave.Tag == null)
                    sql = "Insert into AdminRole(Id,Name,RoleList)values('" + Id + "','" + txtRoleName.Text + "','" + sb.ToString() + "')";
                else
                    sql = "Update AdminRole set Name='" + txtRoleName.Text + "',RoleList='" + sb.ToString() + "' where Id='" + Id + "'";
                if (DBHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("保存成功！");
                    InItList();
                    toolStripButtonAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCRoleSetting));
            }
        }

        private void GetChild(StringBuilder sb, Control cnt,string checkValue)
        {
            if (cnt is CheckBox)
            {
                CheckBox cbx = cnt as CheckBox;
                if (sb == null&&checkValue==null)
                    cbx.Checked = false;
                else
                {
                    if (sb != null)
                    {
                        if (cbx.Checked)
                            sb.Append(cbx.Tag + ",");
                    }
                    if (checkValue != null)
                    {
                        if (cbx.Tag.ToString() == checkValue)
                            cbx.Checked = true;
                    }
                }
            }
            if (cnt.HasChildren)
            {
                ControlCollection cnts = cnt.Controls;
                foreach (Control cn in cnts)
                    GetChild(sb, cn,checkValue);
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            txtRoleName.Text = "";
            tableLayoutPanelGrid.Enabled = true;
            GetChild(null, tableLayoutPanelGrid,null);
            btnSave.Tag = null;
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要编辑的项");
                    return;
                }

                int index = col[0].Index;
                DataTable dt = dgvList.DataSource as DataTable;
                if (dt == null || dt.Rows.Count < 1) return;
                DataRow row = dt.Rows[index];
                
                GetChild(null, tableLayoutPanelGrid, null);//先清掉
                btnSave.Tag = row["Id"].ToString();

                string[] rights = row["RoleList"].ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in rights)
                    GetChild(null, tableLayoutPanelGrid, s);
                txtRoleName.Text = row["Name"].ToString();
                if (row["Id"].ToString() == CommStatic.AdministratorRoleId)
                    tableLayoutPanelGrid.Enabled = false;
                else
                    tableLayoutPanelGrid.Enabled = true;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCRoleSetting));
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要删除的项");
                    return;
                }
                if (MessageBox.Show("确定要删除选中的项吗？数据删除后将不能恢复，点【确定】删除数据，【取消】不删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;
                int index = col[0].Index;
                DataTable dt = dgvList.DataSource as DataTable;
                if (dt == null || dt.Rows.Count < 1) return;
                DataRow row = dt.Rows[index];
                string Id = row["Id"].ToString();
                if (Id == CommStatic.AdministratorRoleId)
                {
                    MessageBox.Show("系统预置角色不能删除");
                    return;
                }
                string sql = "select * from Admin where Rights='" + Id + "'";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("有员工还担任此角色，请将担任这一角色的员工都更改为其他角色或者删除掉这个员工，才可以删除此角色");
                    return;
                }
                sql = "delete from AdminRole where Id='" + Id + "'";
                if (DBHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("删除成功！");
                    InItList();
                    toolStripButtonAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCRoleSetting));
            }
        }
    }
    public class Caps
    {
        public enum Roles
        {
            CloseAccount = 1,//前台结账
            ReCharge = 2,//会员充值
            ConsumeHistory = 3,//消费查询
            AddUser = 4,//新增会员
            ProductsMgr = 5,//产品管理
            AddEmployee = 6,//新增员工
            CheckOnMgr = 7,//考勤管理
            CardMgr = 8,//卡片管理
            AdminMgr = 9,//账号管理
            SystemSetting = 10,//系统设置
            EventWaring = 11,//事件提醒
            UserMgr = 12,//会员管理
            EmployeeMgr = 13,//员工管理
        }
        public static string GetCapsName(string intValue)
        { 
            Roles r;
            if (!Enum.TryParse<Roles>(intValue, out r))
                return null;
            switch (r)
            { 
                case Roles.CloseAccount:
                    return "前台结账";
                case Roles.ReCharge:
                    return "会员充值";
                case Roles.ConsumeHistory:
                    return "消费查询";
                case Roles.AddUser:
                    return "新增会员";
                case Roles.ProductsMgr:
                    return "产品管理";
                case Roles.AddEmployee:
                    return "新增员工";
                case Roles.CheckOnMgr:
                    return "考勤管理";
                case Roles.CardMgr:
                    return "卡片管理";
                case Roles.AdminMgr:
                    return "账号管理";
                case Roles.SystemSetting:
                    return "系统设置";
                case Roles.EventWaring:
                    return "事件提醒";
                case Roles.UserMgr:
                    return "会员管理";
                case Roles.EmployeeMgr:
                    return "员工管理";
                default:
                    return null;
            }
        }

        public static bool HasCaps(string intValue)
        {
            return CommStatic.MyCache.Login.Caps.Contains(intValue);
        }
    }
}
