namespace Website.CoWines.Models
{
    public class CustomerUser
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string UserId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
