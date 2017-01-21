using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.VerlanglijstViewModels
{
    public class VerlanglijstViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Naam { get; set; }
        public bool Prive { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage= "Wens is verplicht")]
        public string Wens { get; set; }
        public string Omschrijving { get; set; }
        public decimal? Prijs { get; set; }
        public string Winkel { get; set; }
        public string Link { get; set; }

        public static implicit operator Verlanglijst(VerlanglijstViewModel model)
        {
            return new Verlanglijst()
            {
                Naam = model.Naam,
                Prive = model.Prive,
                UserId = model.UserId,
                VerlanglijstItems = new List<VerlanglijstItem>()
                {
                    new VerlanglijstItem()
                    {
                        Naam = model.Wens,
                        Omschrijving = model.Omschrijving,
                        Link = model. Link,
                        Prijs = model.Prijs,
                        Winkel = model.Winkel,
                        UserId = model.UserId,
                    }
                }
            };
        }
    }
}
