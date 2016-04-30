namespace Website.CoWines.Attributes
{
    using DAL;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AuthorizeOver18Attribute : AuthorizeAttribute
    {
        private const string AuthorizeOver18Key = "AuthorizeOver18";

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session[AuthorizeOver18Key] != null && (bool)HttpContext.Current.Session[AuthorizeOver18Key] == true) return;

            var userEmailAddress = HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name : null;

            var userDateOfBirth = GetUserDateOrBirthByEmail(userEmailAddress);

            var isUserOver18 = CheckUserOver18(userDateOfBirth);

            if (!isUserOver18) HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var returnUrl = HttpContext.Current.Request.Url.AbsolutePath;
            HttpContext.Current.Response.RedirectToRoute("ValidateAge", new { ReturnUrl = returnUrl });
        }

        private DateTime GetUserDateOrBirthByEmail(string emailAddress)
        {
            var userDateOfBirth = DateTime.Now;
            using (var dbContext = new ApplicationDbContext())
            {
                userDateOfBirth = (from u in dbContext.Users
                                   where u.Email.Equals(emailAddress)
                                   select u.DateOfBirth).FirstOrDefault();
            }

            if (userDateOfBirth == default(DateTime)) return DateTime.Today;

            return userDateOfBirth;
        }

        private bool CheckUserOver18(DateTime dob)
        {
            var isUserOver18 = dob.AddYears(18) <= DateTime.Today ? true : false;
            return isUserOver18;
        }
    }
}
