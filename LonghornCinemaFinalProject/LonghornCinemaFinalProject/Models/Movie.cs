using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public enum MovieGenre { Horror, Drama, Comedy}

    public class Movie
    {

        // Properties
        // MovieID
        public Int32 MovieID { get; set; }

        // Title
        public String Title { get; set; }

        // Genres
        public MovieGenre Genre { get; set; }

        // Overview
        public String Overview { get; set; }

        // ReleaseDate
        public DateTime ReleaseDate { get; set; }

        // Revenue
        public Decimal Revenue { get; set; }

        // Runtime (in minutes)
        public Decimal Runtime { get; set; }

        // Tagline
        public String Tagline { get; set; }

        // Actors
        public String Actors { get; set; }
 
        
        // Navigation Properties
        // MoviePrice
        // MovieReviews
        // Showings
    }
}