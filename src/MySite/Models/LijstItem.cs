using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class LijstItem
    {
        [Key]
        public int LijstItemId { get; set; }
        [Required]
        public string Naam { get; set; }
        public bool Gedaan { get; set; }
        public int LijstId { get; set; }
        public Lijst Lijst { get; set; }
    }
}
