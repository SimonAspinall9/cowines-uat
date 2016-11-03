namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class Sweetness : Entity
    {
        public virtual IEnumerable<Product> Products { get; set; }
    }
}