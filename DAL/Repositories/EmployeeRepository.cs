﻿using DAL.EF.Models;
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
                    !employee.EmployeeAttendence.Any(attendance => attendance.IsAbsent == 1)
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

        public List<string> GetOnHierarchy(int id)
        {
            var hierarchy = new List<string>();
            var visitedIds = new List<int>(); 

            while (id != 0)
            {
                if (visitedIds.Contains(id))
                {
                    break;
                }

                var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }

                hierarchy.Add(employee.EmployeeName);
                visitedIds.Add(id); 
                id = employee.SupervisorId;
            }


            return hierarchy;
        }


    }
}
