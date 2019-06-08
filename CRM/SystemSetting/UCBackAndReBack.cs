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
using System.IO;

using Tools;

namespace CRM
{
    public partial class UCBackAndReBack : UserControl
    {
        public UCBackAndReBack()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        { 
            DataSet ds=DBHelper.ExecuteDataSet("select key,value1,value2 from SysConfig where key='BackUpTime'");
            if(ds==null||ds.Tables[0].Rows.Count<1)
            {
                MessageBox.Show("数据错误请联系管理员");
                return;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr["Value1"] != null && dr["Value1"].ToString() != "")
            {
                dateTimePickerAutoTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + dr["Value1"].ToString());
                radioButtonAutoBackUp.Checked = true;
            }
            else
                radioButtonMenueBackUp.Checked = true;
            if (dr["Value2"] != null && dr["Value2"].ToString() != "")
            {
                txtBackUpPath.Text = dr["Value2"].ToString();
                openFileDialog1.InitialDirectory=txtBackUpPath.Text;
                folderBrowserDialog1.SelectedPath =txtBackUpPath.Text;
            }
        }

        private void btnBrower_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderBrowserDialog1.ShowNewFolderButton = true;
                if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                    txtBackUpPath.Text = folderBrowserDialog1.SelectedPath;
                else
                    MessageBox.Show("您选择的路径不存在，请重新选择");
               
            }
        }

        private void radioButtonAutoBackUp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAutoBackUp.Checked)
            {
                btnBackUp.Enabled = false;
                panelAutoBack.Enabled = true;
            }
        }

        private void radioButtonMenueBackUp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMenueBackUp.Checked)
            {
                btnBackUp.Enabled = true;
                panelAutoBack.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtBackUpPath.Text;
                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("请选择备份路径");
                    return;
                }
                string time = "";
                if (sender != null)
                {
                    time= dateTimePickerAutoTime.Value.ToString("HH:mm");
                    if (MessageBox.Show("您确定要在每天的" + time + "进行自动备份吗？") != DialogResult.OK)
                        return;
                }
                string sql = "Update SysConfig set Value1='" + time + "',Value2='"+path+"' where Key='BackUpTime'";
                int ok=DBHelper.ExecuteNonQuery(sql);
                if (sender != null)
                {
                    if ( ok> 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCBackAndReBack));
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            string path = txtBackUpPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择备份路径");
                return;
            }
            try
            {
                btnSave_Click(null, null);
                File.Copy(DBHelper.DBFilePath, path+"\\"+DateTime.Now.ToString("yyyyMMddHHmmss") + ".back", true);
                MessageBox.Show("备份成功");
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCBackAndReBack));
            }
        }

        private void btnBrower1_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Filter = "备份文件(*.back)|*.back";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                    txtReStore.Text = openFileDialog1.FileName;
                else
                    MessageBox.Show("文件不存在，请选择有效的文件");
                
            }
        }

        private void btnReStore_Click(object sender, EventArgs e)
        {
            string sourcePath = txtReStore.Text;
            if (string.IsNullOrEmpty(sourcePath))
            {
                MessageBox.Show("请选择要还原的文件");
                return;
            }
            try
            {
                File.Copy(sourcePath, DBHelper.DBFilePath+"temp");
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCBackAndReBack));
                MessageBox.Show("数据还原失败"+ex.Message);
                return;
            }
            try
            {
                File.Delete(DBHelper.DBFilePath);
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCBackAndReBack));
                MessageBox.Show("数据还原失败"+ex.Message);
            }
            try
            {
                File.Copy(DBHelper.DBFilePath + "temp", DBHelper.DBFilePath);
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCBackAndReBack));
                MessageBox.Show("数据还原失败"+ex.Message);
            }
            try
            {
                File.Delete(DBHelper.DBFilePath + "temp");
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UCBackAndReBack));
                MessageBox.Show("数据还原成功，但是临时文件"+DBHelper.DBFilePath+"temp删除失败，请手动删除这个文件，防止影响下次还原");
                return;
            }
            MessageBox.Show("还原成功！");
        }


    }
}
