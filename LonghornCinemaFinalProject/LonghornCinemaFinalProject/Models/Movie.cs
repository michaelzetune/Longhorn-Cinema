using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;

namespace LonghornCinemaFinalProject.Models
{
    public enum MPAARating { G, PG, R, Unrated, None};


    public class Movie
    {
        private AppDbContext db = new AppDbContext();

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
                // replaced iterating through List of MovieReviews to find average rating
                // with this instead:
                return db.Movies.Find(MovieID).MovieReviews.Average(mr => mr.NumStars);
            }
        }


        // Navigation Properties
        // MovieReviews
        public virtual List<MovieReview> MovieReviews { get; set; }

        // Showings
        public virtual List<Showing> Showings { get; set; }

        // Genres
        public virtual List<Genre> Genres { get; set; }

        public Movie()
        {
            if (Genres == null)
            {
                Genres = new List<Genre>();
            }

            if (Actors == null)
            {
                Actors = new List<String>();
            }

            if (MovieReviews == null)
            {
                MovieReviews = new List<MovieReview>();
            }
        }
    }
}