namespace Website.CoWines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImgUrl", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImgUrl");
        }
    }
}
