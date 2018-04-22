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
            s1.StartTime = new DateTime(2018, 4, 1, 11, 14);
            s1.EndTime = new DateTime(2018, 4, 1, 13, 39);
            s1.SpecialEvent = NotSpecial;
            s1.TheatreNum = 1;
            s1.SeatList = new List<int>[] { 1, 2, 3, 4 };


        }
    }
}