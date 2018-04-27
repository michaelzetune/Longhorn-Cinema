namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "ExtendedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "ExtendedPrice", c => c.Int(nullable: false));
        }
    }
}
