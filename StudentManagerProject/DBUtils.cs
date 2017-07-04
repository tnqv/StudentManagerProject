using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentManagerProject
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"localhost\SQLEXPRESS";
            string database = "StudentsDB";
            string username = "sa";
            string password = "Bikhung101";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
