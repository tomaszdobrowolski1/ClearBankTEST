using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ClearBank.Services.Core
{
    public static class Config
    {
       
        public static string DataStoreType
        {
            get
            {
                //allows to mock this value
                return ConfigurationManager.AppSettings["DataStoreType"];
            }
        }
    }
}
