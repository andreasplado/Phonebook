using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VR2_Klientrakendus.Service
{
    public static class ServiceConstants
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string UserServiceUrl
        {
            get { return GetValue("UserServiceUrl");}
        }

        public static string ContactServiceUrl
        {
            get { return GetValue("ContactServiceUrl"); }
        }

        public static string GroupServiceUrl
        {
            get { return GetValue("GroupServiceUrl"); }
        }

        public static string ContactInGroupServiceUrl
        {
            get { return GetValue("ContactInGroupServiceUrl"); }
        }

        public static string ContactTypeServiceUrl
        {
            get { return GetValue("ContactTypeServiceUrl"); }
        }

        public static string FavoriteServiceUrl
        {
            get { return GetValue("FavoriteServiceUrl"); }
        }

        public static string LogServiceUrl
        {
            get { return GetValue("LogServiceUrl"); }
        }
    }
}
