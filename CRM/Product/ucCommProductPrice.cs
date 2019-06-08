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
    public partial class ucCommProductPrice : UserControl
    {
        public DataRow row;//在传进来的时候null，在里面添加完之后就不为null，所以外面需要知道；
        private string productId;
        private int priceType;

        public ucCommProductPrice()
        {
            InitializeComponent();
            TvList.ImageList = imageList1;
        }

        public ucCommProductPrice(DataRow _row,int _priceType,string _productId)
        {
            InitializeComponent();
            InitData(_row, _priceType, _productId);
        }

        public void InitData(DataRow _row, int _priceType, string _productId)
        {
            try
            {
                this.row = _row;
                this.priceType = _priceType;
                this.productId = _productId;
                TvList.ImageList = imageList1;
                if (this.row != null && this.row["MarketPrice"] != null && this.row["MarketPrice"].ToString() != "")
                    txtBasicPrice.Text = row["MarketPrice"].ToString();
                else
                {
                    txtBasicPrice.Text = "";
                    txtDiscountPrice.Text = "";
                    txtDiscountRate.Text = "";
                    radioButtonDiscountRate.Checked = true;
                }
                panelRight.Enabled = false;
                InitTv();
                radioButtonDiscountRate_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucCommProductPrice));
            }
        }

        public void InitTv()
        {
            try
            {
                string sql = "select * from UserType where Sort=1";
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                TvList.Nodes.Clear();
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];
                TreeNode[] nodes = new TreeNode[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    nodes[i] = new TreeNode();
                    nodes[i].Text = row["UserTypeName"].ToString();
                    nodes[i].Tag = row["Id"].ToString();
                    nodes[i].ImageIndex = 0;
                }
                TvList.ExpandAll();
                TvList.Nodes.AddRange(nodes);
                TvList.SelectedNode = nodes[0];
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucCommProductPrice));
            }
        }

        private void btnSaveBasic_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                string[] prm = null;
                object[] obj = null;
                if (string.IsNullOrEmpty(txtBasicPrice.Text.Trim()))
                {
                    MessageBox.Show("请输入基本价格");
                    return;
                }
                string mainPriceId;
                if (this.row == null)
                {
                    sql = "Insert into ProductMainPrice(Id,ProductId,PriceType,MarketPrice,CreateTime,UpdateTime)values(@Id,@ProductId,@PriceType,@MarketPrice,@CreateTime,@UpdateTime)";
                    prm = new string[] { "@Id", "@ProductId", "@PriceType", "@MarketPrice", "@CreateTime", "@UpdateTime" };
                    obj = new object[] { mainPriceId = Guid.NewGuid().ToString("N"), productId, priceType, txtBasicPrice.Text.Trim(), DateTime.Now, DateTime.Now };
                }
                else
                {
                    sql = "Update ProductMainPrice set MarketPrice=@MarketPrice,UpdateTime=@UpdateTime where Id=@Id";
                    prm = new string[] { "@MarketPrice", "@Id", "@UpdateTime" };
                    obj = new object[] { txtBasicPrice.Text.Trim(), mainPriceId = row["Id"].ToString(), DateTime.Now };
                }
                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    sql = "select * from ProductMainPrice where Id='" + mainPriceId + "'";
                    DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        row = ds.Tables[0].Rows[0];
                    }
                    MessageBox.Show("基本价格保存成功！");
                    return;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucCommProductPrice));
            }
        }

        private void TvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tn = TvList.SelectedNode;
                clear();
                if (this.row == null || tn == null || tn.Tag == null || tn.Tag.ToString() == "") return;
                string sql = "select * from ProductMemberShipPrice where ProductId=@ProductId and ProductMainPriceId=@ProductMainPriceId and UserTypeId=@UserTypeId";
                DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@ProductId", "@ProductMainPriceId", "@UserTypeId" }, new object[] { this.row["ProductId"].ToString(), this.row["Id"].ToString(), tn.Tag.ToString() });
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataRow row = ds.Tables[0].Rows[0];
                btnVipSave.Tag = row["Id"].ToString();
                string discountType = row["DiscountType"].ToString();
                if (discountType == "2")
                {
                    radioButtonDiscountPrice.Checked = true;
                    txtDiscountPrice.Text = row["DiscountPrice"].ToString();
                    txtDiscountPrice.Enabled = true;
                    txtDiscountRate.Enabled = false;
                }
                else
                {
                    txtDiscountRate.Text = row["DiscountRate"].ToString();
                    radioButtonDiscountRate.Checked = true;
                    txtDiscountRate.Enabled = true;
                    txtDiscountPrice.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucCommProductPrice));
            }
        }

        private void btnVipSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBasicPrice.Text == "" || this.row == null)
                {
                    MessageBox.Show("请先完善基本价格，再添加会员价格");
                    txtBasicPrice.Focus();
                    return;
                }
                TreeNode tn = TvList.SelectedNode;

                if (tn == null || tn.Tag == null || tn.Tag.ToString() == "")
                {
                    MessageBox.Show("请先选择会员类型！");
                    return;
                }
                string vipTypeId = tn.Tag.ToString();
                string discountType = "1";

                if (radioButtonDiscountRate.Checked)
                {
                    discountType = "1";
                    if (txtDiscountRate.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入折扣点数");
                        return;
                    }
                    float rate;
                    if (!float.TryParse(txtDiscountRate.Text.Trim(), out rate))
                    {
                        MessageBox.Show("折扣点数必须是数字类型"); ;
                        return;
                    }
                    if (rate < 1 || rate > 10)
                    {
                        MessageBox.Show("折扣点数必须是介于1和10直接的数字");
                        return;
                    }
                    txtDiscountPrice.Text = "";
                }
                else
                {
                    discountType = "2";
                    if (txtDiscountPrice.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入折扣价格");
                        return;
                    }
                    float price;
                    if (!float.TryParse(txtDiscountPrice.Text.Trim(), out price))
                    {
                        MessageBox.Show("折扣价格必须是数字");
                        return;
                    }
                    txtDiscountRate.Text = "";
                }
                string sql = "";
                string[] prm = null;
                object[] obj = null;
                if (btnVipSave.Tag == null || btnVipSave.Tag.ToString() == "")
                {
                    sql = "Insert into ProductMemberShipPrice(Id,ProductId,ProductMainPriceId,UserTypeId,DiscountType,DiscountPrice,DiscountRate,CreateTime,UpdateTime)values(@Id,@ProductId,@ProductMainPriceId,@UserTypeId,@DiscountType,@DiscountPrice,@DiscountRate,@CreateTime,@UpdateTime)";
                    prm = new string[] { "@Id", "@ProductId", "@ProductMainPriceId", "@UserTypeId", "@DiscountType", "@DiscountPrice", "@DiscountRate", "@CreateTime", "@UpdateTime" };
                    obj = new object[] { Guid.NewGuid().ToString("N"), row["ProductId"].ToString(), row["Id"].ToString(), vipTypeId, discountType, txtDiscountPrice.Text.Trim(), txtDiscountRate.Text.Trim(), DateTime.Now, DateTime.Now };
                }
                else
                {
                    sql = "Update ProductMemberShipPrice set DiscountType=@DiscountType,DiscountPrice=@DiscountPrice,DiscountRate=@DiscountRate,UpdateTime=@UpdateTime where Id=@Id";
                    prm = new string[] { "@DiscountType", "@DiscountPrice", "@DiscountRate", "@Id", "@UpdateTime" };
                    obj = new object[] { discountType, txtDiscountPrice.Text.Trim(), txtDiscountRate.Text.Trim(), btnVipSave.Tag.ToString(), DateTime.Now };
                }
                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    MessageBox.Show("此会员价格保存成功！");
                    return;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(ucCommProductPrice));
            }

        }
        private void clear()
        {
            radioButtonDiscountRate.Checked = true;
            radioButtonDiscountPrice.Checked = false;
            txtDiscountPrice.Text = "";
            txtDiscountRate.Text = "";
            btnVipSave.Tag = null;
            panelRight.Enabled = true;
            radioButtonDiscountRate_CheckedChanged(null, null);
        }

        private void radioButtonDiscountRate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDiscountRate.Checked)
            {
                txtDiscountRate.Enabled = true;
                txtDiscountPrice.Enabled = false;
            }
            else
            {
                txtDiscountRate.Enabled = false;
                txtDiscountPrice.Enabled = true;
            }
        }
    }
}
