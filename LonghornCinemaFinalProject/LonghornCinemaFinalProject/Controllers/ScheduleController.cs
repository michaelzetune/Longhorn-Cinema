using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
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
        private AppDbContext db = new AppDbContext();

        public ActionResult Scheduling(int? ShowingID)
        {

            return View();
        }
        [HttpPost]
        public ActionResult Scheduling(string TargetDate, string TargetTheatre, string CopiedDate)
        {
            
            
            // create variables of appropriate datatype variables 
            DateTime copieddate = DateTime.Now;
            DateTime targetdate = DateTime.Now;
            Theatre targettheatre = Theatre.TheatreOne;
            //Filter through Try and Catch
            try
            {
            copieddate = DateTime.Parse(CopiedDate);
            targetdate = DateTime.Parse(TargetDate);
            targettheatre = (Theatre)Theatre.Parse(typeof(Theatre),TargetTheatre);
            }
            catch
            {
                return RedirectToAction("Scheduling");
            }

            if (copieddate > targetdate)
            {
                return RedirectToAction("Scheduling");
            }
            
            //Create to a list to get all movies
            var query = from r in db.Showings select r;
            query = query.Where(sh => sh.StartTime.Day == copieddate.Day);
            List<Showing> CopyShowings = query.ToList();

            //Get TimeBetween the date they want to copy and the date they want populate
            TimeSpan TimeBetween = (targetdate - copieddate);
            //Create new showing and populate the correct Showing Starttime and Endtime
            Showing show = new Showing();
            int limit = CopyShowings.Count;
            
            //Change Date of every copied showing date before adding to database
            for (int i = 0; i < 2; i++)
            {
                if ((CopyShowings[i].StartTime.Day != targetdate.Day) ||((CopyShowings[i].StartTime.Month != targetdate.Month)))
                {
                    show = CopyShowings[i];
                    show.StartTime.Add(TimeBetween);
                    show.EndTime.Add(TimeBetween);
                    show.TheatreNum = targettheatre;
                    db.Showings.Add(show);
                    db.Entry(show).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            
            //Create a list for all the movies in date
            
            return View("Confirmation");
        }

        public ActionResult Confirmation()
        {
            String strconfirm = "Dates have been copied";
            ViewBag.Confirm = strconfirm;
            return View();
        }

        //Showing s1 = new Showing();
        //s1.StartTime = new DateTime(2018, 5, 4, 9, 5, 0); // 2018, May 4th, 9:05:00
        //s1.EndTime = new DateTime(2018, 5, 4, 11, 14, 0); // 2018, May 4th, 11:14:00
        //s1.SpecialEventStatus = SpecialEvent.NotSpecial;
        //    s1.TheatreNum = Theatre.TheatreOne;
        //    s1.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
        //    db.Showings.AddOrUpdate(s => s.StartTime, s1);
        //    db.SaveChanges();

        ////Split Strings by colons





    }
    
}








    

