using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.HomeViewModels
{
    public class IndexHomeViewModel
    {
        public int AantalReizenGewenst { get; set; }
        public int AantalReizenGeboekt { get; set; }
        public int AantalReizenGedaan { get; set; }

        public int AantalLijstjes { get; set; }
        public int AantalVerlanglijstjes { get; set; }
    }
}
