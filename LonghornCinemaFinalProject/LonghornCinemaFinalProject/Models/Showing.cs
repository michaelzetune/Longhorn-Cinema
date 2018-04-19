using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LonghornCinemaFinalProject.Models
{
    public enum SpecialEvent { NotSpecial, Special };
    public enum Theatre { TheatreOne, TheatreTwo };
    public class Showing
    {
        // Properties
        // ShowingID
        public Int32 ShowingID { get; set; }

        // Start Time
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public DateTime StartTime { get; set; }

        //end time get should be based on length of movie and need of time between movies
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public DateTime EndTime { get; set; }

        // SpecialEvent
        public SpecialEvent SpecialEvent { get; set; }

        // ThetreNum (enum)
        public Theatre TheatreNum { get; set; }

        // SeatList
        //not sure if this is correct -Ben
        public String SeatList { get; set; }

        // Navigation Properties
        // Movie
        public virtual Movie Movie { get; set; }
        // Tickets
        public virtual List<Ticket> Tickets { get; set; }
        // Schedule
        public virtual Schedule Schedule { get; set;}

        public Showing()
        {
            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }
    }
}