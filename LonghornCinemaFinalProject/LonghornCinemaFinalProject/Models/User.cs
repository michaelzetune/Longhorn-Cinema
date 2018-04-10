using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public class User
    {
        // Properties
        // UserID
        public Int32 UserID { get; set; }

        // LastName
        public String LastName { get; set; }

        // FirstName
        public String FirstName { get; set; }

        // Email
        public String Email { get; set; }

        // Password
        public String Password { get; set; }

        // Birthday
        public DateTime Birthday { get; set; }

        // StreetAddress
        public String StreetAddress { get; set; }

        // City
        public String City { get; set; }

        // State
        public String State { get; set; }

        // Zip
        public Int32 ZipCode { get; set; }

        // Phone Number
        public String PhoneNumber { get; set; }

        // UserStatus
        //not sure if this is correct -Ben
        public String UserStatus { get; set; }

        // PopcornPointsBalance
        public Decimal PopcornPointsBalance { get; set; }

        // Navigation Properties
        // Roles
        public virtual List<Role> Roles { get; set; }
        // Orders
        public virtual List<Order> Orders { get; set; }
        // MovieReviews
        public virtual List<MovieReview> MovieReviews { get; set; }
        // CreditCards
        public virtual List<CreditCard> CreditCards { get; set; }

        public User()
        {
            if (Roles == null)
            {
                Roles = new List<Role>();
            }

            if (Orders == null)
            {
                Orders = new List<Order>();
            }

            if (MovieReviews == null)
            {
                MovieReviews = new List<MovieReview>();
            }

            if (CreditCards == null)
            {
                CreditCards = new List<CreditCard>();
            }
        }
    }
}