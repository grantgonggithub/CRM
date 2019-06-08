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
    public partial class frmAddProductName : skinBase
    {
        private DataRow row;
        public frmAddProductName()
        {
            InitializeComponent();
        }
        public frmAddProductName(DataRow _row)
        {
            InitializeComponent();
            this.row = _row;
            this.txtProductName.Text = row["ProductName"].ToString();
            this.txtRemark.Text = row["Remark"] == null ? "" : row["Remark"].ToString();
            txtProductName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text))
                {
                    MessageBox.Show("产品或者服务名称不能为空");
                    return;
                }
                string sql = "select * from Product where ProductName=@ProductName" + (this.row == null ? "" : " and Id<>'" + this.row["Id"].ToString() + "'");
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@ProductName" }, new object[] { txtProductName.Text.Trim() });
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("名字为\"" + txtProductName.Text + "\"的产品或者服务已经存在，请直接对其进行设置");
                    return;
                }
                string[] prm = null;
                object[] obj = null;
                if (row == null)
                {
                    sql = "Insert into Product(ID,ProductName,Remark,CreateTime,UpdateTime)values(@ID,@ProductName,@Remark,@CreateTime,@UpdateTime)";
                    prm = new string[] { "@ID", "@ProductName", "@Remark", "@CreateTime", "@UpdateTime" };
                    obj = new object[] { Guid.NewGuid().ToString("N"), txtProductName.Text, txtRemark.Text.Trim() == "" ? "" : txtRemark.Text, DateTime.Now, DateTime.Now };
                }
                else
                {
                    sql = "Update Product set ProductName=@ProductName,Remark=@Remark,UpdateTime=@UpdateTime where Id=@Id";
                    prm = new string[] { "@ProductName", "@Remark", "@Id", "@UpdateTime" };
                    obj = new object[] { txtProductName.Text.Trim(), txtRemark.Text.Trim() == "" ? "" : txtRemark.Text.Trim(), row["Id"].ToString(), DateTime.Now };
                }
                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmAddProductName));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
