using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XyzOfficeEmployeeTrackerr.Models;

namespace XyzOfficeEmployeeTrackerr.Repository
{
    public class EmployeeRep : iEmployeeRep
    {
        EmployeeContext db;
        public EmployeeRep(EmployeeContext _db)
        {
            db = _db;
        }

        public List<Employee> GetDetails()
        {
            return db.Employees.ToList();
        }

        public Employee GetDetail(int id)
        {
            return db.Employees.Find(id);
        }

        public int AddDetail(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();

            return emp.empId;
        }

        public int UpdateDetail(int id, Employee emp)
        {
            var obj = db.Employees.Find(id);
            if(obj!=null)
            {
                obj.deptName = emp.deptName;
                obj.Name = emp.Name;
                obj.salary = emp.salary;
                obj.deptId = emp.deptId;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public int Delete(int id)
        {
            var obj = db.Employees.Find(id);
            if(obj!=null)
            {
                db.Employees.Remove(obj);
                db.SaveChanges();
                return 1;
            }
            return 0;            

        }
    }
}
