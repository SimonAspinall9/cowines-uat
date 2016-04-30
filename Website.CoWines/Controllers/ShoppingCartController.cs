namespace Website.CoWines.Controllers
{
    using DAL;
    using Models;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModel;
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedProduct = (from p in _dbContext.Products
                                where p.Id.Equals(id)
                                select p).FirstOrDefault();

            var cart = ShoppingCart.GetCart(HttpContext);

            cart.AddToCart(addedProduct);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            var productName = (from i in _dbContext.Carts
                               where i.ItemId.Equals(id)
                               select i.Product.Name).FirstOrDefault();

            var itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + " has been removed from your shopping cart",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id,
            };

            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}
