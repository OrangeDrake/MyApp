using System;

namespace BlazorBattles.Client.Model
{
    public class GoalBuilder
    {
        public string Name { get; set; } 
        public DateTime StartDate { get; set; } = DateTime.Today;
        public int Duration { get; set; } = 30;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30-1);
        public int CalendarValue { get; set; } = 0;
        public bool Monday { get; set; } = true;
        public bool Tuesday { get; set; } = true;
        public bool Wednesday { get; set; } = true;
        public bool Thursday { get; set; } = true;
        public bool Friday { get; set; } = true;
        public bool Saturday { get; set; } = true;
        public bool Sunday { get; set; } = true;

        public bool IsAllDay { get; set; } = true;
        public string StartTime { get; set; }
        public string LengthTime { get; set; } = "01:00:00";

        public int TotalValue { get; set; }
        public string Unit { get; set; }

    }
}
