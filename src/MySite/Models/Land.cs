using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class Land
    {
        public int LandId { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Stad { get; set; }
        public int ReisId { get; set; }
    }
}
