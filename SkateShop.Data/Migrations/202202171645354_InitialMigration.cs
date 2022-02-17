namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Transaction");
            AddColumn("dbo.Product", "ProductName", c => c.String(nullable: false));
            AddColumn("dbo.Product", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "TransactionID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Transaction", "TransactionID");
            DropColumn("dbo.Product", "Name");
            DropColumn("dbo.Product", "Price");
            DropColumn("dbo.Transaction", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "Name", c => c.String(nullable: false));
            DropPrimaryKey("dbo.Transaction");
            DropColumn("dbo.Transaction", "TransactionID");
            DropColumn("dbo.Product", "ProductPrice");
            DropColumn("dbo.Product", "ProductName");
            AddPrimaryKey("dbo.Transaction", "ID");
        }
    }
}
