using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;
using System.Text;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Commo;

namespace LonghornCinemaFinalProject.Utilities
{
    public class GenerateTicketPrice
    {
        public static Decimal GetTicketPrice(DateTime ShowDate)

        {
            //we need a db context to connect to the database

            AppDbContext db = new AppDbContext();

            //Create return value 
            decimal decTicketPrice;
            //Create Max MoviePriceID to be able and filter the most recent update to movie price
            Int32 intMaxMoviePriceID;

            //Initiate bol values to figure out what day/time it is
            Boolean bolWeekday = false; //Variable to check whether the current day is a Weekday(M-F)
            Boolean bolMatinee = false; //Variable to check whether current time < 12:00pm
            Boolean bolFriday = false; //Variable to check whether current day is Friday, because half of friday is the weekend
            Boolean bolTuesday = false; //Variable to check whether it is a discount day or not
            Boolean bolBefore5 = false; //Variable to check whether it is = or < 5pm

            //Convert date of showing to be able to compare and populate booleans
            intMaxMoviePriceID = from c in db.MoviePrice select c.MoviePriceID.max();
            var query = where(x => x.MoviePriceID == intMaxMoviePriceID);

            //Get values from the most recent record of the MoviePriceID
            Decimal decMoviePriceMat = query.decMatineePrice;
            Decimal decMoviePriceWeek = query.decWeekPrice;
            Decimal decMoviePriceWeeknd = query.decWeekendPrice;
            Decimal decMoviePriceTues = query.decTuesdayPrice;

            //Convert showtime date into a comparable type 

            //Use Decisions statements to accurately populate booleans

            //Filter and process through booleans, Call data from Ticket Price, and assign appropriate values to decTicketPrice
            if ((bolTuesday) && (bolBefor5))  // Check if discount rate applies (Tuesday and before 5pm)
            {
                decTicketPrice == decMoviePriceTues;
            }
            else if (!(bolWeekday) || (bolFriday && !(bolMatinee)))  //Check if it is a weekend (friday > 12pm through Sunday evening)
            {
                decTicketPrice == decMoviePriceWeeknd;
            }
            else if (bolMatinee) //Checks if time is before 12pm and through process of elimination falls on a weekday
            {
                decTicketPrice == decMoviePriceMat;
            }
            else //Handles all weekdays after 12pm
            {
                decTicketPrice == decMoviePriceWeek;
            }
            //add one to the current max to find the next one

            intNextOrderNumber = intMaxOrderNumber + 1;



            //return the value

            return decTicketPrice;

        }
    }
}