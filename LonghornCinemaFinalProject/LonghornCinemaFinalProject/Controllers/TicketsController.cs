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
using Microsoft.AspNet.Identity;

namespace LonghornCinemaFinalProject.Controllers
{
    public class TicketsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        
        // GET: Tickets
        [Authorize(Roles = "Manager,Customer")]
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
                return View(db.Tickets.ToList());
            else
            {
                String UserID = User.Identity.GetUserId();
                List<Ticket> Tickets = db.Tickets.Where(t => t.Order.AppUser.Id == UserID).ToList();
                return View(Tickets);
            }
        }

        // GET: Tickets/Details/5
        [Authorize]
        public ActionResult Details(int OrderID)
        {
            Ticket ticket = db.Tickets.Find(OrderID);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Manager,Employee"))
                return View(ticket);
            else
            {
                String UserID = User.Identity.GetUserId();
                if (ticket.Order.AppUser.Id == UserID)
                {
                    return View(ticket);
                }
                else
                {
                    return View("Error", new string[] { "This is not your ticket!!" });
                }
            }
        }

        // GET: Tickets/Create
        [Authorize]
        public ActionResult Create(int ShowingID)
        {
            Showing show = db.Showings.Find(ShowingID);

            Ticket tic = new Ticket();
            tic.Showing = show;

            AppUser user = db.Users.Find(User.Identity.GetUserId());
            Decimal TicketPrice = Utilities.GenerateTicketPrice.GetTicketPrice(show.StartTime);


            if (show.SpecialEventStatus == SpecialEvent.NotSpecial)
            {
                //sets senior citizen discount
                //TODO: Add logic for only allowing discount for 2 tickets per transaction
                if ((DateTime.Now.Year - user.Birthday.Year) >= 60)
                {
                    TicketPrice = TicketPrice - 2;
                    ViewBag.SeniorCitizen = "$2 Senior Citizen Discount Applied";
                }
                else
                {
                    ViewBag.SeniorCitizen = "No Discount";
                }

                //vars for determining time between now and showing start time
                TimeSpan TimeBetween = (show.StartTime - DateTime.Now);

                //sets discount if ticket is purchased 48 hours in advance
                if ((TimeBetween.TotalHours >= 48))
                {
                    TicketPrice = TicketPrice - 1;
                    ViewBag.Advance = "$1 Discount for Purchasing Early";
                }
                else
                {
                    ViewBag.Advance = "No Discount";
                }
            }

            tic.TicketPrice = TicketPrice;

            ViewBag.AllSeats = FindAvailableSeats(show.Tickets);
            return View(tic);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "TicketID,Seat,TicketPrice")] Ticket tic, Int32 ShowingID, Int32 SelectedSeat)
        {
            Showing show = db.Showings.Find(ShowingID);
            tic.Showing = show;
            AppUser user = db.Users.Find(User.Identity.GetUserId()); //TODO: make sure this is assigned correctly

            //clear existing errors - we know there is no seat
            ModelState.Clear();

            //Add the logic to see what seat they picked
            List<Seat> AllSeats = GetAllSeats();
            Seat seat = AllSeats.FirstOrDefault(s => s.SeatID == SelectedSeat);
            tic.Seat = seat.SeatName;

            
            
            //create logic that will not allow overlapping tickets 
            List<Ticket> BoughtTickets = db.Tickets.Where(t => t.Order.AppUser.Id == user.Id).ToList();
            foreach (Ticket t in BoughtTickets)
            {   
                if ((!(t.Showing.ShowingID == ShowingID)) && (t.Showing.StartTime.Day == tic.Showing.StartTime.Day))
                {
                    if (t.Showing.StartTime.Add(t.Showing.EndTime - t.Showing.StartTime) > tic.Showing.StartTime && (tic.Showing.EndTime > t.Showing.StartTime) )
                    {
                        //ViewBag.OverlappingTicketMessage = "Error: Overlapping Movies. Select another showing.";
                        return View("Error", new string[] { "Cannot buy overlapping Tickets!!" });
                        
                    }
                }

    
            }

            TimeSpan eighteenYears = new TimeSpan(24 * 365 * 18, 0, 0);
            if (DateTime.Now - tic.Order.AppUser.Birthday < eighteenYears)
            {
                if (tic.Showing.Movie.MPAARating == MPAARating.R || tic.Showing.Movie.MPAARating == MPAARating.NC-17)
                {

                }

            }
            
            /////////////////////////

            //double-check everything is okay now that we've added seat
            ValidateModel(tic);

            //*******  Shouldn't need this section, right? ************
            Decimal TicketPrice = Utilities.GenerateTicketPrice.GetTicketPrice(show.StartTime);

            if (show.SpecialEventStatus == SpecialEvent.NotSpecial)
            {
                //sets senior citizen discount
                //TODO: Add logic for only allowing discount for 2 tickets per transaction
                if ((DateTime.Now.Year - user.Birthday.Year) >= 60)
                {
                    TicketPrice = TicketPrice - 2;
                    ViewBag.SeniorCitizen = "$2 Senior Citizen Discount Applied";
                }
                else
                {
                    ViewBag.SeniorCitizen = "No Discount";
                }

                //vars for determining time between now and showing start time
                TimeSpan TimeBetween = (show.StartTime - DateTime.Now);

                //sets discount if ticket is purchased 48 hours in advance
                if ((TimeBetween.TotalHours >= 48))
                {
                    TicketPrice = TicketPrice - 1;
                    ViewBag.Advance = "$1 Discount for Purchasing Early";
                }
                else
                {
                    ViewBag.Advance = "No Discount";
                }
            }

            tic.TicketPrice = TicketPrice;

            // ********************************************************

            if (ModelState.IsValid)
            {
                db.Tickets.Add(tic);
                db.SaveChanges();
                String UserId = User.Identity.GetUserId();

                //These six lines replace the next commented out line (Order LastOrder...)
                List<Order> TempOrdersList = db.Orders.Where(o => o.AppUser.Id == UserId).ToList();
                Order LastOrder;
                if (TempOrdersList.Count() != 0)
                    LastOrder = TempOrdersList.Last();
                else
                    LastOrder = null;

                //Order LastOrder = db.Orders.LastOrDefault(o => o.AppUser.Id == UserId);

                //Redirects the user to Orders/Create if the order is null or completed
                if (LastOrder == null || LastOrder.Complete)
                {
                    return RedirectToAction("Create", "Orders", new { TicketID = tic.TicketID });
                }

                //Redirects the user to Orders/Details if the order has not been completed (they are adding more tickets to the order)
                else
                {
                    LastOrder.Tickets.Add(tic);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Orders", new { OrderID = LastOrder.OrderID });
                }
            }

            ViewBag.AllSeats = FindAvailableSeats(tic.Showing.Tickets);
            return View(tic);
        }

        // GET: Tickets/Edit/5
        [Authorize]
        public ActionResult Edit(int TicketID)
        {
            Ticket ticket = db.Tickets.Find(TicketID);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("Manager,Employee"))
            {
                ViewBag.AllSeatsWithName = FindAvailableSeatsForEdit(ticket.Showing.Tickets);
                return View(ticket);
            }
            else
            {
                String UserID = User.Identity.GetUserId();
                if (ticket.Order.AppUser.Id == UserID)
                {
                    ViewBag.AllSeatsWithName = FindAvailableSeatsForEdit(ticket.Showing.Tickets);
                    return View(ticket);
                }
                else
                    return View("Error", new string[] { "This is not your ticket!!" });
            }
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "TicketID,Seat,TicketPrice")] Ticket ticket)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();

                String UserId = User.Identity.GetUserId();
                List<Order> TempOrdersList = db.Orders.Where(o => o.AppUser.Id == UserId).ToList();
                Order LastOrder;
                if (TempOrdersList.Count() != 0)
                    LastOrder = TempOrdersList.Last();
                else
                    LastOrder = null;

                return RedirectToAction("Details","Orders", new { OrderID = LastOrder.OrderID });
            }
            if (User.IsInRole("Manager,Employee"))
                return View(ticket);
            else
            {
                String UserID = User.Identity.GetUserId();
                if (ticket.Order.AppUser.Id == UserID)
                    return View(ticket);
                else
                    return View("Error", new string[] { "This is not your ticket!!" });
            }
        }

        // GET: Tickets/Delete/5
        [Authorize]
        public ActionResult Delete(int? TicketID)
        {
            if (TicketID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(TicketID);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole("Manager,Employee"))
            {
                return View(ticket);
            }
            else
            {
                String UserID = User.Identity.GetUserId();
                if (ticket.Order.AppUser.Id == UserID)
                    return View(ticket);
                else
                    return View("Error", new string[] { "This is not your ticket!!" });
            }
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int TicketID)
        {
            Ticket ticket = db.Tickets.Find(TicketID);
            Order order = ticket.Order;
            db.Tickets.Remove(ticket);
            db.SaveChanges();

            String UserId = User.Identity.GetUserId();
            List<Order> TempOrdersList = db.Orders.Where(o => o.AppUser.Id == UserId).ToList();
            Order LastOrder;

            if (TempOrdersList.Count() != 0)
                LastOrder = TempOrdersList.Last();
            else
                LastOrder = null;

            if (User.IsInRole("Manager,Employee"))
            {
                return RedirectToAction("Details", "Orders", new { OrderID = LastOrder.OrderID });
            }
            else
            {
                if (order.AppUser.Id == UserId)
                    return RedirectToAction("Details", "Orders", new { OrderID = LastOrder.OrderID });
                else
                    return View("Error", new string[] { "This is not your ticket!!" });
            }
        }

        public SelectList FindAvailableSeats(List<Ticket> tickets)
        {
            //create new seat object
            List<Seat> TakenSeats = new List<Seat>();
            //create logic that will add seats already purchased to a list for filtering
            foreach (Ticket t in tickets)
            {
                Seat s = new Seat();
                s.SeatName = t.Seat;
                s.SeatID = GetSeatID(s.SeatName);
                TakenSeats.Add(s);
            }
            //filter through the seats already purchased
            List<Seat> AvailableSeats = GetAllSeats().Except(TakenSeats).ToList();

            SelectList slAvailableSeats = new SelectList(AvailableSeats, "SeatID", "SeatName");
            return slAvailableSeats;
        }

        public SelectList FindAvailableSeatsForEdit(List<Ticket> tickets)
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

            SelectList slAvailableSeats = new SelectList(AvailableSeats, "SeatName", "SeatName");
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
