namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteActivePropertyFromOrderModelClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Active", c => c.Boolean(nullable: false));
        }
    }
}
