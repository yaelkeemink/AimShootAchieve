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
        public Verlanglijst()
        {
            VerlanglijstItems = new List<VerlanglijstItem>();
        }
        public List<VerlanglijstItem> VerlanglijstItems { get; set; }
    }
    public class VerlanglijstItem
        :BaseEntity
    {
        public string Omschrijving { get; set; }
        public decimal? Prijs { get; set; }
        public string Winkel { get; set; }
        public string Link { get; set; }
        public int VerlanglijstId { get; set; }
        public Verlanglijst Verlanglijst { get; set; }
    }
}