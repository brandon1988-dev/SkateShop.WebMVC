namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixinit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "OwnerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Customer", "Payment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Payment");
            DropColumn("dbo.Customer", "OwnerID");
        }
    }
}
