using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _001_Domain.Entities;
using _001_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using _001_Domain.ViewModels.PublicViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class PublicVerlanglijstController
    : BaseController
    {
        private readonly IPublicService<Verlanglijst> _publicService;
        private readonly IVerlanglijstService _verlanglijstService;

        public PublicVerlanglijstController(IPublicService<Verlanglijst> publicLervice,
            IVerlanglijstService verlanglijstService,
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _publicService = publicLervice;
            _verlanglijstService = verlanglijstService;
        }

        public IActionResult Index(BasePublicViewModel<Verlanglijst> model)
        {
            var viewModel = GetPublic(model.Naam);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            Verlanglijst viewModel = _publicService.FindPublic(id);
            return View(viewModel);
        }

        public IActionResult ReturnToIndex(Verlanglijst model)
        {
            var viewModel = new BasePublicViewModel<Lijst>()
            {
                Naam = model.User.UserName,
            };
            return RedirectToAction("index", viewModel);
        }

        public IActionResult Opslaan(Verlanglijst model)
        {
            _verlanglijstService.Update(model);
            return RedirectToAction($"Details/{model.Id}");
        }

        private BasePublicViewModel<Verlanglijst> GetPublic(string naam)
        {
            IEnumerable<Verlanglijst> lijsten;
            if (string.IsNullOrEmpty(naam))
            {
                lijsten = _publicService.FindPublic(GetFirstNaam());
            }
            else
            {
                lijsten = _publicService.FindPublic(naam);
            }
            List<Verlanglijst> lijstModels = new List<Verlanglijst>();

            foreach (var lijst in lijsten)
            {
                lijstModels.Add(lijst);
            }
            return new BasePublicViewModel<Verlanglijst>(lijstModels, GetUserName());
        }
    }
}