using System;
using System.Collections.Generic;

namespace EYBadges
{
    public partial class Modules
    {
        public int RecordNumber { get; set; }
        public DateTime? Date { get; set; }
        public int EmployeeId { get; set; }
        public int? AssignedModules { get; set; }
        public int? FinishedModules { get; set; }
        public int? TimeTakenToFinishModules { get; set; }
        public string RemarksFromTeam { get; set; }
        public string RemarksFromSelf { get; set; }
        public string ComercialAwareness { get; set; }
        public int? CommunicationRatings { get; set; }
    }
}
