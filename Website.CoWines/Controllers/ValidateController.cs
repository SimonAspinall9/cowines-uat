namespace Website.CoWines.Controllers
{
    using System.Web.Mvc;
    using ViewModel;

    public class ValidateController : Controller
    {
        private const string Under18ErrorMessage = "Access Denied. Date of birth entered is not valid.";

        public ActionResult Age(string returnUrl = "/", string errorMessage = Under18ErrorMessage)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Age(ValidateAgeViewModel validateAge, string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                Session["AuthorizeOver18"] = true;
                return Redirect(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            ModelState.AddModelError("", Under18ErrorMessage);
            return View();
        }
    }
}
