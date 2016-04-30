namespace Website.CoWines.ViewModel
{
    public class ShoppingCartItemViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
