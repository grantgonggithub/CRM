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
    public partial class frmLogin : skinBase
    {
        public frmLogin()
        {
            InitializeComponent();
            this.lblLockMsg.Visible = false;
            txtUserName.Focus();
        }

        public frmLogin(bool _isLock)
        {
            InitializeComponent();
            CommStatic.MyCache.Login.isLock = _isLock;
            this.lblLockMsg.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPwd.Text = "";
            txtUserName.Text = "";

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("请输入登陆账号！");
                    return;
                }
                string pwd = txtPwd.Text;
                if (string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("请输入登陆密码！");
                    return;
                }
                if (CommStatic.MyCache != null && CommStatic.MyCache.Login != null && CommStatic.MyCache.Login.isLock)
                {
                    if (userName == CommStatic.MyCache.Login.LoginName)
                    {
                        if (Tools.Tools.GetMD5(pwd) == CommStatic.MyCache.Login.Pwd)
                        {
                            this.DialogResult = DialogResult.OK;
                            CommStatic.MyCache.Login.isLock = false;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("密码错误，请重新输入");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("解锁屏账户必须跟登陆账户一致，请输入锁屏前的登陆账户解锁！");
                        return;
                    }
                }
                string sql = "select * from Admin where LoginName=@LoginName";
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@LoginName" }, new object[] { userName });
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("用户不存在，请重新输入！");
                    return;
                }
                DataRow row = ds.Tables[0].Rows[0];
                if (row["LoginPwd"].ToString() != Tools.Tools.GetMD5(pwd))
                {
                    MessageBox.Show("密码输入错误，请重新输入正确的密码！");
                    return;
                }
                //构造登陆信息

                CommStatic.MyCache.Login = new LoginAdmin() { AdminName = row["AdminName"].ToString(), Id = row["ID"].ToString(), LoginName = row["LoginName"].ToString(), Pwd = row["LoginPwd"].ToString() };
                sql = "select Id, Name,RoleList from AdminRole where Id='" + row["Rights"].ToString() + "'";
                ds = DBHelper.ExecuteDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    row = ds.Tables[0].Rows[0];
                    CommStatic.MyCache.Login.RightsName = row["Name"] == null ? "" : row["Name"].ToString();
                    CommStatic.MyCache.Login.Caps = row["RoleList"] == null ? null : row["RoleList"].ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                }
                ActionLog.Add(ActionName.Login, "登陆");//记录日志
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmLogin));
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CommStatic.MyCache != null && CommStatic.MyCache.Login!=null&&CommStatic.MyCache.Login.isLock)
            {
                MessageBox.Show("请输入解锁账户和密码");
                e.Cancel = true;
                return;
            }
        }
    }
}
