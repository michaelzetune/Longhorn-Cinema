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


        // Navigation Properties
        // User
        public virtual User User { get; set; }
        // Tickets
        public virtual List<Ticket> Tickets { get; set; }
        // Credit Card
        public virtual CreditCard CreditCard { get; set; }

    }
}