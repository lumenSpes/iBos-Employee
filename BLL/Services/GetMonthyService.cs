using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetMonthyService
    {
        public List<GetOnMonthlyAttendenceDTO> GetMonthlyReport()
        {
            var reports = new List<GetOnMonthlyAttendenceDTO>();

            var employees = DataAccessFactory.EmployeeData().Get();

            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            foreach (var employee in employees)
            {
                var attendanceRecords = DataAccessFactory.AttendenceData().Get()
                    .Where(a => a.EmployeeId == employee.EmployeeId &&
                                a.AttendenceDate.Month == currentMonth &&
                                a.AttendenceDate.Year == currentYear)
                    .ToList();
                Console.WriteLine(attendanceRecords);

                var report = new GetOnMonthlyAttendenceDTO
                {
                    EmployeeName = employee.EmployeeName,
                    MonthName = DateTime.Now.ToString("MMMM"), 
                    PayableSalary = employee.EmployeeSalary, 
                    TotalPresent = attendanceRecords.Count(a => a.IsPresent == 1),
                    TotalAbsent = attendanceRecords.Count(a => a.IsAbsent == 1),
                    TotalOffday = attendanceRecords.Count(a => a.IsOffday == 1),
                };

                reports.Add(report);
            }

            return reports;
        }

    }
}
