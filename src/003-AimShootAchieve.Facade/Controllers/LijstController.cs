using _001_Domain.Entities;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.LijstViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _003_AimShootAchieve.Facade.Controllers
{
    [Authorize]
    public class LijstController
        : BaseController
    {
        private readonly ILijstService _service;

        public LijstController(ILijstService service,
            UserManager<ApplicationUser> userManager, 
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _service = service;
        }

        // GET: Lijstjes
        public IActionResult Index()
        {
            var viewModel = _service.GetAll(GetUserId());
            return View(viewModel);
        }

        // GET: Lijstjes/Details/5
        public IActionResult Details(int id)
        {
            var lijst = _service.Get(id, GetUserId());
            if (lijst == null)
            {
                return NotFound();
            }
            //var viewModel = lijstje.Items;
            return View(lijst);
        }
        [HttpPost]
        public IActionResult Update(Lijst lijst)
        {
            _service.Update(lijst);
            return Redirect($"Details/{lijst.Id}");
        }
        // GET: Lijstjes/Create
        public IActionResult Aanmaken()
        {
            return View();
        }

        // POST: Lijstjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aanmaken(AddLijstItemViewModel lijst)
        {
            if (ModelState.IsValid)
            {
                lijst.UserId = GetUserId();
                _service.Add(lijst);
                return RedirectToAction("Index");
            }
            return View(lijst);
        }

        // GET: Lijstjes/Edit/5
        public IActionResult Aanpassen(int id)
        {
            var lijst = _service.Get(id, GetUserId());
            if (lijst == null)
            {
                return NotFound();
            }
            return View(lijst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aanpassen(int id, Lijst lijst)
        {
            if (id != lijst.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(lijst);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LijstExists(lijst.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(lijst);
        }
        public IActionResult LijstItemToevoegen(int id)
        {
            var viewModel = new LijstItem()
            {
                LijstId = id,
                UserId = GetUserId(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult LijstItemToevoegen(LijstItem item)
        {
            _service.AddItem(item);
            var viewModel = new LijstItem()
            {
                LijstId = item.LijstId,                
            };
            return View(viewModel);
        }

        public IActionResult LijstItemVerwijderen(int id)
        {
            var lijstId = _service.RemoveItem(id, GetUserId());

            return RedirectToAction($"Details/{lijstId}");
        }

        // GET: Lijstjes/Delete/5
        public IActionResult Verwijderen(int id)
        {
            var lijst = _service.Get(id, GetUserId());
            if (lijst == null)
            {
                return NotFound();
            }

            return View(lijst);
        }

        // POST: Lijstjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id, GetUserId());
            return RedirectToAction("Index");
        }

        private bool LijstExists(int id)
        {
            return _service.Get(id, GetUserId()) != null;
        }
    }
}
