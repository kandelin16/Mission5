using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieEntryContext _dbContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieEntryContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult MyPodcasts()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MovieEnter(string message = "")
        {
            ViewBag.message = message;
            return View();
        }
        [HttpPost]
        public ActionResult SubmitForm(MovieEntry entry)
        {
            _dbContext.Add(entry);
            _dbContext.SaveChanges();
            return RedirectToAction("MovieEnter", new { message = "Your movie was successfully submitted!" });
        }
    }
}
