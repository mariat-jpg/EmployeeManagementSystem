using System;
using Employee;
using System.Data;
using System.Data.SqlClient;

namespace Employee.Models
{
    public class Emp_DAL
    {
        SqlConnection con;

        void dbcon()
        {
            con = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=Employee; Trusted_Connection=True"); 
            con.Open();
        }
        public IEnumerable <Emp_Data> Get_Details()
        {
            //All Employees
            List <Emp_Data> values =new List<Emp_Data>();
            dbcon();
            SqlCommand cmd = new SqlCommand("dbo.getdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Emp_Data emp = new Emp_Data();
                emp.Emp_ID = Convert.ToInt32(sdr["Emp_ID"]);
                emp.Emp_Name = sdr["Emp_Name"].ToString();
                emp.Salary = Convert.ToInt32(sdr["Salary"]);

                values.Add(emp);
            }
            con.Close();
            sdr.Close();
            return values;
        }
        public void Create_Emp(Emp_Data emp)
        {
            //Add new Employee
            dbcon();
            SqlCommand cmd = new SqlCommand("dbo.create_emp", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_ID",emp.Emp_ID);
            cmd.Parameters.AddWithValue("@Emp_Name",emp.Emp_Name);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);

            cmd.ExecuteNonQuery();  
            con.Close();
        }
        public void Update_Emp(Emp_Data emp)
        {
            //Update Existing Employee
            dbcon();
            SqlCommand cmd = new SqlCommand("dbo.update_emp", con);
            cmd.CommandType= CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_ID", emp.Emp_ID);
            cmd.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_Emp(int id)
        {
            //Delete an Employee
            dbcon();
            SqlCommand cmd = new SqlCommand("dbo.delete_emp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Emp_ID", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Emp_Data Get_Emp(int id)
        {
            //Get Details of Particular Employee
            dbcon();
            Emp_Data emp = new Emp_Data();
            SqlCommand cmd = new SqlCommand("select * from Emp_Details where Emp_ID=" + id, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                emp.Emp_ID = Convert.ToInt32(reader["Emp_ID"]);
                emp.Emp_Name = reader["Emp_Name"].ToString();
                emp.Salary = Convert.ToInt32(reader["Salary"]);
            }
            con.Close();
            return emp;
        }
    }
}
