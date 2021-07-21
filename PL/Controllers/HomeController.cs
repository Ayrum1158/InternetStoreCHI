using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BL;
using PL.CustomComponent;

namespace PL.Controllers
{
    public class HomeController : ControllerWithUserSession
    {
        private readonly DBFillTestClass dbftc;

        public HomeController(DBFillTestClass dbftc)
        {
            this.dbftc = dbftc;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Test")]
        public IActionResult Test()
        {
            dbftc.RefillDB();
            TempData["ToastMessage"] = "Database refilled!";
            return RedirectToAction("Index");
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
