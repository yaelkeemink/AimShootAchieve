using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public int AantalReizenGewenst { get; set; }
        public int AantalReizenGeboekt { get; set; }
        public int AantalReizenGedaan { get; set; }

        public int AantalLijstjes { get; set; }
        public int AantalVerlanglijstjes { get; set; }
    }
}
