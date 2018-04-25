namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TransactionID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Complete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Complete");
            DropColumn("dbo.Orders", "TransactionID");
        }
    }
}
