namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppUserNavProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieReviews", "ReviewText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieReviews", "ReviewText", c => c.String(maxLength: 100));
        }
    }
}
