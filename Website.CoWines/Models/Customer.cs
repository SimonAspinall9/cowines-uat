namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class Customer : Entity
    {
        public string UserId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
