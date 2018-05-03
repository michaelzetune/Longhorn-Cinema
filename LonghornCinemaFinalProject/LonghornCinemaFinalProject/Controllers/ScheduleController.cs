using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;
using Microsoft.AspNet.Identity;

namespace LonghornCinemaFinalProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ScheduleController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index(int? movieID)
        {
            if (movieID == null)
            {
                var query1 = db.Showings.Where(s => s.StartTime.Month == DateTime.Now.Month);
                return View(query1.ToList());
            }
            Movie m = db.Movies.Find(movieID);
            if (m == null)
            {
                return HttpNotFound();
            }

            var query = from r in db.Showings select r;
            if (m != null)
            {
                query = query.Where(r => r.Movie.MovieID == movieID);
            }
            List<Showing> ShowingsToDisplay = query.ToList();

            ViewBag.SelectedShowingssCount = ShowingsToDisplay.Count();
            ViewBag.TotalMovieShowingsCount = db.Showings.ToList().Count();

            return View(ShowingsToDisplay.OrderBy(r => r.StartTime));
            //return View(RedirectToAction("Index", "MoviesController"));

        }

        public ActionResult AddToSchedule(int? MovieID)
        {
            //Create a list of showings that are shown on a certain day
            DateTime dt = DateTime.Now;
            var query  = db.Showings.Where(s => s.StartTime == DateTime.Today);
            List<Showing> Showings = query.ToList();
            ViewBag.DayShowings = Showings;
            return View(Showings.OrderBy(r => r.StartTime));
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToSchedule([Bind(Include = "MovieID")]String TimeString, String DateString)
        {
            return View();
        }

        public ActionResult NextDay(int? x)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NextDay()
        {
            return View();
        }

        ////Split Strings by colons
        //String[] timestrings = TimeString.Split(':');
        //String[] datestrings = DateString.Split('/');
        //DateTime Dtproduct = DateTime.Parse(datestrings[0] + "," + datestrings[1] + "," + datestrings[2] + "," + timestrings[0] +"," + timestrings[1]);
        ////Create new showing and populate the correct Showing Starttime and Endtime
        //Showing show = new Showing();
        //show.StartTime = Dtproduct;





    }
}
