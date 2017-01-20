using _001_Domain.Entities;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.ReisViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _003_AimShootAchieve.Facade.Controllers
{
    [Authorize]
    public class ReisController
        : BaseController
    {
        private IReisService _ReisService;

        public ReisController(IReisService service,
            UserManager<ApplicationUser> userManager, 
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _ReisService = service;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Mijn Reizen";
            var model = _ReisService.GetAll(GetUserId());

            var viewModel = new List<ReisViewModel>();
            foreach (var item in model)
            {
                viewModel.Add((ReisViewModel)item);
            }
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            ReisViewModel viewModel = _ReisService.Get(id, GetUserId());
            return View(viewModel);
        }
        public IActionResult ReisToevoegen()
        {
            var viewModel = new Reis()
            {
                AankomstDatum = DateTime.Now,
                VertrekDatum = DateTime.Now.AddDays(14),
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult ReisToevoegen(Reis reis)
        {
            if (ModelState.IsValid)
            {
                reis.UserId = GetUserId();
                _ReisService.Add(reis);
                return RedirectToAction("Index");
            }
            return View(reis);
        }
        public IActionResult Aanpassen(int id)
        {
            ReisAanpassenViewModel viewmodel = _ReisService.Get(id, GetUserId());
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Aanpassen(ReisAanpassenViewModel reis)
        {
            if (ModelState.IsValid)
            {
                _ReisService.Update(reis);
                return RedirectToAction($"Details/{reis.Id}");
            }
            return View(reis);
        }

        public IActionResult LandToevoegen(int id)
        {
            var viewModel = new Land()
            {
                ReisId = id,
                UserId = GetUserId(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult LandToevoegen(Land land)
        {
            if (ModelState.IsValid)
            {                
                _ReisService.AddLand(land);
                return RedirectToAction($"Details/{land.ReisId}");
            }
            return View(land);
        }
        public IActionResult Verwijderen(int id)
        {
            _ReisService.Delete(id, GetUserId());
            return RedirectToAction("Index");
        }
    }
}
