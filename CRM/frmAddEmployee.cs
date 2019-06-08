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
    public partial class frmAddEmployee : skinBase
    {
        public DataRow row;

        public frmAddEmployee()
        {
            InitializeComponent();
            InitUserType();
            this.Text = "新增员工";
            CommStatic.TxtBoxCardId = txtCardId;
            txtName.Focus();
        }

        public frmAddEmployee(DataRow _row)
        {
            InitializeComponent();
            this.row = _row;
            InitUserType();
            txtAddress.Text = row["Address"] == null ? "" : row["Address"].ToString();

            txtCardId.Text = row["CardId"] == null ? "" : row["CardId"].ToString();
            txtCardId.Tag = row;
            CommStatic.TxtBoxCardId = txtCardId;

            txtName.Text = row["EmployeeName"] == null ? "" : row["EmployeeName"].ToString();
            txtTel.Text = row["Tel"] == null ? "" : row["Tel"].ToString();
            txtEmployeeNum.Text = row["EmployeeNum"] == null ? "" : row["EmployeeNum"].ToString();
            radioButtonMan.Checked = row["Sex"].ToString() == "男";
            radioButtonWen.Checked = row["Sex"].ToString() == "女";
            radioButtonOK.Checked = row["Active"].ToString() == "启用";
            radioButtonStop.Checked = row["Active"].ToString() == "停用";
            cbxUserType.Text = row["EmployeeType"].ToString();

            this.Text = "编辑员工信息";
        }
        

        private void pictureBoxAddUserType_Click(object sender, EventArgs e)
        {
            UserTypeAdd typeMgr = new UserTypeAdd(2);
            if (typeMgr.ShowDialog() == DialogResult.OK)
            {
                InitUserType();
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
                TracingHelper.Error(ex, typeof(frmAddEmployee));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtAddress.Text = "";
            txtName.Text = "";
            txtTel.Text = "";
            cbxUserType.Text = "";
            radioButtonMan.Checked = true;
            radioButtonWen.Checked = false;
            radioButtonOK.Checked = true;
            radioButtonStop.Checked = false;
            dateTimePickerBithDay.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtName.Text;
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("请输入员工姓名");
                    return;
                }

                DataSet dataset = DBHelper.ExecuteDataSet("select * from Employee where EmployeeName=@EmployeeName " + (row == null ? "" : " and Id<>'" + row["Id"].ToString() + "'"), new string[] { "@EmployeeName" }, new object[] { userName });
                if (dataset != null && dataset.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("此员工姓名已经存在，如果是同名员工，请在名字后编号加以区分");
                    return;
                }
                string userNum = txtEmployeeNum.Text;
                if (!string.IsNullOrEmpty(userNum))
                {
                    dataset = DBHelper.ExecuteDataSet("select * from Employee where EmployeeNum=@EmployeeNum " + (row == null ? "" : " and Id<>'" + row["Id"].ToString() + "'"), new string[] { "@EmployeeNum" }, new object[] { userNum });
                    if (dataset != null && dataset.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("此员工编号已经占用，请给此员工重新分配一个未占用的编号！");
                        return;
                    }
                }

                object userType = cbxUserType.SelectedValue;
                if (userType == null || userType.ToString() == "")
                {
                    MessageBox.Show("请选择员工类型");
                    return;
                }
                string sql;
                string[] prm;
                object[] obj;
                string cardId = txtCardId.Text;

                if ((this.row == null || this.row["CardId"] == null || this.row["CardId"].ToString() == "") && !string.IsNullOrEmpty(cardId))//新增和编辑都有可能发卡,只能判断原来没有卡，现在有卡，表示新发卡
                {
                    sql = "select * from Card where CardId=@CardId";
                    prm = new string[] { "@CardId" };
                    obj = new object[] { cardId };
                    DataSet ds = DBHelper.ExecuteDataSet(sql, prm, obj);
                    if (ds == null || ds.Tables[0].Rows.Count < 1)
                    {
                        MessageBox.Show("请勿使用非法卡，否则可能导致系统风险！");
                        return;
                    }
                    DataRow dr = ds.Tables[0].Rows[0];

                    string cipherTxt = dr["Org"].ToString();
                    string cleartTxt = Tools.Tools.Decrypt(cipherTxt);
                    string[] args = cleartTxt.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (args.Length != 4 || args[0] != dr["CardId"].ToString())
                    {
                        MessageBox.Show("此卡数据异常，无法使用，请换其他卡");
                        return;
                    }

                    DateTime time = DateTime.Parse(dr["CreateTime"].ToString());
                    string temp = dr["CardId"].ToString() + time.ToString("yyyyMMdd");
                    temp = Tools.Tools.GetMD5(temp);
                    if (temp != dr["Key"].ToString())
                    {
                        MessageBox.Show("请勿使用非法卡，否则可能导致系统风险！");
                        return;
                    }
                    if (dr["Status"].ToString() != "1")
                    {
                        MessageBox.Show("此卡已经使用，不能重复使用");
                        return;
                    }
                }
                if (this.row == null)//新增
                {
                    sql = "Insert into Employee(ID,EmployeeName,Tel,Address,EmployeeType,Active,CardId,Sex,BirthDay,CreateTime,UpdateTime,EmployeeNum)values(@ID,@EmployeeName,@Tel,@Address,@EmployeeType,@Active,@CardId,@Sex,@BirthDay,@CreateTime,@UpdateTime,@EmployeeNum)";
                    prm = new string[] { "@ID", "@EmployeeName", "@Tel", "@Address", "@EmployeeType", "@Active", "@CardId", "@Sex", "@BirthDay", "@CreateTime", "@UpdateTime", "@EmployeeNum" };
                    obj = new object[] { Guid.NewGuid().ToString("N"), userName, txtTel.Text, txtAddress.Text, userType.ToString(), radioButtonOK.Checked ? 1 : 2, cardId, radioButtonMan.Checked ? 1 : 2, dateTimePickerBithDay.Value, DateTime.Now, DateTime.Now, userNum };
                }
                else//编辑
                {
                    sql = "Update Employee Set EmployeeName=@EmployeeName,Tel=@Tel,Address=@Address,EmployeeType=@EmployeeType,Active=@Active,CardId=@CardId,Sex=@Sex,BirthDay=@BirthDay,CreateTime=@CreateTime,UpdateTime=@UpdateTime,EmployeeNum=@EmployeeNum where ID=@ID";
                    prm = new string[] { "@EmployeeName", "@Tel", "@Address", "@EmployeeType", "@Active", "@CardId", "@Sex", "@BirthDay", "@CreateTime", "@UpdateTime", "@EmployeeNum", "@ID" };
                    obj = new object[] { userName, txtTel.Text, txtAddress.Text, userType.ToString(), radioButtonOK.Checked ? 1 : 2, cardId, radioButtonMan.Checked ? 1 : 2, dateTimePickerBithDay.Value, DateTime.Now, DateTime.Now, userNum, this.row["Id"].ToString() };
                }
                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    if ((this.row == null || this.row["CardId"] == null || this.row["CardId"].ToString() == "") && !string.IsNullOrEmpty(cardId))//新增和编辑都有可能发卡,只能判断原来没有卡，现在有卡，表示新发卡
                        DBHelper.ExecuteNonQuery("Update Card Set Status=2 where CardID=@CardID", new string[] { "@CardID" }, new object[] { cardId });
                    MessageBox.Show("保存成功！");
                    CommStatic.TxtBoxCardId = null;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmAddEmployee));
            }
        }

        private void frmAddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CommStatic.FrmAddEmployee = null;
            CommStatic.TxtBoxCardId = null;
            CommStatic.FrmMain.InitSystemInfo();
            this.DialogResult = DialogResult.OK;
        }
    }
}
