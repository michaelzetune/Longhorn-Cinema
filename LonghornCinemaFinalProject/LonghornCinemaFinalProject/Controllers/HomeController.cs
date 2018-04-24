using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;

using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;

namespace LonghornCinemaFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index(String BasicSearchString)
        {
            List<Movie> MoviesToDisplay = new List<Movie>();

            var query = from r in db.Movies select r;
            if (BasicSearchString != null)
            {
                query = query.Where(r => r.Title.Contains(BasicSearchString) || r.Tagline.Contains(BasicSearchString));
            }
            MoviesToDisplay = query.ToList();

            ViewBag.SelectedMoviesCount = MoviesToDisplay.Count();
            ViewBag.TotalMoviesCount = db.Movies.ToList().Count();

            return View(MoviesToDisplay.OrderBy(r => r.Title));
        }
    }
}