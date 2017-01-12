using MySite.DAL;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models.HomeViewModels;
using MySite.Services.ServiceInterfaces;

namespace MySite.Services
{
    public class HomeService
        : IHomeService
    {
        private IRepository<Lijstje, int> _lijstjeRepo;
        private IRepository<Reis, int> _reisRepo;
        private IRepository<Verlanglijstje, int> _verlanglijstRepo;

        public HomeService(IRepository<Lijstje, int> lijstjeRepo, IRepository<Reis, int> reisRepo, IRepository<Verlanglijstje, int> verlanglijstRepo)
        {
            _lijstjeRepo = lijstjeRepo;
            _reisRepo = reisRepo;
            _verlanglijstRepo = verlanglijstRepo;
        }

        public HomeViewModel GetAantallen()
        {
            int aantalLijsten = _lijstjeRepo.FindAll().Count();
            int aantalVerlangLijst = _verlanglijstRepo.FindAll().Count();
            IEnumerable<Reis> reizen = _reisRepo.FindAll();
            return new HomeViewModel()
            {
                AantalLijstjes = aantalLijsten,
                AantalVerlanglijstjes = aantalVerlangLijst,
                AantalReizenGewenst = reizen.Where(a => a.ReisStatus == "Wens").Count(),
                AantalReizenGeboekt = reizen.Where(a => a.ReisStatus == "Geboekt").Count(),
                AantalReizenGedaan = reizen.Where(a => a.ReisStatus == "Gedaan").Count(),
            };
        }
    }
}
