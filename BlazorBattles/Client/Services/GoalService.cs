using BlazorBattles.Shared;
using Blazored.Toast.Services;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class GoalService : IGoalService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _http;
        //private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };


        public Goal CurrentGoal { get; set; }
        public Goal TempGoal { get; set; }
        public IList<Goal> Goals { get; set; } = new List<Goal>();
        //public IList<GoalDay> GoalDays { get; set; }

        public GoalService(IToastService toastService, HttpClient http)
        {
            _toastService = toastService;
            _http = http;
            
        }
        public async Task AddGoal(Goal goal)
        {
            //var result = await _http.PostAsJsonAsync<Goal>("api/goal", goal, _jsonSerializerOptions);
            var result = await _http.PostAsJsonAsync<Goal>("api/goal", goal);


            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                _toastService.ShowSuccess(await result.Content.ReadAsStringAsync());
            }



            //Goals.Add(goal);
        }

        public async Task EditGoal(Goal goal)
        {
            //foreach (GoalDay day in goal.Days)
            //{
            //    day.Id = 0;
            //}

            var result = await _http.PutAsJsonAsync<Goal>("api/goal", goal);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                _toastService.ShowSuccess(await result.Content.ReadAsStringAsync());
            }

        }



        public async Task LoadGoals()
        {
            if (Goals.Count == 0)
            {
                Goals = await _http.GetFromJsonAsync<IList<Goal>>("api/goal");
            }

        }
        public async Task LoadGoalDays()
        {
            CurrentGoal.Days = new List<GoalDay>(await _http.GetFromJsonAsync<IList<GoalDay>>($"api/goal/days/{CurrentGoal.Id}")).OrderBy(goalDay => goalDay.StartDate).ToList();
            //Console.WriteLine( "goal service,number of days: "  + CurrentGoal.Days.Count.ToString());

        }

        public async Task CheckGoalDay(GoalDay goalDay)
        {
            Console.WriteLine("in service, in check goal");
            var result = await _http.PutAsJsonAsync<GoalDay>("api/goal/day", goalDay);
            Console.WriteLine("Returned from controler: " + await result.Content.ReadAsStringAsync());
        }

        public String PrepareCalenderExport(Goal currentGoal)
        {
            const String GOAL_DAY_SERIE = "A";
            String text = "BEGIN:VCALENDAR\n";
            foreach (GoalDay day in currentGoal.Days)
            {
                text += "BEGIN:VEVENT\n";
                text += "DTSTART: " + day.StartDate.ToString("yyyyMMddThhmmss") + "\n";
                text += "DTEND: " + (day.StartDate + day.LengthTime).ToString("yyyyMMddThhmmss") + "\n";
                text += "UID:" + GOAL_DAY_SERIE + day.Id + "\n";
                text += "SUMMARY:" + currentGoal.Name + " : " + day.Value + " " + currentGoal.Unit + "\n";
                if (day.Note != null)
                {
                    text += "DESCRIPTION:" + day.Note + "\n";
                }
                text += "END:VEVENT\n";
            }
            text += "END:VCALENDAR\n";
            return text;
            //Console.WriteLine("Vyskedny text: " + text);
            //await File.WriteAllTextAsync(@"WriteLines.txt", text);
            //await _js.InvokeAsync<object>("saveFile", "textSave.txt", text);

        }
    }
}
