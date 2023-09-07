using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int, bool> EmployeeData()
        {
            return new EmployeeRepository();
        }

        public static IRepo<EmployeeAttendence, int, bool> AttendenceData()
        {
            return new EmployeeAttendenceRepository();
        }
    }
}
