using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LonghornCinemaFinalProject.Models
{
    public class Order
    {
        private const Decimal TAX_RATE = 0.0825m;

        // Properties
        // OrderID

        public Int32 OrderID { get; set; }

        public Int32 ConfirmationCode { get; set; }

        public Boolean Complete { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Subtotal
        {
            get
            {
                return Tickets.Sum(t => t.TicketPrice);
            }
        }

        [Display(Name = "Tax")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TaxAmount
        {
            get
            {
                return TAX_RATE * Subtotal;
            }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Total
        {
            get
            {
                return Subtotal + TaxAmount;
            }
        }

        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }

        // Tickets
        public virtual List<Ticket> Tickets { get; set; }
        // Credit Card
        public virtual CreditCard CreditCard { get; set; }

        //AppUser
        public virtual AppUser AppUser { get; set; }

        public Order()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }
    }
}