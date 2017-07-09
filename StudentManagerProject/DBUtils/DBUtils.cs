using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StudentManagerProject
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
                //Runscript and Edit password
            string datasource = @"localhost\SQLEXPRESS";
            string database = "StudentsDB";
            string username = "sa";
            string password = "Bikhung101";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }

        public static int ExecuteNonQuery(SqlCommand cmd,SqlConnection con)
        {
            int temp = 0;
            try
            {
                con.Open();
                cmd.Connection = con;
                temp = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error execute Query" + e.Message);
            }
         
            finally
            {
                con.Close();
            }
            return temp;
        }

        public static DataTable ExecuteQuery(SqlCommand cmd,SqlConnection con)
        {
            DataTable table = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table); 
            }
            catch (Exception e)
            {
                throw new Exception("Error executing Query" + e.Message);
            }
            finally
            {
                con.Close();
            }
            return table;
        }
    }
}
