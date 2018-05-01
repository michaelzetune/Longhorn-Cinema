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
    [Authorize(Roles = "Manager")]
    public class ScheduleController : Controller
    {

        public ActionResult AddToSchedule(Int32 ShowingID)
        {
            return View(ShowingID);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovies([Bind(Include = "ShowingID,StartTime, EndTime, SpecialEvent,TheatreNum,SeatList,MovieID")] Showing showing)
        {
            /*Showing s1 = new Showing();
            s1.StartTime = new DateTime(2018, 5, 4, 9, 5, 0); // 2018, May 4th, 9:05:00
            s1.EndTime = new DateTime(2018, 5, 4, 11, 14, 0); // 2018, May 4th, 11:14:00
            s1.SpecialEventStatus = SpecialEvent.NotSpecial;
            s1.TheatreNum = Theatre.TheatreOne;
            s1.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s1);
            db.SaveChanges();*/

            return View(showing);
        }
    }
}