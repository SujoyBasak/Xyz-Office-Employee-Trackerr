using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XyzOfficeEmployeeTrackerr.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }
        
        public EmployeeContext()
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }
    }
}
