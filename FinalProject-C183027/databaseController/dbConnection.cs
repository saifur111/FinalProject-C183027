using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject_C183027.databaseController
{
    public class dbConnection
    {
        protected string connectionSrting = @"Server=DESKTOP-N0MTD5D\SQLEXPRESS; Database=dcmsDB; Integrated Security= True";
        public string qry { get; set; }
        public SqlConnection sqlCon { get; set; }
        public SqlCommand sqlCommand { get; set; }
        public SqlDataReader sqlReader { get; set; }

        public dbConnection()
        {
            sqlCon = new SqlConnection(connectionSrting);
        }
    }
}