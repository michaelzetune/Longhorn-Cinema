namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShowing2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "SpecialEventStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Showings", "SpecialEvent");
            DropColumn("dbo.Showings", "SeatList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "SeatList", c => c.String());
            AddColumn("dbo.Showings", "SpecialEvent", c => c.Int(nullable: false));
            DropColumn("dbo.Showings", "SpecialEventStatus");
        }
    }
}
