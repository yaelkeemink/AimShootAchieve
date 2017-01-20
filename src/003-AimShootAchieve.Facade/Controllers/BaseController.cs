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

        public BaseController(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        protected string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
    }
}
