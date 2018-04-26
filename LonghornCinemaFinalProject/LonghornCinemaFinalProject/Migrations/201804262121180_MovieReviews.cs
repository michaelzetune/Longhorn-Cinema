namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieReviews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieReviews", "ReviewText", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieReviews", "ReviewText", c => c.String());
        }
    }
}
