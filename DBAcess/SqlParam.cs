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
using System.Data;
using System.Text;

namespace DBAccess
{
   public class SqlParam
    {
       private string commondText;
       public string CommondText
       {
           get { return commondText; }
           set { commondText = value; }
       }

       private CommandType commondType;
       public CommandType CmdType
       {
           get { return commondType; }
           set { commondType = value; }
       }

       private int pooId;
       public int PoolId
       {
           get { return pooId; }
           set { pooId = value; }
       }

       private string dataBaseName;
       public string DataBaseName
       {
           get { return dataBaseName; }
           set { dataBaseName = value; }
       }

      private string[] paramsList;

      public string[] ParamsList
      {
          get { return paramsList; }
          set { paramsList = value; }
      }
      private object[] values;
      public object[] Values
      {
          get { return values; }
          set { values = value; }
      }

    }
}
