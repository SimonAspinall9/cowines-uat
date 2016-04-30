namespace Website.CoWines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(unicode: false),
                        Line2 = c.String(unicode: false),
                        Line3 = c.String(unicode: false),
                        TownCity = c.String(unicode: false),
                        County = c.String(unicode: false),
                        Country = c.String(unicode: false),
                        Postcode = c.String(unicode: false),
                        AddressTypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AddressTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BottleSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        PriceExclVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearId = c.Int(nullable: false),
                        BottlesPerCase = c.Int(nullable: false),
                        CatalogueNumber = c.Int(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                        GrapeTypeId = c.Int(nullable: false),
                        SweetnessId = c.Int(nullable: false),
                        BottleSizeId = c.Int(nullable: false),
                        OriginId = c.Int(nullable: false),
                        ProducerId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BottleSizes", t => t.BottleSizeId, cascadeDelete: true)
                .ForeignKey("dbo.GrapeTypes", t => t.GrapeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Origins", t => t.OriginId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Sweetnesses", t => t.SweetnessId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.YearId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.GrapeTypeId)
                .Index(t => t.SweetnessId)
                .Index(t => t.BottleSizeId)
                .Index(t => t.OriginId)
                .Index(t => t.ProducerId);
            
            CreateTable(
                "dbo.GrapeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Origins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sweetnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaxYearVats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaxYearStart = c.DateTime(nullable: false, precision: 0),
                        TaxYearEnd = c.DateTime(nullable: false, precision: 0),
                        VatPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(unicode: false));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false, precision: 0));
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "YearId", "dbo.Years");
            DropForeignKey("dbo.Products", "SweetnessId", "dbo.Sweetnesses");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductTypes", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.Products", "OriginId", "dbo.Origins");
            DropForeignKey("dbo.Products", "GrapeTypeId", "dbo.GrapeTypes");
            DropForeignKey("dbo.Products", "BottleSizeId", "dbo.BottleSizes");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.ProductTypes", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ProducerId" });
            DropIndex("dbo.Products", new[] { "OriginId" });
            DropIndex("dbo.Products", new[] { "BottleSizeId" });
            DropIndex("dbo.Products", new[] { "SweetnessId" });
            DropIndex("dbo.Products", new[] { "GrapeTypeId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.Products", new[] { "YearId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.TaxYearVats");
            DropTable("dbo.Years");
            DropTable("dbo.Sweetnesses");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Producers");
            DropTable("dbo.Origins");
            DropTable("dbo.GrapeTypes");
            DropTable("dbo.Products");
            DropTable("dbo.BottleSizes");
            DropTable("dbo.Customers");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
