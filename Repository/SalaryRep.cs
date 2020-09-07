using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XyzOfficeEmployeeTrackerr.Models;

namespace XyzOfficeEmployeeTrackerr.Repository
{
    public class SalaryRep : ISalaryRep
    {
        private readonly EmployeeContext db;

        public SalaryRep(EmployeeContext _db)
        {
            db = _db;
        }


        public int AddDetail(SalaryDetail obj)
        {
            db.SalaryDetails.Add(obj);
            db.SaveChanges();

            return obj.empId;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.SalaryDetails.FirstOrDefault(x => x.salaryId == id);

                if (post != null)
                {

                    db.SalaryDetails.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;
        }

        public SalaryDetail GetDetail(int id)
        {
            if (db != null)
            {
                return (db.SalaryDetails.Where(x => x.salaryId == id)).FirstOrDefault();
            }
            return null;
        }

        public List<SalaryDetail> GetDetails()
        {
            return db.SalaryDetails.ToList();
        }

        public int UpdateDetail(int id, SalaryDetail obj)
        {
            if (db != null)
            {
                var obj1 = db.SalaryDetails.Where(x => x.salaryId == id).FirstOrDefault();
                if (obj1 != null)
                {

                    obj1.empId = obj.empId;
                    obj1.salary = obj.salary;
                    obj1.date = obj.date;
                    
                    db.SaveChanges();
                    return 1;
                }
                return 0;

            }

            return 0;
        }
    }
}
