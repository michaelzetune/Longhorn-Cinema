using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;
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

            //Convert date of showing to be able to compare and populate booleans
            intMaxMoviePriceID = from c in db.MoviePrice select c.MoviePriceID.max;
            var query = where(x => x.MoviePriceID == intMaxMoviePriceID);

            //Get values from the most recent record of the MoviePriceID
            Decimal decMoviePriceMat = query.decMatineePrice;
            Decimal decMoviePriceWeek = query.decWeekPrice;
            Decimal decMoviePriceWeeknd = query.decWeekendPrice;
            Decimal decMoviePriceTues = query.decTuesdayPrice;

            //Filter and process through booleans, Call data from Ticket Price, and assign appropriate values to decTicketPrice

            if (bolTuesday)
            {
                //decTicketPrice == discountday
            }


            if (db.Orders.Count() == 0) //there are no registrations in the database yet

            {

                intMaxOrderNumber = 5000; //registration numbers start at 101

            }

            else

            {

                intMaxOrderNumber = db.Orders.Max(c => c.OrderNumber); //this is the highest number in the database right now

            }



            //add one to the current max to find the next one

            intNextOrderNumber = intMaxOrderNumber + 1;



            //return the value

            return decTicketPrice;

        }
    }
}