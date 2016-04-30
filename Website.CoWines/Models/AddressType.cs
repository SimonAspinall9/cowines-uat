namespace Website.CoWines.Models
{
    using Repositories;
    using System.Collections.Generic;

    public class AddressType : Entity
    {
        public virtual ICollection<Address> Addresses { get; set; }
    }
}