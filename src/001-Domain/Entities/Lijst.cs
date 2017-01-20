using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public class Lijst
        : BaseEntity
    {
        public Lijst()
        {
            Items = new List<LijstItem>();
        }
        public List<LijstItem> Items { get; set; }
    }
}
