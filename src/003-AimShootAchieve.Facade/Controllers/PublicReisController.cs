using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.PublicReisViewModels;
using _001_Domain.ViewModels.ReisViewModels;

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class PublicReisController
        : BaseController
    {
        private IPublicService<Reis> _service;

        public PublicReisController(IPublicService<Reis> service,
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _service = service;
        }

        public IActionResult Index(PublicReisViewModel model)
        {
            var viewModel = GetPublicReizen(model.Naam);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            ReisViewModel viewModel = _service.FindPublicReis(id);
            return View(viewModel);
        }
        public IActionResult ReturnToIndex(ReisViewModel model)
        {
            var viewModel = new PublicReisViewModel()
            {
                Naam = model.UserNaam,
            };
            return RedirectToAction("index", viewModel);
        }
        private PublicReisViewModel GetPublicReizen(string naam)
        {
            IEnumerable<Reis> reizen;
            if (string.IsNullOrEmpty(naam))
            {
                reizen = _service.FindPublicReizen(GetFirstNaam());
            }
            else
            {
                reizen = _service.FindPublicReizen(naam);
            }
            List<ReisViewModel> reisModels = new List<ReisViewModel>();

            foreach (var reis in reizen)
            {
                reisModels.Add(reis);
            }
            return new PublicReisViewModel(reisModels, GetUserName());
        }
    }
}