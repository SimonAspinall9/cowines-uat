namespace Website.CoWines.Migrations
{
    using DAL;
    using Models;
    using MySql.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new DAL.MySqlHistoryContext(conn, schema));
            CodeGenerator = new MySqlMigrationCodeGenerator();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.BottleSizes.AddOrUpdate(
                b => b.Name,
                new BottleSize { Name = "Bottle" }
            );

            context.SaveChanges();

            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Name = "Wines" },
                new Category { Name = "Champagne & Sparkling" },
                new Category { Name = "Fortified & Liqueurs" },
                new Category { Name = "Spirits" }
            );

            context.SaveChanges();

            context.GrapeTypes.AddOrUpdate(
                g => g.Name,
                new GrapeType { Name = "Pinot Grigio" }
            );

            context.SaveChanges();

            context.Origins.AddOrUpdate(
                o => o.Name,
                new Origin { Name = "France" },
                new Origin { Name = "Spain" }
            );

            context.SaveChanges();

            var categoryId = (from c in context.Categories
                              where c.Name.Equals("Wines")
                              select c.Id).FirstOrDefault();

            context.ProductTypes.AddOrUpdate(
                p => p.Name,
                new ProductType { Name = "Red Wine", CategoryId = categoryId },
                new ProductType { Name = "White Wine", CategoryId = categoryId },
                new ProductType { Name = "Rose Wine", CategoryId = categoryId }
            );

            context.SaveChanges();

            context.Producers.AddOrUpdate(
                p => p.Name,
                new Producer { Name = "Bodegas Senorio de Ayles" }
            );

            context.SaveChanges();

            context.Sweetnesses.AddOrUpdate(
                s => s.Name,
                new Sweetness { Name = "Dry" },
                new Sweetness { Name = "Medium" }
            );

            context.SaveChanges();

            context.Years.AddOrUpdate(
                y => y.Name,
                new Year { Name = "2015" },
                new Year { Name = "2013" }
            );

            context.SaveChanges();

            var bottleSizeId = (from b in context.BottleSizes
                                where b.Name.Equals("Bottle")
                                select b.Id).FirstOrDefault();
            var grapeTypeId = (from g in context.GrapeTypes
                               where g.Name.Equals("Pinot Grigio")
                               select g.Id).FirstOrDefault();
            var originId = (from o in context.Origins
                            where o.Name.Equals("Spain")
                            select o.Id).FirstOrDefault();
            var producerId = (from p in context.Producers
                              where p.Name.Equals("Bodegas Senorio de Ayles")
                              select p.Id).FirstOrDefault();
            var productTypeId = (from p in context.ProductTypes
                                 where p.Name.Equals("Red Wine")
                                 select p.Id).FirstOrDefault();
            var sweetnessId = (from s in context.Sweetnesses
                               where s.Name.Equals("Medium")
                               select s.Id).FirstOrDefault();
            var yearId = (from y in context.Years
                          where y.Name.Equals("2013")
                          select y.Id).FirstOrDefault();

            context.Products.AddOrUpdate(
                p => p.Name,
                new Product { Name = "Test Wine", Description = "", CatalogueNumber = 4100, Price = 5.95M, BottleSizeId = bottleSizeId, GrapeTypeId = grapeTypeId, OriginId = originId, ProducerId = producerId, ProductTypeId = productTypeId, SweetnessId = sweetnessId, YearId = yearId },
                new Product { Name = "Another Test Wine", Description = "", CatalogueNumber = 4100, Price = 7.95M, BottleSizeId = bottleSizeId, GrapeTypeId = grapeTypeId, OriginId = originId, ProducerId = producerId, ProductTypeId = productTypeId, SweetnessId = sweetnessId, YearId = yearId }
            );

            context.SaveChanges();
        }
    }
}
