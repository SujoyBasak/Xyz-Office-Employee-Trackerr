using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XyzOfficeEmployeeTrackerr.Models;

namespace XyzOfficeEmployeeTrackerr.Repository
{
    public interface iEmployeeRep
    {
        List<Employee> GetDetails();
        Employee GetDetail(int id);
        int AddDetail(Employee emp);
        int UpdateDetail(int id, Employee emp);
        int Delete(int id);
    }
}
