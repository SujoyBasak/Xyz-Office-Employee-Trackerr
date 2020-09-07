using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XyzOfficeEmployeeTrackerr.Models;
using XyzOfficeEmployeeTrackerr.Repository;

namespace XyzOfficeEmployeeTrackerr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        readonly log4net.ILog _log4net;

        iEmployeeRep db;

        public EmployeeController(iEmployeeRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(EmployeeController));
        }



        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("EmployeeController GET ALL Action Method called");
            try
            {
                var obj = db.GetDetails();
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public IActionResult Get1(int id)
        {
            Employee data=new Employee();
            try
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data); 
            }
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee obj)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != 0)
                        return Ok(res);

                    return NotFound();
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, emp);
                    if (result != 1)
                        return NotFound();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }
    }
}
