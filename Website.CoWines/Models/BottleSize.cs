namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class BottleSize : Entity
    {
        public virtual IEnumerable<Product> Products { get; set; }
    }
}