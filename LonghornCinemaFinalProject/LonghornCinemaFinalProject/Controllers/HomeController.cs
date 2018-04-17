using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;

namespace LonghornCinemaFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            //ViewBag.TotalMovieCount = db.Movies.Count();

            List<Movie> AllMovies = new List<Movie>();

            var query = from r in db.Movies select r;

            AllMovies = query.ToList();

            return View(AllMovies.OrderByDescending(r => r.Title));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}