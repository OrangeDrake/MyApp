using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    class UserRegister
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Password { get; set; }
        public string ConfirmPasword { get; set; }
        public int StartUid { get; set; }
        public int Bananas { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public bool IsConfirmed { get; set; } = true;

    }
}
