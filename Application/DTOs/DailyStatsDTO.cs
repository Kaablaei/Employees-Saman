using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DailyStatsDTO
    {
        public int Total { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
    }
}
