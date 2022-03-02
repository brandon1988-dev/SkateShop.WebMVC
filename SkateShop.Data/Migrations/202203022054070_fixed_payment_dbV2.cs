namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_payment_dbV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payment", "UserEmail", c => c.String(nullable: false));
            DropColumn("dbo.Payment", "UserEmail1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payment", "UserEmail1", c => c.String());
            AlterColumn("dbo.Payment", "UserEmail", c => c.String());
        }
    }
}
