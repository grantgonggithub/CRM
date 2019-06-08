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
    public partial class frmCardMgr : skinBase
    {
        private DataTable dtOrg;
        public frmCardMgr()
        {
            InitializeComponent();
            dgvCardList.AutoGenerateColumns = false;
            InitList();
            CommStatic.TxtBoxCardId = txtCardId;
            txtCardId.Focus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFilePath.Text == "" || !File.Exists(txtFilePath.Text))
                {
                    MessageBox.Show("所选择的路径不存在，请选择正确的文件路径");
                    return;
                }
                string lineData;
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(txtFilePath.Text, Encoding.UTF8))
                {
                    lineData = reader.ReadLine();
                    string[] col;
                    string sql;
                    while (!string.IsNullOrEmpty(lineData))
                    {
                        string clearTxt = Tools.Tools.Decrypt(lineData);//解除明文
                        col = clearTxt.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (col.Length != 4)
                        {
                            sb.Append("------(非法数据)");
                            goto gotoHere;//跳过
                        }
                        sql = "select * from Card where CardID=@CardID";
                        DataSet ds = DBHelper.ExecuteDataSet(sql, new string[] { "@CardID" }, new object[] { col[0] });
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            sb.AppendLine(lineData + "------(卡已经存在)");
                            goto gotoHere;
                        }
                        sql = "Insert into Card(ID,CardId,Status,Key,CreateTime,Org)values(@ID,@CardId,@Status,@Key,@CreateTime,@Org)";
                        string[] prm = new string[] { "@ID", "@CardId", "@Status", "@Key", "@CreateTime", "@Org" };
                        object[] obj = new object[] { Guid.NewGuid().ToString("N"), col[0], col[1], col[2], DateTime.Parse(col[3]), lineData };
                        if (DBHelper.ExecuteNonQuery(sql, prm, obj) < 1)
                            sb.AppendLine(lineData + "------(插入数据失败)");
                    gotoHere:
                        lineData = reader.ReadLine();
                    }
                }
                if (sb.Length > 0)
                {
                    Tools.TracingHelper.Error("有如下卡号导入失败：" + sb.ToString());
                    MessageBox.Show("有部分卡号导入失败，详情见日志！");
                }
                else
                {
                    MessageBox.Show("卡号导入成功！");
                }
                InitList();
                CommStatic.FrmMain.InitSystemInfo();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCardMgr));
            }
        }

        private void InitList()
        {
            try
            {
                DataSet ds = DBHelper.ExecuteDataSet("select Id,CardId,(case status when 1 then '未使用' when 2 then '已使用' end) as status,CreateTime from Card order by CreateTime desc", null, null);
                if (ds == null || ds.Tables[0].Rows.Count < 1) return;
                dtOrg = ds.Tables[0];
                dgvCardList.DataSource = dtOrg;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCardMgr));
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCardId.Text == "" && cmbxStatus.Text == "")
                {
                    InitList();
                    return;
                }
                if (dtOrg == null || dtOrg.Rows.Count < 1)
                    return;
                DataRow[] rows = dtOrg.Select("1=1" + (txtCardId.Text.Trim() == "" ? "" : (" and CardID like'%" + txtCardId.Text.Trim() + "%'")) + (cmbxStatus.Text == "" ? "" : (" and status='" + cmbxStatus.Text + "'")));
                DataTable temp = dtOrg.Clone();
                foreach (DataRow row in rows)
                {
                    DataRow dr = temp.NewRow();
                    dr.ItemArray = row.ItemArray;
                    temp.Rows.Add(dr);
                }
                dgvCardList.DataSource = temp;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmCardMgr));
            }
        }

        private void frmCardMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommStatic.TxtBoxCardId = null;
        }
    }
}
