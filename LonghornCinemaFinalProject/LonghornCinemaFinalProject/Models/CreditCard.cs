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
        // Properties
        // CreditCardID
        public Int32 CreditCardID { get; set; }

        // CardNumber
        [StringLength(15)] // this needs to be 15-16 somehow
        public String CardNumber { get; set; }

        // CardType
        //public CardType CardType
        //{
        //    get { return CardType; }
        //    set {
        //            switch (CardNumber)
        //            {
        //                case CardNumber.Length == 15:
        //                    CardType = CardType.Amex; break;

        //                case CardNumber.Substring(0,2).Equals("54"): // this is a Mastercard
        //                    CardType = CardType.MasterCard; break;

        //                case CardNumber.Substring(0, 1).Equals("4"): // number is a Visa card
        //                    CardType = CardType.Visa; break;

        //                case CardNumber.Substring(0, 1).Equals("6"): // number is a Discover card
        //                    CardType = CardType.Discover; break;

        //                default: // if the card type doesn't fulfill one of the conditions above, the user messed up
        //                    Console.WriteLine("Card type not valid");
        //                    CardType = null; break;
        //            }


        //        }
        //}


        // Navigation Properties
        // User
        public virtual User User { get; set; }
        // Orders
        public virtual List<Order> Orders { get; set; }
    }
}