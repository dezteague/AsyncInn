using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Show clients the home page
        /// </summary>
        /// <returns>index view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
