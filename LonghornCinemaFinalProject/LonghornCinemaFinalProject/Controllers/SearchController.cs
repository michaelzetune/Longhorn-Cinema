using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LonghornCinemaFinalProject.DAL;
using LonghornCinemaFinalProject.Models;

namespace LonghornCinemaFinalProject.Controllers
{
    public enum Classification {  GreaterThan, LessThan }
    public enum StarFilter { Greater, Less }

    public class SearchController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Content("Bad Request");
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return Content("The resource you are looking for has been removed, had its name changed, or is temporarily unavailable.");
            }
            return View(movie);
        }

        public ActionResult DetailedSearch()
        {
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllMPAARatings = GetAllMPAARatings();
            ViewBag.AllActors = GetAllActors();
            return View();
        }
        
        public ActionResult DisplaySearchResults(String SearchTitle, String SearchTagline, Genre SearchGenre, String SearchYear, MPAARating SearchMPAARating, String SearchStars, StarFilter SearchStarFilter, String SearchActor)
        { // Update Actors and other fields to be multiselectable
            var query = from m in db.Movies
                        select m;

            //SearchTitle for Movie Name
            if (SearchTitle != null)
            {
                query = query.Where(m => m.Title.Contains(SearchTitle));
            }

            //SearchTagline for Movie Tagline
            if (SearchTagline != null)
            {
                query = query.Where(m => m.Tagline.Contains(SearchTagline));
            }

            // SearchGenre for Movie Genre
            if (SearchGenre != null)
            {
                query = query.Where(m => m.Genres.Contains(SearchGenre));
            }

            // SearchYear for Movie year release
            if (SearchYear != null)
            {
                DateTime YearInDateTime = DateTime.Parse(SearchYear);
                
                query = query.Where(m => m.ReleaseDate.Year == YearInDateTime.Year);
            }           
              
            //code for MPAA Rating selection
            if (SearchMPAARating != MPAARating.None)
            {
                query = query.Where(m => m.MPAARating == SearchMPAARating);
            }
          
            //code for customer rating text box
            if (SearchStars != null)
            {
                Decimal decCustomerRating;
                try
                {
                    decCustomerRating = Convert.ToDecimal(SearchStars);
                }
                catch
                {
                    ViewBag.Message = SearchStars + " is not a valid number. Please try again";

                    ViewBag.AllGenres = GetAllGenres();

                    return View("DetailedSearch");
                }

                //code for radio buttons
                if (SearchStarFilter == StarFilter.Greater)
                {
                    query = query.Where(m => m.RatingAverage >= decCustomerRating);
                }
                else if(SearchStarFilter == StarFilter.Less)
                {
                    query = query.Where(m => m.RatingAverage <= decCustomerRating);
                }
            }

            //SearchActors for Movie Actors
            if (SearchActor != "")
            {
                query = query.Where(m => m.Actors.Contains(SearchActor));
            }

            List<Movie> MoviesToDisplay = query.ToList();

            MoviesToDisplay.OrderBy(m => m.Title);

            ViewBag.SelectedMoviesCount = MoviesToDisplay.Count();
            ViewBag.TotalMoviesCount = db.Movies.ToList().Count();

            return View("Index", MoviesToDisplay);
        }

        public SelectList GetAllGenres()
        {
            List<Genre> Genres = db.Genres.ToList();

            Genre SelectNone = new Genre("None") { GenreID = 0, Name = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(g => g.GenreID), "GenreID", "Name");
            return AllGenres;
        }

        public SelectList GetAllMPAARatings()
        {
            List<MPAARating> MPAARatings = new List<MPAARating>();

            foreach (Movie m in db.Movies.ToList())
            {
                if (!MPAARatings.Contains(m.MPAARating))
                    MPAARatings.Add(m.MPAARating);
            }

            MPAARating SelectNone = MPAARating.None; // TODO: need to check that this is a valid way to make selectnone
            MPAARatings.Add(SelectNone);

            SelectList AllRatings = new SelectList(MPAARatings);
            return AllRatings;
        }

        public SelectList GetAllActors()
        {
            List<String> Actors = new List<String>();

            foreach (Movie m in db.Movies.ToList())
            {
                foreach (String a in m.Actors)
                {
                    if (!Actors.Contains(a))
                    {
                        Actors.Add(a);
                    }
                }
            }

            SelectList AllActors = new SelectList(Actors);
            return AllActors;
        }
    }
}