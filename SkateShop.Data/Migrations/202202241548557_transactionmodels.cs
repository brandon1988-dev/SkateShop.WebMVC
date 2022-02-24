namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "ProductName", c => c.String());
            AddColumn("dbo.Transaction", "PaymentID", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "PaymentType", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Transaction", "CreatedUtc", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transaction", "DateOfTransaction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transaction", "CreatedUtc");
            DropColumn("dbo.Transaction", "LastName");
            DropColumn("dbo.Transaction", "PaymentType");
            DropColumn("dbo.Transaction", "PaymentID");
            DropColumn("dbo.Transaction", "ProductName");
        }
    }
}
