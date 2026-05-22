using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee.Models
{
    public class Login_DAL
    {
        SqlConnection con;
        void dbcon()
        {
            con = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=Employee; Trusted_Connection=True");
            con.Open();
        }
        public string Verify(string username, string password)
        {
            string Type = null;
            dbcon();
            SqlCommand cmd = new SqlCommand("select type_user from Login_Details where username=@username and password=@password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Type = sdr["type_user"].ToString();
            }
            sdr.Close();
            con.Close();
            return Type;
        }
        public bool Check(string username, string password)
        {
            bool valid = false;
            dbcon();
            SqlCommand cmd = new SqlCommand("select * from Login_Details where username=@username and password=@password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password",password);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                valid = true;
            }
            rdr.Close();
            con.Close();
            return valid;
        }
        public void Create_User(Register log)
        {
            dbcon();
            SqlCommand check = new SqlCommand("select * from Login_Details where username=@username", con);
            check.Parameters.AddWithValue("@username",log.username);
            SqlDataReader rdr = check.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                con.Close();
                throw new Exception("Username already exists");
            }
            rdr.Close();

            SqlCommand cmd = new SqlCommand("create_user", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", log.username);
            cmd.Parameters.AddWithValue("@password", log.password);
            cmd.Parameters.AddWithValue("@type_user", "user");

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
