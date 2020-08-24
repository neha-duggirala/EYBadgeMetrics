using System;
using System.Collections.Generic;

namespace EYBadges
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? EmployeeType { get; set; }
        public int? TeamId { get; set; }

        public TeamDetails Team { get; set; }
    }
}
