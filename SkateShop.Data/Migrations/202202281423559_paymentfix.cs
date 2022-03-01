namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentfix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transaction", "OwnerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "OwnerID", c => c.Guid(nullable: false));
        }
    }
}
