using LonghornCinemaFinalProject.Models;
using LonghornCinemaFinalProject.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LonghornCinemaFinalProject.Migrations
{
    public class MoviePriceData
    {
        public void SeedMoviePrice(AppDbContext db)
        {
            MoviePrice mp1 = new MoviePrice();
            mp1.decMatineePrice = 5;
            mp1.decTuesdayPrice = 8;
            mp1.decWeekendPrice = 12;
            mp1.decWeekPrice = 10;

            db.MoviePrices.AddOrUpdate(mp => mp.decMatineePrice, mp1);
            db.SaveChanges();
        }
    }
}