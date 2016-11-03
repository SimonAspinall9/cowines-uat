namespace Website.CoWines.Controllers
{
    using Models;
    using Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using ViewModel;
    public class CheckoutController : BaseController
    {
        static readonly IRepository<Product> _productRepository = new ProductRepository();
        static readonly Regex DigitRegex = new Regex("\\d+");

        public override ActionResult Index()
        {
            var shoppingCartCookie = Request.Cookies.Get("shoppingcart");

            if (shoppingCartCookie == null)
                return View();

            var cookieItems = shoppingCartCookie.Value.Split(',');
            var shoppingCartItems = GetShoppingCartItemsFromCookieSplits(_productRepository, cookieItems);

            return View(shoppingCartItems);
        }

        IEnumerable<ShoppingCartItemViewModel> GetShoppingCartItemsFromCookieSplits(IRepository<Product> productRepository, string[] cookieItems)
        {
            var shoppingCartItems = new List<ShoppingCartItemViewModel>();

            for (int i = 0; i < cookieItems.Length - 1; i++)
            {
                var productId = GetIntegerFromShoppingCartCookie(cookieItems[i].Split(':')[0]);
                var quantity = GetIntegerFromShoppingCartCookie(cookieItems[i].Split(':')[1]);
                var product = productRepository.GetById(productId);

                if (shoppingCartItems.Any(s => s.ProductId == productId))
                {
                    UpdateShoppingCartItemQuantity(shoppingCartItems, productId, quantity);
                }
                else
                {
                    shoppingCartItems.Add(new ShoppingCartItemViewModel
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = quantity,
                        ImgUrl = product.ImgUrl ?? "~/Content/img/awaiting-image.jpg",
                        ProductId = productId
                    });
                }
            }

            return shoppingCartItems;
        }

        private static void UpdateShoppingCartItemQuantity(List<ShoppingCartItemViewModel> shoppingCartItems, int productId, int quantity)
        {
            var shoppingCartItem = (from s in shoppingCartItems
                                    where s.ProductId == productId
                                    select s).Single();
            shoppingCartItem.Quantity += quantity;
        }

        static int GetIntegerFromShoppingCartCookie(string cookieString)
        {
            int retval = 0;
            int.TryParse(DigitRegex.Match(cookieString).Value, out retval);
            return retval;
        }
    }
}