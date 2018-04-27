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
using LonghornCinemaFinalProject.Utilities;

namespace LonghornCinemaFinalProject.Controllers
{
    public class TicketsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            Showing show = db.Showings.Find(63); // 63 is the showingID, need to make the viewbag pass this from Showings Index view

            Ticket tic = new Ticket();

            tic.Showing = show;

            ViewBag.AllSeats = FindAvailableSeats(show.Tickets);
            return View(tic);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,Seat,TicketPrice")] Ticket tic, Order order, int SelectedShowing, int SelectedMoviePrice, int UserID)
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
                return RedirectToAction("Details", "Tickets", new { id = tic.TicketID });
            }

            ViewBag.AllSeats = FindAvailableSeats(showing.Tickets);

            return View(tic);

            //if (ModelState.IsValid)
            //{
            //    // find next order number

            //    //AppUser user = db.Users.Find(User.Identity.GetUserId());
            //    ticket.TicketPrice = Utilities.GenerateNextTransactionNumber.GetNextTransactionNumber();

            //    db.Tickets.Add(ticket);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,Seat,TicketPrice")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList FindAvailableSeats(List<Ticket> tickets)
        {
            List<Seat> TakenSeats = new List<Seat>();

            foreach (Ticket t in tickets)
            {
                Seat s = new Seat();
                s.SeatName = t.Seat;
                s.SeatID = GetSeatID(s.SeatName);
                TakenSeats.Add(s);
            }

            List<Seat> AvailableSeats = GetAllSeats().Except(TakenSeats).ToList();

            SelectList slAvailableSeats = new SelectList(AvailableSeats, "SeatID", "SeatName");
            return slAvailableSeats;
        }

        public List<Seat> GetAllSeats()
        {
            List<Seat> AllSeats = new List<Seat>();

            Seat s1 = new Seat() { SeatID = 0, SeatName = "A1" };
            AllSeats.Add(s1);

            Seat s2 = new Seat() { SeatID = 1, SeatName = "A2" };
            AllSeats.Add(s2);

            Seat s3 = new Seat() { SeatID = 2, SeatName = "A3" };
            AllSeats.Add(s3);

            Seat s4 = new Seat() { SeatID = 3, SeatName = "A4" };
            AllSeats.Add(s4);

            Seat s5 = new Seat() { SeatID = 4, SeatName = "A5" };
            AllSeats.Add(s5);

            Seat s6 = new Seat() { SeatID = 5, SeatName = "A6" };
            AllSeats.Add(s6);

            Seat s7 = new Seat() { SeatID = 6, SeatName = "A7" };
            AllSeats.Add(s7);

            Seat s8 = new Seat() { SeatID = 7, SeatName = "A8" };
            AllSeats.Add(s8);

            Seat s9 = new Seat() { SeatID = 8, SeatName = "B1" };
            AllSeats.Add(s9);

            Seat s10 = new Seat() { SeatID = 9, SeatName = "B2" };
            AllSeats.Add(s10);

            Seat s11 = new Seat() { SeatID = 10, SeatName = "B3" };
            AllSeats.Add(s11);

            Seat s12 = new Seat() { SeatID = 11, SeatName = "B4" };
            AllSeats.Add(s12);

            Seat s13 = new Seat() { SeatID = 12, SeatName = "B5" };
            AllSeats.Add(s13);

            Seat s14 = new Seat() { SeatID = 13, SeatName = "B6" };
            AllSeats.Add(s14);

            Seat s15 = new Seat() { SeatID = 14, SeatName = "B7" };
            AllSeats.Add(s15);

            Seat s16 = new Seat() { SeatID = 15, SeatName = "B8" };
            AllSeats.Add(s16);

            Seat s17 = new Seat() { SeatID = 16, SeatName = "C1" };
            AllSeats.Add(s17);

            Seat s18 = new Seat() { SeatID = 17, SeatName = "C2" };
            AllSeats.Add(s18);

            Seat s19 = new Seat() { SeatID = 18, SeatName = "C3" };
            AllSeats.Add(s19);

            Seat s20 = new Seat() { SeatID = 19, SeatName = "C4" };
            AllSeats.Add(s20);

            Seat s21 = new Seat() { SeatID = 20, SeatName = "C5" };
            AllSeats.Add(s21);

            Seat s22 = new Seat() { SeatID = 21, SeatName = "C6" };
            AllSeats.Add(s22);

            Seat s23 = new Seat() { SeatID = 22, SeatName = "C7" };
            AllSeats.Add(s23);

            Seat s24 = new Seat() { SeatID = 23, SeatName = "C8" };
            AllSeats.Add(s24);

            Seat s25 = new Seat() { SeatID = 24, SeatName = "D1" };
            AllSeats.Add(s25);

            Seat s26 = new Seat() { SeatID = 25, SeatName = "D2" };
            AllSeats.Add(s26);

            Seat s27 = new Seat() { SeatID = 26, SeatName = "D3" };
            AllSeats.Add(s27);

            Seat s28 = new Seat() { SeatID = 27, SeatName = "D4" };
            AllSeats.Add(s28);

            Seat s29 = new Seat() { SeatID = 28, SeatName = "D5" };
            AllSeats.Add(s29);

            Seat s30 = new Seat() { SeatID = 29, SeatName = "D6" };
            AllSeats.Add(s30);

            Seat s31 = new Seat() { SeatID = 30, SeatName = "D7" };
            AllSeats.Add(s31);

            Seat s32 = new Seat() { SeatID = 31, SeatName = "D8" };
            AllSeats.Add(s32);

            return AllSeats;
        }

        public Int32 GetSeatID(String seatName)
        {
            if (seatName == "A1") return 0;
            if (seatName == "A2") return 1;
            if (seatName == "A3") return 2;
            if (seatName == "A4") return 3;
            if (seatName == "A5") return 4;
            if (seatName == "A6") return 5;
            if (seatName == "A7") return 6;
            if (seatName == "A8") return 7;
            if (seatName == "B1") return 8;
            if (seatName == "B2") return 9;
            if (seatName == "B3") return 10;
            if (seatName == "B4") return 11;
            if (seatName == "B5") return 12;
            if (seatName == "B6") return 13;
            if (seatName == "B7") return 14;
            if (seatName == "B8") return 15;
            if (seatName == "C1") return 16;
            if (seatName == "C2") return 17;
            if (seatName == "C3") return 18;
            if (seatName == "C4") return 19;
            if (seatName == "C5") return 20;
            if (seatName == "C6") return 21;
            if (seatName == "C7") return 22;
            if (seatName == "C8") return 23;
            if (seatName == "D1") return 24;
            if (seatName == "D2") return 25;
            if (seatName == "D3") return 26;
            if (seatName == "D4") return 27;
            if (seatName == "D5") return 28;
            if (seatName == "D6") return 29;
            if (seatName == "D7") return 30;
            if (seatName == "D8") return 31;

            else return -1;
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
