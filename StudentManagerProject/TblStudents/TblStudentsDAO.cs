using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StudentManagerProject.TblStudents
{
    public class TblStudentsDAO
    {
        
        public bool Add(string studentID, string firstname, string lastname, DateTime birthdate, bool sex, string majorID)
        {        
            try
            {            
            SqlConnection sqlc = new SqlConnection();
            sqlc.ConnectionString = @"uid=sa;pwd=blazblue22;Initial Catalog=StudentsDB;Persist Security Info=True;Data Source=localhost\SQLEXPRESS";
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_students VALUES(@studentId,@firstname,@lastname,@birthdate,@sex,@majorId)",sqlc);
            cmd.Parameters.AddWithValue("@studentId",studentID);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@birthdate", birthdate);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@majorId", majorID);
            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry! Error! Canceling request!" + e.Message);
            }
            return false;
        }

    }
    
}
