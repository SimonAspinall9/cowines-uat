namespace Website.CoWines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _104 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "PriceExclVat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PriceExclVat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "Price");
        }
    }
}
