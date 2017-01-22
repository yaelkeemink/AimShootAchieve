using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _001_Domain.ViewModels.ReceptViewModels;

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class ReceptController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new IndexReceptViewModel();
            return View(viewModel);
        }
    }
}