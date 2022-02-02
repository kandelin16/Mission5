using Microsoft.AspNetCore.Http;
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
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult SubmitForm(MovieEntry entry)
        {
            _dbContext.Add(entry);
            _dbContext.SaveChanges();
            return RedirectToAction("MovieEnter", new { message = "Your movie was successfully submitted!" });
        }
        public ActionResult MovieList(string message = "")
        {
            ViewBag.message = message;
            List<MovieEntry> movies = _dbContext.MovieEntries.ToList();
            foreach (MovieEntry movie in movies)
            {
                movie.Category = _dbContext.Categories.Where(a => a.CategoryID == movie.CategoryID).First();
            }
            ViewBag.movies = movies;
            return View();
        }
        public ActionResult DeleteMovie(IFormCollection form)
        {
            int movieID = Convert.ToInt32(form["movieID"]);
            _dbContext.Remove(_dbContext.MovieEntries.Where(a => a.EntryID == movieID).First());
            _dbContext.SaveChanges();
            return RedirectToAction("MovieList", new { message = "Your movie was deleted." });
        }
        public ActionResult MovieDetail(IFormCollection form)
        {
            MovieEntry movie = _dbContext.MovieEntries.Single(a => a.EntryID == Convert.ToInt32(form["movieID"]));
            ViewBag.movie = movie;
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }
        public ActionResult SubmitUpdate(MovieEntry entry)
        {
            MovieEntry movie = _dbContext.MovieEntries.Single(a => a.EntryID == entry.EntryID);
            movie.Title = entry.Title;
            movie.CategoryID = entry.CategoryID;
            movie.Director = entry.Director;
            movie.Edited = entry.Edited;
            movie.LentTo = entry.LentTo;
            movie.Notes = entry.Notes;
            movie.Rating = entry.Rating;
            movie.Year = entry.Year;
            _dbContext.SaveChanges();
            return RedirectToAction("MovieList", new { message = "Movie Updated" });
        }
    }
}
