using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;
using System.Text;


namespace Router
{
    public class RouterManger
    {
        private static Dictionary<string, DBPool> router = new Dictionary<string, DBPool>();
        private static string currentSite;

        public static bool isCurrentSite(int poolId,string dbName,out string siteUri)
        {
            DBPool pool;
            if (!router.TryGetValue(string.Format("{0}.{1}", dbName, poolId), out pool))
                throw new Exception("找不到指定的数据库");
            siteUri = pool.SiteUri;
            return currentSite.ToLower().Equals(pool.SiteName.ToLower());
        }

        public static XmlNode  InitRouter()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "DBConfig.config";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode current = doc.SelectSingleNode("LocationConfig/Router");
                if (current == null || current.Attributes["Site"] == null)
                {
                    throw new Exception("LocationConfig/Router error");
                }
                currentSite = current.Attributes["Site"].Value;
                XmlNode node =doc.SelectSingleNode("LocationConfig/DataBase");
                foreach (XmlNode site in node.ChildNodes)
                {
                    DBPool dbPool;
                    if(currentSite.ToLower().Equals(site.Attributes["name"].Value.ToLower()))
                       current=site;
                    foreach (XmlNode pool in site.ChildNodes)
                    {
                        dbPool = new DBPool() { Key = pool.Attributes["key"].Value, SiteName = site.Attributes["name"].Value, SiteUri = site.Attributes["uri"].Value };
                        router.Add(dbPool.Key, dbPool);
                    }
                }
                return current;
            }
            catch (Exception ex)
            {
                throw new Exception("DBConfig.config error",ex);
            }

        }

    }
}
