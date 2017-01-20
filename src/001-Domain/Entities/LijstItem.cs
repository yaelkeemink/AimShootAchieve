using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public class LijstItem
        : BaseEntity
    {
        //public int LijstItemId { get; set; }
        public bool Gedaan { get; set; }
        public int LijstId { get; set; }
        public Lijst Lijst { get; set; }
    }
}
