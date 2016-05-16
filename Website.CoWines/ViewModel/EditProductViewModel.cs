using System.Collections.Generic;
using Website.CoWines.Models;

namespace Website.CoWines.ViewModel
{
    public class EditProductViewModel
    {
        public ProductViewModel Product { get; set; }

        public ICollection<Year> Years { get; set; }
        public ICollection<BottleSize> BottleSizes { get; set; }
        public ICollection<GrapeType> GrapeTypes { get; set; }
        public ICollection<Origin> Origins { get; set; }
        public ICollection<Producer> Producers { get; set; }
        public ICollection<Sweetness> Sweetnesses { get; set; }
    }
}