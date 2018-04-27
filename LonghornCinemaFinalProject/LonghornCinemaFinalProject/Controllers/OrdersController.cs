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
    public class OrdersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create(int OrderID, int ShowingID)
        {

            Showing show = db.Showings.Find(ShowingID);
           
            Ticket tic = new Ticket();

            Order ord = db.Orders.Find(OrderID);

            tic.Order = ord;

            tic.Showing = show;

            return View(tic);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID")] Order order, Ticket tic, int SelectedShowing, int SelectedMoviePrice)
        {
            // find next order number
            //AppUser user = db.Users.Find(User.Identity.GetUserId());
            //order.TicketPrice = Utilities.GenerateTicketPrice.GetNextOrderNumber();

            //Record date of order
            order.OrderDate = DateTime.Today;

            Showing showing = db.Showings.Find(SelectedShowing);

            MoviePrice movieprice = db.MoviePrices.Find(SelectedMoviePrice);
            tic.Showing = showing;

            Order ord = db.Orders.Find(tic.Order.OrderID);

            tic.Order = ord;

            //sets movie price if day is Tuesday & movie starts before 5pm
            if (showing.StartTime.DayOfWeek == DayOfWeek.Tuesday &&
                showing.StartTime.Hour > 17)
            {
                tic.TicketPrice = movieprice.decTuesdayPrice;
            }
            
            //sets weekend movie price
            if ((showing.StartTime.DayOfWeek == DayOfWeek.Friday && showing.StartTime.Hour > 12) ||
                showing.StartTime.DayOfWeek == DayOfWeek.Saturday || 
                showing.StartTime.DayOfWeek == DayOfWeek.Sunday)
            {
                tic.TicketPrice = movieprice.decWeekendPrice;
            }

            //sets matinee movie price
            if ((showing.StartTime.DayOfWeek == DayOfWeek.Monday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Tuesday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Wednesday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Thursday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Friday) &&
                showing.StartTime.Hour < 12)
            {
                tic.TicketPrice = movieprice.decMatineePrice;
            }

            //sets weekday movie price
            if ((showing.StartTime.DayOfWeek == DayOfWeek.Monday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Tuesday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Wednesday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Thursday ||
                showing.StartTime.DayOfWeek == DayOfWeek.Friday) &&
                showing.StartTime.Hour > 12)
            {
                tic.TicketPrice = movieprice.decWeekPrice;
            }

            //tic.ExtendedPrice = tic.TicketPrice * tic.Quantity;

            if (ModelState.IsValid)
            {
                db.Tickets.Add(tic);
                db.SaveChanges();
                return RedirectToAction("Details", "Orders", new { id = ord.OrderID });
            }

            return View(tic);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
