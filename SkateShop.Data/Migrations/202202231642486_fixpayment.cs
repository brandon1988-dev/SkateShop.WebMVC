namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixpayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorite", "ProductID", "dbo.Product");
            DropIndex("dbo.Favorite", new[] { "ProductID" });
            AddColumn("dbo.Payment", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payment", "OwnerID");
            CreateIndex("dbo.Favorite", "ProductID");
            AddForeignKey("dbo.Favorite", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
