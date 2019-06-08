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
using System.IO;
using System.Windows.Forms;
using Reader;
using Tools;


namespace CRM
{
    public partial class frmMain : skinBase
    {
        private DataTable dtWaring;
        private List<string> updateIdList = new List<string>();
        private DateTime getDiscountTime;
        private DateTime backUpTime;
        private string backUpPath;
        private int backUpNum;
        public frmMain()
        {
            InitializeComponent();
            this.Text = "宏图会员管理系统";
            Reader.ReaderManager.InitlizeReader(CommStatic.Config.Reader, CommStatic.Config.PollTimeSpan);
            Reader.ReaderManager.PollReadCard(0, null, (Exception ex, uint sn, object o) => {
                CallBack(ex, sn, o);
            });

            toolStripStatusLabelCurrentAdmin.Text = "当前管理员："+CommStatic.MyCache.Login.AdminName;

            dgvList.AutoGenerateColumns = false;
            InitDgv();
          dgvConsume.BackgroundColor=dgvList.BackgroundColor=checkedListBoxUserConsume.BackColor= checkedListBoxProduct.BackColor = Color.FromArgb(216, 229, 250);
          dgvConsume.AutoGenerateColumns = false;
          CommStatic.FrmMain = this;
          timer1.Start();
          getWaringInfo();
          SetRole();
          getBackUpTime();
          Shortcut.CreateShortcut(Shortcut.GetDeskDir() + "\\HTCRM.lnk", Application.ExecutablePath, Application.StartupPath, "宏图春华科技有限公司");
        }

        private void SetRole()
        {
            foreach (string s in CommStatic.MyCache.Login.Caps)
            {
                foreach (ToolStripItem item in toolStripTop.Items)
                    if (item is ToolStripButton)
                    {
                        ToolStripButton sbt = item as ToolStripButton;
                        if (sbt.Tag != null && sbt.Tag.ToString() == s)
                        {
                            sbt.Enabled = true;
                            break;
                        }
                    }
            }
        }

       

