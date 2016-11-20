namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class ProductType : Entity
    {
        public int CategoryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual Category Category {get;set;}
    }
}