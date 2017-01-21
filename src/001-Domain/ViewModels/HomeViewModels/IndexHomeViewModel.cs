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

        public int AantalPubliekeReizenYouri { get; set; }
        public int AantalPubliekeReizenJane { get; set; }
        public int AantalPubliekeReizenEla { get; set; }
        public int AantalPubliekeReizenLouis { get; set; }
        public int AantalPubliekeReizenYael { get; set; }
    }
}
