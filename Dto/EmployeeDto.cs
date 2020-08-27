using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EYBadges.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string TeamName { get; set; }
        public DeveloperKpiDto DeveloperKpiDto { get; set; }
        public OutOfBoxDto OutOfBoxDto { get; set; }

    }
}
