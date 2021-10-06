using BlazorBattles.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    interface IGoalService
    {
        IList<Goal> Goals { get; set; }
        public Task AddGoal(Goal goal);
        public Task LoadGoals();
    }
}
