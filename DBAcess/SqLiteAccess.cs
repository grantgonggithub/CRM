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
using System.Data;
using System.Data.SQLite;


namespace DBAccess
{
   public class SqLiteAccess:DBAccess
    {
       private string connectionStr;
       private string dbPwd="";
       public SqLiteAccess(string _connectionStr,string dbpassWord)
       {
           this.connectionStr ="Data Source="+ _connectionStr;
           this.dbPwd = dbpassWord;
       }

       public bool SetPassWord(string newPassWord,string oldPassWord)
       {
           try
           {
               using (SQLiteConnection connection = new SQLiteConnection(this.connectionStr))
               {
                   if (!string.IsNullOrEmpty(oldPassWord)&&!string.IsNullOrEmpty(newPassWord))//改密码
                   {
                       connection.SetPassword(oldPassWord);
                       connection.Open();
                       connection.ChangePassword(newPassWord);
                   }
                   if (string.IsNullOrEmpty(oldPassWord) && !string.IsNullOrEmpty(newPassWord))//旧密码为空，表示需要加密
                   {
                       connection.Open();
                       connection.ChangePassword(newPassWord);
                   }
                   if (!string.IsNullOrEmpty(oldPassWord) && string.IsNullOrEmpty(newPassWord))//旧密码不为空，新密码为空，表示，去掉密码
                   {
                       connection.SetPassword(oldPassWord);
                       connection.Open();
                       connection.ChangePassword(newPassWord);
                   }
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return true;
       }



       public int ExecuteNonQuery(string cmdText, System.Data.CommandType commandType, string[] paramsList, object[] values)
       {
           SQLiteCommand comd = null;
           try
           {
               comd = new SQLiteCommand();
               using (SQLiteConnection connection = new SQLiteConnection(this.connectionStr))
               {
                   if(!string.IsNullOrEmpty(this.dbPwd))
                      connection.SetPassword(dbPwd);
                   PrepareCommand(comd, connection, commandType, cmdText, paramsList, values);
                   int rows = comd.ExecuteNonQuery();
                   comd.Parameters.Clear();
                   return rows;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               if (comd != null)
                   comd.Dispose();
           }
       }

       public System.Data.DataSet ExecuteDataSet(string cmdText, System.Data.CommandType commandType, string[] paramsList, object[] values)
       {
           SQLiteCommand comd = null;
           SQLiteConnection connection = null;
           try
           {
               connection = new SQLiteConnection(this.connectionStr);
               if (!string.IsNullOrEmpty(this.dbPwd))
                   connection.SetPassword(dbPwd);
               comd = new SQLiteCommand();
               PrepareCommand(comd, connection, commandType, cmdText, paramsList, values);

               using (SQLiteDataAdapter da = new SQLiteDataAdapter(comd))
               {
                   DataSet ds = new DataSet();
                   da.Fill(ds);
                   comd.Parameters.Clear();
                   return ds;
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               if (comd != null)
                   comd.Dispose();
               if (connection != null)
                   connection.Close();
           }
       }

       public void PrepareCommand(IDbCommand cmd, IDbConnection conn, CommandType commandType, string cmdText, string[] paramsList, object[] values)
       {
           if (conn.State != ConnectionState.Open)
               conn.Open();

           cmd.Connection = conn;
           cmd.CommandText = cmdText;
           cmd.CommandType = commandType;
           if (paramsList == null) return;
           if (paramsList.Length < values.Length) throw new Exception("paramsList.length<values.length error");
           if (paramsList != null && paramsList.Length > 0)
           {
               for (int i = 0; i < paramsList.Length; i++)
               {
                   cmd.Parameters.Add(new SQLiteParameter() { ParameterName = paramsList[i], Value = values[i] });
               }
           }
       }
    }
}
