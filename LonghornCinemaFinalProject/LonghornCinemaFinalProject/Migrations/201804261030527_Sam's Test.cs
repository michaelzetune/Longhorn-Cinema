namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SamsTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.MovieReviews", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleID", "dbo.Roles");
            DropForeignKey("dbo.RoleUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Showings", "Schedule_ScheduleID", "dbo.Schedules");
            DropIndex("dbo.CreditCards", new[] { "User_UserID" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.Showings", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.MovieReviews", new[] { "User_UserID" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleID" });
            DropIndex("dbo.RoleUsers", new[] { "User_UserID" });
            AddColumn("dbo.Orders", "ConfirmationID", c => c.Int(nullable: false));
            DropColumn("dbo.CreditCards", "User_UserID");
            DropColumn("dbo.Orders", "TransactionID");
            DropColumn("dbo.Orders", "User_UserID");
            DropColumn("dbo.Showings", "Schedule_ScheduleID");
            DropColumn("dbo.MovieReviews", "User_UserID");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Schedules");
            DropTable("dbo.RoleUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.User_UserID });
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
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
            
            AddColumn("dbo.MovieReviews", "User_UserID", c => c.Int());
            AddColumn("dbo.Showings", "Schedule_ScheduleID", c => c.Int());
            AddColumn("dbo.Orders", "User_UserID", c => c.Int());
            AddColumn("dbo.Orders", "TransactionID", c => c.Int(nullable: false));
            AddColumn("dbo.CreditCards", "User_UserID", c => c.Int());
            DropColumn("dbo.Orders", "ConfirmationID");
            CreateIndex("dbo.RoleUsers", "User_UserID");
            CreateIndex("dbo.RoleUsers", "Role_RoleID");
            CreateIndex("dbo.MovieReviews", "User_UserID");
            CreateIndex("dbo.Showings", "Schedule_ScheduleID");
            CreateIndex("dbo.Orders", "User_UserID");
            CreateIndex("dbo.CreditCards", "User_UserID");
            AddForeignKey("dbo.Showings", "Schedule_ScheduleID", "dbo.Schedules", "ScheduleID");
            AddForeignKey("dbo.RoleUsers", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.RoleUsers", "Role_RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.MovieReviews", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.CreditCards", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
