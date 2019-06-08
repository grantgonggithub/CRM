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
using DBAccess;

namespace CRM
{
   public class DBHelper
    {
       public static string DBFilePath =AppDomain.CurrentDomain.BaseDirectory+"INI.sqlite";
       private static SqLiteAccess db = new SqLiteAccess(DBFilePath, "gongjianchun!@#$%^&*()brysjhhrhl");
       public static int ExecuteNonQuery(string cmdText,string[] paramsList, object[] values)
       {
          return db.ExecuteNonQuery(cmdText, CommandType.Text, paramsList, values);
       }

       public static int ExecuteNonQuery(string cmdText)
       {
           return ExecuteNonQuery(cmdText, null, null);
       }

       public static DataSet ExecuteDataSet(string cmdText,  string[] paramsList, object[] values)
       {
           return db.ExecuteDataSet(cmdText, CommandType.Text, paramsList, values);
       }

       public static DataSet ExecuteDataSet(string cmdText)
       {
           return ExecuteDataSet(cmdText, null, null);
       }
    }
}
