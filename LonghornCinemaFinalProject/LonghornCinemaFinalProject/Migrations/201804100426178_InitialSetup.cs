namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(maxLength: 15),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CreditCard_CreditCardID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_CreditCardID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.CreditCard_CreditCardID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Seat = c.String(),
                        MoviePrice_MoviePriceID = c.Int(),
                        Order_OrderID = c.Int(),
                        Showing_ShowingID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.MoviePrices", t => t.MoviePrice_MoviePriceID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Showings", t => t.Showing_ShowingID)
                .Index(t => t.MoviePrice_MoviePriceID)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Showing_ShowingID);
            
            CreateTable(
                "dbo.MoviePrices",
                c => new
                    {
                        MoviePriceID = c.Int(nullable: false, identity: true),
                        Movieprice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpecialEvent = c.String(),
                        TimeDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoviePriceID);
            
            CreateTable(
                "dbo.Showings",
                c => new
                    {
                        ShowingID = c.Int(nullable: false, identity: true),
                        ShowingTime = c.DateTime(nullable: false),
                        SpecialEvent = c.Int(nullable: false),
                        TheatreNum = c.Int(nullable: false),
                        SeatList = c.String(),
                        Movie_MovieID = c.Int(),
                        Schedule_ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.ShowingID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleID)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.Schedule_ScheduleID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Overview = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Revenue = c.Int(nullable: false),
                        Runtime = c.Int(nullable: false),
                        Tagline = c.String(),
                        MPAARating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        MovieReviewID = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        NumStars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApprovalStatus = c.Int(nullable: false),
                        Movie_MovieID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.MovieReviewID)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        UserStatus = c.String(),
                        PopcornPointsBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_GenreID = c.Int(nullable: false),
                        Movie_MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreID, t.Movie_MovieID })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .Index(t => t.Genre_GenreID)
                .Index(t => t.Movie_MovieID);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.User_UserID })
                .ForeignKey("dbo.Roles", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Showing_ShowingID", "dbo.Showings");
            DropForeignKey("dbo.Showings", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Showings", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.RoleUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.MovieReviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.CreditCards", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.MovieReviews", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.Tickets", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "MoviePrice_MoviePriceID", "dbo.MoviePrices");
            DropForeignKey("dbo.Orders", "CreditCard_CreditCardID", "dbo.CreditCards");
            DropIndex("dbo.RoleUsers", new[] { "User_UserID" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleID" });
            DropIndex("dbo.GenreMovies", new[] { "Movie_MovieID" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_GenreID" });
            DropIndex("dbo.MovieReviews", new[] { "User_UserID" });
            DropIndex("dbo.MovieReviews", new[] { "Movie_MovieID" });
            DropIndex("dbo.Showings", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.Showings", new[] { "Movie_MovieID" });
            DropIndex("dbo.Tickets", new[] { "Showing_ShowingID" });
            DropIndex("dbo.Tickets", new[] { "Order_OrderID" });
            DropIndex("dbo.Tickets", new[] { "MoviePrice_MoviePriceID" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.Orders", new[] { "CreditCard_CreditCardID" });
            DropIndex("dbo.CreditCards", new[] { "User_UserID" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.GenreMovies");
            DropTable("dbo.Schedules");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.MovieReviews");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Showings");
            DropTable("dbo.MoviePrices");
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
            DropTable("dbo.CreditCards");
        }
    }
}
