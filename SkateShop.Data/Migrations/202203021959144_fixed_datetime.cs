namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payment", "CreatedUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payment", "CreatedUtc", c => c.DateTime(nullable: false));
        }
    }
}
