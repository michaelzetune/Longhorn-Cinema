namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LonghornCinemaFinalProject.DAL.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LonghornCinemaFinalProject.DAL.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            MovieData AddMovies = new MovieData();
            AddMovies.SeedMovies(context);

            ShowingData AddShowings = new ShowingData();
            AddShowings.SeedShowings(context);

            UserData AddUsers = new UserData();
            AddUsers.SeedUsers(context);

        }
    }
}
