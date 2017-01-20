using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public class Land
        : BaseEntity
    {
        public string Stad { get; set; }
        public int ReisId { get; set; }
        public Reis Reis { get; set; }
    }
}
