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
            if (db != null)
            {
                return (db.Employees.Where(x => x.empId == id)).FirstOrDefault();
            }
            return null;
        }

        public int AddDetail(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();

            return emp.empId;
        }



        public int UpdateDetail(int id, Employee emp)
        {
            if(db!=null)
            {
                var obj = (db.Employees.Where(x => x.empId == id)).FirstOrDefault();
                if (obj != null)
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
            return 0;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Employees.FirstOrDefault(x => x.empId == id);

                if (post != null)
                {

                    db.Employees.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;

        }
    }
}
