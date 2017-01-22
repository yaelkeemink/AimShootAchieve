using _001_Domain.Entities;
using _001_Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.ReisViewModels
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
        public string UserId { get; set; }
        public List<Land> Landen { get; set; }
        public DateTime? AankomstDatum { get; set; }
        public DateTime? VertrekDatum { get; set; }
        public Status ReisStatus { get; set; }
        public SelectList Statussen { get; set; }
        public bool Prive { get; set; }

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
                UserId = model.UserId,
                Prive = model.Prive,
                Statussen = new SelectList(new List<string>() { "Wens", "Geboekt", "Gedaan" }),
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
                UserId = model.UserId,
                Prive = model.Prive,
            };
        }
    }
}
