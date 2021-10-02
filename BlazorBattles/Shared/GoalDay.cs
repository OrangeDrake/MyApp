using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class GoalDay: IComparable<GoalDay>
    {
        public bool IsAllDay { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan LengthTime { get; set; } 
        public string Note { get; set; }

        public int Value { get; set; }

        public int CompareTo(GoalDay other)
        {
            // A null value means that this object is greater.
            if (other == null)
                return 1;

            else
                return this.StartDate.CompareTo(other.StartDate);
        }
    }
}
