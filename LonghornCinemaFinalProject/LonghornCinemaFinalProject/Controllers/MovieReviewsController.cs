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
                return View(db.MovieReviews.ToList());
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
            }
            List<MovieReview> MovieReviewsToDisplay = query.ToList();

            ViewBag.SelectedMoviesCount = MovieReviewsToDisplay.Count();
            ViewBag.TotalMoviesCount = db.MovieReviews.ToList().Count();

            return View(MovieReviewsToDisplay.OrderBy(r => r.NumStars));
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
        public ActionResult Create([Bind(Include = "MovieReviewID,ReviewText,NumStars,ApprovalStatus")] MovieReview movieReview, Int32 SearchMovieID)
        {
            movieReview.Movie = db.Movies.First(m => m.MovieID == SearchMovieID);

            if (ModelState.IsValid)
            {
                db.MovieReviews.Add(movieReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMoviesList = GetAllMovies();
            return View(movieReview);
        }

        // GET: MovieReviews/Edit/5
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
            return View(movieReview);
        }

        // POST: MovieReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieReviewID,ReviewText,NumStars,ApprovalStatus")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllMoviesList = GetAllMovies();
            return View(movieReview);
        }

        // GET: MovieReviews/Delete/5
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
            return View(movieReview);
        }

        // POST: MovieReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieReview movieReview = db.MovieReviews.Find(id);
            db.MovieReviews.Remove(movieReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList GetAllMovies()
        {
            List<Movie> Movies = db.Movies.ToList();

            SelectList AllMovies = new SelectList(Movies.OrderBy(m => m.Title), "MovieID", "Title");
            return AllMovies;
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
