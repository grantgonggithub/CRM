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
    public partial class frmEventWaring : skinBase
    {
        public frmEventWaring()
        {
            InitializeComponent();
            cmbxWaringType.Text = "一次提醒";
            cmbxWaringType_SelectedIndexChanged(null, null);
            dgvList.AutoGenerateColumns = false;
            InItList();
            txtTitle.Focus();
        }

        private void InitMonthDay()
        {
            DateTime time = DateTime.Now;
            int MothDays = GetDay(time.Year, time.Month);
            for (int i = 1; i <=MothDays; i++)
            {
                cmbxWaringMothDate.Items.Add(i + "日");
            }
        }
        //输入月份后获得该月天数
        private int GetDay(int year, int month)
        {
            int result = 31;
            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    result = 30;
                    break;
                case 2:
                    if ((year % 100 != 0) && (year % 4 == 0) || (year % 400 == 0))
                    {
                        result = 29;
                    }
                    else
                    {
                        result = 28;
                    }
                    break;
            }
            return result;
        }

        private void cmbxWaringType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string waringType = cmbxWaringType.Text;
            if (waringType == "") return;
            switch (waringType)
            { 
                case "一次提醒":
                    panelWaringOneTime.Visible = true;
                    panelWaringEveryDate.Visible = false;
                    panelWaringEveryMoth.Visible = false;
                    panelWaringEveryWeek.Visible = false;
                    break;
                case "每日提醒":
                    panelWaringOneTime.Visible = false;
                    panelWaringEveryDate.Visible = true;
                    panelWaringEveryMoth.Visible = false;
                    panelWaringEveryWeek.Visible = false;
                    break;
                case "每周提醒":
                    panelWaringOneTime.Visible = false;
                    panelWaringEveryDate.Visible = false;
                    panelWaringEveryMoth.Visible = false;
                    panelWaringEveryWeek.Visible = true;
                    break;
                case "每月提醒":
                    panelWaringOneTime.Visible = false;
                    panelWaringEveryDate.Visible = false;
                    panelWaringEveryMoth.Visible = true;
                    panelWaringEveryWeek.Visible = false;
                    InitMonthDay();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void InItList()
        {
            try
            {
                string sql = "select ID,WaringTitle,EventContent,WaringType,(case WaringType when 1 then '一次提醒' when 2 then '每日提醒' when 3 then '每周提醒' when 4 then '每月提醒' end) as WaringTypeName,WaringTime,CycleWaringMonth,CycleWaringWeek,CycleWaringTime,(case Expired when 1 then '等待提醒' when 2 then '已经提醒' end) as Expired,WaringCount,CreateTime from EventWaring order by CreateTime desc";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                DataColumn col = new DataColumn("WaringDateTime", typeof(string));
                dt.Columns.Add(col);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["WaringType"] == null || row["WaringType"].ToString() == "") continue;
                    DateTime time = DateTime.MinValue;
                    if (row["CycleWaringTime"] != null && row["CycleWaringTime"].ToString() != "")
                        time = DateTime.Parse(row["CycleWaringTime"].ToString());
                    switch (row["WaringType"].ToString())
                    {
                        case "1":
                            row["WaringDateTime"] = row["WaringTime"].ToString();
                            break;
                        case "2":
                            row["WaringDateTime"] = time.Hour + ":" + time.Minute;
                            break;
                        case "3":
                            row["WaringDateTime"] = row["CycleWaringWeek"].ToString() + " " + time.Hour + ":" + time.Minute;
                            break;
                        case "4":
                            row["WaringDateTime"] = row["CycleWaringMonth"].ToString() + " " + time.Hour + ":" + time.Minute;
                            break;
                        default:
                            break;
                    }
                }
                dt.AcceptChanges();
                dgvList.DataSource = dt;
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmEventWaring));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                if (string.IsNullOrEmpty(title))
                {
                    MessageBox.Show("给提醒起个名字子吧，便于跟其他提醒区分");
                    return;
                }
                string waringContent = txtWaringContent.Text;
                if (string.IsNullOrEmpty(waringContent))
                {
                    MessageBox.Show("请输入提醒事件的内容");
                    return;
                }
                string waringType = cmbxWaringType.Text;
                if (string.IsNullOrEmpty(waringType))
                {
                    MessageBox.Show("请选择提醒的类型");
                    return;
                }
                string sql = "Insert into EventWaring";
                StringBuilder sbPrm = new StringBuilder();
                sbPrm.Append("(ID,WaringTitle,EventContent,WaringType");
                StringBuilder sbValues = new StringBuilder();
                sbValues.Append("'" + Guid.NewGuid().ToString() + "','" + title + "','" + waringContent + "'," + getWaringType(waringType));
                sbPrm.Append(",WaringTime,CycleWaringTime,CreateTime");
                sbValues.Append(",@WaringTime,@CycleWaringTime,@CreateTime");
                string[] prmArgs = new string[] { "@WaringTime", "@CycleWaringTime", "@CreateTime" };
                object[] obj = new object[3];

                switch (waringType)
                {
                    case "一次提醒":
                        if (dateTimePickerOneDate.Value >= DateTime.Now.AddMinutes(10))//只能添加十分钟以后的提醒
                        {
                            obj[0] = dateTimePickerOneDate.Value;
                            obj[1] = null;
                        }
                        else
                        {
                            MessageBox.Show("只能设置为10分钟之后的提醒，请重新设置时间");
                            return;
                        }
                        break;
                    case "每日提醒":
                        {
                            obj[0] = null;
                            obj[1] = DateTime.Parse(dateTimePickerEveryDate.Value.ToShortTimeString());
                        }
                        break;
                    case "每周提醒":
                        if (cmbxWaringWeek.Text == "")
                        {
                            MessageBox.Show("请选择在每周星期几提醒");
                            return;
                        }

                        sbPrm.Append(",CycleWaringWeek");
                        sbValues.Append(",'" + cmbxWaringWeek.Text + "'");
                        obj[0] = null;
                        obj[1] = DateTime.Parse(dateTimePickerWaringWeekTime.Value.ToShortTimeString());
                        break;
                    case "每月提醒":
                        if (cmbxWaringMothDate.Text == "")
                        {
                            MessageBox.Show("请选择每月几号提醒");
                            return;
                        }
                        sbPrm.Append(",CycleWaringMonth");
                        sbValues.Append(",'" + cmbxWaringMothDate.Text + "'");
                        obj[0] = null;
                        obj[1] = DateTime.Parse(dateTimePickerWaringMothTime.Value.ToShortTimeString());
                        break;
                }
                obj[2] = DateTime.Now;
                sbPrm.Append(",Expired,WaringCount)values(");
                sbValues.Append(",1,0)");
                if (DBHelper.ExecuteNonQuery(sql + sbPrm.ToString() + sbValues.ToString(), prmArgs, obj) > 0)
                {
                    InItList();
                    toolStripButtonAddNew_Click(null, null);
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmEventWaring));
            }

        }

        public int getWaringType(string showMsg)
        { 
            switch (showMsg)
            {
                case "一次提醒":
                    return (int)WaringType.OneTime;
                case "每日提醒":
                    return (int)WaringType.EveryDay;
                case "每周提醒":
                    return (int)WaringType.EveryWeek;
                case "每月提醒":
                    return (int)WaringType.EveryMonth;
                default:
                    return (int)WaringType.UnKnown;
            }
        }

        public enum WaringType
        {
            UnKnown=0,
            OneTime = 1,
            EveryDay,
            EveryWeek,
            EveryMonth,
        }

        private void toolStripButtonAddNew_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtWaringContent.Text = "";
            cmbxWaringType.Text = "一次提醒";
            cmbxWaringMothDate.Text = "";
            cmbxWaringWeek.Text = "";
            dateTimePickerEveryDate.Value = DateTime.Now;
            dateTimePickerOneDate.Value = DateTime.Now;
            dateTimePickerWaringMothTime.Value = DateTime.Now;
            dateTimePickerWaringWeekTime.Value = DateTime.Now;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
                if (col.Count < 1)
                {
                    MessageBox.Show("请选择要删除的行");
                    return;
                }
                if (MessageBox.Show("确定要删除选定的行吗 ？数据删除后将不能恢复，点击【确定】删除数据，【取消】不删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;
                int index = col[0].Index;
                DataTable dt = dgvList.DataSource as DataTable;
                DataRow row = dt.Rows[index];
                string id = row["Id"].ToString();
                string sql = "Delete from EventWaring where Id='" + id + "'";
                if (DBHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("删除成功");
                    InItList();
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmEventWaring));
            }
        }

        private void frmEventWaring_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButtonOutPut_Click(object sender, EventArgs e)
        {
            CommStatic.DataGridViewToExcel(this.dgvList);
        }
    }
}
