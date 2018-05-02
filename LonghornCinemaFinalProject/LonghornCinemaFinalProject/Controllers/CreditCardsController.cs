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
    public class CreditCardsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CreditCards
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Manager,Employee"))
                return View(db.CreditCards.ToList());
            else
            {
                String UserID = User.Identity.GetUserId();
                List<CreditCard> CreditCards = db.CreditCards.Where(c => c.AppUser.Id == UserID).ToList();
                return View(CreditCards);
            }
        }

        // GET: CreditCards/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            CreditCard creditcard = db.CreditCards.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole("Manager,Employee"))
                return View(creditcard);
            else
            {
                if (creditcard.AppUser.Id == User.Identity.GetUserId())
                    return View(creditcard);
                else
                    return View("Error", new string[] { "This is not your Credit Card!" });
            }
        }

        // GET: CreditCards/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardID,CardNumber")] CreditCard creditCard)
        {
            if (creditCard.CardNumber == null)
                return View(creditCard);

            if (((creditCard.CardNumber != null) &&
                (creditCard.CardType != CardType.Invalid) &&
                (creditCard.CardNumber.Length > 0)) &&
                (creditCard.CardType == CardType.Amex && creditCard.CardNumber.Length == 15) ||
                (creditCard.CardType == CardType.Visa && creditCard.CardNumber.Length == 16) ||
                (creditCard.CardType == CardType.MasterCard && creditCard.CardNumber.Length == 16) ||
                (creditCard.CardType == CardType.Discover && creditCard.CardNumber.Length == 16))
            {

                if (ModelState.IsValid)
                {
                    AppUser user = db.Users.Find(User.Identity.GetUserId());
                    user.CreditCards.Add(creditCard);

                    db.CreditCards.Add(creditCard);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CardTypeError = "Invalid Credit Card Number";
            return View(creditCard);
        }

        // GET: CreditCards/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Manager,Employee"))
                return View(creditCard);
            else
            {
                if (creditCard.AppUser.Id == User.Identity.GetUserId())
                    return View(creditCard);
                else
                    return View("Error", new string[] { "This is not your Credit Card!" });
            }
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditCardID,CardNumber")] CreditCard creditCard)
        {
            if (creditCard.CardNumber == null)
                return View(creditCard);

            if (((creditCard.CardNumber != null) &&
                (creditCard.CardType != CardType.Invalid) &&
                (creditCard.CardNumber.Length > 0)) &&
                (creditCard.CardType == CardType.Amex && creditCard.CardNumber.Length == 15) ||
                (creditCard.CardType == CardType.Visa && creditCard.CardNumber.Length == 16) ||
                (creditCard.CardType == CardType.MasterCard && creditCard.CardNumber.Length == 16) ||
                (creditCard.CardType == CardType.Discover && creditCard.CardNumber.Length == 16))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(creditCard).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CardTypeError = "Invalid Credit Card Number";
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Manager,Employee"))
                return View(creditCard);
            else
            {
                if (creditCard.AppUser.Id == User.Identity.GetUserId())
                    return View(creditCard);
                else
                    return View("Error", new string[] { "This is not your Credit Card!" });
            }
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditCard);
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
