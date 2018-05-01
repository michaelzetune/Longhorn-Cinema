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
    public class MovieReviewsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MovieReviews
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                var query1 = from r in db.MovieReviews select r;
                if (User.IsInRole("Customer"))
                    query1 = query1.Where(r => r.ApprovalStatus == ApprovalStatus.Approved);
                ViewBag.SelectedMovieReviewsCount = query1.Count();
                ViewBag.TotalMovieReviewsCount = db.MovieReviews.ToList().Count();
                return View(query1.ToList());
            }
            Movie m = db.Movies.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            var query = from r in db.MovieReviews select r;
            if (m != null)
            {
                query = query.Where(r => r.Movie.MovieID == id);
                query = query.Where(r => r.ApprovalStatus == ApprovalStatus.Approved);
            }
            List<MovieReview> MovieReviewsToDisplay = query.ToList();

            ViewBag.SelectedMovieReviewsCount = MovieReviewsToDisplay.Count();
            ViewBag.TotalMovieReviewsCount = db.MovieReviews.ToList().Count();

            return View(MovieReviewsToDisplay.OrderByDescending(r => r.Votes));
        }

        // GET: MovieReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = db.MovieReviews.Find(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            return View(movieReview);
        }

        [Authorize(Roles="Customer")]
        public ActionResult Upvote(int? id)
        {
            MovieReview movieReview = db.MovieReviews.Find(id);

            if (ModelState.IsValid)
            {
                movieReview.Votes += 1;
                db.Entry(movieReview).State = EntityState.Modified;
                db.SaveChanges();
                return View("VoteSuccess", movieReview);
            }
            return View(movieReview);
        }

        [Authorize(Roles = "Customer")]
        public ActionResult Downvote(int? id)
        {
            MovieReview movieReview = db.MovieReviews.Find(id);

            if (ModelState.IsValid)
            {
                movieReview.Votes -= 1;
                db.Entry(movieReview).State = EntityState.Modified;
                db.SaveChanges();
                return View("VoteSuccess", movieReview);
            }
            return View(movieReview);
        }

        [Authorize(Roles = "Customer")]
        // GET: MovieReviews/Create
        public ActionResult Create()
        {
            ViewBag.AllMoviesList = GetAllMovies();
            return View();
        }

        // POST: MovieReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Create([Bind(Include = "MovieReviewID,ReviewText,NumStars,ApprovalStatus")] MovieReview movieReview, Int32 SearchMovieID)
        {
            AppUser user = db.Users.Find(User.Identity.GetUserId());
            Movie thisMovie = db.Movies.Find(SearchMovieID);
            Boolean UserBoughtMovie = false;

            foreach (Order o in user.Orders)
            {
                foreach (Ticket t in o.Tickets)
                {
                    if (t.Showing.Movie.MovieID == thisMovie.MovieID)
                        UserBoughtMovie = true;
                }
            }

            if (UserBoughtMovie) // only allow review to be created if the user bought a ticket to the movie
            {
                movieReview.Movie = db.Movies.First(m => m.MovieID == SearchMovieID);
                String UserID = User.Identity.GetUserId();
                movieReview.AppUser = db.Users.First(u => u.Id == UserID);
                movieReview.ApprovalStatus = ApprovalStatus.NotApproved;

                if (ModelState.IsValid)
                {
                    db.MovieReviews.Add(movieReview);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.AllMoviesList = GetAllMovies();
                return View(movieReview);
            }
            else
            {
                return View("Error", new string[] { "You haven't bought a ticket to this Movie!" });
            }
        }

        // GET: MovieReviews/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = db.MovieReviews.Find(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllMoviesList = GetAllMovies();

            if (movieReview.AppUser.Id == User.Identity.GetUserId() || User.IsInRole("Manager") || User.IsInRole("Employee"))
                return View(movieReview);
            else
                return View("Error", new string[] { "This is not your Movie Review!!" });
        }

        // POST: MovieReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "MovieReviewID,ReviewText,NumStars,ApprovalStatus")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMoviesList = GetAllMovies();

            if (movieReview.AppUser.Id == User.Identity.GetUserId() || User.IsInRole("Manager") || User.IsInRole("Employee"))
                return View(movieReview);
            else
                return View("Error", new string[] { "This is not your Movie Review!!" });
        }

        // GET: MovieReviews/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = db.MovieReviews.Find(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }

            if (movieReview.AppUser.Id == User.Identity.GetUserId() || User.IsInRole("Manager") || User.IsInRole("Employee"))
                return View(movieReview);
            else
                return View("Error", new string[] { "This is not your Movie Review!!" });
        }

        // POST: MovieReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieReview movieReview = db.MovieReviews.Find(id);
            db.MovieReviews.Remove(movieReview);
            db.SaveChanges();

            if (movieReview.AppUser.Id == User.Identity.GetUserId() || User.IsInRole("Manager") || User.IsInRole("Employee"))
                return RedirectToAction("Index");
            else
                return View("Error", new string[] { "This is not your Movie Review!!" });

            
        }

        public SelectList GetAllMovies()
        {
            List<Movie> Movies = db.Movies.ToList();

            SelectList AllMovies = new SelectList(Movies.OrderBy(m => m.Title), "MovieID", "Title");
            return AllMovies;
        }

        public ActionResult ApproveReview(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            MovieReview m = db.MovieReviews.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            m.ApprovalStatus = ApprovalStatus.Approved;
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UnapproveReview(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            MovieReview m = db.MovieReviews.Find(id);
            if (m == null)
            {
                return HttpNotFound();
            }
            m.ApprovalStatus = ApprovalStatus.NotApproved;
            db.Entry(m).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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
