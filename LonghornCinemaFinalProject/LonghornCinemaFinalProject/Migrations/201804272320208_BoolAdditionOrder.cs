namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolAdditionOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Active");
        }
    }
}
