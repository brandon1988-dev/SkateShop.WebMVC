namespace SkateShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favorite", "FavoriteName", c => c.String());
            AddColumn("dbo.Favorite", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Favorite", "ProductName");
            DropColumn("dbo.Favorite", "FavoriteName");
        }
    }
}
