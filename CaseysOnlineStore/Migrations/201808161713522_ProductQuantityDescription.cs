namespace CaseysOnlineStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductQuantityDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quanity", c => c.Short(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Quanity");
        }
    }
}
