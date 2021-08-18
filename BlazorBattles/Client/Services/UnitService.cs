using BlazorBattles.Client.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class UnitService : IUnitService
    {
        public IList<Unit> Units => new List<Unit>
        {
            new Unit { Id = 1, Title = "Knight", Attack = 10, Defense = 10, BanaCost = 100 },
            new Unit { Id = 1, Title = "Archr", Attack = 15, Defense = 5, BanaCost = 150 },
            new Unit { Id = 1, Title = "MAeg", Attack = 20, Defense = 1, BanaCost = 200 }
        };

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();

        public void AddUnit(int unitId)
        {
            var unit = Units.First(unit => unit.Id == unitId);
            MyUnits.Add(new UserUnit { UnitID = unit.Id, HitPoints = unit.HitPoints });
        }
    }
}
