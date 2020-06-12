using SampleBackendApp.DAL;
using SampleBackendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleBackendApp.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeDAL empDAL;
        public EmployeeController()
        {
            empDAL = new EmployeeDAL();
        }

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return empDAL.GetAllEmployee();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public IHttpActionResult Post(Employee emp)
        {
            try
            {
                empDAL.CreateEmployee(emp);
                return Ok($"Data employee {emp.EmpName} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT: api/Employee/5
        public IHttpActionResult Put(Employee employee)
        {
            try
            {
                empDAL.UpdateEmployee(employee);
                return Ok($"Data employee {employee.EmpName} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE: api/Employee/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                empDAL.DeleteEmployee(id);
                return Ok($"Delete data employee berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
