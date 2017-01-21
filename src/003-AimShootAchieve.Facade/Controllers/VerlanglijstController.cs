using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _001_Domain.Interfaces;
using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using _001_Domain.ViewModels.VerlanglijstViewModels;

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class VerlanglijstController
        : BaseController
    {
        private readonly IVerlanglijstService _service;

        public VerlanglijstController(IVerlanglijstService service,
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var viewModel = _service.GetAll(GetUserId());
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = _service.Get(id, GetUserId());
            return View(viewModel);
        }

        public IActionResult Aanmaken()
        {
            var viewModel = new VerlanglijstViewModel()
            {
                UserId = GetUserId(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Aanmaken(VerlanglijstViewModel model)
        {
            Verlanglijst verlanglijst = model;
            _service.Add(verlanglijst);
            return RedirectToAction($"Details/{verlanglijst.Id}");
        }

        public IActionResult Aanpassen(int id)
        {
            var viewModel = _service.Get(id, GetUserId());
            return View(viewModel);
        }

        [HttpPut]
        public IActionResult Aanpassen(Verlanglijst item)
        {
            _service.Update(item);
            return RedirectToAction("Index");
        }

        public IActionResult WensToevoegen(int id)
        {
            var viewModel = new VerlanglijstItem()
            {
                VerlanglijstId = id,
                UserId = GetUserId(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult WensToevoegen(VerlanglijstItem model)
        {
            _service.Update(model);
            return RedirectToAction($"Details/{model.VerlanglijstId}");
        }

        public IActionResult WensAanpassen(int id)
        {
            VerlanglijstItem viewModel = _service.GetItem(id, GetUserId());
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult WensAanpassen(VerlanglijstItem item)
        {
            _service.UpdateItem(item, GetUserId());
            return RedirectToAction($"Details/{item.VerlanglijstId}");
        }

        public IActionResult Verwijderen(int id)
        {
            var viewModel = _service.Get(id, GetUserId());
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id, GetUserId());
            return RedirectToAction("Index");
        }

        public IActionResult VerwijderWens(int id)
        {
            int verlanglijstId = _service.VerwijderItem(id, GetUserId());
            return RedirectToAction($"Details/{verlanglijstId}");
        }
    }
}