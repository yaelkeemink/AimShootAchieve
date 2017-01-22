using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace _003_AimShootAchieve.Facade.Controllers
{
    [Authorize]
    public class MijnReceptenController 
        : BaseController
    {
        public MijnReceptenController(UserManager<ApplicationUser> userManager, 
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