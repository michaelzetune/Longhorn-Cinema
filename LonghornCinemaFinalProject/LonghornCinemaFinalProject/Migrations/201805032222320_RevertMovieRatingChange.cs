namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertMovieRatingChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieReviews", "NumStars", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieReviews", "NumStars", c => c.Int(nullable: false));
        }
    }
}
