using System;
using System.Collections.Generic;

namespace EYBadges
{
    public partial class TeamDetails
    {
        public TeamDetails()
        {
            ClientSatisfactionReview = new HashSet<ClientSatisfactionReview>();
            Employee = new HashSet<Employee>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamSize { get; set; }

        public ICollection<ClientSatisfactionReview> ClientSatisfactionReview { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
