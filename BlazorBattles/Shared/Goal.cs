using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class Goal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Name { get; set; }
        public List<GoalDay> Days { get; set; } = new List<GoalDay>();
        public bool IsAllDayGenerated { get; set; }
        public DateTime StartDateGenerated { get; set; }
        public TimeSpan LengthTimeGenerated { get; set; }
        public int TotalValue { get; set; }
        public string Unit { get; set; }

    }
}
