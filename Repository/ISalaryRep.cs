using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XyzOfficeEmployeeTrackerr.Models;

namespace XyzOfficeEmployeeTrackerr.Repository
{
    public interface ISalaryRep
    {
        public List<SalaryDetail> GetDetails();
        public SalaryDetail GetDetail(int id);
        public int AddDetail(SalaryDetail obj);
        public int UpdateDetail(int id, SalaryDetail obj);
        public int Delete(int id);
    }
}
