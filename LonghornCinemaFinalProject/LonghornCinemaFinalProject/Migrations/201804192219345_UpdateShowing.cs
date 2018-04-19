namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShowing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Showings", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "ShowingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "ShowingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showings", "EndTime");
            DropColumn("dbo.Showings", "StartTime");
        }
    }
}
