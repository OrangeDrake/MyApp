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

        public GoalService(IToastService toastService, HttpClient http)
        {
            _toastService = toastService;
            _http = http;
        }
        public async Task AddGoal(Goal goal)
        {
            Console.WriteLine("days: "+goal.Days.Count);
            var result = await _http.PostAsJsonAsync<Goal>("api/goal", goal);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                _toastService.ShowSuccess(await result.Content.ReadAsStringAsync());
            }
        }

}
}
