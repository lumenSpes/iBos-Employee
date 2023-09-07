﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GetOnMonthlyAttendenceDTO
    {
        public string EmployeeName { get; set; }
        public string MonthName { get; set; }
        public int PayableSalary { get; set; }
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalOffday { get; set; }
    }
}
