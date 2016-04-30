namespace Website.CoWines.DAL
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<BottleSize> BottleSizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<GrapeType> GrapeTypes { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sweetness> Sweetnesses { get; set; }
        public DbSet<TaxYearVat> TaxYearVats { get; set; }
        public DbSet<Year> Years { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
