using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LonghornCinemaFinalProject.Models;
using System.Data.Entity;

//FYI: we need to enable Entity Framework for these errors to disappear

namespace LonghornCinemaFinalProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyDBConnection") { }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviePrice> MoviePrices { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}