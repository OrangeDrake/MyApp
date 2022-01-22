using BlazorBattles.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    interface IGoalService
    {
        public Goal CurrentGoal { get; set; }
        public Goal TempGoal { get; set; }

        IList<Goal> Goals { get; set; }
        public Task AddGoal(Goal goal);
        public Task EditGoal(Goal goal);
        public Task LoadGoals();
        public Task LoadGoalDays();
        public Task CheckGoalDay(GoalDay goalDay);
        public String PrepareCalenderExport(Goal currentGoal);


    }
}
