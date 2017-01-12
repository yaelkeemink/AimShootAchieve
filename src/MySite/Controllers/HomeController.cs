using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySite.Services;
using MySite.Models.HomeViewModels;
using Microsoft.AspNetCore.Authorization;
using MySite.Services.ServiceInterfaces;

namespace MySite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            HomeViewModel viewModel = _homeService.GetAantallen();
            return View(viewModel);
        }        

        public IActionResult CV()
        {
            ViewData["Message"] = "Mijn CV.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
