using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.DataAccess
{
    internal class DataConnectionFactory
    {
        internal static string GetConnectionString(string connectionName)
        {
            switch (connectionName)
            {
                case "socialsite":
                    return DataConnectionConfig.Instance.socialsite;
                 

            }
            return "";
        }
    }
}
