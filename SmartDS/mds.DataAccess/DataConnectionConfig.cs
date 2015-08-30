﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    internal class DataConnectionConfig
    {
        private static DataConnectionConfig _instance = new DataConnectionConfig();

        public static DataConnectionConfig Instance
        {
            get { return DataConnectionConfig._instance; }
           
        }
        public string socialsite
        {
            get { return ConfigurationManager.ConnectionStrings["socialsite"].ToString(); }
        }

        public string userservice { get { return ConfigurationManager.ConnectionStrings["userservice"].ToString(); } }
    }
}
