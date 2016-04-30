namespace Website.CoWines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _103 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailAddresses");
        }
    }
}
