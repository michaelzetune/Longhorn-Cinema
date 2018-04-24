namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShowing3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditCards", "CardNumber", c => c.String(maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditCards", "CardNumber", c => c.String(maxLength: 15));
        }
    }
}
