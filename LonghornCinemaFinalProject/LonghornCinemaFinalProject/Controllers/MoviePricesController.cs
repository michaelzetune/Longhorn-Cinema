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
    public class MoviePricesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MoviePrices
        //public ActionResult Index()
        //{
        //    return View(db.MoviePrices.ToList());
        //}

        // GET: MoviePrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoviePrice moviePrice = db.MoviePrices.Find(id);
            if (moviePrice == null)
            {
                return HttpNotFound();
            }
            return View(moviePrice);
        }

        // GET: MoviePrices/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: MoviePrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MoviePriceID,decMatineePrice,decTuesdayPrice,decWeekendPrice,decWeekPrice")] MoviePrice moviePrice)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.MoviePrices.Add(moviePrice);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(moviePrice);
        //}

        // GET: MoviePrices/Edit/5
        public ActionResult Edit()
        {
            MoviePrice moviePrice = db.MoviePrices.Find(2);
            if (moviePrice == null)
            {
                return HttpNotFound();
            }
            return View(moviePrice);
        }

        // POST: MoviePrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoviePriceID,decMatineePrice,decTuesdayPrice,decWeekendPrice,decWeekPrice")] MoviePrice moviePrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviePrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return View(moviePrice);
        }

        // GET: MoviePrices/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MoviePrice moviePrice = db.MoviePrices.Find(id);
        //    if (moviePrice == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(moviePrice);
        //}

        // POST: MoviePrices/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MoviePrice moviePrice = db.MoviePrices.Find(id);
        //    db.MoviePrices.Remove(moviePrice);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
