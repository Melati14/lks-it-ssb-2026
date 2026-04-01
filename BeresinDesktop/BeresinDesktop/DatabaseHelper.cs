using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace BeresinDesktop
{
    internal class DatabaseHelper
    {
        public static string connString =
            @"Server=localhost\SQLEXPRESS;Database=BeresinDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }
    }
}

