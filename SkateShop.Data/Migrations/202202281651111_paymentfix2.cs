namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentfix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payment", "Customer_CustomerID", c => c.Int());
            CreateIndex("dbo.Payment", "Customer_CustomerID");
            AddForeignKey("dbo.Payment", "Customer_CustomerID", "dbo.Customer", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "Customer_CustomerID", "dbo.Customer");
            DropIndex("dbo.Payment", new[] { "Customer_CustomerID" });
            DropColumn("dbo.Payment", "Customer_CustomerID");
        }
    }
}
