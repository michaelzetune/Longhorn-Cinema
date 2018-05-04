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
    public class ShowingsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Showings
        public ActionResult Index(int? id)
        {
            if (id == null || id == -1)
            {
                return View(db.Showings.ToList());
            }
            if (id == 0)
            {
                //DateTime Today = DateTime.Today;
                //var query1 = from r in db.Showings select r;

                //foreach (Showing s in query1.ToList())
                //{
                //    if (s.StartTime.Date == Today)
                //        query1 = query1.Where(r => r.ShowingID != s.ShowingID);
                //}

                //List<Showing> ShowingsToDisplay1 = query1.ToList();

                //ViewBag.SelectedShowingsCount = ShowingsToDisplay1.Count();
                //ViewBag.TotalMovieShowingsCount = db.Showings.ToList().Count();
                int Day = DateTime.Now.Day;
                return View(db.Showings.Where(u => u.StartTime.Day == Day).ToList());
            }
            Movie m = db.Movies.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            var query = from r in db.Showings select r;
            if (m != null)
            {
                query = query.Where(r => r.Movie.MovieID == id);
            }
            List<Showing> ShowingsToDisplay = query.ToList();

            ViewBag.SelectedShowingsCount = ShowingsToDisplay.Count();
            ViewBag.TotalMovieShowingsCount = db.Showings.ToList().Count();

            return View(ShowingsToDisplay.OrderBy(r => r.StartTime));
        }

        //public ActionResult FilterByToday()
        //{
        //    DateTime Today = DateTime.Today;
        //    var query = from r in db.Showings select r;
            
        //    foreach (Showing s in query.ToList())
        //    {
        //        if (s.StartTime.Date == Today)
        //            query = query.Where(r => r.ShowingID != s.ShowingID);
        //    }

        //    List<Showing> ShowingsToDisplay = query.ToList();

        //    ViewBag.SelectedShowingsCount = ShowingsToDisplay.Count();
        //    ViewBag.TotalMovieShowingsCount = db.Showings.ToList().Count();

        //    return RedirectToAction("Index", new { id = 0 });
        //}



        // GET: Showings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            return View(showing);
        }

        // GET: Showings/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            ViewBag.AllMoviesList = GetAllMovies();
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "ShowingID,StartTime,SpecialEvent,TheatreNum,SeatList,MovieID")] Showing showing, Int32 SearchMovieID)
        {

            if (ModelState.IsValid && showing.StartTime > DateTime.Now)
            {
                Movie m = db.Movies.FirstOrDefault(x => x.MovieID == SearchMovieID);
                showing.EndTime = showing.StartTime.AddMinutes(m.Runtime);
                showing.Movie = m;
                db.Showings.Add(showing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMoviesList = GetAllMovies();
            ViewBag.ShowingInPastError = "You've scheduled this Showing in the past. Pick a future start time.";
            return View(showing);
        }

        // GET: Showings/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllMoviesList = GetAllMovies();
            return View(showing);
        }

        // POST: Showings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "ShowingID,StartTime,SpecialEvent,TheatreNum,SeatList")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showing);
        }

        // GET: Showings/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            return View(showing);
        }

        // POST: Showings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Showing showing = db.Showings.Find(id);
            
            
            ////Sam's code insertion
            AppUser user = db.Users.Find(User.Identity.GetUserId());
            Utilities.EmailMessaging.SendEmail(user.Email, "Team 5: LonghornCinema Showing Cancellation Confirmation",
            "We apologize but we cancelled your showing, " + showing.Movie.ToString());
            db.Showings.Remove(showing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public SelectList GetAllMovies()
        {
            List<Movie> Movies = db.Movies.ToList();

            SelectList AllMovies = new SelectList(Movies.OrderBy(m => m.Title), "MovieID", "Title");
            return AllMovies;

        }

        public ActionResult CopyMovies(int id)
        {

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
