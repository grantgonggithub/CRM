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
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace CRM
{
   public delegate void ControlEventHandler(Control control, Action<Exception> callBack);
   public class CommStatic
    {
       public static MyConfig Config=new MyConfig();
       public static Cache MyCache=new Cache();
       //public static frmAddUser FrmAddUser;
       //public static frmAddEmployee FrmAddEmployee;
       public static frmMain FrmMain;
       public static TextBox TxtBoxCardId;
       public readonly static string AdministratorId = "d66db53fad9f43ca9808a42a9de7ff12";
       public readonly static string AdministratorRoleId = "5806e75cfecc477a8acbb5cc784c0eea";
       //private static ucConsumeDetail ucConDetail;
       //public static ucConsumeDetail getConsumeDetail(string Id)
       //{
       //    if (ucConDetail == null)
       //        ucConDetail = new ucConsumeDetail();
       //    ucConDetail.InItList(Id);
       //    return ucConDetail;
       //}
       //public static void DisplayConsumeDetail()
       //{
       //    if (ucConDetail != null)
       //        ucConDetail.Visible = false;
       //}

       public static void ConfigInitlize()
       {
          object o=ConfigurationManager.AppSettings["Reader"];
          if (o != null && o.ToString() != "")
              Config.Reader = o.ToString();
          o = ConfigurationManager.AppSettings["PollTimeSpan"];
          if (o != null)
          {
              if (!int.TryParse(o.ToString(), out Config.PollTimeSpan))
                  Config.PollTimeSpan = 500;
          }
          o = ConfigurationManager.AppSettings["ConnectionString"];
          if (o != null)
              Config.ConnectionString = o.ToString();
       }

       public static void SystemInitlize()
       { 

       }

       #region 公共操作方法
       /// <summary>
       /// 在线程中操作UI
       /// </summary>
       /// <param name="control"></param>
       /// <param name="callBack"></param>
       public static void ThreadOperationControl(Control control, Action<Exception> callBack)
       {
           try
           {
               if (control == null) return;
               if (control.InvokeRequired)
               {
                   ControlEventHandler handler = new ControlEventHandler(ThreadOperationControl);
                   control.BeginInvoke(handler, control, callBack);
               }
               else
               {
                   callBack(null);
               }
           }
           catch (Exception ex)
           {
               callBack(ex);
           }
       }

       #endregion


       /// <summary>   
       /// 常用方法，列之间加\t开。   
       /// </summary>   
       /// <remarks>   
       /// using System.IO;   
       /// </remarks>   
       /// <param name="dgv"></param>   
       public static void DataGridViewToExcel(DataGridView dgv)
       {
           SaveFileDialog dlg = new SaveFileDialog();
           dlg.Filter = "Execl files (*.xls)|*.xls";
           dlg.CheckFileExists = false;
           dlg.CheckPathExists = false;
           dlg.FilterIndex = 0;
           dlg.RestoreDirectory = true;
           dlg.CreatePrompt = true;
           dlg.Title = "保存为Excel文件";

           if (dlg.ShowDialog() == DialogResult.OK)
           {
               Stream myStream;
               myStream = dlg.OpenFile();
               using (StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0)))
               {
                   string columnTitle = "";
                   try
                   {
                       //写入列标题   
                       for (int i = 0; i < dgv.ColumnCount; i++)
                       {
                           if (i > 0)
                           {
                               columnTitle += "\t";
                           }
                           columnTitle += dgv.Columns[i].HeaderText;
                       }
                       sw.WriteLine(columnTitle);

                       //写入列内容   
                       for (int j = 0; j < dgv.Rows.Count; j++)
                       {
                           string columnValue = "";
                           for (int k = 0; k < dgv.Columns.Count; k++)
                           {
                               if (k > 0)
                               {
                                   columnValue += "\t";
                               }
                               if (dgv.Rows[j].Cells[k].Value == null)
                                   columnValue += "";
                               else
                                   columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                           }
                           sw.WriteLine(columnValue);
                       }
                       sw.Close();
                       myStream.Close();
                   }
                   catch (Exception e)
                   {
                       MessageBox.Show(e.ToString());
                   }
                   finally
                   {
                       sw.Close();
                       myStream.Close();
                   }
               }
               System.Diagnostics.Process.Start("Explorer.exe", "/select," + dlg.FileName);
           }
       }

    }
   public class MyConfig
   {
      public string Reader;
      public int PollTimeSpan;
      public string ConnectionString;
   }
   public class Cache
   {
       public LoginAdmin Login;
   }
   public class LoginAdmin
   {
       public string Id;
       public string AdminName;
       public string LoginName;
       public string Pwd;
       public bool isLock=false;
       public string RightsName;
       public string[] Caps;
   }
}
