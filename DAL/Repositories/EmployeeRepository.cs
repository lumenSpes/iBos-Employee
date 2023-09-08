using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class EmployeeRepository : Repo, IRepo<Employee, int, bool>
    {
        public bool Create(Employee obj)
        {
            db.Employees.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Get3rd()
        {
            return db.Employees
            .OrderByDescending(e => e.EmployeeSalary)
            .Skip(2) 
            .Take(1) 
            .FirstOrDefault();
        }

        /*public List<Employee> GetMonthlyAttendence()
        {
            throw new NotImplementedException();
        }*/

        public List<Employee> GetOnAbsent()
        {
            var employeesWithNoAbsentRecords = db.Employees
            .Where(employee =>
                employee.EmployeeAttendence.All(attendance => attendance.IsAbsent == 0)
            )
            .OrderByDescending(employee => employee.EmployeeSalary)
            .ToList();

            return employeesWithNoAbsentRecords;
        }

        public bool Update(Employee obj)
        {
            var exObj = Get(obj.EmployeeId);
            if (exObj == null)
            {
                return false;
            }

            bool isSame = exObj.EmployeeCode == obj.EmployeeCode;
            if (isSame)
            {
                return false;
            }

            exObj.EmployeeName = obj.EmployeeName;
            exObj.EmployeeCode = obj.EmployeeCode;

            db.Employees.Update(exObj);
            return db.SaveChanges() > 0;
        }

        List<string> IRepo<Employee, int, bool>.GetOnHierarchy(int id)
        {
            var hierarchy = new List<string>();

            while (id != 0)
            {
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                {
                    // Employee not found
                    return null;
                }

                hierarchy.Add(employee.EmployeeName);
                id = employee.SupervisorId;
            }

            hierarchy.Reverse(); // Reverse the hierarchy to get the correct order
            return hierarchy;
        }
    }
}
