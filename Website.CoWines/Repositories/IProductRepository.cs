namespace Website.CoWines.Repositories
{
    using Enums;
    using Models;
    using System.Collections.Generic;

    public interface IProductRepository : IRepository<Product>
    {
        ICollection<Product> GetByProductType(ProductTypes productType);
    }
}
