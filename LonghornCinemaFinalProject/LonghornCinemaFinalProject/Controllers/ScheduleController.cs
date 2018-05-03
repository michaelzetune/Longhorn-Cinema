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
                var query1 = db.Showings.Where(s => s.StartTime.Day == DateTime.Today.Day);
                return View(query1.ToList());
            }
            Movie m = db.Movies.Find(movieID);
            if (m == null)
            {
                return HttpNotFound();
            }

            var query = from r in db.Showings select r;
            if (movieID != null)
            {
                query = query.Where(r => r.Movie.MovieID == movieID);
            }
            List<Showing> ShowingsToDisplay = query.ToList();

            ViewBag.SelectedShowingssCount = ShowingsToDisplay.Count();
            ViewBag.TotalMovieShowingsCount = db.Showings.ToList().Count();

            return View(ShowingsToDisplay.OrderBy(r => r.StartTime));
            //return View(RedirectToAction("Index", "MoviesController"));

        }

        public ActionResult NextDay(int intcount)
        {
            if (intcount == 0)
            {
                return RedirectToAction("Index");
            }

            DateTime dtrequested = DateTime.Now;
            dtrequested.AddDays(intcount);
            var query1 = db.Showings.Where(s => s.StartTime.Day == dtrequested.Day);
            return View(query1.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NextDay([Bind(Include = "ShowingID,StartTime,SpecialEvent,TheatreNum,SeatList")]int intcount, Showing ShowingID)
        {
            if (intcount == 0)
            {
                return RedirectToAction("Index");
            }

            DateTime dtrequested = DateTime.Now;
            dtrequested.AddDays(intcount);
            var query1 = db.Showings.Where(s => s.StartTime.Day == dtrequested.Day);
            return View(query1.ToList());
            
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
