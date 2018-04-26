namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Samtest2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Seat", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Seat", c => c.String());
        }
    }
}
