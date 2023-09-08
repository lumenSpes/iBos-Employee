using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set;}
        public int EmployeeSalary { get; set; }
        public int SupervisorId { get; set; }
        public virtual ICollection<EmployeeAttendence> EmployeeAttendence { get; set; }

        public Employee()
        {
            EmployeeAttendence = new List<EmployeeAttendence>();
        }
    }
}
