namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductName", c => c.String(nullable: false));
            DropColumn("dbo.Product", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Product", "ProductName");
        }
    }
}
