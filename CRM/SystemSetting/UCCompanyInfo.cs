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
    public partial class UCCompanyInfo : UserControl
    {
        private DataTable DtProvince;
        public UCCompanyInfo()
        {
            InitializeComponent();
            getProvince();
            InitData();
        }

        private void getProvince()
        {
            string sql = "select * from Province";
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            if (ds == null) return;
            DtProvince = ds.Tables[0];
            cmboxProvince.DataSource = getTable("level=1");
            cmboxProvince.DisplayMember = "name";
            cmboxProvince.ValueMember = "id";
        }

        private void InitData()
        {
            try
            {
                string sql = "select * from SysConfig  where key='CompanyAddress'";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                txtCompanyName.Text = (row["Value1"] == null || row["Value1"].ToString() == "") ? "" : row["Value1"].ToString();
                txtTel.Text = (row["Value2"] == null || row["Value2"].ToString() == "") ? "" : row["Value2"].ToString();
                txtLeaderName.Text = (row["Value3"] == null || row["Value3"].ToString() == "") ? "" : row["Value3"].ToString();
                txtDetailAddress.Text = (row["Value8"] == null || row["Value8"].ToString() == "") ? "" : row["Value8"].ToString();
                if(row["Value4"] != null && row["Value4"].ToString() != "")
                 cmboxProvince.SelectedValue =row["Value4"].ToString();
                if(row["Value5"] != null && row["Value5"].ToString()!= "")
                 cmboxCity.SelectedValue =row["Value5"].ToString();
                if(row["Value6"] != null && row["Value6"].ToString() != "")
                 cmboxeare.SelectedValue =row["Value6"].ToString();
                if(row["Value7"] != null&& row["Value7"].ToString()!= "")
                 cmboxroud.SelectedValue =row["Value7"].ToString();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCCompanyInfo));
            }
        }

        private DataTable getTable(string whereSql)
        {
            DataTable dt = DtProvince.Clone();
            DataRow[] rows = DtProvince.Select(whereSql);
            if (rows.Length < 1) return dt;
            foreach (DataRow row in rows)
            {
                DataRow newrow = dt.NewRow();
                newrow.ItemArray = row.ItemArray;
                dt.Rows.Add(newrow);
            }

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            dt.AcceptChanges();
            return dt;
        }

        private void cmboxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboxProvince.SelectedValue == null || cmboxProvince.SelectedValue.ToString() == "")
            {
                cmboxCity.DataSource = null;
                cmboxeare.DataSource = null;
                cmboxroud.DataSource = null;
                return;
            }
            string id = cmboxProvince.SelectedValue.ToString();
            cmboxCity.DataSource = getTable("upid="+id);
            cmboxCity.DisplayMember = "name";
            cmboxCity.ValueMember = "id";
        }

        private void cmboxCity_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmboxCity.SelectedValue == null || cmboxCity.SelectedValue.ToString() == "")
            {
                cmboxeare.DataSource = null;
                cmboxroud.DataSource = null;
                return;
            }
            string id = "";
            if (cmboxCity.SelectedValue is DataRowView)
            {
                DataRowView view = cmboxCity.SelectedValue as DataRowView;
                if (view.Row["Id"] == null || view.Row["Id"].ToString() == "") return;
                 id = view.Row["Id"].ToString();
            }
            else
                id = cmboxCity.SelectedValue.ToString();
            if (string.IsNullOrEmpty(id)) return;
            cmboxeare.DataSource = getTable("upid=" + id);
            cmboxeare.DisplayMember = "name";
            cmboxeare.ValueMember = "id";
        }

        private void cmboxeare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboxeare.SelectedValue == null || cmboxeare.SelectedValue.ToString() == "")
            {
                cmboxroud.DataSource = null;
                return;
            }
            string id = "";
            if (cmboxeare.SelectedValue is DataRowView)
            {
                DataRowView view = cmboxeare.SelectedValue as DataRowView;
                if (view.Row["Id"] == null || view.Row["Id"].ToString() == "") return;
                 id = view.Row["Id"].ToString();
            }
            else
                id = cmboxeare.SelectedValue.ToString();
            if (string.IsNullOrEmpty(id)) return;
            cmboxroud.DataSource = getTable("upid=" + id);
            cmboxroud.DisplayMember = "name";
            cmboxroud.ValueMember = "id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string company = txtCompanyName.Text;
                if (string.IsNullOrEmpty(company))
                {
                    MessageBox.Show("请输入企业名称");
                    return;
                }
                string tel = txtTel.Text;
                if (string.IsNullOrEmpty(tel))
                {
                    MessageBox.Show("请输入联系电话");
                    return;
                }
                string leaderName = txtLeaderName.Text;
                if (string.IsNullOrEmpty(leaderName))
                {
                    MessageBox.Show("请输入负责人姓名");
                    return;
                }
                if (cmboxProvince.SelectedValue == null || cmboxProvince.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("请选择所在省份");
                    return;
                }
                string pId = cmboxProvince.SelectedValue.ToString();
                if (cmboxCity.SelectedValue == null || cmboxCity.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("请选择地市");
                    return;
                }
                string cityId = cmboxCity.SelectedValue.ToString();
                if (cmboxeare.SelectedValue == null || cmboxeare.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("请选择区县");
                    return;
                }
                string eareId = cmboxeare.SelectedValue.ToString();
                if (cmboxroud.Items.Count>0)
                {
                    if (cmboxroud.SelectedValue == null || cmboxroud.SelectedValue.ToString() == "")
                    {
                        MessageBox.Show("请选择乡镇");
                        return;
                    }
                }
                string roudId =(cmboxroud.SelectedValue==null||cmboxroud.SelectedValue.ToString()=="")?"":cmboxroud.SelectedValue.ToString();
                if (string.IsNullOrEmpty(txtDetailAddress.Text))
                {
                    MessageBox.Show("请输入详细地址");
                    return;
                }
                string sql = "Update  SysConfig set Value1='{0}',Value2='{1}',Value3='{2}',Value4='{3}',Value5='{4}',Value6='{5}',Value7='{6}',Value8='{7}' where key='CompanyAddress'";
                sql = string.Format(sql, company, tel, leaderName, pId, cityId, eareId, roudId, txtDetailAddress.Text);
                if (DBHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("保存成功");

                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCCompanyInfo));
            }
        }
    }
}
