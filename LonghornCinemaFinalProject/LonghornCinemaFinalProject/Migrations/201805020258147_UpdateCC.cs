namespace LonghornCinemaFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCC : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CreditCards", name: "User_Id", newName: "AppUser_Id");
            RenameIndex(table: "dbo.CreditCards", name: "IX_User_Id", newName: "IX_AppUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CreditCards", name: "IX_AppUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.CreditCards", name: "AppUser_Id", newName: "User_Id");
        }
    }
}
