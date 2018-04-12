namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllMovieData1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MoviePrices", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Movies", "Revenue", c => c.Long(nullable: false));
            DropColumn("dbo.MoviePrices", "Movieprice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MoviePrices", "Movieprice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Movies", "Revenue", c => c.Int(nullable: false));
            DropColumn("dbo.MoviePrices", "Price");
        }
    }
}
