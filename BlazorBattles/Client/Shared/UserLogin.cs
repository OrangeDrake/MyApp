using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Please enter the name")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
