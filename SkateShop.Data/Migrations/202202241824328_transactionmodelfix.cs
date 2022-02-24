namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionmodelfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Transaction", "PaymentID");
            AddForeignKey("dbo.Transaction", "PaymentID", "dbo.Payment", "PaymentID", cascadeDelete: true);
            DropColumn("dbo.Transaction", "ProductName");
            DropColumn("dbo.Transaction", "PaymentType");
            DropColumn("dbo.Transaction", "LastName");
            DropColumn("dbo.Transaction", "CreatedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "CreatedUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaction", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Transaction", "PaymentType", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "ProductName", c => c.String());
            DropForeignKey("dbo.Transaction", "PaymentID", "dbo.Payment");
            DropIndex("dbo.Transaction", new[] { "PaymentID" });
            DropColumn("dbo.Transaction", "DateOfTransaction");
        }
    }
}
