using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _001_Domain.Interfaces;

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class PublicLijstController 
        : BaseController
    {
        private IPublicService<Lijst> _service;

        public PublicLijstController(UserManager<ApplicationUser> userManager, 
            ILoggerFactory loggerFactory) 
            : base(userManager, loggerFactory)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}