using System;
using System.Collections.Generic;

namespace EYBadges.Models
{
    public partial class BadgesList
    {
        public BadgesList()
        {
            EmployeeBadges = new HashSet<EmployeeBadges>();
        }

        public int BadgeId { get; set; }
        public string BadgeName { get; set; }
        public string LevelOfBadge { get; set; }
        public int? DurationInHours { get; set; }

        public ICollection<EmployeeBadges> EmployeeBadges { get; set; }
    }
}
