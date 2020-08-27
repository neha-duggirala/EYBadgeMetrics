using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EYBadges.Dto
{
    public class DeveloperKpiDto
    {
        public DateTime Date { get; set; }
        public int? TestCoverage { get; set; }
        public int? CodeSmellPercent { get; set; }
        public int? CodeQualityPercent { get; set; }
        public int? Kloc { get; set; }
        public int? Throughput { get; set; }
    }
}
