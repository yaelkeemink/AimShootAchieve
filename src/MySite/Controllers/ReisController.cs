using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySite.Models;
using MySite.Services;
using MySite.Models.ReisViewModels;
using Microsoft.AspNetCore.Authorization;
using MySite.Services.ServiceInterfaces;

namespace MySite.Controllers
{
    [Authorize]
    public class ReisController : Controller
    {
        private IService<Reis, int> _ReisService;

        public ReisController(IService<Reis, int> service)
        {
            _ReisService = service;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Mijn Reizen";
            var model = _ReisService.GetAll();

            var viewModel = new List<ReisViewModel>();
            foreach(var item in model)
            {
                viewModel.Add((ReisViewModel)item);
            }
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            ReisViewModel viewModel = _ReisService.Get(id);
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
                _ReisService.Add(reis);
                return RedirectToAction("Index");
            }
            return View(reis);
        }
        public IActionResult Aanpassen(int id)
        {
            Reis viewmodel = _ReisService.Get(id);
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Aanpassen(Reis reis)
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
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult LandToevoegen(Land land)
        {
            if (ModelState.IsValid)
            {
                var reis = _ReisService.Get(land.ReisId);
                reis.Landen.Add(land);
                _ReisService.Update(reis);
                return RedirectToAction($"Details/{land.ReisId}");
            }
            return View(land);
        }
        public IActionResult Delete(int id)
        {
            _ReisService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}