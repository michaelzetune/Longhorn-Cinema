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
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Manager,Employee"))
                return View(db.Orders.ToList());
            else
            {
                String UserID = User.Identity.GetUserId();
                List<Order> Orders = db.Orders.Where(o => o.AppUser.Id == UserID).ToList();
                return View(Orders);
                //var query = from o in db.Orders select o;
                //query = query.Where(o => o.AppUser.Id == User.Identity.GetUserId());
                //return View(query.ToList());
            }
        }

        // GET: Orders/Details/5
        [Authorize]
        public ActionResult Details(int OrderID)
        {
            Order order = db.Orders.Find(OrderID);
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
                    return View("Error", new string[] { "This is not your Order!" });
            }
        }

        // GET: Orders/Create
        [Authorize]
        public ActionResult Create(int TicketID)
        {
            // Add the first ticket to the order. For subsequent tickets, this is handled in the
            // POST Tickets/Create near the end
            //Order ord = new Order();
            //Ticket ticket = db.Tickets.Find(TicketID);
            //ord.Tickets.Add(ticket);
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ConfirmationCode,Complete,Subtotal,TaxAmount,Total,OrderDate")] Order order, Int32 TicketID)
        {
            // Add first ticket to order
            Ticket ticket = db.Tickets.Find(TicketID);
            order.Tickets.Add(ticket);

            //Record date of order
            order.OrderDate = DateTime.Today;
            order.Status = OrderStatus.Pending;

            order.ConfirmationCode = Utilities.GenerateNextConfirmationCode.GetNextConfirmationCode();

            AppUser user = db.Users.Find(User.Identity.GetUserId());
            order.AppUser = user;

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Details", "Orders", new { OrderID = order.OrderID });
            }
            //ViewBag.
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
                    return View("Error", new string[] { "This is not your Order!" });
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
                    return View("Error", new string[] { "This is not your Order!" });
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
                    return View("Error", new string[] { "This is not your Order!" });
            }
        }

        // POST: Orders/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CancelConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            order.Status = OrderStatus.Cancelled;
            db.SaveChanges();

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                    return View(order);
                else
                    return View("Error", new string[] { "This is not your Order!" });
            }
        }

        // GET: Orders/Checkout/ID
        public ActionResult Checkout(int? OrderID)
        {
            if (OrderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(OrderID);
            if (order == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                {
                    return View(order);
                }
                else
                {
                    return View("Error", new string[] { "This is not your Order!" });
                }
            }
        }

        // POST: Orders/Checkout/ID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Checkout([Bind(Include = "OrderID,CreditCard")] Order order, String CardNumber)
        {
            AppUser user = db.Users.Find(User.Identity.GetUserId());
            CreditCard thisCard = new CreditCard(CardNumber);
            thisCard.User = user;

            db.CreditCards.Add(thisCard);
            db.SaveChanges();

            order.CreditCard = db.CreditCards.Find(thisCard.CreditCardID);

=======
        public ActionResult Checkout(Order order)
        {
            AppUser user = db.Users.Find(User.Identity.GetUserId());
           
>>>>>>> 70a079261fdabdb434ee484fe1e8c4197f1584fb
            // TODO: MOVE THIS:
            //order.Status = OrderStatus.Complete;
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return View("Confirm");
            }

            if (User.IsInRole("Manager,Employee"))
                return View(order);
            else
            {
                if (order.AppUser.Id == User.Identity.GetUserId())
                {
                    return View(order);
                }
                else
                {
                    return View("Error", new string[] { "This is not your Order!" });
                }
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
