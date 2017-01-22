using _001_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.ReceptViewModels
{
    public class IndexReceptViewModel
    {
        public string Trefwoord { get; set; }
        public Keuken Keuken { get; set; }
        public Overig Overig { get; set; }
        public MenuGang Menugang { get; set; }
    }
}
