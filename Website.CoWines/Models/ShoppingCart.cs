namespace Website.CoWines.Models
{
    using DAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public partial class ShoppingCart
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        private string _shoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart._shoppingCartId = cart.GetCartId(context);

            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            var cartItem = (from i in _dbContext.Carts
                            where i.CartId.Equals(_shoppingCartId) && i.ProductId.Equals(product.Id)
                            select i).FirstOrDefault();
            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ProductId = product.Id,
                    CartId = _shoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now,
                };

                _dbContext.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            _dbContext.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = (from i in _dbContext.Carts
                            where i.CartId.Equals(_shoppingCartId) && i.ProductId.Equals(id)
                            select i).FirstOrDefault();
            var itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else {
                    _dbContext.Carts.Remove(cartItem);
                }

                _dbContext.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = (from i in _dbContext.Carts
                             where i.CartId.Equals(_shoppingCartId)
                             select i);

            foreach (var item in cartItems)
            {
                _dbContext.Carts.Remove(item);
            }

            _dbContext.SaveChanges();
        }

        public ICollection<Cart> GetCartItems()
        {
            return (from i in _dbContext.Carts
                    where i.CartId.Equals(_shoppingCartId)
                    select i).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in _dbContext.Carts
                          where cartItems.CartId.Equals(_shoppingCartId)
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in _dbContext.Carts
                              where cartItems.CartId.Equals(_shoppingCartId)
                              select (decimal?)cartItems.Count * cartItems.Product.PriceExclVat).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            var orderTotal = decimal.Zero;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                    UnitPrice = item.Product.PriceExclVat,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.PriceExclVat);

                _dbContext.OrderDetails.Add(orderDetail);
            }

            order.Total = orderTotal;

            _dbContext.SaveChanges();

            EmptyCart();

            return order.Id;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    var tempCartId = Guid.NewGuid().ToString();
                    context.Session[CartSessionKey] = tempCartId;
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string username)
        {
            var shoppingCart = (from i in _dbContext.Carts
                                where i.CartId.Equals(_shoppingCartId)
                                select i);

            foreach (var item in shoppingCart)
            {
                item.CartId = username;
            }

            _dbContext.SaveChanges();
        }
    }
}
