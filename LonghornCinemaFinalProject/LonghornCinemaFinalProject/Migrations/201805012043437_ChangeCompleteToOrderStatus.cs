namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCompleteToOrderStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Complete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Complete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Status");
        }
    }
}
