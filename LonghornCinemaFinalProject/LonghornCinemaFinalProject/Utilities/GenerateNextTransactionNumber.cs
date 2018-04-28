using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;

namespace LonghornCinemaFinalProject.Utilities
{
    public class GenerateNextTransactionNumber
    {
        public static Int32 GetNextTransactionNumber()

        {

            //we need a db context to connect to the database

            AppDbContext db = new AppDbContext();


            Int32 intMaxTransactionNumber; //the current maximum Order number

            Int32 intNextTransactionNumber; //the Order number for the next Product



            if (db.Orders.Count() == 0) //there are no registrations in the database yet

            {

                intMaxTransactionNumber = 5000; //registration numbers start at 101

            }

            else

            {

                intMaxTransactionNumber = db.Orders.Max(c => c.ConfirmationCode); //this is the highest number in the database right now

            }



            //add one to the current max to find the next one

            intNextTransactionNumber = intMaxTransactionNumber + 1;



            //return the value

            return intNextTransactionNumber;

        }
    }
}