namespace Website.CoWines.ViewModel
{
    using Models;
    using System.Collections.Generic;
    public class ShoppingCartViewModel
    {
        public ICollection<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
