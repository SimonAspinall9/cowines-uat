namespace Website.CoWines.Models
{
    using Repositories;

    public class Product : Entity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public int YearId { get; set; }
        public int BottlesPerCase { get; set; }
        public int CatalogueNumber { get; set; }
        public int ProductTypeId { get; set; }
        public int GrapeTypeId { get; set; }
        public int SweetnessId { get; set; }
        public int BottleSizeId { get; set; }
        public int OriginId { get; set; }
        public int ProducerId { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual GrapeType GrapeType { get; set; }
        public virtual Sweetness Sweetness { get; set; }
        public virtual BottleSize BottleSize { get; set; }
        public virtual Origin Origin { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Year Year { get; set; }
    }
}