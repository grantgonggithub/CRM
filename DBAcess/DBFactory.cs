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
using System.Xml;
using System.Data;

namespace DBAccess
{
   public class DBFactory
    {
       private static readonly Dictionary<string, DBAccess> dbList = new Dictionary<string, DBAccess>();

       /// <summary>
       /// 统一配置的时候用这个初始化
       /// </summary>
       /// <param name="dbConfig"></param>
       public static void Initialization(string dbConfig)
       {
           try
           {
               if (string.IsNullOrEmpty(dbConfig)) throw new Exception("DataBase Item is Empty,Initialization Error");
               XmlDocument doc = new XmlDocument();
               doc.LoadXml(dbConfig);
               XmlNode database = doc.SelectSingleNode("DataBase/Site");
               if (database == null || database.ChildNodes.Count < 1) throw new Exception("DataBase Item is Empty,Initialization Error");
               Initialization(database);
           }
           catch (Exception ex)
           {
               throw new Exception("DBConfig.config error",ex);
           }
       }
       /// <summary>
       /// 本地Agent部署，需要用这个初始化
       /// </summary>
       public static void Initialization()
       {
           string path = AppDomain.CurrentDomain.BaseDirectory + "DBConfig.config";
           XmlDocument doc = new XmlDocument();
           doc.Load(path);
           XmlNode node = doc.SelectSingleNode("LocationConfig");
           Initialization(node.InnerXml);
       }
       /// <summary>
       /// Resource初始化需要用这个，设置当前site
       /// </summary>
       /// <param name="site"></param>
       public static void Initialization(XmlNode site)
       {
           if (site == null || site.ChildNodes.Count < 1)
           {
               throw new Exception("site XmlNode error");
           }
           foreach (XmlNode node in site.ChildNodes)
           {
               XmlAttribute key = node.Attributes["key"];
               XmlAttribute connstr = node.Attributes["connectionString"];
               XmlAttribute dbType = node.Attributes["DBType"];
               if (key == null || string.IsNullOrEmpty(key.Value) ||
                   connstr == null || string.IsNullOrEmpty(connstr.Value) ||
                   dbType == null || string.IsNullOrEmpty(dbType.Value)) continue;
               DBAccess db = null;
               DBType t;
               if (!Enum.TryParse<DBType>(dbType.Value.ToLower(), out t))
                   continue;
               switch (t)
               {
                   case DBType.sqlserver:
                       db = new SqlAccess(connstr.Value);
                       break;
                   case DBType.mysql:
                       db = new MySqlAccess(connstr.Value);
                       break;
                   case DBType.sqlite:
                       db = new SqLiteAccess(connstr.Value,null);
                       break;
                   default:
                       continue;
               }
               if (!dbList.ContainsKey(key.Value))
                   dbList.Add(key.Value, db);
           }
       }

       private static DBAccess getDB(string key)
       {
           DBAccess db;
           dbList.TryGetValue(key, out db);
           if (db == null) throw new Exception("this DataBase is not found");
           return db;
       }

       public static int ExecuteNonQuery(SqlParam sqlParam,int poolId)
       {
           if (sqlParam == null||
               string.IsNullOrEmpty(sqlParam.CommondText)
               ||string.IsNullOrEmpty(sqlParam.DataBaseName)
               ||sqlParam.ParamsList.Length<1) return -1;//这里不允许直接传sql语句，必须使用参数化的
           if (poolId < 1) poolId = 1;//默认只有一个数据库
           DBAccess db=getDB(string.Format("{0}.{1}",sqlParam.DataBaseName,poolId));
           return db.ExecuteNonQuery(sqlParam.CommondText, sqlParam.CmdType,sqlParam.ParamsList,sqlParam.Values);
       }

       public static DataSet ExecuteDataSet(SqlParam sqlParam,int poolId)
       {
           if (sqlParam == null||
               string.IsNullOrEmpty(sqlParam.CommondText)
               || string.IsNullOrEmpty(sqlParam.DataBaseName)
               || sqlParam.ParamsList.Length < 1) return null;//这里不允许直接传sql语句，必须使用参数化的
           if (poolId < 1) poolId = 1;//默认只有一个数据库
           DBAccess db = getDB(string.Format("{0}.{1}", sqlParam.DataBaseName, poolId));
           return db.ExecuteDataSet(sqlParam.CommondText, sqlParam.CmdType,sqlParam.ParamsList,sqlParam.Values);
       }

    }
}
