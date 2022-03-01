namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "OwnerID");
        }
    }
}
