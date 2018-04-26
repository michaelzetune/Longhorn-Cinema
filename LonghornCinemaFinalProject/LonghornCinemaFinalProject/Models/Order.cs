using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public class Order
    {
        // Properties
        // OrderID
        public Int32 OrderID { get; set; }

        //TODO: implement get for transaction ID/add utility class
        public Int32 ConfirmationID { get; set; }

        public Boolean Complete { get; set; }

        // Navigation Properties
        // Tickets
        public virtual List<Ticket> Tickets { get; set; }
        // Credit Card
        public virtual CreditCard CreditCard { get; set; }

        public Order()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }
    }
}