using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace LonghornCinemaFinalProject.Models
{
    public enum CardType { MasterCard, Visa, Discover, Amex, Invalid }

    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        [Display(Name ="Credit Card Number")]
        [MinLength(15, ErrorMessage ="Credit Card must be 15-16 digits")]
        [MaxLength(16, ErrorMessage ="Credit Card must be 15-16 digits")]
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
                    return CardType.Invalid;
            }
        }


        // Navigation Properties
        // Orders
        public virtual List<Order> Orders { get; set; }
        public virtual AppUser User { get; set; }

        public CreditCard()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
        }

        public CreditCard(String CardNum)
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }

            CardNumber = CardNum;
        }
    }
}