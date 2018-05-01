namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieReviews", "AppUser_Id", "dbo.AspNetUsers");
            AddColumn("dbo.AspNetUsers", "MovieReview_MovieReviewID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "MovieReview_MovieReviewID1", c => c.Int());
            AddColumn("dbo.MovieReviews", "AppUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "MovieReview_MovieReviewID");
            CreateIndex("dbo.AspNetUsers", "MovieReview_MovieReviewID1");
            CreateIndex("dbo.MovieReviews", "AppUser_Id1");
            AddForeignKey("dbo.AspNetUsers", "MovieReview_MovieReviewID", "dbo.MovieReviews", "MovieReviewID");
            AddForeignKey("dbo.AspNetUsers", "MovieReview_MovieReviewID1", "dbo.MovieReviews", "MovieReviewID");
            AddForeignKey("dbo.MovieReviews", "AppUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieReviews", "AppUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "MovieReview_MovieReviewID1", "dbo.MovieReviews");
            DropForeignKey("dbo.AspNetUsers", "MovieReview_MovieReviewID", "dbo.MovieReviews");
            DropIndex("dbo.MovieReviews", new[] { "AppUser_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "MovieReview_MovieReviewID1" });
            DropIndex("dbo.AspNetUsers", new[] { "MovieReview_MovieReviewID" });
            DropColumn("dbo.MovieReviews", "AppUser_Id1");
            DropColumn("dbo.AspNetUsers", "MovieReview_MovieReviewID1");
            DropColumn("dbo.AspNetUsers", "MovieReview_MovieReviewID");
            AddForeignKey("dbo.MovieReviews", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
