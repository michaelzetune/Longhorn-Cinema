using LonghornCinemaFinalProject.Models;
using LonghornCinemaFinalProject.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LonghornCinemaFinalProject.Migrations
{
    public class ShowingData
    {
        public void SeedShowings(AppDbContext db)
        {
            //test
            Showing s1 = new Showing(); 
            s1.StartTime = new DateTime(2018, 5, 4, 9, 5, 0); // 2018, May 4th, 9:05:00
            s1.EndTime = new DateTime(2018, 5, 4, 11, 14, 0); // 2018, May 4th, 11:14:00
            s1.SpecialEventStatus = SpecialEvent.NotSpecial;
            s1.TheatreNum = Theatre.TheatreOne;
            s1.Movie = db.Movies.FirstOrDefault(x => x.Title == "The Sting");
            db.Showings.AddOrUpdate(s => s.StartTime, s1);
            db.SaveChanges();

            // I made this example to exactly echo the first example in the spreadsheet
            // NOTE: keep in mind there are only 12 showings in the seed data -
            //         it might be easier to type them in manually than to create a script
            // removed s1.SeatList(...  because it gets created in the Showing.cs constructor
        }
    }
}