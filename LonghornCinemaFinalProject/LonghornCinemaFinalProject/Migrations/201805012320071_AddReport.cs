namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        DisplaySeats = c.Boolean(nullable: false),
                        DisplayRevenue = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RatingFilter = c.Int(nullable: false),
                        CustomerFilter_Id = c.String(maxLength: 128),
                        MovieFilter_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerFilter_Id)
                .ForeignKey("dbo.Movies", t => t.MovieFilter_MovieID)
                .Index(t => t.CustomerFilter_Id)
                .Index(t => t.MovieFilter_MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "MovieFilter_MovieID", "dbo.Movies");
            DropForeignKey("dbo.Reports", "CustomerFilter_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reports", new[] { "MovieFilter_MovieID" });
            DropIndex("dbo.Reports", new[] { "CustomerFilter_Id" });
            DropTable("dbo.Reports");
        }
    }
}
