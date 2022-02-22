namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productmodels : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payment");
            AddColumn("dbo.Product", "OwnerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Payment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Payment", "PaymentID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Payment", "BillingAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Payment", "CardNumber", c => c.Int());
            AddPrimaryKey("dbo.Payment", "PaymentID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Payment");
            AlterColumn("dbo.Payment", "CardNumber", c => c.String());
            AlterColumn("dbo.Payment", "BillingAddress", c => c.String());
            AlterColumn("dbo.Payment", "PaymentID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Payment", "CreatedUtc");
            DropColumn("dbo.Product", "OwnerID");
            AddPrimaryKey("dbo.Payment", "PaymentID");
        }
    }
}
