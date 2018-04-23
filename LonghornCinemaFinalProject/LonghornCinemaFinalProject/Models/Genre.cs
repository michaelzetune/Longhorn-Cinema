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
            if (Movies == null)
            {
                Movies = new List<Movie>();
            }

        }

        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Genre g = (Genre) obj;
            return (Name == g.Name);
        }

        public Genre()
        {
            if (Movies == null)
            {
                Movies = new List<Movie>();
            }
        }
    }
}