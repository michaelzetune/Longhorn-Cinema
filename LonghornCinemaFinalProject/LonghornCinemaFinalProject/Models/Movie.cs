using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.DAL;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Movie Title")]
        public String Title { get; set; }

        // Overview
        public String Overview { get; set; }

        // ReleaseDate
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        // Revenue
        public Int64 Revenue { get; set; }

        // Runtime (in minutes)
        public Int32 Runtime { get; set; }

        // Tagline
        public String Tagline { get; set; }

        // Actors
        public String Actors { get; set; }

        // MPAA rating
        [Display(Name = "MPAA Rating")]
        public MPAARating MPAARating { get; set; }

        // Customer Rating Average
        [DisplayFormat(DataFormatString = "{0:0.#}")]
        public Decimal RatingAverage
        {
            get
            {
                Movie m = db.Movies.Find(MovieID);
                if (m.MovieReviews.Count() == 0)
                    return 0;
                else
                    return db.Movies.Find(MovieID).MovieReviews.Average(mr => mr.NumStars);
            }
        }

        public String GenresString
        {
            get
            {
                String ret = "";
                foreach(Genre g in Genres)
                {
                    ret += g.Name + ", ";
                }
                if (ret.Length < 2) return ret; // no Genres (this shouldn't happen, but if it does this will prevent an error
                return ret.Substring(0,ret.Length-2); // removes ending comma and space
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

            if (MovieReviews == null)
            {
                MovieReviews = new List<MovieReview>();
            }
            
            if (Showings == null)
            {
                Showings = new List<Showing>();   
            }
        }
    }
}