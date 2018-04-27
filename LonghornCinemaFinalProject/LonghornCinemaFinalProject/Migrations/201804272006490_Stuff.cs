namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "CreditCardUsed");
            DropColumn("dbo.Orders", "TransactionNumber");
            DropColumn("dbo.Tickets", "Quantity");
            DropColumn("dbo.Tickets", "ExtendedPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ExtendedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TransactionNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CreditCardUsed", c => c.String(nullable: false));
        }
    }
}
