namespace Website.CoWines.Controllers
{
    using Models;
    using Repositories;
    using System.Web.Mvc;
    using ViewModel;
    public class HomeController : BaseController
    {
        private IRepository<Product> _repository;

        public HomeController()
        {
            _repository = new ProductRepository(DbContext);
        }

        public override ActionResult Index()
        {
            ViewBag.IsHome = true;
            return base.Index();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contactDetails)
        {
            try {
                var contactFormDetails = new ContactFormDetails(contactDetails.FirstName, contactDetails.LastName, contactDetails.EmailAddress, contactDetails.Subject, contactDetails.Body);
                contactFormDetails.SendContactForm();
            }
            catch
            {
                return Redirect("~/Home/Error");
            }

            return RedirectToAction("Index");
        }
    }
}