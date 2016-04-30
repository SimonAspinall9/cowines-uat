namespace Website.CoWines.Models
{
    using Repositories;

    public class EmailAddress : Entity
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
