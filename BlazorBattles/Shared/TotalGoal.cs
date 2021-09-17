using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class TotalGoal
    {
        public DateTime startDate { get; set; } = DateTime.Now;
        public int duration = 30;
        public DateTime endDate { get; set; } = DateTime.Now.AddDays(30);
    }
}
