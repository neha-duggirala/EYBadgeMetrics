using System;
using System.Collections.Generic;

namespace EYBadges
{
    public partial class ClientSatisfactionReview
    {
        public int RecordNumber { get; set; }
        public DateTime Date { get; set; }
        public int? Ratings { get; set; }
        public string Communication { get; set; }
        public string Accountability { get; set; }
        public string Likes { get; set; }
        public string Disappointment { get; set; }
        public string ActionItems { get; set; }
        public bool? RequirementsMet { get; set; }
        public int? TeamId { get; set; }

        public TeamDetails Team { get; set; }
    }
}
