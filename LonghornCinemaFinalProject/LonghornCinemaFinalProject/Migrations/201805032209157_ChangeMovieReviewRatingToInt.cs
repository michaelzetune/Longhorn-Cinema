namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieReviewRatingToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieReviews", "NumStars", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieReviews", "NumStars", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
