using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using _001_Domain.Interfaces;
using _001_Domain.ViewModels.HomeViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using _001_Domain.Entities;

namespace _003_AimShootAchieve.Facade.Controllers
{
    [Authorize]
    public class HomeController 
        : BaseController
    {
        public IHomeService _homeService;
        public HomeController(IHomeService homeService,
            UserManager<ApplicationUser> userManager, 
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            IndexHomeViewModel viewModel = _homeService.GetAantallen(GetUserId());
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

        public IActionResult Test()
        {

            return View();
        }
    }
}
