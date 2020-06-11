using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using SampleBackendApp.Models;

namespace SampleBackendApp.DAL
{
    public class EmployeeDAL
    {
        private string GetConnStr()
        {
            return WebConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees order by EmpName asc";
                SqlCommand cmd = new SqlCommand(strSql,conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstEmployee.Add(new Employee
                        {
                            EmpId = Convert.ToInt32(dr["EmpId"]),
                            EmpName = dr["EmpName"].ToString(),
                            Designation = dr["Designation"].ToString(),
                            Department = dr["Department"].ToString(),
                            Qualification = dr["Qualification"].ToString(),
                            BirthDate = Convert.ToDateTime(dr["BirthDate"])
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstEmployee;
        }

        public void CreateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into 
                Employees(EmpName,Designation,Department,Qualification,BirthDate) 
                values(@EmpName,@Designation,@Department,@Qualification,@BirthDate)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmpName",emp.EmpName);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Qualification", emp.Qualification);
                cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result != 1)
                        throw new Exception("Data gagal ditambah !");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }
}