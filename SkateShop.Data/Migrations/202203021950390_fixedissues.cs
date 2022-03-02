namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedissues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payment", "CreatedUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
