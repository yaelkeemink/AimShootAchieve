using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class Lijstje
    {
        public Lijstje()
        {
            Items = new List<LijstItem>();
        }
        public int LijstjeId { get; set; }
        [Required]
        public string Naam { get; set; }
        public List<LijstItem> Items { get; set; }
    }
}
