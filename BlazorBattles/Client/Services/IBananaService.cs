using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    interface IBananaService
    {
        event Action Onchange;
        int Bananas { get; set;}
        void EatBananas(int amount);
        void AddBananas(int amount);
    }

}
