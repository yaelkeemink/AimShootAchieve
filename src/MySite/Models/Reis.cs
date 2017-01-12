using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MySite.Models
{
    public enum Status
    {
        Wens = 1,
        Geboekt = 2,
        Gedaan = 3,
    }
    public class Reis
    {
        public Reis()
        {
            Landen = new List<Land>();
        }
        [Key]
        public int Id { get; set; }   
        [Required] 
        public string Naam { get; set; }

        [DisplayName("Aankomst datum")]
        public DateTime AankomstDatum { get; set; }
        [DisplayName("Vertrek datum")]
        public DateTime VertrekDatum { get; set; }
        public string ReisStatus { get; set; }
        public List<Land> Landen { get; set; }
    }
}
