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
using MySite.Models.LijstViewModels;
using Microsoft.AspNetCore.Authorization;
using MySite.Services.ServiceInterfaces;

namespace MySite.Controllers
{
    [Authorize]
    public class LijstjeController : Controller
    {
        private readonly ILijstService<Lijstje, int> _service;

        public LijstjeController(ILijstService<Lijstje, int> service)
        {
            _service = service;    
        }

        // GET: Lijstjes
        public  IActionResult Index()
        {
            var viewModel = _service.GetAll();
            return View(viewModel);
        }

        // GET: Lijstjes/Details/5
        public IActionResult Details(int id)
        {           
            var lijstje = _service.Get(id);
            if (lijstje == null)
            {
                return NotFound();
            }

            return View(lijstje);
        }

        // GET: Lijstjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lijstjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LijstItemAddViewModel lijstje)
        {
            if (ModelState.IsValid)
            {
                _service.Add(lijstje);
                return RedirectToAction("Index");
            }
            return View(lijstje);
        }

        // GET: Lijstjes/Edit/5
        public IActionResult Edit(int id)
        {
            var lijstje = _service.Get(id);
            if (lijstje == null)
            {
                return NotFound();
            }
            return View(lijstje);
        }

        // POST: Lijstjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Lijstje lijstje)
        {
            if (id != lijstje.LijstjeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(lijstje);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LijstjeExists(lijstje.LijstjeId))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(lijstje);
        }

        public IActionResult LijstItemToevoegen(int id)
        {
            var viewModel = new LijstItem()
            {
                LijstjeId = id,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult LijstItemToevoegen(LijstItem item)
        {
            _service.AddItem(item);
            return RedirectToAction($"Details/{item.LijstjeId}");
        }

        public IActionResult LijstItemVerwijderen(int id)
        {
            var lijstId = _service.RemoveItem(id);
           
            return RedirectToAction($"Details/{lijstId}");
        }
        
        // GET: Lijstjes/Delete/5
        public IActionResult Delete(int id)
        {
            var lijstje = _service.Get(id);
            if (lijstje == null)
            {
                return NotFound();
            }

            return View(lijstje);
        }

        // POST: Lijstjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        private bool LijstjeExists(int id)
        {
            return _service.Get(id) != null;
        }
    }
}
