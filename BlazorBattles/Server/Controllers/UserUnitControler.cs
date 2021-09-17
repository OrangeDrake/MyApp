﻿using BlazorBattles.Client.Shared;
using BlazorBattles.Server.Data;
using BlazorBattles.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBattles.Shared;

namespace BlazorBattles.Server.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/userunit")]
    [ApiController]
    [Authorize]
    public class UserUnitController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUtilityService _utilityService;

        public UserUnitController(DataContext context, IUtilityService utilityService)

        {
            _context = context;
            _utilityService = utilityService;
        }


        [HttpPost]
        public async Task<IActionResult> BuildUSerUnit([FromBody] int unitId)
        {
            var unit = await _context.Units.FirstOrDefaultAsync<Unit>(u => u.Id == unitId);
            var user = await _utilityService.GetUser();
            if (user.Bananas < unit.BanaCost)
            {
                return BadRequest("Not enought bananas!");
            }
            var newUserUnit = new UserUnit
            {

                UnitId = unit.Id,
                UserId = user.Id,
                HitPoints = unit.HitPoints
            };

            user.Bananas -= unit.BanaCost;

            _context.UserUnits.Add(newUserUnit);
            await _context.SaveChangesAsync();
            return Ok(newUserUnit);
            {

            }
        }



        [HttpPost("revive")]
        public  async Task<IActionResult> ReviveArmy()
        {
            var user = await _utilityService.GetUser();
            var userUnits = await _context.UserUnits
                .Where(unit => unit.UserId == user.Id)
                .Include(unit => unit.Unit)
                .ToListAsync();

            int bananaCost = 1000;

            if(user.Bananas < bananaCost)
            {
                return BadRequest("Not enought bananas! You need 1000 bananas to revive your army.");
            }
            bool armyAlreadyAlive = true;
            foreach(var userUnit in userUnits)
            {
                if (userUnit.HitPoints <= 0)
                {
                    armyAlreadyAlive = false;

                    userUnit.HitPoints = new Random().Next(userUnit.Unit.HitPoints);
                }
            }

            if (armyAlreadyAlive)
            {
                return Ok("Your army is already alive"); 
            }
            user.Bananas -= bananaCost;
            await _context.SaveChangesAsync();
            return Ok("Army revived");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserUnit()
        {
            var user = await _utilityService.GetUser();
            var userUnit = await _context.UserUnits.Where(unit => unit.UserId == user.Id).ToListAsync();
            var response = userUnit.Select(
                unit => new UserUnitResponse
                {
                    UnitId = unit.UnitId,
                    HitPoints = unit.HitPoints

                });
            return Ok(response);
        }


    }
}
