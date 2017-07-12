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

        public bool DeleteStudent(int id)
        {
            
            try
            {
                SqlConnection con = DBUtils.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_students WHERE id = " + id);
                DBUtils.ExecuteNonQuery(cmd, con);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot delete , error occured" + e.Message);
                
            }
        }

        public bool checkDuplicateStudentCode(string studentId)
        {
            SqlConnection con = DBUtils.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_students WHERE studentId = @studentId");
            cmd.Parameters.AddWithValue("@studentId", studentId);
            DataTable table = DBUtils.ExecuteQuery(cmd, con);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;

        }

        public bool Update(int id,string studentID, string firstname, string lastname, DateTime birthdate, bool sex, string majorID)
        {
            try {
                SqlConnection con = DBUtils.GetDBConnection();
                SqlCommand cmd = new SqlCommand("UPDATE tbl_students SET studentId = @studentId , firstname = @firstname , lastname = @lastname, birthdate = @birthdate, sex = @sex , majorId = @majorId WHERE id = @id");
                cmd.Parameters.AddWithValue("@studentId", studentID);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@birthdate", birthdate);
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@majorId", majorID);
                cmd.Parameters.AddWithValue("@id", id);
                DBUtils.ExecuteNonQuery(cmd, con);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot update , error occured" + e.Message);
            }
        }

        public bool Add(string studentID, string firstname, string lastname, DateTime birthdate, bool sex, string majorID)
        {        
            try
            {
            SqlConnection con = DBUtils.GetDBConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_students VALUES(@studentId,@firstname,@lastname,@birthdate,@sex,@majorId)");
            cmd.Parameters.AddWithValue("@studentId",studentID);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@birthdate", birthdate);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@majorId", majorID);

            DBUtils.ExecuteNonQuery(cmd, con);

            return true;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Add , error occured" + e.Message);
                
            }
        }

    }
    
}
