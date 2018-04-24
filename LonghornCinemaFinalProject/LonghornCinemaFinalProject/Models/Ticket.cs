using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public class Ticket
    {
        // Properties
        // TicketID
        public Int32 TicketID { get; set; }
        // Seat
        public String Seat { get; set; }

        // Commenting this out because I think TicketPrice and MoviePrice would be the same value (-Michael) :
        // Price
        public Decimal TicketPrice { get; set; }        

        // Navigation Properties
        // Order
        public virtual Order Order { get; set; }
        // Showing
        public virtual Showing Showing { get; set; }
    

    }
}