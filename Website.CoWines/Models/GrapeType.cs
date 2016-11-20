namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class GrapeType : Entity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}