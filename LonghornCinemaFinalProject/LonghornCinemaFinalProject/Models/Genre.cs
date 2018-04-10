using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public class Genre
    {
        public Int32 GenreID { get; set; }
        public String Name { get; set; }


        public virtual List<Movie> Movies { get; set; }

        public Genre(String TheName)
        {
            Name = TheName;
        }

        public Genre()
        { }
    }
}