using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    
    public enum Time { Morning, Afternoon, Evening}
    public class MoviePrice
    {
        public Int32 MoviePriceID { get; set; }
        // Properties
        // MoviePriceID
        // Talked to Katie and she explained how this class is just like a copy type of deal
        public Decimal Movieprice { get; set; }
        public String SpecialEvent {get;set;}
        public Time TimeDay { get; set; }
    }
}