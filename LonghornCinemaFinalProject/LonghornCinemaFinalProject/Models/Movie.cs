using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public enum MPPArating { G, PG, R, Unrated};
    

    public class Movie
    {

        // Properties
        // MovieID
        public Int32 MovieID { get; set; }

        // Title
        public String Title { get; set; }

        // Genres
        public String Genre { get; set; }

        // Overview
        public String Overview { get; set; }

        // ReleaseDate
        public DateTime ReleaseDate { get; set; }

        // Revenue
        public Int32 Revenue { get; set; }

        // Runtime (in minutes)
        public Int32 Runtime { get; set; }

        // Tagline
        public String Tagline { get; set; }

        // Actors
        public String Actors { get; set; }

        //MPAA rating
        public MPPArating MPPArating { get; set; }

        
        // Navigation Properties
        // MovieReviews
        public virtual List <MovieReview> MovieReviews { get; set; }

        // Showings
        public virtual List <Showing> Showings { get; set; }
    }
}