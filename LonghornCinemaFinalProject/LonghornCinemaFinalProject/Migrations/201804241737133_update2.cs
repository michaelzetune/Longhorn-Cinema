namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MoviePrices", "decMatineePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MoviePrices", "decTuesdayPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MoviePrices", "decWeekendPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MoviePrices", "decWeekPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.MoviePrices", "Price");
            DropColumn("dbo.MoviePrices", "SpecialEvent");
            DropColumn("dbo.MoviePrices", "TimeDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MoviePrices", "TimeDay", c => c.Int(nullable: false));
            AddColumn("dbo.MoviePrices", "SpecialEvent", c => c.String());
            AddColumn("dbo.MoviePrices", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.MoviePrices", "decWeekPrice");
            DropColumn("dbo.MoviePrices", "decWeekendPrice");
            DropColumn("dbo.MoviePrices", "decTuesdayPrice");
            DropColumn("dbo.MoviePrices", "decMatineePrice");
        }
    }
}
