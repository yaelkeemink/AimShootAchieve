using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.PublicViewModels
{
    public class BasePublicViewModel<Entity>
    {
        public BasePublicViewModel()
        {

        }
        public BasePublicViewModel(IEnumerable<Entity> entities, string userName)
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
            this.Entities = entities;
        }
        public IEnumerable<Entity> Entities { get; set; }
        public string Naam { get; set; }
        public SelectList Namen { get; set; }
    }
}
