using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class EmployeeAttendenceRepository : Repo, IRepo<EmployeeAttendence, int, bool>
    {
        public bool Create(EmployeeAttendence obj)
        {
            db.EmployeeAttendences.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<EmployeeAttendence> Get()
        {
            return db.EmployeeAttendences.ToList();
        }

        public EmployeeAttendence Get(int id)
        {
            return db.EmployeeAttendences.Find(id);
        }

        public EmployeeAttendence Get3rd()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeAttendence> GetOnAbsent()
        {
            throw new NotImplementedException();
        }

        public bool Update(EmployeeAttendence obj)
        {
            throw new NotImplementedException();
        }

        List<string> IRepo<EmployeeAttendence, int, bool>.GetOnHierarchy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
