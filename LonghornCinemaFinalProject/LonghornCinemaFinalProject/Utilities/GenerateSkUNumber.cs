using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;

namespace LonghornCinemaFinalProject.Utilities
{
    public class GenerateSKUNumber
    {

        public static Int32 GetNextSKUNumber()

        {

            //we need a db context to connect to the database

            AppDbContext db = new AppDbContext();



            Int32 intMaxSKUNumber; //the current maximum SKU number

            Int32 intNextSKUNumber; //the SKU number for the next class



            if (db.Products.Count() == 0) //there are no courses in the database yet

            {

                intMaxSKUNumber = 5000; //course numbers start at 5001

            }

            else

            {

                intMaxSKUNumber = db.Products.Max(c => c.SKU); //this is the highest number in the database right now

            }



            //add one to the current max to find the next one

            intNextSKUNumber = intMaxSKUNumber + 1;



            //return the value

            return intNextSKUNumber;

        }
    }
}