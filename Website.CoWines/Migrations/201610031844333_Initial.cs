namespace Website.CoWines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Addresses",
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
                .ForeignKey("AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AddressTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    FirstName = c.String(unicode: false),
                    LastName = c.String(unicode: false),
                    DateOfBirth = c.DateTime(nullable: false, precision: 0),
                    Email = c.String(maxLength: 256, storeType: "nvarchar"),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(unicode: false),
                    SecurityStamp = c.String(unicode: false),
                    PhoneNumber = c.String(unicode: false),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(precision: 0),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })                
                .ForeignKey("AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })                
                .ForeignKey("AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "BottleSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImgUrl = c.String(unicode: false),
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
                .ForeignKey("BottleSizes", t => t.BottleSizeId, cascadeDelete: true)
                .ForeignKey("GrapeTypes", t => t.GrapeTypeId, cascadeDelete: true)
                .ForeignKey("Origins", t => t.OriginId, cascadeDelete: true)
                .ForeignKey("Producers", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .ForeignKey("Sweetnesses", t => t.SweetnessId, cascadeDelete: true)
                .ForeignKey("Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.YearId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.GrapeTypeId)
                .Index(t => t.SweetnessId)
                .Index(t => t.BottleSizeId)
                .Index(t => t.OriginId)
                .Index(t => t.ProducerId);
            
            CreateTable(
                "GrapeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Origins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Sweetnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "EmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;

            CreateTable(
                "AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TaxYearVats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaxYearStart = c.DateTime(nullable: false, precision: 0),
                        TaxYearEnd = c.DateTime(nullable: false, precision: 0),
                        VatPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)                ;
            
        }
        
        public override void Down()
        {
            DropForeignKey("AspNetUserRoles", "RoleId", "AspNetRoles");
            DropForeignKey("Products", "YearId", "Years");
            DropForeignKey("Products", "SweetnessId", "Sweetnesses");
            DropForeignKey("Products", "ProductTypeId", "ProductTypes");
            DropForeignKey("ProductTypes", "CategoryId", "Categories");
            DropForeignKey("Products", "ProducerId", "Producers");
            DropForeignKey("Products", "OriginId", "Origins");
            DropForeignKey("Products", "GrapeTypeId", "GrapeTypes");
            DropForeignKey("Products", "BottleSizeId", "BottleSizes");
            DropForeignKey("Customers", "UserId", "AspNetUsers");
            DropForeignKey("AspNetUserRoles", "UserId", "AspNetUsers");
            DropForeignKey("AspNetUserLogins", "UserId", "AspNetUsers");
            DropForeignKey("AspNetUserClaims", "UserId", "AspNetUsers");
            DropForeignKey("Addresses", "CustomerId", "Customers");
            DropForeignKey("Addresses", "AddressTypeId", "AddressTypes");
            DropIndex("AspNetRoles", "RoleNameIndex");
            DropIndex("ProductTypes", new[] { "CategoryId" });
            DropIndex("Products", new[] { "ProducerId" });
            DropIndex("Products", new[] { "OriginId" });
            DropIndex("Products", new[] { "BottleSizeId" });
            DropIndex("Products", new[] { "SweetnessId" });
            DropIndex("Products", new[] { "GrapeTypeId" });
            DropIndex("Products", new[] { "ProductTypeId" });
            DropIndex("Products", new[] { "YearId" });
            DropIndex("AspNetUserRoles", new[] { "RoleId" });
            DropIndex("AspNetUserRoles", new[] { "UserId" });
            DropIndex("AspNetUserLogins", new[] { "UserId" });
            DropIndex("AspNetUserClaims", new[] { "UserId" });
            DropIndex("AspNetUsers", "UserNameIndex");
            DropIndex("Customers", new[] { "UserId" });
            DropIndex("Addresses", new[] { "CustomerId" });
            DropIndex("Addresses", new[] { "AddressTypeId" });
            DropTable("TaxYearVats");
            DropTable("AspNetRoles");
            DropTable("EmailAddresses");
            DropTable("Years");
            DropTable("Sweetnesses");
            DropTable("Categories");
            DropTable("ProductTypes");
            DropTable("Producers");
            DropTable("Origins");
            DropTable("GrapeTypes");
            DropTable("Products");
            DropTable("BottleSizes");
            DropTable("AspNetUserRoles");
            DropTable("AspNetUserLogins");
            DropTable("AspNetUserClaims");
            DropTable("AspNetUsers");
            DropTable("Customers");
            DropTable("AddressTypes");
            DropTable("Addresses");
        }
    }
}
