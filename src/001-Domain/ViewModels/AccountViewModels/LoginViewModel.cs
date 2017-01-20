using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_.Domain.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is verplicht!")]
        [EmailAddress(ErrorMessage = "Email is ongeldig!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Wachtwoord is verplicht!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Vergeet me niet!")]
        public bool RememberMe { get; set; }
    }
}
