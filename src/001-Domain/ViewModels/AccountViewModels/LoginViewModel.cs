using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Naam is verplicht!")]
        public string Naam { get; set; }

        [Required(ErrorMessage ="Wachtwoord is verplicht!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Vergeet me niet!")]
        public bool RememberMe { get; set; }
    }
}
