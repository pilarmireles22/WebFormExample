using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormCrud.Model;
using System.Data.SqlClient;
using System.Data;

namespace WebFormCrud.Repository
{
    public class EmployeeRepository

    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ASPCRUD;Integrated Security=True";
        public void CreateOrUpdateEmployee(Employee employee)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("CreaterOrUpdateEmployee", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@EmployeeID",employee.EmployeeID);
                sqlcmd.Parameters.AddWithValue("@FirstName",employee.FirstName);
                sqlcmd.Parameters.AddWithValue("@LastName", employee.LastName);
                sqlcmd.Parameters.AddWithValue("@SecondLastName", employee.SecondLastName);
                sqlcmd.Parameters.AddWithValue("@Phone", employee.Phone);
                sqlcmd.Parameters.AddWithValue("@Email", employee.Email);
                sqlcmd.Parameters.AddWithValue("@Address", employee.Address);
                sqlcmd.ExecuteNonQuery();

            }
        }
        public void DeleteEmployeeByID(int EmployeeID)
        {
            using (SqlConnection sqlcon= new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("DeleteEmployeeByID", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                sqlcmd.ExecuteNonQuery();
            }
        }
        public Employee GetEmployeeByID(int EmployeeID)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetEmployeeByID", sqlcon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                Employee employee = new Employee();
                employee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"].ToString());
                employee.FirstName = dt.Rows[0]["FirstName"].ToString();
                employee.LastName = dt.Rows[0]["LastName"].ToString();
                employee.SecondLastName = dt.Rows[0]["SecondLastName"].ToString();
                employee.Phone = dt.Rows[0]["Phone"].ToString();
                employee.Email = dt.Rows[0]["Email"].ToString();
                employee.Address = dt.Rows[0]["Address"].ToString();
                return employee;

            }
        }
        public DataTable GetAllEmployees()
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("ViewAllEmployee", sqlcon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
            return dt;
            }
            
        }
    }
}