using BlazorBattles.Shared;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace BlazorBattles.Client.Services
{
    public class GoalService : IGoalService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _http;

        public Goal CurrentGoal { get; set; }
        public IList<Goal> Goals { get; set; } = new List<Goal>();
        //public IList<GoalDay> GoalDays { get; set; }




        public GoalService(IToastService toastService, HttpClient http)
        {
            _toastService = toastService;
            _http = http;
        }
        public async Task AddGoal(Goal goal)
        {
            var result = await _http.PostAsJsonAsync<Goal>("api/goal", goal);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                _toastService.ShowSuccess(await result.Content.ReadAsStringAsync());
            }
            Goals.Add(goal);
        }

        public async Task EditGoal(Goal goal)
        {
            var result = await _http.PutAsJsonAsync<Goal>("api/goal", goal);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                _toastService.ShowSuccess(await result.Content.ReadAsStringAsync());
            }
            Goals.Add(goal);
        }



        public async Task LoadGoals()
        {
            if(Goals.Count == 0)
            {
                Goals = await _http.GetFromJsonAsync<IList<Goal>>("api/goal");
            }

        }
        public async Task LoadGoalDays()
        {    
            CurrentGoal.Days = new List<GoalDay>(await _http.GetFromJsonAsync<IList<GoalDay>>($"api/goal/days/{CurrentGoal.Id}"));
            //Console.WriteLine( "goal service,number of days: "  + CurrentGoal.Days.Count.ToString());

        }



    }
}
