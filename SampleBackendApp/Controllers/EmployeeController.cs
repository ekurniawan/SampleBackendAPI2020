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
        private IEnumerable<Employee> tblEmployee;

        public EmployeeController()
        {
            tblEmployee = new List<Employee>
            {
                new Employee{EmpId=1,EmpName="Budi",Designation="System Engineer",
                    Department="IT",Qualification="Xamarin", BirthDate=new DateTime(1990,7,7)},
                new Employee{EmpId=2,EmpName="Joko",Designation="Web Developer",
                    Department="IT",Qualification="ASP",BirthDate=new DateTime(1986,3,3)}
            };
        }

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return tblEmployee;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
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
