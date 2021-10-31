using BlazorBattles.Server.Data;
using BlazorBattles.Server.Services;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUtilityService _utilityService;

        public GoalController(DataContext context, IUtilityService utilityService)
        {
            _context = context;
            _utilityService = utilityService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateGoal(Goal goal)
        {
            var user = await _utilityService.GetUser();
            goal.UserId = user.Id;

            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return Ok("Goal added days:" + goal.Days.Count);
            {

            }
        }


        [HttpPut("day")]
        public async Task<IActionResult> CheckGoalDay(GoalDay goalDay)
        {
            var checkGoalDay = await _context.GoalDays.FirstOrDefaultAsync(goalDayDatabase => goalDayDatabase.Id == goalDay.Id);

            if (goalDay.Note == String.Empty)
            {
                goalDay.Note = null;
            }
            else
            {
                checkGoalDay.Note = (String)goalDay.Note.Clone();
            }

            checkGoalDay.CheckedValue = goalDay.CheckedValue;

            await _context.SaveChangesAsync();

            return Ok("Goal progress checked: " + goalDay.CheckedValue);
        }
        

        [HttpPut]
        public async Task<IActionResult> EditeGoal(Goal goal)
        {
            var user = await _utilityService.GetUser();
            goal.UserId = user.Id;

            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return Ok("Goal added days:" + goal.Days.Count);
            {

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserGoals()
        {
            var user = await _utilityService.GetUser();
            var userGoals = await _context.Goals.Where(goal => goal.UserId == user.Id).ToListAsync();
            return Ok(userGoals);
        }


        
        [HttpGet("days/{GoalId}")]
        public async Task<IActionResult> GetGoalDays(int GoalId)
        {
            var goalDays = await _context.GoalDays.Where(day => day.GoalId == GoalId).ToListAsync();
            goalDays = await _context.GoalDays.Where(day => day.GoalId == GoalId).ToListAsync();
            return Ok(goalDays);
        }
        

    }
}
