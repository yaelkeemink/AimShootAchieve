using _001_Domain.Entities;
using _001_Domain.Enums;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.Services.NonPublicServices
{
    public class HomeService
       : IHomeService
    {
        private readonly IRepository<Lijst> _lijstRepo;
        private readonly IRepository<Reis> _reisRepo;
        private readonly IRepository<Verlanglijst> _verlanglijstRepo;

        public HomeService(IRepository<Lijst> lijstjeRepo, IRepository<Reis> reisRepo, IRepository<Verlanglijst> verlanglijstRepo)
        {
            _lijstRepo = lijstjeRepo;
            _reisRepo = reisRepo;
            _verlanglijstRepo = verlanglijstRepo;
        }

        public IndexHomeViewModel GetAantallen(string userId)
        {
            int aantalLijsten = _lijstRepo.FindAll(userId).Count();
            int aantalVerlangLijst = _verlanglijstRepo.FindAll(userId).Count();
            IEnumerable<Reis> reizen = _reisRepo.FindAll(userId);
            return new IndexHomeViewModel()
            {
                AantalLijstjes = aantalLijsten,
                AantalVerlanglijstjes = aantalVerlangLijst,
                AantalReizenGewenst = reizen.Where(a => a.ReisStatus == Status.Wens).Count(),
                AantalReizenGeboekt = reizen.Where(a => a.ReisStatus == Status.Geboekt).Count(),
                AantalReizenGedaan = reizen.Where(a => a.ReisStatus == Status.Gedaan).Count(),

                AantalPubliekeReizenEla = _reisRepo.FindAllPublic("Ela").Count(),
                AantalPubliekeReizenJane = _reisRepo.FindAllPublic("Jane").Count(),
                AantalPubliekeReizenLouis = _reisRepo.FindAllPublic("Louis").Count(),
                AantalPubliekeReizenYael = _reisRepo.FindAllPublic("Yael").Count(),
                AantalPubliekeReizenYouri = _reisRepo.FindAllPublic("Youri").Count(),

                AantalPubliekeLijstenEla = _lijstRepo.FindAllPublic("Ela").Count(),
                AantalPubliekeLijstenJane = _lijstRepo.FindAllPublic("Jane").Count(),
                AantalPubliekeLijstenLouis = _lijstRepo.FindAllPublic("Louis").Count(),
                AantalPubliekeLijstenYael = _lijstRepo.FindAllPublic("Yael").Count(),
                AantalPubliekeLijstenYouri = _lijstRepo.FindAllPublic("Youri").Count(),

                AantalPubliekeVerlanglijstenEla = _verlanglijstRepo.FindAllPublic("Ela").Count(),
                AantalPubliekeVerlanglijstenJane = _verlanglijstRepo.FindAllPublic("Jane").Count(),
                AantalPubliekeVerlanglijstenLouis = _verlanglijstRepo.FindAllPublic("Louis").Count(),
                AantalPubliekeVerlanglijstenYael = _verlanglijstRepo.FindAllPublic("Yael").Count(),
                AantalPubliekeVerlanglijstenYouri = _verlanglijstRepo.FindAllPublic("Youri").Count(),
            };
        }
    }
}