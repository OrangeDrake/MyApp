using BlazorBattles.Client.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    interface IUnitService
    {
        IList<Unit> Units{ get;}
        IList<UserUnit> MyUnits { get; set; }
        void AddUnit(int unitId);

    }
}
