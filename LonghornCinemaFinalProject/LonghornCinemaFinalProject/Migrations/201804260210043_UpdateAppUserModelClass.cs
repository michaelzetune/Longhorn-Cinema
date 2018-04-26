namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppUserModelClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCards", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MovieReviews", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "StreetAddress", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PopcornPointsBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.CreditCards", "AppUser_Id");
            CreateIndex("dbo.Orders", "AppUser_Id");
            CreateIndex("dbo.MovieReviews", "AppUser_Id");
            AddForeignKey("dbo.CreditCards", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MovieReviews", "AppUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Orders", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MovieReviews", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CreditCards", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MovieReviews", new[] { "AppUser_Id" });
            DropIndex("dbo.Orders", new[] { "AppUser_Id" });
            DropIndex("dbo.CreditCards", new[] { "AppUser_Id" });
            DropColumn("dbo.AspNetUsers", "PopcornPointsBalance");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "StreetAddress");
            DropColumn("dbo.AspNetUsers", "Birthday");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.MovieReviews", "AppUser_Id");
            DropColumn("dbo.Orders", "AppUser_Id");
            DropColumn("dbo.CreditCards", "AppUser_Id");
        }
    }
}
