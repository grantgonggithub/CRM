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
    public partial class frmProductsMgr : skinBase
    {
        public frmProductsMgr()
        {
            InitializeComponent();
            tvList.ImageList = imageList1;
            InitTv();
            this.Focus();
        }

        private void InitTv()
        {
            try
            {
                string sql = "select * from product";
                DataSet ds = DBHelper.ExecuteDataSet(sql, null, null);
                tvList.Nodes.Clear();
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                DataTable dt = ds.Tables[0];
                TreeNode[] nodes = new TreeNode[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    nodes[i] = new TreeNode(row["ProductName"].ToString());
                    nodes[i].Tag = row;
                    nodes[i].ImageIndex = 0;
                    nodes[i].SelectedImageIndex = 0;

                    TreeNode[] childs = new TreeNode[2];
                    childs[0] = new TreeNode("日常价格");
                    childs[0].Tag = row["Id"].ToString();
                    childs[0].ImageIndex = 1;
                    childs[0].SelectedImageIndex = 2;

                    childs[1] = new TreeNode("促销计划");
                    childs[1].Tag = row["Id"].ToString();
                    childs[1].ImageIndex = 1;
                    childs[1].SelectedImageIndex = 2;

                    nodes[i].Nodes.AddRange(childs);
                }
                tvList.Nodes.AddRange(nodes);
                //tvList.ExpandAll();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmProductsMgr));
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            frmAddProductName addProduct = new frmAddProductName();
            if (addProduct.ShowDialog() == DialogResult.OK)
            {
                InitTv();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = tvList.SelectedNode;
            DataRow row=null;
            if (node != null && node.Tag is DataRow)
            {
                row = node.Tag as DataRow;
            }
            else
            {
                MessageBox.Show("只能修改产品或者服务名称节点，其他节点不能修改");
                return;
            }
            frmAddProductName addProduct = new frmAddProductName(row);
            if (addProduct.ShowDialog() == DialogResult.OK)
            {
                InitTv();
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = tvList.SelectedNode;
                DataRow row = null;
                if (node != null && node.Tag is DataRow)
                {
                    row = node.Tag as DataRow;
                }
                else
                {
                    MessageBox.Show("只能删除产品或者服务名称节点，其他节点不能删除！");
                    return;
                }
                if (MessageBox.Show("确定要删除此产品或者服务吗？删除之后数据将不能恢复,请谨慎操作，选【确定】删除，【取消】不删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string sql = "delete from Product where Id=@Id";
                    if (DBHelper.ExecuteNonQuery(sql, new string[] { "@Id" }, new object[] { row["Id"].ToString() }) > 0)
                    {
                        sql = "delete from ProductMainPrice where ProductId=@Id";
                        DBHelper.ExecuteNonQuery(sql, new string[] { "@Id" }, new object[] { row["Id"].ToString() });
                        sql = "delete from ProductMemberShipPrice where ProductId=@Id";
                        DBHelper.ExecuteNonQuery(sql, new string[] { "@Id" }, new object[] { row["Id"].ToString() });
                        InitTv();
                    }
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmProductsMgr));
                MessageBox.Show(ex.Message);
            }
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode node = tvList.SelectedNode;
                panelRightContent.Controls.Clear();
                if (node != null && node.Tag is DataRow)
                {
                    ucProductHelperMsg msg = new ucProductHelperMsg();
                    msg.Dock = DockStyle.Fill;
                    panelRightContent.Controls.Add(msg);
                    return;
                }
                string tag = node.Tag.ToString();
                string nodeText = node.Text;
                switch (nodeText)
                {
                    case "日常价格":
                        string sql = "select * from ProductMainPrice where ProductId=@ProductId and PriceType=1";
                        DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@ProductId" }, new object[] { tag });
                        DataRow row = null;
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            row = ds.Tables[0].Rows[0];
                        }
                        ucCommProductPrice commPrice = new ucCommProductPrice(row, 1, tag);//日常价格PriceType=1;,如果是第一次添加，这个row==null，所以需要传进去个productId
                        commPrice.Dock = DockStyle.Fill;
                        panelRightContent.Controls.Add(commPrice);
                        break;
                    case "促销计划":
                        ucPromoteDiscount promoteDiscount = new ucPromoteDiscount(tag);
                        promoteDiscount.Dock = DockStyle.Fill;
                        panelRightContent.Controls.Add(promoteDiscount);
                        break;
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmProductsMgr));
                MessageBox.Show(ex.Message);
            }
        }

        private void frmProductsMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.FrmMain.InitSystemInfo();
            this.DialogResult = DialogResult.OK;
        }
    }
}
