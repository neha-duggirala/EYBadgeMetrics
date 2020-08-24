using System;
using System.Collections.Generic;

namespace EYBadges
{
    public partial class EmployeeBadges
    {
        public int RecordNumber { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int BadgeId { get; set; }
        public int? Grade { get; set; }
        public bool? Retook { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? BreakoutSessions { get; set; }
        public int? ExternalCourse { get; set; }
        public string ExternalCourseComments { get; set; }

        public BadgesList Badge { get; set; }
    }
}