        private void CallBack(Exception ex, uint sn, object o)
        {
            try
            {
                if (sn > 0)
                {
                    CommStatic.ThreadOperationControl(this, (Exception ex1) =>
                    {
                        notifyIcon1_MouseDoubleClick(null, null);
                        if (CommStatic.MyCache.Login.isLock)
                        {
                            this.toolStripStatusLabelCardID.Text = string.Format("卡号：{0}({1})", sn.ToString(), "当前处于锁屏状态，请解锁后进行操作");
                            return;//锁屏状态啥都不干；
                        }
                        else
                            this.toolStripStatusLabelCardID.Text = string.Format("卡号：{0}", sn.ToString());
                        if (CommStatic.TxtBoxCardId != null)
                        {
                            string cardId=CommStatic.TxtBoxCardId.Text;
                            if (CommStatic.TxtBoxCardId.Tag != null && CommStatic.TxtBoxCardId.Tag is DataRow)
                            {
                                DataRow row = CommStatic.TxtBoxCardId.Tag as DataRow;
                                if (row != null&&!string.IsNullOrEmpty(cardId)&& cardId != sn.ToString())//输入框卡号不为空，并且不是当前读到的卡，证明是别的卡，不能直接赋值
                                {
                                    MessageBox.Show("卡号分配之后不能修改");
                                    return;
                                }

                            }
                            CommStatic.TxtBoxCardId.Text = sn.ToString();
                            return;
                        }
                        //if (CommStatic.FrmAddUser != null)
                        //{
                        //    string cardid = CommStatic.FrmAddUser.txtCardId.Text;
                        //    if (CommStatic.FrmAddUser.row != null && cardid != sn.ToString())//输入框卡号不为空，并且不是当前读到的卡，证明是别的卡，不能直接赋值
                        //    {
                        //        MessageBox.Show("只能修改用户信息，不能修改卡号");
                        //        return;
                        //    }
                        //    CommStatic.FrmAddUser.txtCardId.Text = sn.ToString();
                        //    return;
                        //}
                        //if (CommStatic.FrmAddEmployee != null)
                        //{
                        //    string cardid = CommStatic.FrmAddEmployee.txtCardId.Text;
                        //    if (CommStatic.FrmAddEmployee.row != null
                        //        && CommStatic.FrmAddEmployee.row["CardId"] != null &&
                        //        CommStatic.FrmAddEmployee.row["CardId"].ToString() != "")//之前没有卡，可以随便赋值，不管编辑还是新增
                        //    {
                        //        MessageBox.Show("只能修改员工信息，不能修改卡号");
                        //        return;
                        //    }
                        //    CommStatic.FrmAddEmployee.txtCardId.Text = sn.ToString();
                        //    return;
                        //}
                        //上面都没拦住，说明是付费刷卡
                        //通过卡号找人
                        string sql = "select a.Id,a.VipCardId,a.UserName,a.Tel,a.Money,a.Active,a.UserType,b.UserTypeName from User as a left join UserType as b on a.UserType=b.Id where a.VipCardId='" + sn.ToString() + "'";
                        DataSet ds = DBHelper.ExecuteDataSet(sql);
                        if (ds == null || ds.Tables[0].Rows.Count < 1)
                        {
                            sql = "select Id,CardId,EmployeeName,Active from Employee where CardId='" + sn.ToString() + "'";//这个卡不是会员，看看是否是员工
                            ds = DBHelper.ExecuteDataSet(sql);
                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                            {
                                this.toolStripStatusLabelCardID.Text = string.Format("卡号：{0}(员工卡)", sn.ToString());
                                if (ds.Tables[0].Rows[0]["Active"] != null && ds.Tables[0].Rows[0]["Active"].ToString() != "1")
                                {
                                    MessageBox.Show("此员工卡已经被管理员停用，如果要使用请在员工管理界面进行修改。");
                                    return;
                                }
                                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    cmbxEmployee.SelectedValue = ds.Tables[0].Rows[0]["Id"].ToString();
                                    sql = "Insert into EmployeeCheckOn(Id,CardId,CurrTime,EmployeeId,EmployeeName)values('{0}','{1}',@CurrTime,'{2}','{3}')";
                                    sql = string.Format(sql, Guid.NewGuid().ToString("N"), sn, ds.Tables[0].Rows[0]["Id"].ToString(), ds.Tables[0].Rows[0]["EmployeeName"] == null ? "" : ds.Tables[0].Rows[0]["EmployeeName"].ToString());
                                    DBHelper.ExecuteNonQuery(sql, new string[] { "@CurrTime" }, new object[] { DateTime.Now });
                                    return;
                                }
                            }
                            sql = "select * from Card where CardId='" + sn.ToString() + "'";
                            ds = DBHelper.ExecuteDataSet(sql);
                            if (ds == null || ds.Tables[0].Rows.Count < 1)//卡库里面没有
                            {
                                MessageBox.Show("请勿使用非法卡，这可能会给系统带来不安全的风险");
                                return;
                            }
                            else//卡库里面有
                            {
                                if (MessageBox.Show("此卡还没有分配给任何用户，是否新增用户？点【是】新增用户，点【否】不新增", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    frmAddUser addUser = new frmAddUser();
                                    CommStatic.TxtBoxCardId.Text = sn.ToString();
                                    addUser.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                           
                            this.toolStripStatusLabelCardID.Text = string.Format("卡号：{0}(会员卡)", sn.ToString());
                            DataRow row = ds.Tables[0].Rows[0];
                            if (row["Active"] != null && row["Active"].ToString() != "1")
                            {
                                MessageBox.Show("此会员卡已经被管理员停用，如果要使用请在用户管理界面进行修改。");
                                return;
                            }
                            txtCardId.Text = row["VipCardId"].ToString();
                            txtCountMoney.Text = row["Money"].ToString();
                            //txtTel.Text = row["Sex"].ToString() == "1" ? "男" : "女";
                            txtStatus.Text = row["Active"].ToString() == "1" ? "启用" : "停用";
                            txtUserName.Text = row["UserName"].ToString();
                            txtTel.Text = row["Tel"] == null ? "" : row["Tel"].ToString();
                            txtUserType.Text = row["UserTypeName"] == null ? "" : row["UserTypeName"].ToString();
                            txtUserType.Tag = row;
                            linkLabelMore.Tag = row["Id"].ToString();
                            picBoxAdd_Click(this, null);
                        }
                    });
                }
            }
            catch (Exception ex1)
            {
                TracingHelper.Error(ex1, typeof(frmMain));
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            //this.Visible = false;
            this.ShowInTaskbar = false;
            this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "提示";
            this.notifyIcon1.Text = "";
            this.notifyIcon1.BalloonTipText = "宏图会员管理系统已经最小化运行\n双击、或者刷卡将会最大化窗口,\n如果要退出系统，请右键点击退出.....";
            this.notifyIcon1.ShowBalloonTip(15000);
            return;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Maximized;
            this.Activate();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(sender, null);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？【是】退出系统，【否】不退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
                Environment.Exit(0);
            else
                return;
        }

        private void toolStripButtonAdmin_Click(object sender, EventArgs e)
        {
            frmAdminMgr admin = new frmAdminMgr();
            admin.ShowDialog();
        }

        private void toolStripButtonAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser addUser = new frmAddUser();
            //CommStatic.FrmAddUser = addUser;
            addUser.ShowDialog();
        }

        private void ToolStripMenuItemUserMgr_Click(object sender, EventArgs e)
        {
            if (Caps.HasCaps(ToolStripMenuItemUserMgr.Tag.ToString()))
            {
                frmUserMgr userMgr = new frmUserMgr();
                userMgr.ShowDialog();
            }
        }

        private void toolStripButtonCardMgr_Click(object sender, EventArgs e)
        {
            frmCardMgr cardMgr = new frmCardMgr();
            cardMgr.ShowDialog();
        }

        private void toolStripButtonEmploy_Click(object sender, EventArgs e)
        {
            frmAddEmployee addEmployee = new frmAddEmployee();
            //CommStatic.FrmAddEmployee = addEmployee;
            if (addEmployee.ShowDialog() == DialogResult.OK)
            {
                InItEmployee();
            }
        }

        private void ToolStripMenuItemBasicInfo_Click(object sender, EventArgs e)
        {
            if (Caps.HasCaps(ToolStripMenuItemBasicInfo.Tag.ToString()))
            {
                frmEmployeeMgr employeeMgr = new frmEmployeeMgr();
                if (employeeMgr.ShowDialog() == DialogResult.OK)
                    InItEmployee();
            }
        }

        private void toolStripButtonProduct_Click(object sender, EventArgs e)
        {
            frmProductsMgr productMgr = new frmProductsMgr();
            if (productMgr.ShowDialog() == DialogResult.OK)
                InitProduct();
        }

        private void InitDgv()
        {
            try
            {
                InitConsumeHistory();
                InitProduct();
                InItEmployee();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void InitProduct()
        {
            string sql = "select * from Product";
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            checkedListBoxProduct.DataSource = ds.Tables[0];
            checkedListBoxProduct.ValueMember = "Id";
            checkedListBoxProduct.DisplayMember = "ProductName";
        }

        private void InItEmployee()
        {
            string sql = "select Id,CardId,EmployeeName from Employee order by EmployeeName";
            DataSet ds = DBHelper.ExecuteDataSet(sql);
            if (ds == null || ds.Tables[0].Rows.Count < 1) return;
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.InsertAt(row, 0);
            cmbxEmployee.DataSource = ds.Tables[0];
            cmbxEmployee.DisplayMember = "EmployeeName";
            cmbxEmployee.ValueMember = "Id";
        }

        private void InitConsumeHistory()
        {
            try
            {
                string sql = "select * from ConsumeBill order by ConsumeTime desc limit 0,1000";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                dgvList.DataSource = ds.Tables[0];

                InitSystemInfo();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        public void InitSystemInfo()
        {
            try
            {
                txtCurrAdmin.Text = CommStatic.MyCache.Login.AdminName;
                DataTable dt = dgvList.DataSource as DataTable;
                if (dt != null)
                {
                    DateTime time = DateTime.Now;
                    txtCurrConsumeCount.Text = dt.Select("ConsumeTime>='" + time.ToShortDateString() + "' and ConsumeTime<'" + time.AddDays(1).ToShortDateString() + "'").Length.ToString();
                    object o = dt.Compute("SUM(ConsumeMoney)", "ConsumeTime>='" + time.ToShortDateString() + "' and ConsumeTime<'" + time.AddDays(1).ToShortDateString() + "'");
                    txtCurrConsumeTotMoney.Text = (o == null || o.ToString() == "") ? "0" : o.ToString();
                }
                txtCurrVipTot.Text = getTableRowCount("User");
                txtCurrCardTot.Text = getTableRowCount("Card");
                txtCurrEmploytot.Text = getTableRowCount("Employee");
                txtCurrProductTot.Text = getTableRowCount("Product");
                txtCurrUnSendCard.Text = getTableRowCount("Card where Status=1");
                getDiscountInfo();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void getDiscountInfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("今日是：" + DateTime.Now.ToString("yyyy年MM月dd日"));
                getDiscountTime = DateTime.Now;
                string sql = "select b.ProductName from ProductMainPrice as a left join Product as b on a.ProductId=b.id where (a.DiscountStartDay<=datetime('" + getDiscountTime.ToString("yyyy-MM-dd") + "') and a.DiscountEndDay>=datetime('" + getDiscountTime.ToString("yyyy-MM-dd") + "')) group by b.ProductName";
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds == null || ds.Tables[0].Rows.Count < 1)
                {
                    txtDiscountInfo.Text = ",今日无促销计划";
                    return;
                }
                DataTable dt = ds.Tables[0];

                sb.Append("今日有【" + dt.Rows.Count + "】件产品或服务有促销：");
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append("【" + row["ProductName"].ToString() + "】  ");
                }
                txtDiscountInfo.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void getWaringInfo()
        {
            try
            {
                StringBuilder sbMsg = new StringBuilder();
                string frontMsg = "今日是：" + DateTime.Now.ToString("yyyy年MM月dd日") + "\r\n";
                sbMsg.Append(frontMsg);
                if (dtWaring == null)
                {
                    string sql = "select * from EventWaring where Expired=1";
                    DataSet ds = DBHelper.ExecuteDataSet(sql);
                    updateIdList.Clear();
                    if (ds == null || ds.Tables[0].Rows.Count < 1)
                    {
                        sbMsg.AppendLine();
                        sbMsg.AppendLine("今天您没有事件提醒");
                        return;
                    }
                    else
                        dtWaring = ds.Tables[0];
                }
                DateTime currTime = DateTime.Now;
                double timespan = 0;
                string partMsg = "【{0}分钟】后，你有一个代办事项，内容是：{1}";
                foreach (DataRow row in dtWaring.Rows)
                {
                    if (row["WaringType"] == null || row["WaringType"].ToString() == "") continue;
                    DateTime CycleWaringTime = DateTime.MinValue;
                    if (row["CycleWaringTime"] != null && row["CycleWaringTime"].ToString() != "")
                        CycleWaringTime = DateTime.Parse(row["CycleWaringTime"].ToString());
                    DateTime waringTime = DateTime.MinValue;
                    if (row["WaringTime"] != null && row["WaringTime"].ToString() != "")
                        waringTime = DateTime.Parse(row["WaringTime"].ToString());
                    string waringType = row["WaringType"].ToString();
                    switch (waringType)
                    {
                        case "1":
                            timespan = (waringTime - DateTime.Now).TotalMinutes;
                            if (timespan > -1 && timespan <= 11)
                            {
                                sbMsg.AppendLine(string.Format(partMsg, Math.Ceiling(timespan), row["EventContent"].ToString()));
                            }
                            break;
                        case "2":
                            DateTime waring = new DateTime(currTime.Year, currTime.Month, currTime.Day, CycleWaringTime.Hour, CycleWaringTime.Minute, 0);
                            timespan = (waring - currTime).TotalMinutes;
                            if (timespan > -1 && timespan <= 11)
                            {
                                sbMsg.AppendLine(string.Format(partMsg, Math.Ceiling(timespan), row["EventContent"].ToString()));
                            }
                            break;
                        case "3":
                            DayOfWeek week = currTime.DayOfWeek;
                            if (week == getWeekByName(row["CycleWaringWeek"].ToString()))
                            {
                                waring = new DateTime(currTime.Year, currTime.Month, currTime.Day, CycleWaringTime.Hour, CycleWaringTime.Minute, 0);
                                timespan = (waring - currTime).TotalMinutes;
                                if (timespan > -1 && timespan <= 11)
                                {
                                    sbMsg.AppendLine(string.Format(partMsg, Math.Ceiling(timespan), row["EventContent"].ToString()));
                                }
                            }
                            break;
                        case "4":
                            int day = int.Parse(row["CycleWaringMonth"].ToString().Replace("日", ""));
                            if (currTime.Day == day)
                            {
                                waring = new DateTime(currTime.Year, currTime.Month, day, CycleWaringTime.Hour, CycleWaringTime.Minute, 0);
                                timespan = (waring - currTime).TotalMinutes;
                                if (timespan > -1 && timespan <= 11)
                                {
                                    sbMsg.AppendLine(string.Format(partMsg, Math.Ceiling(timespan), row["EventContent"].ToString()));
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    if (timespan < 0)
                    {
                        string id = row["Id"].ToString();
                        string updateTime = row["UpdateTime"] == null ? "" : row["UpdateTime"].ToString();
                        if (updateTime != "" && (DateTime.Parse(updateTime).ToShortDateString() == currTime.ToShortDateString())) continue;//今天更了就不更了，防止退出软件再打开重复更新次数；
                        if (!updateIdList.Contains(id))
                        {
                            string sql = "Update EventWaring  ";
                            if (waringType == "1")
                                sql += " set Expired=2,WaringCount=1,UpdateTime=@UpdateTime";
                            else
                                sql += " set WaringCount=WaringCount+1,UpdateTime=@UpdateTime";
                            sql += " where Id='" + id + "'";
                            DBHelper.ExecuteNonQuery(sql, new string[] { "@UpdateTime" }, new object[] { currTime });
                            updateIdList.Add(id);
                        }
                    }
                }
                if (sbMsg.ToString() == frontMsg)
                {
                    sbMsg.AppendLine();
                    sbMsg.AppendLine("今天您没有事件提醒");
                }
                txtEventWaring.Text = sbMsg.ToString();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void getBackUpTime()
        {
            DataSet ds = DBHelper.ExecuteDataSet("select key,value1,value2 from SysConfig where key='BackUpTime'");
            if (ds == null || ds.Tables[0].Rows.Count < 1)
            {
                return;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr["Value1"] != null && dr["Value1"].ToString() != "")
            {
                backUpTime = DateTime.Parse(dr["Value1"].ToString());
                backUpPath = dr["Value2"].ToString();
                backUpNum = 0;
            }
            else
            {
                backUpTime = DateTime.MinValue;
                backUpPath = "";
            }
        }

        private DayOfWeek getWeekByName(string name)
        {
            switch (name)
            { 
                case "周一":
                    return DayOfWeek.Monday;
                case "周二":
                    return DayOfWeek.Tuesday;
                case "周三":
                    return DayOfWeek.Wednesday;
                case "周四":
                    return DayOfWeek.Thursday;
                case "周五":
                    return DayOfWeek.Friday;
                case "周六":
                    return DayOfWeek.Saturday;
                case "周日":
                    return DayOfWeek.Sunday;
                default:
                    return DayOfWeek.Monday;
            }
        }

        private string getTableRowCount(string tail)
        {
            try
            {
                string sql = "select count(*) from " + tail;
                DataSet ds = DBHelper.ExecuteDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != null && ds.Tables[0].Rows[0][0] != DBNull.Value)
                    return ds.Tables[0].Rows[0][0].ToString();
                return "";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
                return "";
            }
        }

        private void linkLabelMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelMore.Tag == null || linkLabelMore.Tag.ToString() == "")
                return;
            frmUserMgr userMgr = new frmUserMgr();
            userMgr.SelectView(linkLabelMore.Tag.ToString());
            userMgr.Show();
        }

        private void picBoxAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckedListBox.CheckedItemCollection checkedItems = checkedListBoxProduct.CheckedItems;
                //checkedListBoxUserConsume.Items.Clear();
                if (checkedItems.Count < 1 && !(sender is frmMain))
                {
                    MessageBox.Show("请选择要增加的产品或者服务");
                    return;
                }
                DataTable dt = checkedListBoxProduct.DataSource as DataTable;
                DataTable orgDt = dt.Clone();
                for (int i = 0; i < checkedItems.Count; i++)
                {
                    DataRowView rowView = checkedItems[i] as DataRowView;
                    DataRow row = orgDt.NewRow();
                    row.ItemArray = rowView.Row.ItemArray;
                    orgDt.Rows.Add(row);
                }
                checkedListBoxUserConsume.DataSource = orgDt;
                checkedListBoxUserConsume.ValueMember = "Id";
                checkedListBoxUserConsume.DisplayMember = "ProductName";
                getProductSelect();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void picBoxDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CheckedListBox.CheckedItemCollection checkedItems = checkedListBoxUserConsume.CheckedItems;
                if (checkedItems.Count < 1)
                {
                    MessageBox.Show("请选择要去掉的产品或者服务");
                    return;
                }
                DataTable dt = checkedListBoxUserConsume.DataSource as DataTable;
                DataRow[] rows = new DataRow[checkedItems.Count];
                for (int i = 0; i < checkedItems.Count; i++)//不能再这个循环里面移除，移除之后就变了；
                {
                    DataRowView rowView = checkedItems[i] as DataRowView;
                    rows[i] = rowView.Row;
                }
                for (int i = 0; i < rows.Length; i++)
                {
                    dt.Rows.Remove(rows[i]);
                }
                checkedListBoxUserConsume.DataSource = dt;
                checkedListBoxUserConsume.ValueMember = "Id";
                checkedListBoxUserConsume.DisplayMember = "ProductName";
                getProductSelect();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void getProductSelect()
        {
            try
            {
                DataTable dt = checkedListBoxUserConsume.DataSource as DataTable;
                DataTable table = new DataTable();
                DataColumn[] cols = new DataColumn[6];

                cols[0] = new DataColumn("ProductName", typeof(string));
                cols[1] = new DataColumn("MarketPrice", typeof(float));
                cols[2] = new DataColumn("DiscountPrice", typeof(float));
                cols[3] = new DataColumn("Count", typeof(int));
                cols[4] = new DataColumn("SumPrice", typeof(float));
                cols[5] = new DataColumn("ProductId", typeof(string));

                table.Columns.AddRange(cols);
                if (dt != null || dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)//遍历选择的产品，查看是否有当前的促销计划
                    {
                        string productId = row["Id"].ToString();
                        string sql = "select a.*,b.productName from ProductMainPrice as a left join Product as b on a.ProductId=b.Id where a.ProductId='{0}'";
                        DataSet ds = DBHelper.ExecuteDataSet(string.Format(sql, productId));
                        if (ds == null || ds.Tables[0].Rows.Count < 1)
                        {
                            MessageBox.Show(string.Format("产品【{0}】没有设置产品价格，无法计算费用", row["ProductName"].ToString()));
                            return;
                        }
                        DataTable orgDt = ds.Tables[0];
                        string time = DateTime.Now.ToShortDateString();
                        DataRow[] rows = orgDt.Select("PriceType=2 and (DiscountStartDay<='" + time + "' and DiscountEndDay>='" + time + "')");//看看有没有促销价格
                        if (rows.Length > 0)//如果有符合条件的促销价格，促销优先
                        {
                            buildTable(productId, table, rows);
                        }
                        else//没有促销价格不管是不是会员都走基本价格
                        {
                            rows = orgDt.Select("PriceType=1");
                            if (rows.Length < 1)
                            {
                                MessageBox.Show(string.Format("产品【{0}】没有设置基本价格，无法计算费用", rows[0]["productName"].ToString()));
                                return;
                            }
                            buildTable(productId, table, rows);
                        }
                    }
                }
                dgvConsume.DataSource = table;
                if(table!=null&&table.Rows.Count>0)
                   dgvCompute();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }
        private void buildTable(string productId, DataTable table, DataRow[] rows)
        {
            try
            {
                string sql = "";
                bool isVip = string.IsNullOrEmpty(txtCardId.Text) ? false : true;//是否有卡号，有则是vip，没有就不是
                DataRow userInfoRow = txtUserType.Tag as DataRow;
                if (!isVip)
                {
                    DataRow newRow = table.NewRow();
                    newRow["ProductId"] = rows[0]["ProductId"];
                    newRow["ProductName"] = rows[0]["productName"];
                    newRow["DiscountPrice"] = newRow["MarketPrice"] = rows[0]["MarketPrice"];//非会员走促销基本价格
                    newRow["Count"] = 1;
                    newRow["SumPrice"] = 1 * float.Parse(rows[0]["MarketPrice"].ToString());
                    table.Rows.Add(newRow);
                }
                else
                {
                    string vipTypeId = userInfoRow["UserType"].ToString();
                    sql = "select * from ProductMemberShipPrice where ProductId='{0}' and ProductMainPriceId='{1}' and UserTypeId='{2}'";
                    DataSet subDs = DBHelper.ExecuteDataSet(string.Format(sql, productId, rows[0]["Id"].ToString(), vipTypeId));
                    if (subDs == null || subDs.Tables[0].Rows.Count < 1)
                    {
                        MessageBox.Show(string.Format("产品【{0}】设置了促销，但没有设置会员价格", rows[0]["productName"].ToString()));
                        return;
                    }
                    DataRow subRow = subDs.Tables[0].Rows[0];
                    DataRow newRow = table.NewRow();
                    newRow["ProductId"] = rows[0]["ProductId"];
                    newRow["ProductName"] = rows[0]["productName"];
                    newRow["MarketPrice"] = rows[0]["MarketPrice"];//非会员走促销基本价格
                    float discountPrice = 0;
                    if (subRow["DiscountType"].ToString() == "2")//直接是折扣后的价格
                    {
                        discountPrice = float.Parse(subRow["DiscountPrice"].ToString());
                    }
                    else
                    {
                        float rate = float.Parse(subRow["DiscountRate"].ToString());
                        float marketPrice = float.Parse(rows[0]["MarketPrice"].ToString());
                        discountPrice = (rate * 0.1f) * marketPrice;
                    }
                    newRow["DiscountPrice"] = discountPrice.ToString();
                    newRow["Count"] = 1;
                    newRow["SumPrice"] = (1 * discountPrice).ToString();
                    table.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void dgvConsume_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                if (colIndex < 0 || rowIndex < 0) return;
                if (dgvConsume.Columns[colIndex].Name == "ColCount")
                {
                    object o = dgvConsume.Rows[rowIndex].Cells[colIndex].Value;
                    if (o == null || o.ToString() == "")
                    {
                        dgvConsume.Rows[rowIndex].Cells[colIndex].Value = 1;
                        MessageBox.Show("数量必须是半角数字，请检查是否输入的是半角数字");
                    }
                    dgvConsume.Rows[rowIndex].Cells["ColSubCount"].Value = (int.Parse(dgvConsume.Rows[rowIndex].Cells[colIndex].Value.ToString()) * float.Parse(dgvConsume.Rows[rowIndex].Cells["ColDisountPrice"].Value.ToString()));
                }
                dgvCompute();
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void dgvCompute()
        {
            try
            {
                DataTable dt = dgvConsume.DataSource as DataTable;
                object sumMoney = dt.Compute("SUM(SumPrice)", null);
                if (sumMoney == null || sumMoney.ToString() == "")
                    txtSumMoney.Text = "";
                txtSumMoney.Text = sumMoney.ToString();
                float consumeMoney = float.Parse(sumMoney.ToString());//消费总额
                float accountMoney = 0;
                float listMoney = 0;
                if(!string.IsNullOrEmpty(txtCountMoney.Text))
                    accountMoney=float.Parse(txtCountMoney.Text);//账户余额
                if (accountMoney >= consumeMoney)//余额大于消费
                {
                    txtNeedCutMoney.Text = consumeMoney.ToString();//扣除消费
                    txtEnRichMoney.Text = "0";//补缴现金为0
                    listMoney = accountMoney - consumeMoney;//余额大于消费，账户余额记为差
                }
                else//余额小于总额
                {
                    txtNeedCutMoney.Text = accountMoney.ToString();//扣除全部余额
                    txtEnRichMoney.Text = (consumeMoney - accountMoney).ToString();//总额减余额=补缴现金
                    listMoney = 0;//余额小于消费，账户余额记为0；
                }

                btnSave.Text = "需补"+txtEnRichMoney.Text + "元现金\n\r" + btnSave.Tag.ToString();
                btncut.Tag = listMoney.ToString();
                txtRealMoney.Text = "";
                txtCutMoney.Text = "";
                cmbxEmployee.SelectedValue = "";
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void dgvConsume_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            dgvConsume.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            MessageBox.Show("数量必须是半角数字，请检查是否输入的是半角数字");
        }

        private void dgvConsume_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
                if (colIndex < 0 || rowIndex < 0) return;
                if (dgvConsume.Columns[colIndex].Name == "ColCount")
                {
                    object o = dgvConsume.Rows[rowIndex].Cells[colIndex].Value;
                    if (o == null || o.ToString() == "")
                    {
                        e.Cancel = true;
                        dgvConsume.Rows[rowIndex].Cells[colIndex].Value = 1;
                        MessageBox.Show("数量必须是半角数字，请检查是否输入的是半角数字");
                    }
                    int t;
                    if (!int.TryParse(dgvConsume.Rows[rowIndex].Cells[colIndex].Value.ToString(), out t))
                    {
                        e.Cancel = true;
                        dgvConsume.Rows[rowIndex].Cells[colIndex].Value = 1;
                        MessageBox.Show("数量必须是半角数字，请检查是否输入的是半角数字");
                    }
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void dgvConsume_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            if (colIndex < 0 || rowIndex < 0) return;
            if (dgvConsume.Columns[colIndex].Name == "ColCount")
            {
                dgvConsume.Rows[rowIndex].Cells[0].Selected = true;
            }
        }

        private void btncut_Click(object sender, EventArgs e)
        {
            string realMoney = txtRealMoney.Text;
            if (string.IsNullOrEmpty(realMoney))
            {
                MessageBox.Show("请输入实收金额");
                return;
            }
            float money;
            if (!float.TryParse(realMoney, out money))
            {
                MessageBox.Show("实收金额必须是数字");
                return;
            }
            float enRichMoney = float.Parse(txtEnRichMoney.Text);
            if (enRichMoney == 0)
            {
                MessageBox.Show("账户余额能够支付本次消费，无需补缴现金");
                return;
            }
            if (enRichMoney > money)
            {
                txtCutMoney.Text = "";
                MessageBox.Show("实收金额不能小于应收金额");
                return;
            }
            txtCutMoney.Text = (money - enRichMoney).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string consumeMoney = txtSumMoney.Text;
                if (string.IsNullOrEmpty(consumeMoney))
                {
                    MessageBox.Show("请选择本次使用的产品或服务");
                    return;
                }
                float money;
                if (!float.TryParse(consumeMoney, out money))
                {
                    MessageBox.Show("价格计算异常，请重新选择产品或服务");
                    return;
                }
                if (money <= 0)
                {
                    MessageBox.Show("总计应收应该大于0，请再次确认产品数量和价格");
                    return;
                }
                if (MessageBox.Show("您确认要进行本次结账吗？（会员信息、接待员工、产品数量和金额是否正确）点击【是】进行本次结账，点击【否】重新确认信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
                string employeeId = cmbxEmployee.SelectedValue == null ? "" : cmbxEmployee.SelectedValue.ToString();
                string billId = DateTime.Now.ToString("yyyyMMddHHmmss");
                string sql = "Insert into ConsumeBill(Id,BillId,EmployeeId,EmployeeName,ConsumeMoney,ConsumeTime,AdminId,AdminName,UserId,UserName,UserType,CardId)values(@Id,@BillId,@EmployeeId,@EmployeeName,@ConsumeMoney,@ConsumeTime,@AdminId,@AdminName,@UserId,@UserName,@UserType,@CardId)";
                string[] prm = new string[] { "@Id", "@BillId", "@EmployeeId", "@EmployeeName", "@ConsumeMoney", "@ConsumeTime", "@AdminId", "@AdminName", "@UserId", "@UserName", "@UserType", "@CardId" };
                object[] obj = new object[] { Guid.NewGuid().ToString("N"), billId, employeeId, cmbxEmployee.Text, txtSumMoney.Text, DateTime.Now, CommStatic.MyCache.Login.Id, CommStatic.MyCache.Login.AdminName, linkLabelMore.Tag == null ? "" : linkLabelMore.Tag.ToString(), txtUserName.Text == "" ? "" : txtUserName.Text, txtUserType.Text == "" ? "" : txtUserType.Text, txtCardId.Text == "" ? "" : txtCardId.Text };
                if (DBHelper.ExecuteNonQuery(sql, prm, obj) > 0)
                {
                    DataTable dt = dgvConsume.DataSource as DataTable;
                    foreach (DataRow row in dt.Rows)
                    {
                        sql = "Insert into ConsumeHistory(Id,ConsumeBillId,ProductID,ProductName,DiscountPrice,ConsumeMoney,ProductCount,MarketPrice)values(@Id,@ConsumeBillId,@ProductID,@ProductName,@DiscountPrice,@ConsumeMoney,@ProductCount,@MarketPrice)";
                        prm = new string[] { "@Id", "@ConsumeBillId", "@ProductID", "@ProductName", "@DiscountPrice", "@ConsumeMoney", "@ProductCount", "@MarketPrice" };
                        obj = new object[] { Guid.NewGuid().ToString("N"), billId, row["ProductId"].ToString(), row["ProductName"].ToString(), row["DiscountPrice"].ToString(), row["SumPrice"].ToString(), row["Count"].ToString(), row["MarketPrice"].ToString() };
                        DBHelper.ExecuteNonQuery(sql, prm, obj);
                    }
                    if (txtNeedCutMoney.Text != "0" && linkLabelMore.Tag != null)//账号扣除不为0，并且有账号
                    {
                        sql = "Update User set Money="+btncut.Tag.ToString() + " where Id='" + linkLabelMore.Tag.ToString() + "'";
                        DBHelper.ExecuteNonQuery(sql);
                    }
                    InitConsumeHistory();
                    InitSystemInfo();
                    clear();
                }
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }
        private void clear()
        {
            try
            {
                txtCardId.Text = "";
                txtCountMoney.Text = "";
                txtCutMoney.Text = "";
                txtNeedCutMoney.Text = "";
                txtEnRichMoney.Text = "";
                txtRealMoney.Text = "";
                txtStatus.Text = "";
                txtSumMoney.Text = "";
                txtTel.Text = "";
                txtUserName.Text = "";
                txtUserType.Text = "";
                cmbxEmployee.SelectedIndex = -1;
                btnSave.Text = btnSave.Tag.ToString();
                foreach (int index in checkedListBoxProduct.CheckedIndices)
                    checkedListBoxProduct.SetItemChecked(index, false);
                picBoxAdd_Click(this, null);
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void toolStripButtonPay_Click(object sender, EventArgs e)
        {
            frmCloseAccount closeAcc = new frmCloseAccount();
            if (closeAcc.ShowDialog() == DialogResult.OK)
            {
                CallBack(null, closeAcc.sn, null);
            }
        }

        private void toolStripButtonRecharge_Click(object sender, EventArgs e)
        {
            frmRechargecs recharge = new frmRechargecs();
            if (recharge.ShowDialog() == DialogResult.OK)
            {
                CallBack(null, recharge.sn, null);
            }
        }

        private void toolStripButtonEventWaring_Click(object sender, EventArgs e)
        {
            frmEventWaring eventWaring = new frmEventWaring();
            if (eventWaring.ShowDialog() == DialogResult.OK)
            {
                dtWaring = null;
                getWaringInfo();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getWaringInfo();
            if (getDiscountTime==null||getDiscountTime.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))//今天取一次，到明天才取
              getDiscountInfo();
            //自动备份，每天检查是否到了备份时间点
            if (backUpTime != null&&backUpTime.Year>2000&& backUpTime.ToString("HH:mm:00") == DateTime.Now.ToString("HH:mm:00"))
            {
                try
                {
                    if (backUpNum < 1)
                    {
                        File.Copy(DBHelper.DBFilePath, backUpPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".back", true);
                        backUpNum += 1;
                    }
                }
                catch (Exception ex)
                {
                    backUpNum = 0;
                    TracingHelper.Error(ex, typeof(frmMain), "自动备份失败，参数:path=" + backUpPath + ",time=" + backUpTime);
                }
            }
            else
                backUpNum = 0;//过了这个点，清0，开始进入第二天备份；
        }

        private void toolStripButtonLock_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin(true);
            login.MinimizeBox = false;
            this.Enabled = false;
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
                this.toolStripStatusLabelCardID.Text = "";
                this.txtCurrAdmin.Focus();
            }
        }

        private void toolStripButtonWorkRecord_Click(object sender, EventArgs e)
        {
            frmCheckOnMgr checkOn = new frmCheckOnMgr();
            checkOn.ShowDialog();
        }

        private void toolStripButtonConsulm_Click(object sender, EventArgs e)
        {
            frmConsumeHistory consume = new frmConsumeHistory();
            consume.ShowDialog();
        }

        private void dgvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewSelectedRowCollection col = dgvList.SelectedRows;
            if (col.Count < 1)
            {
                MessageBox.Show("请选择要查看的记录!");
                return;
            }
            int index = col[0].Index;
            DataTable dt = dgvList.DataSource as DataTable;
            DataRow row = dt.Rows[index];
            frmConsumeDetail detail = new frmConsumeDetail(row);
            detail.ShowDialog();
        }

        private void ToolStripMenuItemWorkTime_Click(object sender, EventArgs e)
        {
            if (Caps.HasCaps(ToolStripMenuItemWorkTime.Tag.ToString()))
            {
                toolStripButtonWorkRecord_Click(sender, e);
            }
        }

        private void ToolStripMenuItemLink_Click(object sender, EventArgs e)
        {
            frmContact cnt = new frmContact();
            cnt.ShowDialog();
        }

        private void toolStripButtonSysSetting_Click(object sender, EventArgs e)
        {
            frmSystemSetting setting = new frmSystemSetting();
            if (setting.ShowDialog() == DialogResult.OK)
            {
                getBackUpTime();
            }
        }

        private void ToolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要切换账号吗？系统将退出当前登录账号，点击【确定】退出并切换账号，【取消】不做任何操作", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;
            Application.Restart();
            Environment.Exit(0);
        }

        private void toolStripButtonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "help.chm");
            }
            catch (Exception ex)
            {
                TracingHelper.Error(ex, typeof(frmMain));
            }
        }

        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            toolStripButtonHelp_Click(sender, e);
        }

        private void linkLabelClearInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCardId.Text == "") return;
            clear();
        }
    }
    public class Obj<K, V>
    {
        private K key;

        private V _value;

        public K Key
        {
            get { return key; }
            set { key = value; }
        }

        public V Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
