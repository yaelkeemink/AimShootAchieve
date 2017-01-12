using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySite.Controllers
{
    public class LijstenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}