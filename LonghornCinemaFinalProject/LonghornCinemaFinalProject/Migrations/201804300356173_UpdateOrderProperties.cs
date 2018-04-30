namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Subtotal");
            DropColumn("dbo.Orders", "TaxAmount");
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TaxAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
