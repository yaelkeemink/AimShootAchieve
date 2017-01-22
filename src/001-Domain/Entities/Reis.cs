using _001_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public class Reis
        : BaseEntity
    {
        public Reis()
        {
            Landen = new List<Land>();
        }
        
        public DateTime? AankomstDatum { get; set; }
        public DateTime? VertrekDatum { get; set; }
        public Status ReisStatus { get; set; }
        public List<Land> Landen { get; set; }
        public decimal TotaalPrijs { get; set; }
        public IEnumerable<Kostenpost> Prijzen { get; set; }
    }
    public class Kostenpost
        : BaseEntity
    {
        public decimal Prijs { get; set; }
        public int ReisId { get; set; }
        public Reis Reis { get; set; }
    }
}
