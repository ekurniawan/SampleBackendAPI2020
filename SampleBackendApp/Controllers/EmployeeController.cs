﻿using SampleBackendApp.DAL;
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
