using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LonghornCinemaFinalProject.Models
{
    public enum SpecialEvent { NotSpecial, Special };

    public enum Theatre {TheatreOne, TheatreTwo};
    public class Showing
    {
        // Properties
        // ShowingID
        public Int32 ShowingID { get; set; }

        // Start Time
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy h\\:mm tt}")]
        public DateTime StartTime { get; set; }

        //end time get should be based on length of movie and need of time between movies --> put this logic in controller
        [Required]
        [Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy h\\:mm tt}")]
        public DateTime EndTime { get; set; }

        // SpecialEvent
        [Required]
        [Display(Name = "Special Event?")]
        public SpecialEvent SpecialEventStatus { get; set; }

        // ThetreNum (enum)
        [Required]
        [Display(Name = "Theatre")]
        public Theatre TheatreNum { get; set; }

        // SeatList
        // Changed this to String list because seats are labeled "A1", "A2" etc, not by number
        public List<String> SeatList { get; set; }

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
            if (SeatList == null)
            {
                SeatList = new List<String>( new String[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8"});
            }
        }
    }
}