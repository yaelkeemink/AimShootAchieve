using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.LijstViewModels
{
    public class AddLijstItemViewModel
    {
        public string Naam { get; set; }
        public string Wens1 { get; set; }
        public string Wens2 { get; set; }
        public string Wens3 { get; set; }
        public string Wens4 { get; set; }
        public string Wens5 { get; set; }
        public bool Prive { get; set; }
        public string UserId { get; set; }

        public static implicit operator Lijst(AddLijstItemViewModel model)
        {
            var lijstItems = new List<LijstItem>()
                {
                    new LijstItem()
                    {
                        Naam = model.Wens1
                    }
                    ,
                    new LijstItem()
                    {
                        Naam = model.Wens2
                    },
                    new LijstItem()
                    {
                        Naam = model.Wens3
                    },
                    new LijstItem()
                    {
                        Naam = model.Wens4
                    },
                    new LijstItem()
                    {
                        Naam = model.Wens5
                    }
                };
            
            var lijst = new Lijst()
            {
                Naam = model.Naam,
                Items = lijstItems.Where(a => a.Naam != null).ToList(),
                Prive = model.Prive,
                UserId = model.UserId,
            };

            return lijst;
        }
    }
}
