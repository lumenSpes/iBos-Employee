﻿using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeAttendenceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly AttendenceDate { get; set; }
        public int IsPresent { get; set; }
        public int IsAbsent { get; set; }
        public int IsOffday { get; set; }
        public Employee Employee { get; set; }
    }
}
