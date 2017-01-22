using _001_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Entities
{
    public class Recept
    {
        public Recept()
        {
            //Tags = new List<Tag>();
            Ingredienten = new List<Ingredient>();
        }
        public int Id { get; set; }
        public string Naam { get; set; }        
        public string Plaatje { get; set; }
        public IEnumerable<Stap> Bereiding { get; set; }
        public IEnumerable<Ingredient> Ingredienten { get; set; }
        //public IEnumerable<Tag> Tags { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }

    public class Ingredient
    {
        public int Id { get; set; }
        public int Naam { get; set; }
        public Maateenheid Maateeneheid { get; set; }
        public double Hoeveelheid { get; set; }
    }

    public class Stap
    {
        public int Id { get; set; }
        public string Bereiding { get; set; }
    }

    public class Tag
    {
        public Tag()
        {
            Keukens = new List<KeukenTag>();
            Overig = new List<OverigTag>();
        }
        public int Id { get; set; }
        public MenuGang Type { get; set; }
        public IEnumerable<KeukenTag> Keukens { get; set; }
        public IEnumerable<OverigTag> Overig { get; set; }
    }
    public class KeukenTag
    {

    }
    public class OverigTag
    {

    }    
}
