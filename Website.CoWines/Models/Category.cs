namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class Category : Entity
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}