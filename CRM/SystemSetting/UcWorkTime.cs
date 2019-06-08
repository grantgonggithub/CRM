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
    public partial class UcWorkTime : UserControl
    {
        public UcWorkTime()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            try
            {
                string sql = "select * from SysConfig where key='StartWorkTimeSetting' or key='GoOffWorkTimeSetting'";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 2) return;
                DataTable dt = ds.Tables[0];
                DataRow row0;
                DataRow row1;
                if (dt.Rows[0]["key"].ToString() == "StartWorkTimeSetting")
                {
                    row0 = dt.Rows[0];
                    row1 = dt.Rows[1];
                }
                else
                {
                    row0 = dt.Rows[1];
                    row1 = dt.Rows[0];
                }

                nupdStartHour1.Value = decimal.Parse(row0["Value1"].ToString());
                nupdStartMinite1.Value = decimal.Parse(row0["Value2"].ToString());
                nupdStartHour2.Value = decimal.Parse(row0["Value3"].ToString());
                nupdStartMinite2.Value = decimal.Parse(row0["Value4"].ToString());

                nupdGoOffHour1.Value = decimal.Parse(row1["Value1"].ToString());
                nupdGoOffMinite1.Value = decimal.Parse(row1["Value2"].ToString());
                nupdGoOffHour2.Value = decimal.Parse(row1["Value3"].ToString());
                nupdGoOffMinite2.Value = decimal.Parse(row1["Value4"].ToString());
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UcWorkTime));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (nupdStartHour1.Value > nupdStartHour2.Value)
                {
                    MessageBox.Show("上班时间不能比迟到时间晚");
                    return;
                }
                if (nupdStartHour1.Value == nupdStartHour2.Value)
                {
                    if (nupdStartMinite1.Value > nupdStartMinite2.Value)
                    {
                        MessageBox.Show("上班时间不能比迟到时间晚");
                        return;
                    }
                }
                if (nupdGoOffHour1.Value < nupdGoOffHour2.Value)
                {
                    MessageBox.Show("下班时间不能比早退时间早");
                    return;
                }
                if (nupdGoOffHour1.Value == nupdGoOffHour2.Value)
                {
                    if (nupdGoOffMinite1.Value < nupdGoOffMinite2.Value)
                    {
                        MessageBox.Show("下班时间不能比早退时间早");
                        return;
                    }
                }
                string sql = "Update SysConfig set Value1='{0}',Value2='{1}',Value3='{2}',Value4='{3}' where key='{4}'";
                if (DBHelper.ExecuteNonQuery(string.Format(sql, nupdStartHour1.Value, nupdStartMinite1.Value, nupdStartHour2.Value, nupdStartMinite2.Value, "StartWorkTimeSetting")) > 0)
                {
                    if (DBHelper.ExecuteNonQuery(string.Format(sql, nupdGoOffHour1.Value, nupdGoOffMinite1.Value, nupdGoOffHour2.Value, nupdGoOffMinite2.Value, "GoOffWorkTimeSetting")) > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(UcWorkTime));
            }
        }
    }
}
