using LonghornCinemaFinalProject.Models;
using LonghornCinemaFinalProject.DAL;
using System.Data.Entity.Migrations;
using System;
using System.Linq;

namespace LonghornCinemaFinalProject.Migrations
{
    public class MoviePriceData
    {
        public void SeedMoviePrices(AppDbContext db)
        {
            MoviePrice mp1 = new MoviePrice();
            //movie price for matinee = $5
            mp1.decMatineePrice = 5;
            //movie price for tuesday(discountday) 12< x < 5= $8
            mp1.decTuesdayPrice = 8;
            mp1.decWeekendPrice = 12;
            mp1.decWeekPrice = 10;
            db.MoviePrices.AddOrUpdate(m => m.decMatineePrice, mp1);
            db.SaveChanges();
        }
    }
}