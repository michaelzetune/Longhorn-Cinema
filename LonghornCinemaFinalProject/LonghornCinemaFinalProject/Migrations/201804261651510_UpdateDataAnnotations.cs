namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TaxAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "CreditCardUsed", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "TransactionNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "ExtendedPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "ExtendedPrice");
            DropColumn("dbo.Tickets", "Quantity");
            DropColumn("dbo.Orders", "TransactionNumber");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "CreditCardUsed");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "TaxAmount");
            DropColumn("dbo.Orders", "Subtotal");
        }
    }
}
