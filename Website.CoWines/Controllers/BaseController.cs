namespace Website.CoWines.Controllers
{
    using DAL;
    using Models;
    using System.Web.Mvc;
    using System.Linq;
    using Attributes;
    using System.Collections.Generic;
    using ViewModel;
    using System;

    [AuthorizeOver18]
    public abstract class BaseController : Controller
    {
        private ApplicationDbContext _dbContext;
        private ApplicationUser _currentUser;
        private TaxYearVat _taxYearVat;

        protected ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public BaseController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        protected ApplicationUser CurrentUser
        {
            get
            {
                return _currentUser ?? GetUser();
            }
        }

        private ApplicationUser GetUser()
        {
            if (!User.Identity.IsAuthenticated) return null;

            var user = (from u in DbContext.Users
                        where u.Email.Equals(User.Identity.Name)
                        select u).FirstOrDefault();

            return user;
        }

        private Customer GetCustomer(ApplicationUser user)
        {
            if (user == null) return null;

            var customer = (from c in DbContext.Customers
                            where c.UserId.Equals(user.Id)
                            select c).FirstOrDefault();

            return customer;
        }

        protected TaxYearVat CurrentTaxYearVat
        {
            get
            {
                if (_taxYearVat == null)
                {
                    _taxYearVat = DbContext.TaxYearVats.Single(t => t.TaxYearStart <= DateTime.Today && t.TaxYearEnd >= DateTime.Today);
                }

                return _taxYearVat;
            }
        }

        protected ProductViewModel GetProductById(int productId)
        {
            var product = (from p in DbContext.Products
                           where p.Id == productId
                           select p).SingleOrDefault();
            return new ProductViewModel
            {
                BottleSize = product.BottleSize.Name,
                BottlesPerCase = product.BottlesPerCase,
                CatalogueNumber = product.CatalogueNumber,
                Description = product.Description,
                Grape = product.GrapeType.Name,
                Id = product.Id,
                ImgUrl = product.ImgUrl ?? "",
                Name = product.Name,
                Origin = product.Origin.Name,
                PriceInclVat = product.Price,
                Producer = product.Producer.Name,
                Sweetness = product.Sweetness.Name,
                Year = product.Year.Name
            };
        }
    }
}
