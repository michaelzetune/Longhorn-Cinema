using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LonghornCinemaFinalProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false) { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviePrice> MoviePrices { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Genre> Genres { get; set; }

        //NOTE: This is a dbSet that you need to make roles work
        public DbSet<AppRole> AppRoles { get; set; }

        public System.Data.Entity.DbSet<LonghornCinemaFinalProject.Models.Report> Reports { get; set; }
    }

}