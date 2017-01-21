using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.ReisViewModels;
using _001_Domain.ViewModels.PublicViewModels;

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

        public IActionResult Index(BasePublicViewModel<ReisViewModel> model)
        {
            var viewModel = GetPublicReizen(model.Naam);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            ReisViewModel viewModel = _service.FindPublic(id);
            return View(viewModel);
        }
        public IActionResult ReturnToIndex(ReisViewModel model)
        {
            var viewModel = new BasePublicViewModel<ReisViewModel>()
            {
                Naam = model.UserNaam,
            };
            return RedirectToAction("index", viewModel);
        }
        private BasePublicViewModel<ReisViewModel> GetPublicReizen(string naam)
        {
            IEnumerable<Reis> reizen;
            if (string.IsNullOrEmpty(naam))
            {
                reizen = _service.FindPublic(GetFirstNaam());
            }
            else
            {
                reizen = _service.FindPublic(naam);
            }
            List<ReisViewModel> reisModels = new List<ReisViewModel>();

            foreach (var reis in reizen)
            {
                reisModels.Add(reis);
            }
            return new BasePublicViewModel<ReisViewModel>(reisModels, GetUserName());
        }
    }
}