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
    public class MoviesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Movies
        // NOTE: commented out because we don't use Movies Index, we use HomeController's Index now
        //public ActionResult Index()
        //{
        //    return View(db.Movies.ToList());
        //}

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

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles ="Manager")]
        public ActionResult Create()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create([Bind(Include = "MovieID,Title,Overview,ReleaseDate,Revenue,Runtime,Tagline,Actors,MPAARating")] Movie movie, int[] SelectedGenres)
        {
            if (ModelState.IsValid)
            {
                foreach (int i in SelectedGenres)
                {
                    Genre gen = db.Genres.Find(i);
                    movie.Genres.Add(gen);
                    //gen.Movies.Add(movie); // Brooke on Piazza says we don't need to add Movie to Genre AND Genre to Movie, just one -Michael
                    db.SaveChanges();
                }

                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllGenres = GetAllGenres();
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllGenres = GetAllGenres();
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Edit([Bind(Include = "MovieID,Title,Overview,ReleaseDate,Revenue,Runtime,Tagline,Actors,MPAARating")] Movie movie/*, String Title, String Overview, DateTime ReleaseDate, Int32 Revenue, Int32 Runtime, String Tagline, String Actors, MPAARating MPAARating*/, int[] SelectedGenres)
        {
            if (ModelState.IsValid)
            {
                Movie movieToChange = db.Movies.Find(movie.MovieID);
                movieToChange.Genres.Clear();

                foreach (int i in SelectedGenres)
                {
                    Genre gen = db.Genres.Find(i);
                    movieToChange.Genres.Add(gen);
                    gen.Movies.Add(movieToChange);
                }

                movieToChange.Title = movie.Title;
                movieToChange.Overview = movie.Overview;
                movieToChange.ReleaseDate = movie.ReleaseDate;
                movieToChange.Revenue = movie.Revenue;
                movieToChange.Runtime = movie.Runtime;
                movieToChange.Tagline = movie.Tagline;
                movieToChange.Actors = movie.Actors;
                movieToChange.MPAARating = movie.MPAARating;

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllGenres = GetAllGenres();
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
        public MultiSelectList GetAllGenres()
        {
            List<Genre> allGenres = db.Genres.OrderBy(g => g.Name).ToList();

            MultiSelectList selGenres = new MultiSelectList(allGenres, "GenreID", "Name");

            return selGenres;
        }
        
    }
}
