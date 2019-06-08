using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Router
{
    public class DBPool
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string siteName;

        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; }
        }

        private string siteUri;

        public string SiteUri
        {
            get { return siteUri; }
            set { siteUri = value; }
        }
    }
}
