using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public enum MPAARating { G, PG, R, Unrated, None};
    

    public class Movie
    {

        // Properties
        // MovieID
        public Int32 MovieID { get; set; }

        // Title
        public String Title { get; set; }

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
        public List<String> Actors { get; set; }

        // MPAA rating
        public MPAARating MPAARating { get; set; }

        // Customer Rating Average
        public Decimal RatingAverage
        {
            get
            {
                Decimal sum = 0m;
                int count = 0;
                foreach(MovieReview mr in MovieReviews)
                {
                    sum += mr.NumStars;
                    count++;
                }
                sum = sum / count;
                return sum;
            }
        }

        
        // Navigation Properties
        // MovieReviews
        public virtual List <MovieReview> MovieReviews { get; set; }

        // Showings
        public virtual List <Showing> Showings { get; set; }

        // Genres
        public virtual List<Genre> Genres { get; set; }
    }
}