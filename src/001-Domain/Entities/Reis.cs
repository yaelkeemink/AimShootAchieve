using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public enum Status
    {
        Wens = 1,
        Geboekt = 2,
        Gedaan = 3,
    }
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
    }
}
