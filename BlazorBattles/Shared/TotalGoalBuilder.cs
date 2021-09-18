using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class TotalGoalBuilder
    {
        public DateTime startDate { get; set; } = DateTime.Now;
        public int duration { get; set; } = 30;
        public DateTime endDate { get; set; } = DateTime.Now.AddDays(30);
        public int calendarValue { get; set; } = 0;
        public bool monday { get; set; } = true;
        public bool tuesday { get; set; } = true;
        public bool wednesday { get; set; } = true;
        public bool thursday { get; set; } = true;
        public bool friday { get; set; } = true;
        public bool saturday { get; set; } = true;
        public bool sunday { get; set; } = true;
        
    }
}
