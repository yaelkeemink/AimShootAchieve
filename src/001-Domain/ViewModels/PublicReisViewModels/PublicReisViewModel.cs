using _001_Domain.Entities;
using _001_Domain.ViewModels.ReisViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.PublicReisViewModels
{
    public class PublicReisViewModel
    {
        public PublicReisViewModel()
        {

        }
        public PublicReisViewModel(IEnumerable<ReisViewModel> reizen, string userName)
        {
            List<string> namenLijst = new List<string>()
            {
                "Jane",
                "Youri",
                "Ela",
                "Louis",
                "Yael"
            };
            namenLijst = namenLijst.Where(a => a != userName).ToList();
            Namen = new SelectList(namenLijst);
            Reizen = reizen;
        }
        public IEnumerable<ReisViewModel> Reizen { get; set; }
        public string Naam { get; set; }
        public SelectList Namen { get; set; }
    }
}
