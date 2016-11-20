using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website.CoWines.Models;
using Website.CoWines.ViewModel;

namespace Website.CoWines.Controllers
{
    [Authorize]
    public class BaseAdminController : BaseController
    {
        protected virtual IEnumerable<ProductViewModel> MapToProductViewModels(ICollection<Product> products)
        {
            return products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                BottleSize = p.BottleSize == null ? string.Empty : p.BottleSize.Name,
                BottlesPerCase = p.BottlesPerCase,
                CatalogueNumber = p.CatalogueNumber,
                Description = p.Description,
                Grape = p.GrapeType == null ? string.Empty : p.GrapeType.Name,
                ImgUrl = p.ImgUrl ?? "~/Content/img/awaiting-image.jpg",
                Name = p.Name,
                Origin = p.Origin == null ? string.Empty : p.Origin.Name,
                PriceExclVat = (p.Price * 100) / (100 + CurrentTaxYearVat.VatPercent),
                PriceInclVat = p.Price,
                Producer = p.Producer == null ? string.Empty : p.Producer.Name,
                Sweetness = p.Sweetness == null ? string.Empty : p.Sweetness.Name,
                Year = p.Year == null ? string.Empty : p.Year.Name
            }).ToList();
        }

        protected virtual ProductViewModel MapToProductViewModel(Product product)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                BottleSize = product.BottleSize.Name,
                BottlesPerCase = product.BottlesPerCase,
                CatalogueNumber = product.CatalogueNumber,
                Description = product.Description,
                Grape = product.GrapeType.Name,
                ImgUrl = product.ImgUrl ?? "~/Content/img/awaiting-image.jpg",
                Name = product.Name,
                Origin = product.Origin.Name,
                PriceExclVat = (product.Price * 100) / (100 + CurrentTaxYearVat.VatPercent),
                PriceInclVat = product.Price,
                Producer = product.Producer.Name,
                Sweetness = product.Sweetness.Name,
                Year = product.Year.Name
            };

            return productViewModel;
        }
    }
}