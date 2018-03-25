using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public enum CardType { MasterCard, Visa, Discover}

    public class CreditCard
    {
        // Properties
        // CreditCardID
        public Int32 CreditCardID { get; set; }

        // CardNumber
        public Int32 CardNumber { get; set; }

        // CardType
        public CardType CardType { get; set; }


        // Navigation Properties
        // User
        // Orders
    }
}