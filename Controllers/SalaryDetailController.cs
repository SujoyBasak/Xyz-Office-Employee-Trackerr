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
    public class SalaryDetailController : ControllerBase
    {
        private readonly EmployeeContext con;
        public SalaryDetailController(EmployeeContext _con)
        {
            con = _con;
        }
        // GET: api/SalaryDetail
        [HttpGet]
        public IEnumerable<SalaryDetail> Get()
        {
            return con.SalaryDetails.ToList();
        }

        // GET: api/SalaryDetail/5
        [HttpGet("{id}")]
        public IEnumerable<SalaryDetail> Get(int id)
        {
            return con.SalaryDetails.Where(p => p.empId == id).ToList();        
        }

        // POST: api/SalaryDetail
        [HttpPost]
        public string Post([FromBody] SalaryDetail obj)
        {
            con.SalaryDetails.Add(obj);
            con.SaveChanges();
            return "Record Added";
        }

        // PUT: api/SalaryDetail/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] SalaryDetail sal)
        {
            SalaryDetail obj = con.SalaryDetails.Find(id);
            if(obj!=null)
            {
                obj.empId = sal.empId;
                obj.date = sal.date;
                obj.salary = sal.salary;
                con.SaveChanges();
                return "Record Updated";
            }

            return "Record Not Found";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SalaryDetail obj = con.SalaryDetails.Find(id);
            if(obj!=null)
            {
                con.SalaryDetails.Remove(obj);
                con.SaveChanges();
                return "Record Deleted";
            }

            return "Record Not Found";

        }
    }
}
