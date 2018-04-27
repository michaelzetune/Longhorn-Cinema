namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfirmationCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ConfirmationCode", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ConfirmationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ConfirmationID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ConfirmationCode");
        }
    }
}
