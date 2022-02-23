using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>

namespace AddressBook
{
    public class DatabaseConfig
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
} 
