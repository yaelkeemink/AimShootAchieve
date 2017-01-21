using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.ViewModels.ReisViewModels
{
    public class ReisViewModel
    {
        public ReisViewModel()
        {
            Landen = new List<Land>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public List<Land> Landen { get; set; }
        public string AankomstDatum { get; set; }
        public string VertrekDatum { get; set; }
        public Status ReisStatus { get; set; }
        public int ResiStatusInt { get; set; }
        public bool Prive { get; set; }
        public string UserNaam { get; set; }

        public static implicit operator ReisViewModel(Reis model)
        {
            return new ReisViewModel()
            {
                Id = model.Id,
                Naam = model.Naam,
                Landen = model.Landen,
                ReisStatus = model.ReisStatus,
                AankomstDatum = model.AankomstDatum?.ToString("yyyy-MM-dd"),
                VertrekDatum = model.VertrekDatum?.ToString("yyyy-MM-dd"),
                ResiStatusInt = model.ReisStatus == Status.Wens ? 1 : model.ReisStatus == Status.Geboekt ? 2 : 3,
                Prive = model.Prive,
                UserNaam = model.User.UserName,
            };
        }
    }
}
