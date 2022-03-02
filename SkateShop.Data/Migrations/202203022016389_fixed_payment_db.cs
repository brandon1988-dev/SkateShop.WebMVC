namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_payment_db : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Payment", name: "UserEmail", newName: "UserEmail1");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Payment", name: "UserEmail1", newName: "UserEmail");
        }
    }
}
