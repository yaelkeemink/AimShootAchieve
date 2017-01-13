using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models.ReisViewModels
{
    public class ReisAanpassenViewModel
    {     
        public ReisAanpassenViewModel()
        {
            Landen = new List<Land>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public List<Land> Landen { get; set; }
        public DateTime AankomstDatum { get; set; }
        public DateTime VertrekDatum { get; set; }
        public string ReisStatus { get; set; }
        public SelectList Statussen { get; set; }

        public static implicit operator ReisAanpassenViewModel(Reis model)
        {
            return new ReisAanpassenViewModel()
            {
                Id = model.Id,
                Naam = model.Naam,
                Landen = model.Landen,
                ReisStatus = model.ReisStatus,
                AankomstDatum = model.AankomstDatum,
                VertrekDatum = model.VertrekDatum,
                Statussen = new SelectList(new List<string>(){"Wens", "Geboekt", "Gedaan" }),
            };
        }

        public static implicit operator Reis(ReisAanpassenViewModel model)
        {
            return new Reis()
            {
                Id = model.Id,
                Naam = model.Naam,
                Landen = model.Landen,
                ReisStatus = model.ReisStatus,
                AankomstDatum = model.AankomstDatum,
                VertrekDatum = model.VertrekDatum,
            };
        }
    }
}