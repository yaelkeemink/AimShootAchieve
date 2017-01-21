using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _003_AimShootAchieve.Facade.Controllers
{
    public class BaseController
        :Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly ILogger _logger;
        protected IEnumerable<string> _namen;

        public BaseController(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory)
        {
            _namen = new List<string>()
            {
                "Jane",
                "Youri",
                "Ela",
                "Louis",
                "Yael"
            }.Where(a => a != GetUserName());
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        protected virtual string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
        protected virtual string GetUserName()
        {
            return _userManager.GetUserName(HttpContext.User);
        }
        protected virtual string GetFirstNaam()
        {
            return _namen.FirstOrDefault();
        }
    }
}
