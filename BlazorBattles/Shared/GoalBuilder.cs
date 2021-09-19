using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class GoalBuilder
    {
        public DateTime startDate { get; set; } = DateTime.Today;
        public int duration { get; set; } = 30;
        public DateTime endDate { get; set; } = DateTime.Now.AddDays(30);
        public int calendarValue { get; set; } = 0;
        public bool Monday { get; set; } = true;
        public bool Tuesday { get; set; } = true;
        public bool Wednesday { get; set; } = true;
        public bool Thursday { get; set; } = true;
        public bool Friday { get; set; } = true;
        public bool Saturday { get; set; } = true;
        public bool Sunday { get; set; } = true;
        
    }
}
