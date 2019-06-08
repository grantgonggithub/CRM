using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBAccess;
using Router;

namespace Resource
{
    /// <summary>
    /// 把数据当成一种资源，上层调用者不用关心，数据是本地的还是远程的，但是为了保证性能，这里如果是返回记录集的操作，请自己实现分页，不能返回太大量的数据集,调用之前需要在系统初始化的时候,做Resource.Initialization()的初始化
    /// </summary>
   public class Resource
    {
       public static void Initialization()
       {
           DBFactory.Initialization(RouterManger.InitRouter());
       }

        public static int ExecuteNonQuery(SqlParam sqlParam, int poolId)
        {
            string uri;
            if (RouterManger.isCurrentSite(poolId, sqlParam.DataBaseName, out uri))
                return DBFactory.ExecuteNonQuery(sqlParam, poolId);
            else
            {
                DBAgentSoapClient agent = new DBAgentSoapClient("DBAgentSoap", uri);
                //DBAgent.SqlParam sql = new DBAgent.SqlParam() { CmdType=(DBAgent.CommandType)sqlParam.CmdType, CommondText=sqlParam.CommondText, DataBaseName=sqlParam.DataBaseName, ParamsList=sqlParam.ParamsList, Values=sqlParam.Values };
                return agent.ExecuteNonQuery(sqlParam, poolId);
            }
        }

        public static System.Data.DataSet ExecuteDataSet(SqlParam sqlParam, int poolId)
        {
            string uri;
            if (RouterManger.isCurrentSite(poolId, sqlParam.DataBaseName, out uri))
                return DBFactory.ExecuteDataSet(sqlParam, poolId);
            else
            {
                DBAgentSoapClient agent = new DBAgentSoapClient("DBAgentSoap", uri);
                //DBAgent.SqlParam sql = new DBAgent.SqlParam() { CmdType = (DBAgent.CommandType)sqlParam.CmdType, CommondText = sqlParam.CommondText, DataBaseName = sqlParam.DataBaseName, ParamsList = sqlParam.ParamsList, Values = sqlParam.Values };
                return agent.ExecuteDataSet(sqlParam, poolId);
            }
        }

    }
}
