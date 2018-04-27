namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieReviews", "Votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieReviews", "Votes");
        }
    }
}
