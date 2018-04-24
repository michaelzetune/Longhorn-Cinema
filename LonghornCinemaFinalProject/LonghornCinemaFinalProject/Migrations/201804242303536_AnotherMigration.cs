namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "MoviePrice_MoviePriceID", "dbo.MoviePrices");
            DropIndex("dbo.Tickets", new[] { "MoviePrice_MoviePriceID" });
            AddColumn("dbo.Tickets", "TicketPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Tickets", "MoviePrice_MoviePriceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "MoviePrice_MoviePriceID", c => c.Int());
            DropColumn("dbo.Tickets", "TicketPrice");
            CreateIndex("dbo.Tickets", "MoviePrice_MoviePriceID");
            AddForeignKey("dbo.Tickets", "MoviePrice_MoviePriceID", "dbo.MoviePrices", "MoviePriceID");
        }
    }
}
