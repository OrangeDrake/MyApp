using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class Goal
    {
        public String Name { get; set; }
        public List<GoalDay> Days { get; } = new List<GoalDay>();

    }
}
