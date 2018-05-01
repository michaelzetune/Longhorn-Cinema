namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "SeniorCitizenDiscount", c => c.String());
            AddColumn("dbo.Tickets", "EarlyDiscount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "EarlyDiscount");
            DropColumn("dbo.Tickets", "SeniorCitizenDiscount");
        }
    }
}
