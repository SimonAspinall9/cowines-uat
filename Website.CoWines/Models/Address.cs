namespace Website.CoWines.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public int AddressTypeId { get; set; }
        public int CustomerId { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
