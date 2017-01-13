using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models.ReisViewModels
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
        public string ReisStatus { get; set; }    

        public static implicit operator ReisViewModel(Reis model)
        {
            return new ReisViewModel()
            {
                Id = model.Id,
                Naam = model.Naam,
                Landen = model.Landen,
                ReisStatus = model.ReisStatus,
                AankomstDatum = model.AankomstDatum.ToString("yyyy-MM-dd"),
                VertrekDatum = model.VertrekDatum.ToString("yyyy-MM-dd"),
            };
        }
    }
}
