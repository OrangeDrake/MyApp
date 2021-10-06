using BlazorBattles.Server.Data;
using BlazorBattles.Server.Services;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateGoal( Goal goal)
        {
            var user = await _utilityService.GetUser();
            goal.UserId = user.Id;
            /*
             if (user.Bananas < unit.BanaCost)
             {
                 return BadRequest("Not enought bananas!");
             }
            */

            _context.Goals.Add(goal);
            //_context.GoalDays.Add(goal.Days[0]);
            await _context.SaveChangesAsync();
            return Ok("Goal added days:"  + goal.Days.Count);
            {

            }
        }


    }
}
