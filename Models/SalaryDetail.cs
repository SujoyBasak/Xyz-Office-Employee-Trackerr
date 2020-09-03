using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace XyzOfficeEmployeeTrackerr.Models
{
    public class SalaryDetail
    {
        [Key]
        public int salaryId { get; set; }
        public int empId { get; set; }
        public DateTime date { get; set; }
        public int salary { get; set; }
    }
}
