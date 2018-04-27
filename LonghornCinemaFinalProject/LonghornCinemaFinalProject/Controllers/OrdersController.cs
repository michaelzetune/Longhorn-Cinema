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
        //[Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID")] Order order, Ticket tic, int SelectedShowing, int SelectedMoviePrice, int UserID)
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

            AppUser user = db.Users.Find(UserID);

            tic.Order = ord;

            tic.TicketPrice = Utilities.GenerateTicketPrice.GetTicketPrice(showing.StartTime);

            if (showing.SpecialEventStatus == SpecialEvent.NotSpecial)
            {
                //sets senior citizen discount
                //TODO: Add logic for only allowing discount for 2 tickets per transaction
                if ((DateTime.Now.Year - user.Birthday.Year) >= 60)
                {
                    tic.TicketPrice = tic.TicketPrice - 2;
                    ViewBag.SeniorCitizen = "$2 Senior Citizen Discount Applied";
                }
                else
                {
                    ViewBag.SeniorCitizen = "No Discount";
                }

                //vars for determining time between now and showing start time
                Int32 intDayHours = (DateTime.Now.Day - showing.StartTime.Day) * 24;
                Int32 intHours = (DateTime.Now.Hour - showing.StartTime.Hour);
                Int32 intTotalHours = intDayHours + intHours;

                //sets discount if ticket is purchased 48 hours in advance
                if ((intTotalHours >= 48))
                {
                    tic.TicketPrice = tic.TicketPrice - 1;
                    ViewBag.Advance = "$1 Discount for Purchasing Early";
                }
                else
                {
                    ViewBag.Advance = "No Discount";
                }
            }
            tic.ExtendedPrice = tic.TicketPrice * tic.Quantity;

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

        // GET: Orders/cancel/5
        public ActionResult Cancel(int? id)
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

        // POST: Orders/cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public ActionResult cancelConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            order.active = false;
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
