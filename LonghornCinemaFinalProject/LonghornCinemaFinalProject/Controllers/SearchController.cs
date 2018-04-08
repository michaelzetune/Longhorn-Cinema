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
            return View();
        }
        
        public ActionResult DisplaySearchResults(String SearchMovie, String SearchTagline, Genre SelectedGenre, DateTime? SelectedReleaseYear, MPAARating SelectedRating, Classification SelectedClass, String DesiredCustomerRating, String SearchActors)
        {
            var query = from m in db.Movies
                        select m;

            //SearchMovie for Movie Name
            if (SearchMovie != null)
            {
                query = query.Where(m => m.Title.Contains(SearchMovie));
            }

            //SearchTagline for Movie Tagline
            if (SearchTagline != null)
            {
                query = query.Where(m => m.Tagline.Contains(SearchTagline));
            }

            //code for Genre selection
            if (SelectedGenre != 0)
            {
                query = query.Where(m => m.Movie.MovieID == SelectedGenre);
            }

            //code for Released After datetime field in the view
            if (SelectedReleaseYear != null)
            {
                DateTime datSelected = SelectedReleaseYear ?? new DateTime(1900, 1, 1);

                query = query.Where(m => m.ReleaseYear >= datSelected);
            }           
              
            //code for MPAA Rating selection
            if (SelectedRating != 0)
            {
                query = query.Where(m => m.Movie.MPAARating == SelectedRating);
            }
          
            //code for customer rating text box
            if (DesiredCustomerRating != null && DesiredCustomerRating != "")
            {
                Decimal decCustomerRating;
                try
                {
                    decCustomerRating = Convert.ToDecimal(DesiredCustomerRating);
                }
                catch
                {
                    ViewBag.Message = DesiredCustomerRating + " is not a valid number. Please try again";

                    ViewBag.AllGenres = GetAllGenres();

                    return View("DetailedSearch")
                }

                //code for radio buttons
                if (SelectedClass == Classification.GreaterThan)
                {
                    query = query.Where(m => m.NumStars >= decCustomerRating);
                }
                if (SelectedClass == Classification.LessThan)
                {
                    query = query.Where(m => m.NumStars <= decCustomerRating);
                }
            }

            //SearchActors for Movie Actors
            if (SearchActors != null)
            {
                query = query.Where(m => m.Actors.Contains(SearchActors));
            }

            List<Movie> MoviesToDisplay = query.ToList();

            MoviesToDisplay.OrderBy(m => m.Title);

            ViewBag.SelectedMovies = MoviesToDisplay.Count();
            ViewBag.TotalMovies = MoviesToDisplay.Count();

            return View("Index", MoviesToDisplay);
        }

        public SelectList GetAllGenres()
        {
            List<Genre> Genres = db.Genres.ToList();

            Genres SelectNone = new Models.Genre() { GenreID = 0, Name = "All Genres" };
            Genres.Add(SelectNone);

            SelectList AllGenres = new SelectList(Genres.OrderBy(g => g.GenreID), "GenreID", "Name");
            return AllGenres;
        }
    }
}