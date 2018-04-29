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
        [Authorize]
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

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                    return View(order);
                else
                    return View("Error", new string[] { "This is not your Order!!" });
            }
        }

        // GET: Orders/Create
        [Authorize]
        public ActionResult Create(int ShowingID)
        {
            ViewBag.CurrentShowingID = ShowingID;
            //Showing showing = db.Showings.Find(ShowingID);
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ConfirmationCode,Complete,Subtotal,TaxAmount,Total,OrderDate")] Order order)
        {

            //Record date of order
            order.OrderDate = DateTime.Today;
            order.Complete = false;

            order.ConfirmationCode = 1;
            order.Subtotal = 1;
            order.TaxAmount = 1;
            order.Total = 2;

            Showing showing = db.Showings.Find(ViewBag.CurrentShowingID);

            //AppUser user = db.Users.Find(User.Identity.GetUserId());
            //order.AppUser = user;

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Create", "Tickets", new { OrderID = order.OrderID, ShowingID = showing.ShowingID });
            }

            return View(order);
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

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                    return View(order);
                else
                    return View("Error", new string[] { "This is not your Order!!" });
            }

        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "OrderID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                    return View(order);
                else
                    return View("Error", new string[] { "This is not your Order!!" });
            }
        }

        // GET: Orders/Cancel/5
        [Authorize]
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

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                    return View(order);
                else
                    return View("Error", new string[] { "This is not your Order!!" });
            }
        }

        // POST: Orders/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CancelConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            order.Active = false;
            db.SaveChanges();

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                    return View(order);
                else
                    return View("Error", new string[] { "This is not your Order!!" });
            }
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
