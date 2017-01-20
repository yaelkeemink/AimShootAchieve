using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public class Verlanglijst
        : BaseEntity
    {
        public string Omschrijving { get; set; }
        public decimal? Prijs { get; set; }
        public string Winkel { get; set; }
        public string Link { get; set; }
    }
}
