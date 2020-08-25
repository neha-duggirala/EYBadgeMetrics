using System;
using System.Collections.Generic;

namespace EYBadges.Models
{
    public partial class DeveloperKpi
    {
        public int RecordNumber { get; set; }
        public DateTime Date { get; set; }
        public int? EmployeeId { get; set; }
        public int? SprintBurnout { get; set; }
        public int? Velocity { get; set; }
        public int? CycleTime { get; set; }
        public int? BugsCount { get; set; }
        public int? TestCoverage { get; set; }
        public int? CodeSmellPercent { get; set; }
        public int? CodeQualityPercent { get; set; }
        public int? Kloc { get; set; }
        public int? Throughput { get; set; }
    }
}
