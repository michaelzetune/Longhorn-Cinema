using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;
using System.Text;
using System.Data.SqlClient;


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
            
            ////Initiate bol values to figure out what day/time it is
            Boolean bolWeekend = false; //Variable to check whether the current day is a Weekday(M-F)
            Boolean bolMatinee = false; //Variable to check whether current time < 12:00pm
            Boolean bolFriday = false; //Variable to check whether current day is Friday, because half of friday is the weekend
            Boolean bolTuesday = false; //Variable to check whether it is a discount day or not
            Boolean bolBefore5 = false; //Variable to check whether it is = or < 5pm

            //Create movieprice object that references the most recent record of the MoviePriceID
            MoviePrice movieprice = db.MoviePrices.Last();

            ////Get prices of different showings to be able to compare and populate booleans
            Decimal decMoviePriceMat = movieprice.decMatineePrice;
            Decimal decMoviePriceWeek = movieprice.decWeekPrice;
            Decimal decMoviePriceWeeknd = movieprice.decWeekendPrice;
            Decimal decMoviePriceTues = movieprice.decTuesdayPrice;

            //Convert showtime date into a comparable type 
            
            String strday = ShowDate.DayOfWeek.ToString();
            Int32 inthour = ShowDate.Hour;

            //Use Decisions statements to accurately populate booleans
            if (strday == "Friday")
            {
                bolFriday = true;
            }

            if ((strday == "Saturday") || (strday == "Sunday"))
            {
                bolWeekend = true;
            }

            if (strday == "Tuesday")
            {
                bolTuesday = true;
            }

            if (inthour < 12)
            {
                bolMatinee = true;
            }
            else if (inthour < 17)
            {
                bolBefore5 = true;
            }

            ////Filter and process through booleans, Call data from Ticket Price, and assign appropriate values to decTicketPrice
            if ((bolTuesday) && (bolBefore5))  // Check if discount rate applies (Tuesday and before 5pm)
            {
                decTicketPrice = decMoviePriceTues;
            }
            else if ((bolWeekend) || (bolFriday && !(bolMatinee)))  //Check if it is a weekend (friday > 12pm through Sunday evening)
            {
                decTicketPrice = decMoviePriceWeeknd;
            }
            else if (bolMatinee) //Checks if time is before 12pm and through process of elimination falls on a weekday
            {
                decTicketPrice = decMoviePriceMat;
            }
            else //Handles all weekdays after 12pm
            {
                decTicketPrice = decMoviePriceWeek;
            }
            

            //return the value

            return decTicketPrice; 

        }
    }
}