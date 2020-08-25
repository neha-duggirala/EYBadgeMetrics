using System;
using System.Collections.Generic;

namespace EYBadges.Models
{
    public partial class TesterKpi
    {
        public int? BugSeverity { get; set; }
        public int? TimeTakenToTest { get; set; }
        public int? TestCasesCreated { get; set; }
        public int? BugCount { get; set; }
        public int? TestCasesAutomated { get; set; }
        public int? DefectResolution { get; set; }
        public int? RejectedDefects { get; set; }
        public int? EmployeeId { get; set; }
        public int RecordNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
