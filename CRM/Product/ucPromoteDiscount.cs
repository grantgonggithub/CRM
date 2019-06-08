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
    public partial class ucPromoteDiscount : UserControl
    {
        private string productId;
        private DataRow selectRow;
        public ucPromoteDiscount()
        {
            InitializeComponent();
            showControl();
            monthCalendar1.Visible = false;
        }

        public ucPromoteDiscount(string _productId)
        {
            InitializeComponent();
            this.productId = _productId;
            showControl();
            monthCalendar1.Visible = false;
            radioButtonDay.Visible = false;
            panelDay.Visible = false;
            radioButtonTimeSpan.Checked = true;
            dgvList.AutoGenerateColumns = false;
            ucCommProductPrice1.InitData(null,2,_productId);
            InitList();
        }

        private void pictureBoxShowDatePic_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
                monthCalendar1.Visible = false;
            else
            {
                monthCalendar1.Visible = true;
                monthCalendar1.BringToFront();
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (txtDateSelected.Text == "")
                txtDateSelected.Text = monthCalendar1.SelectionStart.ToShortDateString();
            else
                txtDateSelected.Text += "," + monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void radioButtonDay_CheckedChanged(object sender, EventArgs e)
        {
            showControl();
        }

        private void radioButtonTimeSpan_CheckedChanged(object sender, EventArgs e)
        {
            showControl();
        }
        private void showControl()
        {
            if (radioButtonDay.Checked)
            {
                panelDay.Enabled=true;
                panelDayPart.Enabled = false;
            }
            else
            {
                panelDay.Enabled = false;
                monthCalendar1.Visible = false;
                panelDayPart.Enabled = true;
            }
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            toolStripButtonEdit_Click(null, null);
        }

        private void InitList()
        {
            try
            {
                string sql = "select * from ProductMainPrice where ProductId=@ProductId and PriceType=@PriceType order by CreateTime desc";
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@ProductId", "@PriceType" }, new object[] { productId, 2 });
                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                DataColumn col = new DataColumn("DiscountTime", typeof(string));
                dt.Columns.Add(col);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["DiscountTimeType"].ToString() == "1")
                        dr["DiscountTime"] = dr["DiscountDay"];
                    else
                    {
                        dr["DiscountTime"] = dr["DiscountStartDay"].ToString() + "--" + dr["DiscountEndDay"].ToString();
                    }
                }
                dgvList.DataSource = dt;
                if (dgvList.Rows.Count > 0)
                {
                    dgvList.Rows[0].Selected = true;
                    toolStripButtonEdit_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucPromoteDiscount));
            }
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            ucCommProductPrice1.InitData(null, 2, productId);
            radioButtonTimeSpan.Checked = true;
            txtDateSelected.Text = "";
            txtDiscountName.Text = "";
            dateTimePickerEnd.Value=dateTimePickerStart.Value = DateTime.Now;
            selectRow = null;
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请在下面列表选择要编辑的促销计划!");
                    return;
                }
                DataGridViewRow dgvRow = col[0];
                int index = dgvRow.Index;
                DataTable dt = dgvList.DataSource as DataTable;
                selectRow = dt.Rows[index];
                ucCommProductPrice1.InitData(selectRow, 2, productId);
                txtDiscountName.Text = selectRow["DiscountName"].ToString();
                if (selectRow["DiscountTimeType"].ToString() == "1")
                {
                    radioButtonDay.Checked = true;
                    txtDateSelected.Text = selectRow["DiscountDay"].ToString();
                    dateTimePickerStart.Value = DateTime.Now;
                    dateTimePickerEnd.Value = DateTime.Now;
                }
                else
                {
                    radioButtonTimeSpan.Checked = true;
                    if (selectRow["DiscountStartDay"] != null && selectRow["DiscountStartDay"].ToString() != "")
                        dateTimePickerStart.Value = DateTime.Parse(selectRow["DiscountStartDay"].ToString());
                    if (selectRow["DiscountEndDay"] != null && selectRow["DiscountEndDay"].ToString() != "")
                        dateTimePickerEnd.Value = DateTime.Parse(selectRow["DiscountEndDay"].ToString());
                    txtDateSelected.Text = "";
                }
                showControl();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucPromoteDiscount));
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除这条促销计划吗？数据删除后将不能再恢复，点击【确定】删除数据，【取消】不删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请在下面列表选择要删除的促销计划!");
                    return;
                }

                DataGridViewRow dgvRow = col[0];
                int index = dgvRow.Index;
                DataTable dt = dgvList.DataSource as DataTable;
                DataRow row = dt.Rows[index];
                string id = row["Id"].ToString();
                string sql = "delete from ProductMainPrice where Id='" + id + "'";
                if (DBHelper.ExecuteNonQuery(sql, null, null) > 0)
                {
                    sql = "delete from ProductMemberShipPrice where ProductId=@ProductId and ProductMainPriceId=@ProductMainPriceId";
                    DBHelper.ExecuteNonQuery(sql, new string[] { "@ProductId", "@ProductMainPriceId" }, new object[] { this.productId, id });
                    InitList();
                    MessageBox.Show("删除成功！");
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucPromoteDiscount));
            }
        }

        private void btnSaveTimeSpan_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ucCommProductPrice1.row;//以内层控件的row为准，里面有可能新增
                if (dr == null)
                {
                    MessageBox.Show("请先完善基本价格之后，再确定折扣时间");
                    return;
                }
                string discountName = txtDiscountName.Text;
                if (string.IsNullOrEmpty(discountName))
                {
                    MessageBox.Show("请为这个促销计划起个名字吧，比如：2014年5月1日促销");
                    return;
                }
                string dateSelected = "";
                DateTime start = DateTime.MinValue;
                DateTime end = DateTime.MinValue;
                int discountType;
                if (radioButtonDay.Checked)
                {
                    dateSelected = txtDateSelected.Text;
                    if (dateSelected == "")
                    {
                        MessageBox.Show("请点击后面的日历选择促销日期");
                        return;
                    }
                    string[] list = dateSelected.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (list.Length < 1)
                    {
                        MessageBox.Show("输入的日期格式不正确，请删除后，重新选择");
                        return;
                    }
                    foreach (string s in list)
                    {
                        DateTime t;
                        if (!DateTime.TryParse(s, out t))
                        {
                            MessageBox.Show("输入的日期格式不正确，请删除后，重新选择");
                            return;
                        }
                    }
                    discountType = 1;
                }
                else
                {
                    start = DateTime.Parse(dateTimePickerStart.Value.ToShortDateString());
                    end = DateTime.Parse(dateTimePickerEnd.Value.ToShortDateString());
                    DateTime timeNow = DateTime.Parse(DateTime.Now.ToShortDateString());
                    if (start < timeNow)
                    {
                        MessageBox.Show("促销计划开始时间不能小于今天");
                        return;
                    }
                    if (start > end)
                    {
                        MessageBox.Show("促销结束时间不能小于开始时间");
                        return;
                    }
                    discountType = 2;

                }
                string prm = "";
                List<object> objList = new List<object>();
                string sql = "Update ProductMainPrice set DiscountName=@DiscountName,DiscountTimeType=@DiscountTimeType,UpdateTime=@UpdateTime,";
                objList.Add(txtDiscountName.Text);
                objList.Add(discountType);
                objList.Add(DateTime.Now);
                prm += "@DiscountName,@DiscountTimeType,@UpdateTime";
                if (discountType == 1)
                {
                    sql += " DiscountDay=@DiscountDay ,DiscountStartDay=null,DiscountEndDay=null";
                    prm += ",@DiscountDay";
                    objList.Add(dateSelected);
                }
                else
                {
                    sql += " DiscountStartDay=@DiscountStartDay,DiscountEndDay=@DiscountEndDay,DiscountDay=''";
                    prm += ",@DiscountStartDay,@DiscountEndDay";
                    objList.Add(start);
                    objList.Add(end);
                }
                sql += " where Id=@Id";
                prm += ",@Id";
                objList.Add(dr["Id"].ToString());
                if (DBHelper.ExecuteNonQuery(sql, prm.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries), objList.ToArray()) > 0)
                {
                    InitList();
                    MessageBox.Show("修改成功！");
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucPromoteDiscount));
            }

        }
    }
}
