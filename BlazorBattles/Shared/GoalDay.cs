using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class GoalDay
    {
        public bool IsAllDay { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Length { get; set; }
        public string Note { get; set; }

    }
}
