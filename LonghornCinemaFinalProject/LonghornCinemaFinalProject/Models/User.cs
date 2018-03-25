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
        // Orders
        // MovieReviews
        // CreditCards
    }
}