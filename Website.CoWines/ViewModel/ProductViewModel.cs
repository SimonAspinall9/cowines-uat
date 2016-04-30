namespace Website.CoWines.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string BottleSize { get; set; }
        public int BottlesPerCase { get; set; }
        public int CatalogueNumber { get; set; }
        public string Description { get; set; }
        public string Grape { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public decimal PriceExclVat { get; set; }
        public decimal PriceInclVat { get; set; }
        public string Producer { get; set; }
        public string Sweetness { get; set; }
        public string Year { get; set; }
    }
}