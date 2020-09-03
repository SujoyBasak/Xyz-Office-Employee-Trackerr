using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XyzOfficeEmployeeTrackerr.Models;

namespace XyzOfficeEmployeeTrackerr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext con;

        public EmployeeController(EmployeeContext _con)
        {
            con = _con;

        }
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return con.Employees.ToList();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return con.Employees.Find(id);
        }

        // POST: api/Employee
        [HttpPost]
        public string Post([FromBody] Employee obj)
        {
            con.Employees.Add(obj);
            con.SaveChanges();
            return "Record Added";
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Employee emp)
        {
            Employee obj = con.Employees.Find(id);
            obj.Name = emp.Name;
            obj.deptId = emp.deptId;
            obj.deptName = emp.deptName;
            obj.salary = emp.salary;

            con.SaveChanges();

            return "Record Updated";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Employee obj = con.Employees.Find(id);
            if(obj!=null)
            {
                con.Employees.Remove(obj);
                con.SaveChanges();
                return "Record Deleted";
            }
            return "Not Found";
        }
    }
}
