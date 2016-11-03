namespace Website.CoWines.Repositories
{
    using Enums;
    using Models;
    using System.Collections.Generic;

    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByProductType(ProductTypes productType);
    }
}
