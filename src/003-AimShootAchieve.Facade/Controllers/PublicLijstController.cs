using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.PublicViewModels;

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class PublicLijstController 
        : BaseController
    {
        private readonly IPublicService<Lijst> _publicService;
        private readonly ILijstService _lijstServie;

        public PublicLijstController(IPublicService<Lijst> publicLervice,
            ILijstService lijstService,
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _publicService = publicLervice;
            _lijstServie = lijstService;
        }

        public IActionResult Index(BasePublicViewModel<Lijst> model)
        {
            var viewModel = GetPublic(model.Naam);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            Lijst viewModel = _publicService.FindPublic(id);
            return View(viewModel);
        }

        public IActionResult ReturnToIndex(Lijst model)
        {
            var viewModel = new BasePublicViewModel<Lijst>()
            {
                Naam = model.User.UserName,
            };
            return RedirectToAction("index", viewModel);
        }

        public IActionResult Opslaan(Lijst model)
        {
            _lijstServie.Update(model);
            return RedirectToAction($"Details/{model.Id}");
        }

        private BasePublicViewModel<Lijst> GetPublic(string naam)
        {
            IEnumerable<Lijst> lijsten;
            if (string.IsNullOrEmpty(naam))
            {
                lijsten = _publicService.FindPublic(GetFirstNaam());
            }
            else
            {
                lijsten = _publicService.FindPublic(naam);
            }
            List<Lijst> lijstModels = new List<Lijst>();

            foreach (var lijst in lijsten)
            {
                lijstModels.Add(lijst);
            }
            return new BasePublicViewModel<Lijst>(lijstModels, GetUserName());
        }
    }
}