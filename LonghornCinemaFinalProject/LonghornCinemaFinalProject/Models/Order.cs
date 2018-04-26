using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "TicketPrice is required.")]
        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Tax Amount is required.")]
        public decimal TaxAmount { get; set; }

        [Required(ErrorMessage = "Total is required.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "CreditCardUsed is required.")]
        public String CreditCardUsed {get; set;}

        [Required(ErrorMessage = "OrderDate is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "TransactionNumber is required.")]
        public Int32 TransactionNumber { get; set; }
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