using _001_Domain.Entities;
using _001_Domain.Interfaces;
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
    public class VerlanglijstController
        : BaseController
    {
        private readonly IService<Verlanglijst, int> _service;

        public VerlanglijstController(IService<Verlanglijst, int> service,
            UserManager<ApplicationUser> userManager, 
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _service = service;
        }

        // GET: Verlanglijstjes
        public IActionResult Index()
        {
            var viewModel = _service.GetAll(GetUserId());
            return View(viewModel);
        }

        // GET: Verlanglijstjes/Details/5
        public IActionResult Details(int id)
        {
            var viewModel = _service.Get(id, GetUserId());
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Verlanglijstjes/Create
        public IActionResult Aanmaken()
        {
            return View();
        }

        // POST: Verlanglijstjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aanmaken([Bind("Id,Link,Naam,Omschrijving,Prijs,Winkel")] Verlanglijst verlanglijstje)
        {
            if (ModelState.IsValid)
            {
                verlanglijstje.UserId = GetUserId();
                _service.Add(verlanglijstje);
                return RedirectToAction("Index");
            }
            return View(verlanglijstje);
        }

        // GET: Verlanglijstjes/Edit/5
        public IActionResult Aanpassen(int id)
        {
            var verlanglijstje = _service.Get(id, GetUserId());
            if (verlanglijstje == null)
            {
                return NotFound();
            }
            return View(verlanglijstje);
        }

        // POST: Verlanglijstjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aanpassen(int id, Verlanglijst verlanglijstje)
        {
            if (id != verlanglijstje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(verlanglijstje);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerlanglijstjeExists(verlanglijstje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(verlanglijstje);
        }

        // GET: Verlanglijstjes/Delete/5
        public IActionResult Verwijderen(int id)
        {
            var verlanglijstje = _service.Get(id, GetUserId());
            if (verlanglijstje == null)
            {
                return NotFound();
            }

            return View(verlanglijstje);
        }

        // POST: Verlanglijstjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id, GetUserId());
            return RedirectToAction("Index");
        }

        private bool VerlanglijstjeExists(int id)
        {
            return _service.Get(id, GetUserId()) != null;
        }
    }
}
