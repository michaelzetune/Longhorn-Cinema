using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace LonghornCinemaFinalProject.Models
{
    public enum CardType { MasterCard, Visa, Discover, Amex}

    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        [StringLength(16, MinimumLength=15)]
        public String CardNumber { get; set; }

        // CardType
        public CardType CardType
        {
            get
            {
                if (CardNumber.Length == 15)
                    return CardType.Amex;
                else if (CardNumber.Substring(0, 2) == "54")
                    return CardType.MasterCard;
                else if (CardNumber.Substring(0, 1) == "4")
                    return CardType.Visa;
                else if (CardNumber.Substring(0, 1) == "6")
                    return CardType.Discover;
                else
                    throw new System.Exception("Card Number is not in a valid format");
            }
        }


        // Navigation Properties
        // Orders
        public virtual List<Order> Orders { get; set; }

        public CreditCard()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
        }
    }
}