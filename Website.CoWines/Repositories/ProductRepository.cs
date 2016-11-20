namespace Website.CoWines.Repositories
{
    using DAL;
    using Enums;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository()
            : base(new ApplicationDbContext())
        {
        }

        public ProductRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }



        #region IProductRepository

        public void Add(Product entity)
        {
            ChangeEntityState(entity, EntityState.Added);
        }

        public void Delete(Product entity)
        {
            ChangeEntityState(entity, EntityState.Deleted);
        }

        public ICollection<Product> Get()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                return dbContext.Products
                    .Include("BottleSize")
                    .Include("GrapeType")
                    .Include("Origin")
                    .Include("Producer")
                    .Include("ProductType")
                    .Include("Sweetness")
                    .Include("Year").ToList();
            }
        }

        public Product GetById(int id)
        {
            return Get().Single(p => p.Id == id);
        }

        public Product GetByName(string name)
        {
            var product = (from p in DbContext.Products
                           where p.Name.Equals(name)
                           select p).FirstOrDefault();

            return product;
        }

        public ICollection<Product> GetByProductType(ProductTypes productType)
        {
            var productTypeDescription = productType.GetEnumDescription();
            return DbContext.Products.Where(p => p.ProductType.Name.Equals(productTypeDescription, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public void Update(Product entity)
        {
            ChangeEntityState(entity, EntityState.Modified);
        }

        #endregion
    }
}
