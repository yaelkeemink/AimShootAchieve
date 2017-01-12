using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySite.DAL;
using MySite.Models;
using MySite.Services;
using Microsoft.AspNetCore.Authorization;
using MySite.Services.ServiceInterfaces;

namespace MySite.Controllers
{
    [Authorize]
    public class VerlanglijstjeController : Controller
    {
        private readonly IService<Verlanglijstje, int> _service;

        public VerlanglijstjeController(IService<Verlanglijstje, int> service)
        {
            _service = service;    
        }

        // GET: Verlanglijstjes
        public IActionResult Index()
        {
            var viewModel = _service.GetAll();
            return View(viewModel);
        }

        // GET: Verlanglijstjes/Details/5
        public IActionResult Details(int id)
        {
            var viewModel = _service.Get(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Verlanglijstjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verlanglijstjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Link,Naam,Omschrijving,Prijs,Winkel")] Verlanglijstje verlanglijstje)
        {
            if (ModelState.IsValid)
            {
                _service.Add(verlanglijstje);
                return RedirectToAction("Index");
            }
            return View(verlanglijstje);
        }

        // GET: Verlanglijstjes/Edit/5
        public IActionResult Edit(int id)
        {
            var verlanglijstje = _service.Get(id);
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
        public IActionResult Edit(int id, [Bind("Id,Link,Naam,Omschrijving,Prijs,Winkel")] Verlanglijstje verlanglijstje)
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
        public IActionResult Delete(int id)
        {
            var verlanglijstje = _service.Get(id);
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
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        private bool VerlanglijstjeExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}
