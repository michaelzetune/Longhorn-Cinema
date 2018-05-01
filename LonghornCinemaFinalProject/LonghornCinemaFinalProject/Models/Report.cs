using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public class Report
    {
        public Int32 ReportID { get; set; }
        public Boolean DisplaySeats { get; set; }
        public Boolean DisplayRevenue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Movie MovieFilter { get; set; } // not a navigational property!!
        public MPAARating RatingFilter { get; set; }
        public AppUser CustomerFilter { get; set; } // also not a navigational property

    }
}