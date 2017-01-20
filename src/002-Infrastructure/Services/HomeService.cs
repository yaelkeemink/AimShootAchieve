﻿using _001_Domain.Entities;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.Services
{
    public class HomeService
       : IHomeService
    {
        private IRepository<Lijst, int> _lijstjeRepo;
        private IRepository<Reis, int> _reisRepo;
        private IRepository<Verlanglijst, int> _verlanglijstRepo;

        public HomeService(IRepository<Lijst, int> lijstjeRepo, IRepository<Reis, int> reisRepo, IRepository<Verlanglijst, int> verlanglijstRepo)
        {
            _lijstjeRepo = lijstjeRepo;
            _reisRepo = reisRepo;
            _verlanglijstRepo = verlanglijstRepo;
        }

        public IndexHomeViewModel GetAantallen(string userId)
        {
            int aantalLijsten = _lijstjeRepo.FindAll(userId).Count();
            int aantalVerlangLijst = _verlanglijstRepo.FindAll(userId).Count();
            IEnumerable<Reis> reizen = _reisRepo.FindAll(userId);
            return new IndexHomeViewModel()
            {
                AantalLijstjes = aantalLijsten,
                AantalVerlanglijstjes = aantalVerlangLijst,
                AantalReizenGewenst = reizen.Where(a => a.ReisStatus == Status.Wens).Count(),
                AantalReizenGeboekt = reizen.Where(a => a.ReisStatus == Status.Geboekt).Count(),
                AantalReizenGedaan = reizen.Where(a => a.ReisStatus == Status.Gedaan).Count(),
            };
        }
    }
}