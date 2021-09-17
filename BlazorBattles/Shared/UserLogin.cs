using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Please enter the an Email Adresss")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
