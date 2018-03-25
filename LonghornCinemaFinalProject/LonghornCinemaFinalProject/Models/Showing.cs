using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public enum SpecialEvent { NotSpecial, Special }
    public enum Theatre { TheatreOne, TheatreTwo }
    public class Showing
    {
        // Properties
        // ShowingID
        public Int32 ShowingID { get; set; }

        // Time
        public DateTime ShowingTime { get; set; }

        // SpecialEvent
        public SpecialEvent SpecialEvent { get; set; }

        // ThetreNum (enum)
        public Theatre TheatreNum { get; set; }

        // SeatList
        //not sure if this is correct -Ben
        public String SeatList { get; set; }

        // Navigation Properties
        // Movie
        // Tickets
        // Schedule

    }
}